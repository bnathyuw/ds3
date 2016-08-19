using System;
using System.Linq;
using DeliverySolutions.Web.Api.HealthCheck.v1;
using DeliverySolutions.Web.Wiring;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Infra
{
    [TestFixture]
    public class DependencyResolverShould
    {
        private readonly Type _unknownType = typeof(int);
        private DependencyResolver _dependencyResolver;

        [SetUp]
        public void SetUp()
        {
            _dependencyResolver = new DependencyResolver();
        }

        [Test]
        public void Resolve_healthcheck_controller()
        {
            Assert.That(_dependencyResolver.GetService(typeof(HealthcheckController)), Is.TypeOf<HealthcheckController>());
            Assert.That(_dependencyResolver.GetServices(typeof(HealthcheckController)).First(), Is.TypeOf<HealthcheckController>());
        }

        [Test]
        public void Resolve_deliver_to_home_controller()
        {
            Assert.That(_dependencyResolver.GetService(typeof(Web.Api.DeliverToHome.v1.DeliverToHomeController)), Is.TypeOf<Web.Api.DeliverToHome.v1.DeliverToHomeController>());
            Assert.That(_dependencyResolver.GetServices(typeof(Web.Api.DeliverToHome.v1.DeliverToHomeController)).First(), Is.TypeOf<Web.Api.DeliverToHome.v1.DeliverToHomeController>());
        }

        [Test]
        public void Not_resolve_unknown_type()
        {
            Assert.That(_dependencyResolver.GetService(_unknownType), Is.Null);
            Assert.That(_dependencyResolver.GetServices(_unknownType), Is.Empty);
        }
    }
}