using System.Web.Http.Results;
using DeliverySolutions.Web.Api;
using DeliverySolutions.Web.Domain;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace DeliverySolutions.Web.InProcess.Specs
{
    [Binding]
    public class CheckStatusOfServiceSteps
    {
        private Health _content;

        [When(@"I hit the healthcheck endpoint")]
        public void WhenIHitTheHealthcheckEndpoint()
        {
            var healthcheckController = new HealthcheckController(new HealthChecker(new DatabaseConnectionChecker()), new HealthResponseBuilder());
            var response = (OkNegotiatedContentResult<Health>)healthcheckController.Get();
            _content = response.Content;
        }
        
        [Then(@"I should see the database connection status")]
        public void ThenIShouldSeeTheDatabaseConnectionStatus()
        {
            Assert.That(_content.Checks, Does.Contain(new Check("Can connect to database", "1")));
        }
    }
}
