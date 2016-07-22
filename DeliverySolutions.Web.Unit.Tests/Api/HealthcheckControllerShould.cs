﻿using System.Web.Http.Results;
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

        [SetUp]
        public void SetUp()
        {
            var healthChecker = Substitute.For<HealthChecker>((DatabaseConnectionChecker)null);
            _expectedHealth = new Health(43);
            healthChecker.CheckHealth().Returns(_expectedHealth);
            _healthcheckController = new HealthcheckController(healthChecker);
        }

        [Test]
        public void Responds_ok_with_health_of_application()
        {
            var response = (OkNegotiatedContentResult<Health>)_healthcheckController.Get();

            Assert.That(response.Content, Is.EqualTo(_expectedHealth));
        }
    }
}