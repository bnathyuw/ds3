using System.Collections.Generic;
using System.Linq;
using DeliverySolutions.Web.Api.DeliverToHome.v1;

namespace DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1
{
    public class DeliverToHomeRequestBuilder
    {
        private string _assignmentId = "";
        private int _addressId;
        private readonly List<int> _variantIds = new List<int>();

        public static DeliverToHomeRequestBuilder ADeliverToHomeRequest => new DeliverToHomeRequestBuilder();

        public DeliverToHomeRequestBuilder WithAssignmentId(string assignmentId)
        {
            _assignmentId = assignmentId;
            return this;
        }

        public DeliverToHomeRequestBuilder WithAddressId(int addressId)
        {
            _addressId = addressId;
            return this;
        }

        public DeliverToHomeRequestBuilder AddVariantId(int variantId)
        {
            _variantIds.Add(variantId);
            return this;
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