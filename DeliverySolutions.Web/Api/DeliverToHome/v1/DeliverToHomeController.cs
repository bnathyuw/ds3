using System.Web.Http;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api.DeliverToHome.v1
{
    public class DeliverToHomeController : ApiController
    {
        private readonly DeliverToHomeResponseBuilder _deliverToHomeResponseBuilder;
        private readonly DeliverySolutionFinder _deliverySolutionFinder;
        private readonly BagFactory _bagFactory;

        public DeliverToHomeController(DeliverToHomeResponseBuilder deliverToHomeResponseBuilder, DeliverySolutionFinder deliverySolutionFinder, BagFactory bagFactory)
        {
            _deliverToHomeResponseBuilder = deliverToHomeResponseBuilder;
            _deliverySolutionFinder = deliverySolutionFinder;
            _bagFactory = bagFactory;
        }

        [HttpPost, Route("v1/deliver-to-home")]
        public IHttpActionResult Post(DeliverToHomeRequest deliverToHomeRequest)
        {
            _deliverySolutionFinder.FindDthSolutions(_deliverToHomeResponseBuilder, _bagFactory.BuildFrom(deliverToHomeRequest));
            return Ok(_deliverToHomeResponseBuilder.Build());
        }
    }
}