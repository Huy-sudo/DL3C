namespace DL3C_API.Data
{
    /// <summary>
    /// Add custom services into Dependency Injection Container.
    /// </summary>
    public static class ModuleRegister
    {
        /// <summary>
        /// DI Service classes for Data module.
        /// </summary>
        /// <param name="services">Service container form Program</param>
        public static void RegisterData(this IServiceCollection services)
        {
            //--Register Data Repository
            //services.AddScoped<IUserRepo, UserRepo>();
            //services.AddScoped<IPermissionRepo, PermissionRepo>();
            //services.AddScoped<IRoleRepo, RoleRepo>();
            //services.AddScoped<IUserRoleRepo, UserRoleRepo>();
            //services.AddScoped<IRolePermissionRepo, RolePermissionRepo>();
        }
    }
}
