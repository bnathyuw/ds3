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
        private Bag _bag;

        [SetUp]
        public void SetUp()
        {
            _deliverToHomeProposal = Substitute.For<DeliverToHomeProposal>();
            _deliverToHomeSolutions = Substitute.For<Web.Infra.SqlDeliverToHomeSolutions>();
            _deliverySolutionFinder = new DeliverySolutionFinder(_deliverToHomeSolutions);

            _bag = new Bag(AssignmentId, DeliveryAddressId);
            _deliverySolutionFinder.FindDthSolutions(_deliverToHomeProposal, _bag);

        }

        [Test]
        public void Set_bag_for_proposal()
        {
            _deliverToHomeProposal.Received().ForBag(_bag);
        }

        [Test]
        public void Add_solutions()
        {
            _deliverToHomeSolutions.Received().WriteDeliverToHomeSolutionsTo(_deliverToHomeProposal);
        }
    }
}