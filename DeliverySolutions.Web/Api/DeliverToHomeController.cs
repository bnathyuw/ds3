using System.Web.Http;

namespace DeliverySolutions.Web.Api
{
    public class DeliverToHomeController : ApiController
    {
        private readonly DeliverToHomeResponseBuilder _deliverToHomeResponseBuilder;

        public DeliverToHomeController(DeliverToHomeResponseBuilder deliverToHomeResponseBuilder)
        {
            _deliverToHomeResponseBuilder = deliverToHomeResponseBuilder;
        }

        public IHttpActionResult Post()
        {
            var deliverToHomeResponse = _deliverToHomeResponseBuilder.Build();
            return Ok(deliverToHomeResponse);
        }
    }
}