using System.Collections.Generic;

namespace DeliverySolutions.OutOfProcess.Specs.Request
{
    public class DthRequestBuilder
    {
        private string _assignmentId;
        private string _region;
        private List<Item> _items = new List<Item>();
        private DeliveryDetailsBuilder _deliveryDetailsBuilder = DeliveryDetailsBuilder.ADeliveryDetails;
        public static DthRequestBuilder ADthRequest => new DthRequestBuilder();

        public DthRequest Build()
        {
            return new DthRequest
            {
                AssignmentId = _assignmentId,
                Region = _region,
                Items = _items.ToArray(),
                DeliveryDetails = _deliveryDetailsBuilder.Build()
            };
        }
    }
}