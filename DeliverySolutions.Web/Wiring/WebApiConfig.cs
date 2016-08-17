using System.Web.Http;

namespace DeliverySolutions.Web.Wiring
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.DependencyResolver = new DependencyResolver();
        }
    }
}
