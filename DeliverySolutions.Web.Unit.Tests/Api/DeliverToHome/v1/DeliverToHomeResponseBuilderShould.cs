using DeliverySolutions.Web.Api.DeliverToHome.v1;
using NUnit.Framework;
using static DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1.DeliverToHomeRequestBuilder;

namespace DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1
{
    [TestFixture]
    public class DeliverToHomeResponseBuilderShould
    {
        private const string AssignmentId = "123";
        private const int DeliveryAddressId = 123;
        private const int VariantId1 = 234;
        private const int VariantId2 = 345;

        private DeliverToHomeResponseBuilder _deliverToHomeResponseBuilder;

        [SetUp]
        public void SetUp()
        {
            _deliverToHomeResponseBuilder = new DeliverToHomeResponseBuilder();
        }

        [Test]
        public void Build_response_with_given_assignment_id()
        {
            _deliverToHomeResponseBuilder.WithRequest(ADeliverToHomeRequest.WithAssignmentId(AssignmentId).Build());

            Assert.That(_deliverToHomeResponseBuilder.Build().AssignmentId, Is.EqualTo(AssignmentId));
        }

        [Test]
        public void Build_response_with_given_address_id()
        {
            _deliverToHomeResponseBuilder.WithRequest(ADeliverToHomeRequest.WithAddressId(DeliveryAddressId).Build());

            Assert.That(_deliverToHomeResponseBuilder.Build().DeliveryAddressId, Is.EqualTo(DeliveryAddressId));
        }

        [Test]
        public void Build_respones_with_given_items()
        {
            _deliverToHomeResponseBuilder.WithRequest(ADeliverToHomeRequest.AddVariantId(VariantId1).AddVariantId(VariantId2).Build());

            Assert.That(_deliverToHomeResponseBuilder.Build().Items.Length, Is.EqualTo(2));
            Assert.That(_deliverToHomeResponseBuilder.Build().Items[0].VariantId, Is.EqualTo(VariantId1));
            Assert.That(_deliverToHomeResponseBuilder.Build().Items[1].VariantId, Is.EqualTo(VariantId2));
        }

        [Test]
        public void Build_response_with_given_solutions()
        {
            _deliverToHomeResponseBuilder.WithRequest(ADeliverToHomeRequest.AddVariantId(VariantId1).Build());
            _deliverToHomeResponseBuilder.AddSolution("Solution 1");
            _deliverToHomeResponseBuilder.AddSolution("Solution 2");

            Assert.That(_deliverToHomeResponseBuilder.Build().Items[0].DeliverySolutions.Length, Is.EqualTo(2));
        }
    }
}