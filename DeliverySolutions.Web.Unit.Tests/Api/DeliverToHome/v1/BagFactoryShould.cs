using DeliverySolutions.Web.Api.DeliverToHome.v1;
using NUnit.Framework;

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

            var bag = bagFactory.BuildFrom(new DeliverToHomeRequest
            {
                AssignmentId = AssignmentId,
                DeliveryDetails = new DeliveryDetails {AddressId = AddressId}
            });

            Assert.That(bag.AssignmentId, Is.EqualTo(AssignmentId));
            Assert.That(bag.DeliveryAddressId, Is.EqualTo(AddressId));
        }
    }
}