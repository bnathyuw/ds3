using System;
using System.Linq;
using DeliverySolutions.Web.Api;
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
        public void Not_resolve_unknown_type()
        {
            Assert.That(_dependencyResolver.GetService(_unknownType), Is.Null);
            Assert.That(_dependencyResolver.GetServices(_unknownType), Is.Empty);
        }
    }
}