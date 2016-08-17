﻿using System.Web.Http;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api.DeliverToHome.v1
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

        [HttpPost, Route("v1/deliver-to-home")]
        public IHttpActionResult Post(DeliverToHomeRequest deliverToHomeRequest)
        {
            _deliverToHomeResponseBuilder.WithAssignmentId(deliverToHomeRequest.AssignmentId);
            _deliverToHomeResponseBuilder.WithAddressId(deliverToHomeRequest.DeliveryDetails.AddressId);
            _deliverySolutionFinder.FindDthSolutions(_deliverToHomeResponseBuilder);
            return Ok(_deliverToHomeResponseBuilder.Build());
        }
    }
}