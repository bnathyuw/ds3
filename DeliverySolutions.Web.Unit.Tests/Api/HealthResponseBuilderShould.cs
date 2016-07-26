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

            healthResponseBuilder.AddCheck("Check name", "Check value");
            healthResponseBuilder.WithServiceVersion("1.2.3.4");
            var health = healthResponseBuilder.Build();
            Assert.That(health.ServiceVersion, Is.EqualTo("1.2.3.4"));
            Assert.That(health.Checks, Does.Contain(new Check("Check name", "Check value")));
        }
    }
}