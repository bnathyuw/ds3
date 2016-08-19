using System.Web.Http;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api.HealthCheck.v1
{
    public class HealthcheckController : ApiController
    {
        private readonly HealthChecker _healthChecker;
        private readonly ResponseBuilder _responseBuilder;

        public HealthcheckController(HealthChecker healthChecker, ResponseBuilder responseBuilder)
        {
            _healthChecker = healthChecker;
            _responseBuilder = responseBuilder;
        }

        [HttpGet, Route("v1/healthcheck")]
        public IHttpActionResult Get()
        {
            _healthChecker.WriteHealthTo(_responseBuilder);
            return Ok(_responseBuilder.Build());
        }
    }
}