using System.Web.Http;

namespace DeliverySolutions.Web.Wiring
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DeliverToHome",
                routeTemplate: "v1/deliver-to-home/",
                defaults: new {controller = "DeliverToHome"});

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new DependencyResolver();
        }
    }
}
