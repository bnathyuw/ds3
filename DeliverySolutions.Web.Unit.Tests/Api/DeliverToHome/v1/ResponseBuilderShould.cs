using DeliverySolutions.Web.Api.DeliverToHome.v1;
using NUnit.Framework;
using static DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1.RequestBuilder;

namespace DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1
{
    [TestFixture]
    public class ResponseBuilderShould
    {
        private const string AssignmentId = "123";
        private const int DeliveryAddressId = 123;
        private const int VariantId1 = 234;
        private const int VariantId2 = 345;

        private ResponseBuilder _responseBuilder;

        [SetUp]
        public void SetUp()
        {
            _responseBuilder = new ResponseBuilder();
        }

        [Test]
        public void Build_response_with_given_assignment_id()
        {
            _responseBuilder.WithRequest(ARequest.WithAssignmentId(AssignmentId).Build());

            Assert.That(_responseBuilder.Build().AssignmentId, Is.EqualTo(AssignmentId));
        }

        [Test]
        public void Build_response_with_given_address_id()
        {
            _responseBuilder.WithRequest(ARequest.WithAddressId(DeliveryAddressId).Build());

            Assert.That(_responseBuilder.Build().DeliveryAddressId, Is.EqualTo(DeliveryAddressId));
        }

        [Test]
        public void Build_respones_with_given_items()
        {
            _responseBuilder.WithRequest(ARequest.AddVariantId(VariantId1).AddVariantId(VariantId2).Build());

            Assert.That(_responseBuilder.Build().Items.Length, Is.EqualTo(2));
            Assert.That(_responseBuilder.Build().Items[0].VariantId, Is.EqualTo(VariantId1));
            Assert.That(_responseBuilder.Build().Items[1].VariantId, Is.EqualTo(VariantId2));
        }

        [Test]
        public void Build_response_with_given_solutions()
        {
            _responseBuilder.WithRequest(ARequest.AddVariantId(VariantId1).Build());
            _responseBuilder.AddSolution("Solution 1");
            _responseBuilder.AddSolution("Solution 2");

            Assert.That(_responseBuilder.Build().Items[0].DeliverySolutions.Length, Is.EqualTo(2));
        }
    }
}