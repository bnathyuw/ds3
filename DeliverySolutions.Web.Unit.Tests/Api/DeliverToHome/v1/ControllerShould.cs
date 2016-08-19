using System.Web.Http.Results;
using DeliverySolutions.Web.Api.DeliverToHome.v1;
using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;
using static DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1.RequestBuilder;

namespace DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1
{
    [TestFixture]
    public class ControllerShould
    {
        private ResponseBuilder _responseBuilder;
        private Response _expectedResponse;
        private DeliverToHomeController _deliverToHomeController;
        private DeliverToHomeSolutionFinder _deliverToHomeSolutionFinder;

        private const string AssignmentId = "abc";
        private const int AddressId = 123;
        private const int VariantId1 = 234;
        private const int VariantId2 = 345;

        [SetUp]
        public void SetUp()
        {
            _responseBuilder = Substitute.For<ResponseBuilder>();
            _expectedResponse = new Response();
            _deliverToHomeSolutionFinder = Substitute.For<DeliverToHomeSolutionFinder>((Web.Infra.SqlDeliverToHomeSolutions)null);
            _deliverToHomeController = new DeliverToHomeController(_responseBuilder, _deliverToHomeSolutionFinder);
        }

        [Test]
        public void Update_builder_with_bag_details()
        {
            var deliverToHomeRequest = ARequest.WithAssignmentId(AssignmentId).WithAddressId(AddressId).AddVariantId(VariantId1).AddVariantId(VariantId2).Build();

            _deliverToHomeController.Post(deliverToHomeRequest);

            _responseBuilder.Received().WithRequest(deliverToHomeRequest);
        }


        [Test]
        public void Find_delivery_solutions()
        {
            var deliverToHomeRequest = ARequest.Build();
            _deliverToHomeController.Post(deliverToHomeRequest);

            _deliverToHomeSolutionFinder.Received().WriteDeliverToHomeSolutionsTo(_responseBuilder);
        }

        [Test]
        public void Respond_ok_with_response_from_builder()
        {
            _responseBuilder.Build().Returns(_expectedResponse);

            var deliverToHomeRequest = ARequest.Build();
            var httpActionResult = (OkNegotiatedContentResult<Response>)_deliverToHomeController.Post(deliverToHomeRequest);

            Assert.That(httpActionResult.Content, Is.EqualTo(_expectedResponse));
        }
    }
}