using System.Web.UI;

namespace DeliverySolutions.Web.Api
{
    public class DeliverToHomeRequest
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