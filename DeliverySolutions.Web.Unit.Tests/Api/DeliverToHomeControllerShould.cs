using System.Web.Http.Results;
using DeliverySolutions.Web.Api;
using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;
using static DeliverySolutions.Web.Unit.Tests.Api.DeliverToHomeRequestBuilder;

namespace DeliverySolutions.Web.Unit.Tests.Api
{
    [TestFixture]
    public class DeliverToHomeControllerShould
    {
        private DeliverToHomeResponseBuilder _deliverToHomeResponseBuilder;
        private DeliverToHomeResponse _expectedDeliverToHomeResponse;
        private DeliverToHomeController _deliverToHomeController;
        private DeliverySolutionFinder _deliverySolutionFinder;
        private const string AssignmentId = "123";
        private const int AddressId = 123;
        private const int VariantId = 234;
        private const int AnotherVariantId = 345;

        [SetUp]
        public void SetUp()
        {
            _deliverToHomeResponseBuilder = Substitute.For<DeliverToHomeResponseBuilder>();
            _expectedDeliverToHomeResponse = new DeliverToHomeResponse();
            _deliverySolutionFinder = Substitute.For<DeliverySolutionFinder>((Web.Infra.DeliverySolutions)null);
            _deliverToHomeController = new DeliverToHomeController(_deliverToHomeResponseBuilder, _deliverySolutionFinder);
        }

        [Test]
        public void Find_delivery_solutions()
        {
            var deliverToHomeRequest = ADeliverToHomeRequest
                .WithAssignmentId(AssignmentId)
                .WithAddressId(AddressId)
                .AddVariantId(VariantId)
                .AddVariantId(AnotherVariantId)
                .Build();
            _deliverToHomeController.Post(deliverToHomeRequest);

            _deliverySolutionFinder.Received().FindDthSolutions(_deliverToHomeResponseBuilder, AssignmentId, AddressId);
        }

        [Test]
        public void Respond_ok_with_response_from_builder()
        {
            _deliverToHomeResponseBuilder.Build().Returns(_expectedDeliverToHomeResponse);

            var deliverToHomeRequest = ADeliverToHomeRequest.Build();
            var httpActionResult = (OkNegotiatedContentResult<DeliverToHomeResponse>)_deliverToHomeController.Post(deliverToHomeRequest);

            Assert.That(httpActionResult.Content, Is.EqualTo(_expectedDeliverToHomeResponse));
        }
    }
}