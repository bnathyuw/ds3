namespace DeliverySolutions.Web.Api.DeliverToHome.v1
{
    public class DeliverToHomeResponse
    {
        public string AssignmentId { get; set; }
        public int DeliveryAddressId { get; set; }
        public ResponseItem[] Items { get; set; }
    }

    public class ResponseItem
    {
        public DeliverySolution[] DeliverySolutions { get; set; }
    }

    public class DeliverySolution
    {
    }
}