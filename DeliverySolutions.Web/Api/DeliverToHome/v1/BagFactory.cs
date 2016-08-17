using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api.DeliverToHome.v1
{
    public class BagFactory
    {
        public virtual Bag BuildFrom(DeliverToHomeRequest deliverToHomeRequest)
        {
            return new Bag(deliverToHomeRequest.AssignmentId, deliverToHomeRequest.DeliveryDetails.AddressId);
        }
    }
}