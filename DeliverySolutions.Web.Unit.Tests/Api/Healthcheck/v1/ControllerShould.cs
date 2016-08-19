using DeliverySolutions.Web.Api.HealthCheck.v1;
using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Api.Healthcheck.v1
{
    [TestFixture]
    public class ControllerShould
    {
        private HealthcheckController _healthcheckController;
        private HealthChecker _healthChecker;
        private ResponseBuilder _responseBuilder;

        [SetUp]
        public void SetUp()
        {
            _healthChecker = Substitute.For<HealthChecker>(null, null);
            _responseBuilder = Substitute.For<ResponseBuilder>();
            _healthcheckController = new HealthcheckController(_healthChecker, _responseBuilder);
        }

        [Test]
        public void Responds_ok_with_health_of_application()
        {
            _healthcheckController.Get();

            _healthChecker.Received().WriteHealthTo(_responseBuilder);
        }
    }
}