using DeliverySolutions.Web.Api.DeliverToHome.v1;
using NUnit.Framework;
using static DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1.DeliverToHomeRequestBuilder;

namespace DeliverySolutions.Web.Unit.Tests.Api.DeliverToHome.v1
{
    [TestFixture]
    public class BagFactoryShould
    {
        private const string AssignmentId = "ABC";

        private const int AddressId = 123;

        [Test]
        public void Create_bag()
        {
            var bagFactory = new BagFactory();
            var deliverToHomeRequest = ADeliverToHomeRequest.WithAssignmentId(AssignmentId)
                .WithAddressId(AddressId)
                .Build();
            var bag = bagFactory.BuildFrom(deliverToHomeRequest);

            Assert.That(bag.AssignmentId, Is.EqualTo(AssignmentId));
            Assert.That(bag.DeliveryAddressId, Is.EqualTo(AddressId));
        }
    }
}