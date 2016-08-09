using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api
{
    public class DeliverToHomeResponseBuilder : DeliverToHomeSolutionsBuilder
    {
        private string _assignmentId;
        private int _deliveryAddressId;

        public virtual void SetAssignmentId(string assignmentId)
        {
            _assignmentId = assignmentId;
        }

        public virtual void SetDeliveryAddressId(int deliveryAddressId)
        {
            _deliveryAddressId = deliveryAddressId;
        }

        public virtual DeliverToHomeResponse Build()
        {
            return new DeliverToHomeResponse
            {
                AssignmentId = _assignmentId,
                DeliveryAddressId = _deliveryAddressId
            };
        }
    }
}