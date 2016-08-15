using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using DeliverySolutions.Web.Api;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Infra
{
    public class DependencyResolver: IDependencyResolver
    {
        public void Dispose()
        {
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(HealthcheckController))
            {
                return BuildHealthcheckController();
            }
            if (serviceType == typeof(DeliverToHomeController))
            {
                return DeliverToHomeController();
            }
            return null;
        }

        private static DeliverToHomeController DeliverToHomeController()
        {
            return new DeliverToHomeController(new DeliverToHomeResponseBuilder(), new DeliverySolutionFinder(new DeliverySolutions()));
        }

        private static HealthcheckController BuildHealthcheckController()
        {
            return new HealthcheckController(new HealthChecker(new SqlDatabase(), new ThisApplication()), new HealthResponseBuilder());
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == typeof(HealthcheckController))
            {
                yield return BuildHealthcheckController();
            }
            if (serviceType == typeof(DeliverToHomeController))
            {
                yield return DeliverToHomeController();
            }
        }
    }
}