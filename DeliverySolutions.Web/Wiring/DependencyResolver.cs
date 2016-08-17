using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using DeliverySolutions.Web.Api.DeliverToHome.v1;
using DeliverySolutions.Web.Api.HealthCheck.v1;
using DeliverySolutions.Web.Domain;
using DeliverySolutions.Web.Infra;

namespace DeliverySolutions.Web.Wiring
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
            return new DeliverToHomeController(new DeliverToHomeResponseBuilder(), new DeliverySolutionFinder(new Infra.SqlDeliverToHomeSolutions()), new BagFactory());
        }

        private static HealthcheckController BuildHealthcheckController()
        {
            return new HealthcheckController(new HealthChecker(new SqlDatabase(), new ThisService()), new HealthResponseBuilder());
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