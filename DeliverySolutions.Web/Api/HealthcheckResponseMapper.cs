using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api
{
    public class HealthcheckResponseMapper
    {
        public virtual HealthcheckResponse MapResponse(Health health)
        {
            return new HealthcheckResponse
            {
                DatabaseStatus = health.DatabaseStatus
            };
        }
    }
}