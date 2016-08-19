using System.Collections.Generic;
using System.Linq;

namespace DeliverySolutions.Web.Api.HealthCheck.v1
{
    public class ResponseBuilder : Domain.Health
    {
        private readonly List<Check> _checks = new List<Check>();
        private string _serviceVersion = "";

        public void SetDatabaseStatus(bool isSuccessful)
        {
            _checks.Add(new Check("Can connect to database", isSuccessful));
        }

        public void SetServiceVersion(string serviceVersion)
        {
            _serviceVersion = serviceVersion;
        }

        public virtual Response Build()
        {
            return new Response(_checks, _serviceVersion, _checks.All(c => c.IsSuccessful));
        }
    }
}