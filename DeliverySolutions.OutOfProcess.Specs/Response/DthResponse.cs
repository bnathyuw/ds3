namespace DeliverySolutions.OutOfProcess.Specs.Response
{
    public class DthResponse
    {
        public string AssignmentId { get; set; }
        public int DeliveryAddressId { get; set; }
        public Item[] Items { get; set; }
    }
}