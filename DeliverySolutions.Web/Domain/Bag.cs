namespace DeliverySolutions.Web.Domain
{
    public class Bag
    {
        public string AssignmentId { get; }
        public int DeliveryAddressId { get; }

        public Bag(string assignmentId, int deliveryAddressId)
        {
            AssignmentId = assignmentId;
            DeliveryAddressId = deliveryAddressId;
        }
    }
}