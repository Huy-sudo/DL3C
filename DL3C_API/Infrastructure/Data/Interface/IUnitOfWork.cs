namespace DL3C_API.Infrastructure.Data.Interface;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Interface for UnitOfWork
/// </summary>
/// <typeparam name="TContext">DbContext</typeparam>
public interface IUnitOfWork<TContext>
    where TContext : DbContext
{
    /// <summary>
    /// Get repository based on entity.
    /// </summary>
    /// <typeparam name="T">entity class.</typeparam>
    /// <returns>a repository of an entity.</returns>
    IBaseRepository<T> GetRepository<T>()
        where T : class;

    /// <summary>
    /// Save change async in one context
    /// </summary>
    /// <returns>number of row affected.</returns>
    Task<int> SaveChangeAsync();

    /// <summary>
    /// Roll back transaction of all contexts.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task RollbackAsync();
}