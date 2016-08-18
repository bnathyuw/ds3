using System.Web.Http.Results;
using DeliverySolutions.Web.Api.DeliverToHome.v1;
using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;
using static DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1.DeliverToHomeRequestBuilder;

namespace DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1
{
    [TestFixture]
    public class DeliverToHomeControllerShould
    {
        private DeliverToHomeResponseBuilder _deliverToHomeResponseBuilder;
        private DeliverToHomeResponse _expectedDeliverToHomeResponse;
        private DeliverToHomeController _deliverToHomeController;
        private DeliverySolutionFinder _deliverySolutionFinder;

        private const string AssignmentId = "abc";
        private const int AddressId = 123;
        private const int VariantId1 = 234;
        private const int VariantId2 = 345;

        [SetUp]
        public void SetUp()
        {
            _deliverToHomeResponseBuilder = Substitute.For<DeliverToHomeResponseBuilder>();
            _expectedDeliverToHomeResponse = new DeliverToHomeResponse();
            _deliverySolutionFinder = Substitute.For<DeliverySolutionFinder>((Web.Infra.SqlDeliverToHomeSolutions)null);
            _deliverToHomeController = new DeliverToHomeController(_deliverToHomeResponseBuilder, _deliverySolutionFinder);
        }

        [Test]
        public void Update_builder_with_bag_details()
        {
            var deliverToHomeRequest = ADeliverToHomeRequest.WithAssignmentId(AssignmentId).WithAddressId(AddressId).AddVariantId(VariantId1).AddVariantId(VariantId2).Build();

            _deliverToHomeController.Post(deliverToHomeRequest);

            _deliverToHomeResponseBuilder.Received().WithAssignmentId(AssignmentId);
            _deliverToHomeResponseBuilder.Received().WithAddressId(AddressId);
            _deliverToHomeResponseBuilder.AddItem(VariantId1);
            _deliverToHomeResponseBuilder.AddItem(VariantId2);
        }


        [Test]
        public void Find_delivery_solutions()
        {
            var deliverToHomeRequest = ADeliverToHomeRequest.Build();
            _deliverToHomeController.Post(deliverToHomeRequest);

            _deliverySolutionFinder.Received().FindDthSolutions(_deliverToHomeResponseBuilder);
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