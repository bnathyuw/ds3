using System.Collections.Generic;
using System.Linq;

namespace DeliverySolutions.OutOfProcess.Specs.Request
{
    public class DthRequestBuilder
    {
        private readonly string _assignmentId;
        private readonly string _region;
        private readonly IEnumerable<Item> _items;
        private readonly DeliveryDetailsBuilder _deliveryDetailsBuilder;

        public static DthRequestBuilder ADthRequest => new DthRequestBuilder("Assignment ID", "Region 1", new List<Item>(), DeliveryDetailsBuilder.ADeliveryDetails);

        private DthRequestBuilder(string assignmentId, string region, IEnumerable<Item> items, DeliveryDetailsBuilder deliveryDetailsBuilder)
        {
            _assignmentId = assignmentId;
            _region = region;
            _items = items;
            _deliveryDetailsBuilder = deliveryDetailsBuilder;
        }

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
            return new DthRequestBuilder(_assignmentId, _region, _items.Concat(new[] {new Item {VariantId = variantId}}),
                _deliveryDetailsBuilder);
        }
    }
}