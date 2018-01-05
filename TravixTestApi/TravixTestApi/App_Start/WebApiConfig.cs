using System.Web.Http;
using Infrastructure.Infrastructure;
using Ninject;
using TravixTestApi.App_Start;
using TravixTestApi.Infrastructure;

namespace TravixTestApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            RegisterInjections();
            MappingRegisterService.RegisterMappings();
        }

        private static void RegisterInjections()
        {
            IKernel kernel = NinjectWebCommon.Bootstrapper.Kernel;
            InfrastructureInjectionRegistration.Register(kernel);
        }
    }
}
