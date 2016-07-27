using System.Web.Http;
using DeliverySolutions.Web.Infra;

namespace DeliverySolutions.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
