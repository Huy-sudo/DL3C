using DL3C_API.Data.Repository.Body;
using DL3C_API.Data.Repository.BodyComp;
using DL3C_API.Data.Repository.Building;
using DL3C_API.Data.Repository.Face;
using DL3C_API.Data.Repository.Node;
using DL3C_API.Data.Repository.Prism;

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
            services.AddScoped<IBodyRepo, BodyRepo>();
            services.AddScoped<IBodyCompRepo, BodyCompRepo>();
            services.AddScoped<IBuildingRepo, BuildingRepo>();
            services.AddScoped<IFaceRepo, FaceRepo>();
            services.AddScoped<INodeRepo, NodeRepo>();
            services.AddScoped<IPrismRepo, PrismRepo>();
        }
    }
}
