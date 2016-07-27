using DeliverySolutions.Web.Api;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Api
{
    [TestFixture]
    public class HealthResponseBuilderShould
    {
        [Test]
        public void Build_health_response_with_supplied_values()
        {
            var healthResponseBuilder = new HealthResponseBuilder();
            healthResponseBuilder.AddCheck("Check name", true);
            healthResponseBuilder.WithServiceVersion("1.2.3.4");

            var health = healthResponseBuilder.Build();

            Assert.That(health.ServiceVersion, Is.EqualTo("1.2.3.4"));
            Assert.That(health.Checks, Does.Contain(new Check("Check name", true)));
        }

        [Test]
        public void Builds_healthy_when_all_checks_pass()
        {
            var healthResponseBuilder = new HealthResponseBuilder();
            healthResponseBuilder.AddCheck("Check one", true);
            healthResponseBuilder.AddCheck("Check two", true);
            healthResponseBuilder.AddCheck("Check three", true);

            var health = healthResponseBuilder.Build();

            Assert.That(health.IsHealthy, Is.True);
        }

        [Test]
        public void Build_unhealth_when_not_all_checks_pass()
        {
            var healthResponseBuilder = new HealthResponseBuilder();
            healthResponseBuilder.AddCheck("Check one", true);
            healthResponseBuilder.AddCheck("Check two", false);
            healthResponseBuilder.AddCheck("Check three", true);

            var health = healthResponseBuilder.Build();

            Assert.That(health.IsHealthy, Is.False);
        }
    }
}