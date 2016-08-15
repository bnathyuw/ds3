using System.Web.Http;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api
{
    public class DeliverToHomeController : ApiController
    {
        private readonly DeliverToHomeResponseBuilder _deliverToHomeResponseBuilder;
        private readonly DeliverySolutionFinder _deliverySolutionFinder;

        public DeliverToHomeController(DeliverToHomeResponseBuilder deliverToHomeResponseBuilder, DeliverySolutionFinder deliverySolutionFinder)
        {
            _deliverToHomeResponseBuilder = deliverToHomeResponseBuilder;
            _deliverySolutionFinder = deliverySolutionFinder;
        }

        public IHttpActionResult Post(DeliverToHomeRequest deliverToHomeRequest)
        {
            _deliverySolutionFinder.FindDthSolutions(_deliverToHomeResponseBuilder, deliverToHomeRequest.AssignmentId, deliverToHomeRequest.DeliveryDetails.AddressId);
            var deliverToHomeResponse = _deliverToHomeResponseBuilder.Build();
            return Ok(deliverToHomeResponse);
        }
    }
}