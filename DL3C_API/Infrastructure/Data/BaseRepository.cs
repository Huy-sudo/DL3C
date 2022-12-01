namespace DL3C_API.Infrastructure.Data;

using DL3C_API.Infrastructure.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

/// <inheritdoc />
public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet;

    private DbContext CurrentContext { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
    /// </summary>
    /// <param name="currentContext">context</param>
    public BaseRepository(DbContext currentContext)
    {
        CurrentContext = currentContext;
        _dbSet = CurrentContext.Set<TEntity>();
    }

    /// <summary>
    /// Load include properties of entity using eager loading.
    /// </summary>
    /// <param name="query">object context.</param>
    /// <param name="includeProperties">Array for include properties.</param>
    /// <returns>DbSet of entity.</returns>
    private IQueryable<TEntity> IncludeProperties(IQueryable<TEntity> query, Expression<Func<TEntity, object>>[]? includeProperties)
    {
        if (includeProperties != null)
        {
            includeProperties.Aggregate(query, (current, property) => current.Include(property));
        }

        return query;
    }

    /// <inheritdoc cref="IBaseRepository{Entity}.EntityEntry"/>
    public EntityEntry<TEntity> EntityEntry(TEntity entity) => CurrentContext.Entry(entity);

    /// <inheritdoc cref="IBaseRepository{Entity}.GetAll"/>
    public IQueryable<TEntity> GetAll() => _dbSet.AsQueryable();

    /// <inheritdoc cref="IBaseRepository{Entity}.GetById"/>
    public TEntity? GetById(object? id)
    {
        DbSet<TEntity> query = _dbSet;
        return query.Find(id);
    }

    /// <inheritdoc cref="IBaseRepository{Entity}.GetByIdAsync"/>
    public async Task<TEntity?> GetByIdAsync(object id)
    {
        DbSet<TEntity> query = _dbSet;
        TEntity entity = await query.FindAsync(id);
        CurrentContext.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    /// <inheritdoc cref="IBaseRepository{Entity}.Get"/>
    public IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>[]? includeProperties = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }

        query = IncludeProperties(query, includeProperties);

        return query;
    }

    /// <inheritdoc cref="IBaseRepository{Entity}.GetFirstOrDefault"/>
    public TEntity? GetFirstOrDefault(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>[]? includeProperties = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }

        query = IncludeProperties(query, includeProperties);

        return query.FirstOrDefault();
    }

    /// <inheritdoc cref="IBaseRepository{Entity}.GetFirstOrDefaultAsync"/>
    public async Task<TEntity?> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>[]? includeProperties = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }

        query = IncludeProperties(query, includeProperties);

        return await query.FirstOrDefaultAsync();
    }

    /// <inheritdoc cref="IBaseRepository{TEntity}.Insert(TEntity)"/>
    public void Insert(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _dbSet.Add(entity);
    }

    /// <inheritdoc />
    public async void Insert(IEnumerable<TEntity> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }

        await _dbSet.AddRangeAsync(entities);
    }

    /// <inheritdoc cref="IBaseRepository{Entity}.InsertAsync(Entity)"/>
    public async Task InsertAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await _dbSet.AddAsync(entity);
    }

    /// <inheritdoc cref="IBaseRepository{Entity}.InsertAsync(IEnumerable{Entity})"/>
    public void InsertAsync(IEnumerable<TEntity> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }

        _dbSet.AddRange(entities);
    }

    /// <inheritdoc cref="IBaseRepository{Entity}.Update(Entity)"/>
    public void Update(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _dbSet.Attach(entity);
        CurrentContext.Update(entity);
    }

    /// <inheritdoc cref="IBaseRepository{Entity}.Update(IEnumerable{Entity})"/>
    public void Update(IEnumerable<TEntity> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }

        var enumerable = entities as TEntity[] ?? entities.ToArray();
        _dbSet.AttachRange(enumerable);
        CurrentContext.UpdateRange(enumerable as object[]);
    }

    /// <inheritdoc cref="IBaseRepository{Entity}.Delete(Entity)"/>
    public void Delete(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        if (CurrentContext.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }

        _dbSet.Remove(entity);
    }

    /// <inheritdoc cref="IBaseRepository{Entity}.Delete(IEnumerable{Entity})"/>
    public void Delete(IEnumerable<TEntity> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }

        var enumerable = entities as TEntity[] ?? entities.ToArray();
        foreach (var entity in enumerable)
        {
            if (CurrentContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
        }

        _dbSet.RemoveRange(enumerable);
    }
}