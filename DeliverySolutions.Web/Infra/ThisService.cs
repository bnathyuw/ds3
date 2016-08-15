using System.Reflection;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Infra
{
    public class ThisService : Service
    {
        public void WriteVersionTo(ServiceVersion serviceVersion)
        {
            serviceVersion.SetServiceVersion(Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }
    }
}