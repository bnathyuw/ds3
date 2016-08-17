using System.Collections.Generic;
using System.Linq;

namespace DeliverySolutions.Web.Api.HealthCheck.v1
{
    public class HealthResponseBuilder : Domain.Health
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

        public virtual HealthResponse Build()
        {
            return new HealthResponse(_checks, _serviceVersion, _checks.All(c => c.IsSuccessful));
        }
    }
}