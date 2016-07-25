using System.Web.Http;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api
{
    public class HealthcheckController : ApiController
    {
        private readonly HealthChecker _healthChecker;
        private readonly HealthcheckResponseMapper _healthcheckResponseMapper;

        public HealthcheckController(HealthChecker healthChecker, HealthcheckResponseMapper healthcheckResponseMapper)
        {
            _healthChecker = healthChecker;
            _healthcheckResponseMapper = healthcheckResponseMapper;
        }

        public IHttpActionResult Get()
        {
            var health = _healthChecker.CheckHealth();
            var healthcheckResponse = _healthcheckResponseMapper.MapResponse(health);
            return Ok(healthcheckResponse);
        }
    }
}