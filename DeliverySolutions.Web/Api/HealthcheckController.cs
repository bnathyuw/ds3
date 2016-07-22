using System.Web.Http;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api
{
    public class HealthcheckController : ApiController
    {
        private readonly HealthChecker _healthChecker;

        public HealthcheckController(HealthChecker healthChecker)
        {
            _healthChecker = healthChecker;
        }

        public void Get()
        {
            _healthChecker.CheckHealth();
        }
    }
}