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

        [Test]
        public void Resolve_healthcheck_controller()
        {
            var dependencyResolver = new DependencyResolver();

            Assert.That(dependencyResolver.GetService(typeof(HealthcheckController)), Is.TypeOf<HealthcheckController>());
            Assert.That(dependencyResolver.GetServices(typeof(HealthcheckController)).First(), Is.TypeOf<HealthcheckController>());
        }

        [Test]
        public void Not_resolve_unknown_type()
        {
            var dependencyResolver = new DependencyResolver();

            Assert.That(dependencyResolver.GetService(_unknownType), Is.Null);
            Assert.That(dependencyResolver.GetServices(_unknownType), Is.Empty);
        }
    }
}