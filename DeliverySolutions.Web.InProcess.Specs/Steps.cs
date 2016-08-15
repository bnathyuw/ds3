using System.Web.Http.Results;
using DeliverySolutions.Web.Api;
using DeliverySolutions.Web.Domain;
using DeliverySolutions.Web.Infra;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace DeliverySolutions.Web.InProcess.Specs
{
    [Binding]
    public class CheckStatusOfServiceSteps
    {
        private const string AssemblyVersionPattern = "\\d+\\.\\d+\\.\\d+\\.\\d+";
        private HealthResponse _content;

        [When(@"I hit the healthcheck endpoint")]
        public void WhenIHitTheHealthcheckEndpoint()
        {
            var healthcheckController = new HealthcheckController(new HealthChecker(new SqlDatabase(), new ThisService()), new HealthResponseBuilder());
            var response = (OkNegotiatedContentResult<HealthResponse>)healthcheckController.Get();
            _content = response.Content;
        }

        [Then(@"I should see the assembly version of the service")]
        public void ThenIShouldSeeTheAssemblyVersionOfTheService()
        {
            Assert.That(_content.ServiceVersion, Does.Match(AssemblyVersionPattern));
        }

        [Then(@"I should see the database connection status")]
        public void ThenIShouldSeeTheDatabaseConnectionStatus()
        {
            Assert.That(_content.Checks, Does.Contain(new Check("Can connect to database", true)));
        }

        [Then(@"I should see the overall system health")]
        public void ThenIShouldSeeTheOverallSystemHealth()
        {
            Assert.That(_content.IsHealthy, Is.True);
        }

    }
}
