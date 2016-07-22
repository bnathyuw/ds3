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
                return new HealthcheckController(new HealthChecker());
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == typeof(HealthcheckController))
            {
                yield return new HealthcheckController(new HealthChecker());
            }
        }
    }
}