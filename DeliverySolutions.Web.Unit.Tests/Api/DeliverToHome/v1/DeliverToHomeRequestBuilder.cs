using System.Collections.Generic;
using System.Linq;
using DeliverySolutions.Web.Api.DeliverToHome.v1;

namespace DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1
{
    public class DeliverToHomeRequestBuilder
    {
        private readonly string _assignmentId;
        private readonly int _addressId;
        private readonly IEnumerable<int> _variantIds;

        public static DeliverToHomeRequestBuilder ADeliverToHomeRequest => new DeliverToHomeRequestBuilder("", 0, new int[]{});

        private DeliverToHomeRequestBuilder(string assignmentId, int addressId, IEnumerable<int> variantIds)
        {
            _assignmentId = assignmentId;
            _addressId = addressId;
            _variantIds = variantIds;
        }

        public DeliverToHomeRequestBuilder WithAssignmentId(string assignmentId)
        {
            return new DeliverToHomeRequestBuilder(assignmentId, _addressId, _variantIds);
        }

        public DeliverToHomeRequestBuilder WithAddressId(int addressId)
        {
            return new DeliverToHomeRequestBuilder(_assignmentId, addressId, _variantIds);
        }

        public DeliverToHomeRequestBuilder AddVariantId(int variantId)
        {
            return new DeliverToHomeRequestBuilder(_assignmentId, _addressId, _variantIds.Concat(new [] { variantId}));
        }

        public DeliverToHomeRequest Build()
        {
            return new DeliverToHomeRequest
            {
                AssignmentId = _assignmentId,
                DeliveryDetails = new DeliveryDetails
                {
                    AddressId = _addressId
                },
                Items = _variantIds.Select(variantId => new Item { VariantId = variantId}).ToArray()
            };
        }
    }
}