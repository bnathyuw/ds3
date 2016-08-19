using System.Collections.Generic;
using System.Linq;
using DeliverySolutions.Web.Api.DeliverToHome.v1;

namespace DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1
{
    public class RequestBuilder
    {
        private readonly string _assignmentId;
        private readonly int _addressId;
        private readonly IEnumerable<int> _variantIds;

        public static RequestBuilder ARequest => new RequestBuilder("", 0, new int[]{});

        private RequestBuilder(string assignmentId, int addressId, IEnumerable<int> variantIds)
        {
            _assignmentId = assignmentId;
            _addressId = addressId;
            _variantIds = variantIds;
        }

        public RequestBuilder WithAssignmentId(string assignmentId)
        {
            return new RequestBuilder(assignmentId, _addressId, _variantIds);
        }

        public RequestBuilder WithAddressId(int addressId)
        {
            return new RequestBuilder(_assignmentId, addressId, _variantIds);
        }

        public RequestBuilder AddVariantId(int variantId)
        {
            return new RequestBuilder(_assignmentId, _addressId, _variantIds.Concat(new [] { variantId}));
        }

        public Request Build()
        {
            return new Request
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