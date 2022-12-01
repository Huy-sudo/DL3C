namespace DL3C_API.Infrastructure.Data;

using DL3C_API.Data.Source;
using DL3C_API.Infrastructure.Data.Interface;
using Microsoft.EntityFrameworkCore;

public static class ModuleRegister
{
    /// <summary>
    /// DI Service classes for Data module.
    /// </summary>
    /// <param name="services">Service container form Program</param>
    public static void RegisterDataInfrastructure(this IServiceCollection services)
    {
        //--Register DbContext
        services.AddScoped<DbContext, NhahatlonContext>();

        //--Register Base
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        services.AddScoped<IDbContextFactory, DbContextFactory>();
    }
}