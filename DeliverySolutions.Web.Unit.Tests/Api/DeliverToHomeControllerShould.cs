using System.Web.Http.Results;
using DeliverySolutions.Web.Api;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Api
{
    [TestFixture]
    public class DeliverToHomeControllerShould
    {
        private DeliverToHomeResponseBuilder _deliverToHomeResponseBuilder;
        private DeliverToHomeResponse _expectedDeliverToHomeResponse;
        private DeliverToHomeController _deliverToHomeController;

        [SetUp]
        public void SetUp()
        {
            _deliverToHomeResponseBuilder = Substitute.For<DeliverToHomeResponseBuilder>();
            _expectedDeliverToHomeResponse = new DeliverToHomeResponse();
            _deliverToHomeController = new DeliverToHomeController(_deliverToHomeResponseBuilder);
        }

        [Test]
        public void Respond_ok_with_response_from_builder()
        {
            _deliverToHomeResponseBuilder.Build().Returns(_expectedDeliverToHomeResponse);

            var httpActionResult = (OkNegotiatedContentResult<DeliverToHomeResponse>)_deliverToHomeController.Post();

            Assert.That(httpActionResult.Content, Is.EqualTo(_expectedDeliverToHomeResponse));
        }
    }
}