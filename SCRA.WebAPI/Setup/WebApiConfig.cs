using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using SCRA.Framework.Common.Errors;
using SCRA.Framework.Common.Resolver;
using SCRA.Framework.Clinical;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Lifetime;

namespace SCRA.WebApi.Setup
{
    public static class WebApiConfig
    {
        public static void Setup(HttpConfiguration configuration)
        {
            SetupConfiguration(configuration);
            SetupRoutes(configuration.Routes);
            SetupInterceptionPolicies(configuration);
        }

        private static void SetupRoutes(HttpRouteCollection routes)
        {
            routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{id}", new {id = RouteParameter.Optional});
        }

        public static void SetupConfiguration(HttpConfiguration configuration)
        {
            var jsonSerializerSettings =
                configuration.Formatters.OfType<JsonMediaTypeFormatter>().Single().SerializerSettings;
            jsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializerSettings.Converters.Add(new IsoDateTimeConverter());
        }

        public static void SetupInterceptionPolicies(HttpConfiguration configuration)
        {
            IUnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();

            container.RegisterType<IClinicalService, ClinicalService>(
                new HierarchicalLifetimeManager(),
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<ExceptionInterceptionBehavior>());

            configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}