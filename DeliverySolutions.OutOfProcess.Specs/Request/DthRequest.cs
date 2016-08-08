namespace DeliverySolutions.OutOfProcess.Specs.Request
{
    public class DthRequest
    {
        public string AssignmentId { get; set; }
        public Item[] Items { get; set; }
        public string Region { get; set; }
        public DeliveryDetails DeliveryDetails { get; set; }
    }
}