using DeliverySolutions.Web.Api;
using DeliverySolutions.Web.Api.DeliverToHome.v1;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Api
{
    [TestFixture]
    public class DeliverToHomeResponseBuilderShould
    {
        private const string AssignmentId = "123";
        private const int DeliveryAddressId = 123;

        private DeliverToHomeResponseBuilder _deliverToHomeResponseBuilder;

        [SetUp]
        public void SetUp()
        {
            _deliverToHomeResponseBuilder = new DeliverToHomeResponseBuilder();
        }

        [Test]
        public void Build_response_with_given_assignment_id()
        {
            _deliverToHomeResponseBuilder.SetAssignmentId(AssignmentId);

            Assert.That(_deliverToHomeResponseBuilder.Build().AssignmentId, Is.EqualTo(AssignmentId));
        }

        [Test]
        public void Build_response_with_given_delivery_address_id()
        {
            _deliverToHomeResponseBuilder.SetDeliveryAddressId(DeliveryAddressId);

            Assert.That(_deliverToHomeResponseBuilder.Build().DeliveryAddressId, Is.EqualTo(DeliveryAddressId));
        }

        [Test]
        public void Build_response_with_given_solutions()
        {
            _deliverToHomeResponseBuilder.AddSolution("Solution 1");
            _deliverToHomeResponseBuilder.AddSolution("Solution 2");

            Assert.That(_deliverToHomeResponseBuilder.Build().Items[0].DeliverySolutions.Length, Is.EqualTo(2));
        }
    }
}