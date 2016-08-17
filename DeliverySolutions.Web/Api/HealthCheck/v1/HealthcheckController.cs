using System.Web.Http;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api.HealthCheck.v1
{
    public class HealthcheckController : ApiController
    {
        private readonly HealthChecker _healthChecker;
        private readonly HealthResponseBuilder _healthResponseBuilder;

        public HealthcheckController(HealthChecker healthChecker, HealthResponseBuilder healthResponseBuilder)
        {
            _healthChecker = healthChecker;
            _healthResponseBuilder = healthResponseBuilder;
        }

        [HttpGet, Route("v1/healthcheck")]
        public IHttpActionResult Get()
        {
            _healthChecker.WriteHealthTo(_healthResponseBuilder);
            return Ok(_healthResponseBuilder.Build());
        }
    }
}