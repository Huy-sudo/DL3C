using System.Security;

namespace DL3C_API.Business
{
    /// <summary>
    /// Add custom services into Dependency Injection Container.
    /// </summary>

    public static class ModuleRegister
    {
        /// <summary>
        /// DI Service classes for Business module.
        /// </summary>
        /// <param name="services">Service container form Program.</param>
        public static void RegisterBusiness(this IServiceCollection services)
        {
            //--Register Service
            //services.AddScoped<IUserSvc, UserSvc>();
            //services.AddScoped<IPermissionSvc, PermissionSvc>();
            //services.AddScoped<IRoleSvc, RoleSvc>();
        }
    }
}
