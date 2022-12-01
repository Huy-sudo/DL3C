namespace DL3C_API.Infrastructure.Data;

using DL3C_API.Infrastructure.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using static System.Activator;

/// <summary>
/// DbContext Factory
/// </summary>
public class DbContextFactory : IDbContextFactory, IDisposable
{
    private bool _disposed;
    private bool _completed;

    private IConfiguration Configuration { get; }

    private Hashtable? Contexts { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DbContextFactory"/> class.
    /// </summary>
    /// <param name="configuration">IConfiguration.</param>
    public DbContextFactory(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <inheritdoc />
    public IUnitOfWork<TContext> GetContext<TContext>()
        where TContext : DbContext
    {
        Contexts ??= new Hashtable();

        string key = typeof(TContext).Name;
        if (!Contexts.ContainsKey(key))
        {
            string connectionString = Configuration
                .GetConnectionString($"{typeof(TContext).Name.Replace("Context", String.Empty)}");
            TContext contextInstance = (TContext)CreateInstance(
                typeof(TContext),
                ConfigureSqlServer<TContext>(connectionString).Options)!;
            UnitOfWork<TContext> unitOfWorkInstance = new UnitOfWork<TContext>(contextInstance);
            Contexts.Add(key, unitOfWorkInstance);
        }

        return (Contexts[key] as IUnitOfWork<TContext>)!;
    }

    /// <inheritdoc />
    public async Task<int> SaveAllAsync()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException("UoW disposed");
        }

        if (_completed)
        {
            throw new InvalidOperationException("Can not SaveChange()");
        }

        int rowAffected = 0;
        try
        {
            foreach (DictionaryEntry dictionaryEntry in Contexts!)
            {
                dynamic dbContext = this.GetContextFromCollection(dictionaryEntry);
                rowAffected += await (dbContext as DbContext)?.SaveChangesAsync()!;
            }

            foreach (DictionaryEntry dictionaryEntry in Contexts)
            {
                dynamic dbContext = this.GetContextFromCollection(dictionaryEntry);
                IDbContextTransaction? transaction = (dbContext as DbContext)!
                    .Database
                    .CurrentTransaction;
                if (transaction != null)
                {
                    await transaction.CommitAsync();
                    transaction.Dispose();
                }
            }
        }
        catch (Exception e)
        {
            await this.RollbackAsync();
            throw new Exception($"{nameof(this.SaveAllAsync)} :", e);
        }

        _completed = true;

        return rowAffected;
    }

    /// <summary>
    /// Roll back Async
    /// </summary>
    /// <exception cref="ObjectDisposedException">UoW disposed</exception>
    /// <exception cref="InvalidOperationException">UoW complete</exception>
    /// <exception cref="Exception">Error of rollback</exception>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task RollbackAsync()
    {
        if (this._disposed)
        {
            throw new ObjectDisposedException("UoW disposed");
        }

        if (this._completed)
        {
            throw new InvalidOperationException("Can not SaveChange()");
        }

        try
        {
            foreach (DictionaryEntry dictionaryEntry in Contexts!)
            {
                dynamic dbContext = this.GetContextFromCollection(dictionaryEntry);

                var transaction = (dbContext as DbContext)?.Database.CurrentTransaction;
                if (transaction != null)
                {
                    await transaction.RollbackAsync();
                    await transaction.DisposeAsync();
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception($"{nameof(this.RollbackAsync)}:", e);
        }

        _completed = true;
    }

    /// <inheritdoc />
    public async void Dispose()
    {
        (Configuration as IDisposable)?.Dispose();
        if (Contexts!.Count > 0)
        {
            try
            {
                if (!_completed)
                {
                    await this.RollbackAsync();
                }

                if (!_disposed)
                {
                    foreach (DictionaryEntry dE in Contexts)
                    {
                        dynamic dbContext = GetContextFromCollection(dE);
                        await (dbContext as DbContext)!.DisposeAsync();
                    }
                }

                _disposed = true;
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(Dispose)}:", e);
            }
        }
    }



    private dynamic GetContextFromCollection(DictionaryEntry dbContextCollection)
    {
        return dbContextCollection
            .Value!
            .GetType()
            .GetProperty(nameof(UnitOfWork<DbContext>.CurrentContext))!
            .GetValue(dbContextCollection.Value)!;
    }

    protected virtual DbContextOptionsBuilder<TContext> ConfigureSqlServer<TContext>(string connectionString)
        where TContext : DbContext
    {
        DbContextOptionsBuilder<TContext> optionsBuilder = new DbContextOptionsBuilder<TContext>();
        optionsBuilder.UseSqlServer(connectionString);
        // .UseLazyLoadingProxies();
        return optionsBuilder;
    }
}