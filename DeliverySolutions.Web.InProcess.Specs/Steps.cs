﻿using System.Web.Http.Results;
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
        private Health _content;

        [When(@"I hit the healthcheck endpoint")]
        public void WhenIHitTheHealthcheckEndpoint()
        {
            var healthcheckController = new HealthcheckController(new HealthChecker(new DatabaseConnectionChecker(), new AssemblyVersioner()), new HealthResponseBuilder());
            var response = (OkNegotiatedContentResult<Health>)healthcheckController.Get();
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
            Assert.That(_content.Checks, Does.Contain(new Check("Can connect to database", "1")));
        }
    }
}
