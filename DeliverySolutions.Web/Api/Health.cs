using System.Collections.Generic;

namespace DeliverySolutions.Web.Api
{
    public class Health
    {
        public string ServiceVersion { private set; get; }
        public IEnumerable<Check> Checks { get; private set; }

        public Health(IEnumerable<Check> checks, string serviceVersion)
        {
            ServiceVersion = serviceVersion;
            Checks = checks;
        }
    }
}