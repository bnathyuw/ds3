using System.Web.Http.Results;
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
        private Health _expectedHealth;
        private HealthcheckResponseMapper _healthcheckResponseMapper;
        private HealthcheckResponse _expectedHealthcheckResponse;

        [SetUp]
        public void SetUp()
        {
            var healthChecker = Substitute.For<HealthChecker>((DatabaseConnectionChecker)null);
            _expectedHealth = new Health(43);
            healthChecker.CheckHealth().Returns(_expectedHealth);
            _healthcheckResponseMapper = Substitute.For<HealthcheckResponseMapper>();
            _expectedHealthcheckResponse = new HealthcheckResponse();
            _healthcheckResponseMapper.MapResponse(_expectedHealth).Returns(_expectedHealthcheckResponse);
            _healthcheckController = new HealthcheckController(healthChecker, _healthcheckResponseMapper);
        }

        [Test]
        public void Maps_response_from_health_checker()
        {
            _healthcheckController.Get();

            _healthcheckResponseMapper.Received().MapResponse(_expectedHealth);
        }

        [Test]
        public void Responds_ok_with_health_of_application()
        {
            var response = (OkNegotiatedContentResult<HealthcheckResponse>)_healthcheckController.Get();

            Assert.That(response.Content, Is.EqualTo(_expectedHealthcheckResponse));
        }
    }
}