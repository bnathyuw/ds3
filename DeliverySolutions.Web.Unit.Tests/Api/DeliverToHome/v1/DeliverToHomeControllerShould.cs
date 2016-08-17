using System.Web.Http.Results;
using DeliverySolutions.Web.Api.DeliverToHome.v1;
using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1
{
    [TestFixture]
    public class DeliverToHomeControllerShould
    {
        private DeliverToHomeResponseBuilder _deliverToHomeResponseBuilder;
        private DeliverToHomeResponse _expectedDeliverToHomeResponse;
        private DeliverToHomeController _deliverToHomeController;
        private DeliverySolutionFinder _deliverySolutionFinder;
        private BagFactory _bagFactory;
        private const string AssignmentId = "123";
        private const int AddressId = 123;
        private const int VariantId = 234;
        private const int AnotherVariantId = 345;

        [SetUp]
        public void SetUp()
        {
            _deliverToHomeResponseBuilder = Substitute.For<DeliverToHomeResponseBuilder>();
            _expectedDeliverToHomeResponse = new DeliverToHomeResponse();
            _deliverySolutionFinder = Substitute.For<DeliverySolutionFinder>((Web.Infra.SqlDeliverToHomeSolutions)null);
            _bagFactory = Substitute.For<BagFactory>();
            _deliverToHomeController = new DeliverToHomeController(_deliverToHomeResponseBuilder, _deliverySolutionFinder, _bagFactory);
        }

        [Test]
        public void Build_a_bag()
        {
            var deliverToHomeRequest = DeliverToHomeRequestBuilder.ADeliverToHomeRequest.Build();
            _deliverToHomeController.Post(deliverToHomeRequest);

            _bagFactory.Received().BuildFrom(deliverToHomeRequest);
        }

        [Test]
        public void Find_delivery_solutions()
        {
            var deliverToHomeRequest = DeliverToHomeRequestBuilder.ADeliverToHomeRequest
                .WithAssignmentId(AssignmentId)
                .WithAddressId(AddressId)
                .AddVariantId(VariantId)
                .AddVariantId(AnotherVariantId)
                .Build();
            var bag = new Bag(AssignmentId, AddressId);
            _bagFactory.BuildFrom(deliverToHomeRequest).Returns(bag);
            _deliverToHomeController.Post(deliverToHomeRequest);

            _deliverySolutionFinder.Received().FindDthSolutions(_deliverToHomeResponseBuilder, bag);
        }

        [Test]
        public void Respond_ok_with_response_from_builder()
        {
            _deliverToHomeResponseBuilder.Build().Returns(_expectedDeliverToHomeResponse);

            var deliverToHomeRequest = DeliverToHomeRequestBuilder.ADeliverToHomeRequest.Build();
            var httpActionResult = (OkNegotiatedContentResult<DeliverToHomeResponse>)_deliverToHomeController.Post(deliverToHomeRequest);

            Assert.That(httpActionResult.Content, Is.EqualTo(_expectedDeliverToHomeResponse));
        }
    }
}