namespace DL3C_API.Infrastructure.Data.Interface;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Interface of DbContextFactory
/// </summary>
public interface IDbContextFactory
{
    /// <summary>
    /// Get the UoW when using factory.
    /// </summary>
    /// <typeparam name="T">db context.</typeparam>
    /// <returns>UoW</returns>
    IUnitOfWork<T> GetContext<T>() where T : DbContext;

    /// <summary>
    /// Save change for all context in UoW with async.
    /// </summary>
    /// <returns>number of row affected.</returns>
    Task<int> SaveAllAsync();
}