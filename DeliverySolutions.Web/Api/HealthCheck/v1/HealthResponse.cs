using System.Collections.Generic;

namespace DeliverySolutions.Web.Api.HealthCheck.v1
{
    public class HealthResponse
    {
        public HealthResponse(IEnumerable<Check> checks, string serviceVersion, bool isHealthy)
        {
            ServiceVersion = serviceVersion;
            IsHealthy = isHealthy;
            Checks = checks;
        }

        public string ServiceVersion { get; private set; }
        public bool IsHealthy { get; private set; }
        public IEnumerable<Check> Checks { get; private set; }
    }
}