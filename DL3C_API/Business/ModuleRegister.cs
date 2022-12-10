using DL3C_API.Business.Body.Service;
using DL3C_API.Business.BodyComp.Service;
using DL3C_API.Business.Building.Service;
using DL3C_API.Business.Face.Service;
using DL3C_API.Business.Node.Service;
using DL3C_API.Business.Prism.Service;

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
            services.AddScoped<IBodySvc, BodySvc>();
            services.AddScoped<IBodyCompSvc, BodyCompSvc>();
            services.AddScoped<IBuildingSvc, BuildingSvc>();
            services.AddScoped<IFaceSvc, FaceSvc>();
            services.AddScoped<INodeSvc, NodeSvc>();
            services.AddScoped<IPrismSvc, PrismSvc>();

        }
    }
}
