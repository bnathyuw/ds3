using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using DeliverySolutions.Web.Api.HealthCheck.v1;
using DeliverySolutions.Web.Domain;
using DeliverySolutions.Web.Infra;
using ResponseBuilder = DeliverySolutions.Web.Api.HealthCheck.v1.ResponseBuilder;

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
            if (serviceType == typeof(Api.DeliverToHome.v1.DeliverToHomeController))
            {
                return DeliverToHomeController();
            }
            return null;
        }

        private static Api.DeliverToHome.v1.DeliverToHomeController DeliverToHomeController()
        {
            return new Api.DeliverToHome.v1.DeliverToHomeController(new Api.DeliverToHome.v1.ResponseBuilder(), new DeliverToHomeSolutionFinder(new SqlDeliverToHomeSolutions()));
        }

        private static HealthcheckController BuildHealthcheckController()
        {
            return new HealthcheckController(new HealthChecker(new SqlDatabase(), new ThisService()), new ResponseBuilder());
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == typeof(HealthcheckController))
            {
                yield return BuildHealthcheckController();
            }
            if (serviceType == typeof(Api.DeliverToHome.v1.DeliverToHomeController))
            {
                yield return DeliverToHomeController();
            }
        }
    }
}