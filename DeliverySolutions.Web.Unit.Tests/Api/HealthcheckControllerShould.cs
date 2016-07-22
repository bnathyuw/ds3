using DeliverySolutions.Web.Api;
using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Api
{
    [TestFixture]
    public class HealthcheckControllerShould
    {
        [Test]
        public void Check_health_of_application()
        {
            var healthChecker = Substitute.For<HealthChecker>();
            var healthcheckController = new HealthcheckController(healthChecker);

            healthcheckController.Get();

            healthChecker.Received().CheckHealth();
        }
    }
}