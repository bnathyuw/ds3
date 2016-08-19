using System.Collections.Generic;
using System.Linq;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api.DeliverToHome.v1
{
    public class ResponseBuilder : DeliverToHomeProposal
    {
        private string _assignmentId;
        private int _deliveryAddressId;
        private readonly List<string> _solutions = new List<string>();
        private readonly List<int> _variantIds = new List<int>();

        public void AddSolution(string solution)
        {
            _solutions.Add(solution);
        }

        public virtual Response Build()
        {
            return new Response
            {
                AssignmentId = _assignmentId,
                DeliveryAddressId = _deliveryAddressId,
                Items = _variantIds.Select(variantId => new ResponseItem
                {
                    VariantId = variantId,
                    DeliverySolutions = _solutions.Select(solution => new DeliverySolution()).ToArray()
                }).ToArray()
            };
        }

        public virtual void WithRequest(Request request)
        {
            _assignmentId = request.AssignmentId;
            _deliveryAddressId = request.DeliveryDetails.AddressId;
            _variantIds.AddRange(request.Items.Select(item => item.VariantId));
        }
    }
}