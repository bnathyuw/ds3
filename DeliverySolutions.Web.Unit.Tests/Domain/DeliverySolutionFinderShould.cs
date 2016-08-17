using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Domain
{
    [TestFixture]
    public class DeliverySolutionFinderShould
    {
        private const string AssignmentId = "123";
        private const int DeliveryAddressId = 234;
        private DeliverySolutionFinder _deliverySolutionFinder;
        private DeliverToHomeProposal _deliverToHomeProposal;
        private DeliverToHomeSolutions _deliverToHomeSolutions;

        [SetUp]
        public void SetUp()
        {
            _deliverToHomeProposal = Substitute.For<DeliverToHomeProposal>();
            _deliverToHomeSolutions = Substitute.For<Web.Infra.SqlDeliverToHomeSolutions>();
            _deliverySolutionFinder = new DeliverySolutionFinder(_deliverToHomeSolutions);

            _deliverySolutionFinder.FindDthSolutions(_deliverToHomeProposal, new Bag(AssignmentId, DeliveryAddressId));

        }

        [Test]
        public void Set_assignment_id_on_the_solutions()
        {
            _deliverToHomeProposal.Received().SetAssignmentId(AssignmentId);
        }

        [Test]
        public void Set_address_id_on_the_solutions()
        {
            _deliverToHomeProposal.Received().SetDeliveryAddressId(DeliveryAddressId);
        }

        [Test]
        public void Add_solutions()
        {
            _deliverToHomeSolutions.Received().WriteDeliverToHomeSolutionsTo(_deliverToHomeProposal);
        }
    }
}