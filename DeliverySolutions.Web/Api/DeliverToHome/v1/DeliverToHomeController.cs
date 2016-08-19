using System.Web.Http;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api.DeliverToHome.v1
{
    public class DeliverToHomeController : ApiController
    {
        private readonly ResponseBuilder _responseBuilder;
        private readonly DeliverToHomeSolutionFinder _deliverToHomeSolutionFinder;

        public DeliverToHomeController(ResponseBuilder responseBuilder, DeliverToHomeSolutionFinder deliverToHomeSolutionFinder)
        {
            _responseBuilder = responseBuilder;
            _deliverToHomeSolutionFinder = deliverToHomeSolutionFinder;
        }

        [HttpPost, Route("v1/deliver-to-home")]
        public IHttpActionResult Post(Request request)
        {
            _responseBuilder.WithRequest(request);
            _deliverToHomeSolutionFinder.WriteDeliverToHomeSolutionsTo(_responseBuilder);
            return Ok(_responseBuilder.Build());
        }
    }
}