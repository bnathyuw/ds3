using System.Reflection;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Infra
{
    public class AssemblyVersioner
    {
        public virtual void WriteVersionTo(BuildHealth healthBuilder)
        {
            healthBuilder.WithServiceVersion(Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }
    }
}