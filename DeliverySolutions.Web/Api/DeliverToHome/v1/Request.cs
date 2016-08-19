namespace DeliverySolutions.Web.Api.DeliverToHome.v1
{
    public class Request
    {
        public string AssignmentId { get; set; }
        public DeliveryDetails DeliveryDetails { get; set; }
        public Item[] Items { get; set; }
    }

    public class DeliveryDetails
    {
        public int AddressId { get; set; }
    }

    public class Item
    {
        public int VariantId { get; set; }
    }
}