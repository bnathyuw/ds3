using System.Collections.Generic;

namespace DeliverySolutions.OutOfProcess.Specs.Request
{
    public class DthRequestBuilder
    {
        private string _assignmentId = "Assignment ID";
        private string _region = "Region 1";
        private readonly List<Item> _items = new List<Item>();
        private readonly DeliveryDetailsBuilder _deliveryDetailsBuilder = DeliveryDetailsBuilder.ADeliveryDetails;
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

        public DthRequestBuilder WithVariantId(int variantId)
        {
            _items.Add(new Item {VariantId = variantId});
            return this;
        }
    }
}