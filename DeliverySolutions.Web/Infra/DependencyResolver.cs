using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using DeliverySolutions.Web.Api;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web
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
            return null;
        }

        private static HealthcheckController BuildHealthcheckController()
        {
            return new HealthcheckController(new HealthChecker(new DatabaseConnectionChecker()), new HealthResponseBuilder());
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == typeof(HealthcheckController))
            {
                yield return BuildHealthcheckController();
            }
        }
    }
}