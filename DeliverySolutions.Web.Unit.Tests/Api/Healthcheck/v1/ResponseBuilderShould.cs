using DeliverySolutions.Web.Api.HealthCheck.v1;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Api.Healthcheck.v1
{
    [TestFixture]
    public class ResponseBuilderShould
    {
        private ResponseBuilder _responseBuilder;

        [SetUp]
        public void SetUp()
        {
            _responseBuilder = new ResponseBuilder();
        }

        [Test]
        public void Build_health_response_with_database_status()
        {
            _responseBuilder.SetDatabaseStatus(true);

            var health = _responseBuilder.Build();

            Assert.That(health.Checks, Does.Contain(new Check("Can connect to database", true)));
        }

        [Test]
        public void Build_health_response_with_service_version()
        {
            _responseBuilder.SetServiceVersion("1.2.3.4");

            var health = _responseBuilder.Build();

            Assert.That(health.ServiceVersion, Is.EqualTo("1.2.3.4"));
        }

        [Test]
        public void Builds_healthy_when_database_is_health()
        {
            _responseBuilder.SetDatabaseStatus(true);

            var health = _responseBuilder.Build();

            Assert.That(health.IsHealthy, Is.True);
        }

        [Test]
        public void Build_unhealthy_when_database_is_unhealthy()
        {
            _responseBuilder.SetDatabaseStatus(false);

            var health = _responseBuilder.Build();

            Assert.That(health.IsHealthy, Is.False);
        }
    }
}