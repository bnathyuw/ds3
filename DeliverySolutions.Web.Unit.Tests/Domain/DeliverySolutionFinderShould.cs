using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Domain
{
    [TestFixture]
    public class DeliverySolutionFinderShould
    {
        private DeliverySolutionFinder _deliverySolutionFinder;
        private DeliverToHomeProposal _deliverToHomeProposal;
        private DeliverToHomeSolutions _deliverToHomeSolutions;

        [SetUp]
        public void SetUp()
        {
            _deliverToHomeProposal = Substitute.For<DeliverToHomeProposal>();
            _deliverToHomeSolutions = Substitute.For<Web.Infra.SqlDeliverToHomeSolutions>();
            _deliverySolutionFinder = new DeliverySolutionFinder(_deliverToHomeSolutions);

            _deliverySolutionFinder.FindDthSolutions(_deliverToHomeProposal);
        }

        [Test]
        public void Add_solutions()
        {
            _deliverToHomeSolutions.Received().WriteDeliverToHomeSolutionsTo(_deliverToHomeProposal);
        }
    }
}