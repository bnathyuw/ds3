using System.Reflection;

namespace DeliverySolutions.Web
{
    public class AssemblyVersioner
    {
        public virtual void WriteVersionTo(BuildHealth healthBuilder)
        {
            healthBuilder.WithServiceVersion(Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }
    }
}