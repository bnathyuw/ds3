using DeliverySolutions.Web.Api;
using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Api
{
    [TestFixture]
    public class HealthcheckControllerShould
    {
        private HealthcheckController _healthcheckController;
        private HealthChecker _healthChecker;
        private HealthResponseBuilder _healthResponseBuilder;

        [SetUp]
        public void SetUp()
        {
            _healthChecker = Substitute.For<HealthChecker>(null, null);
            _healthResponseBuilder = Substitute.For<HealthResponseBuilder>();
            _healthcheckController = new HealthcheckController(_healthChecker, _healthResponseBuilder);
        }

        [Test]
        public void Responds_ok_with_health_of_application()
        {
            _healthcheckController.Get();

            _healthChecker.Received().WriteHealthTo(_healthResponseBuilder);
        }
    }
}