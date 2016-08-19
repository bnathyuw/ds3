using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Domain
{
    [TestFixture]
    public class DeliverySolutionFinderShould
    {
        private DeliverToHomeSolutionFinder _deliverToHomeSolutionFinder;
        private DeliverToHomeProposal _deliverToHomeProposal;
        private DeliverToHomeSolutions _deliverToHomeSolutions;

        [SetUp]
        public void SetUp()
        {
            _deliverToHomeProposal = Substitute.For<DeliverToHomeProposal>();
            _deliverToHomeSolutions = Substitute.For<Web.Infra.SqlDeliverToHomeSolutions>();
            _deliverToHomeSolutionFinder = new DeliverToHomeSolutionFinder(_deliverToHomeSolutions);

            _deliverToHomeSolutionFinder.WriteDeliverToHomeSolutionsTo(_deliverToHomeProposal);
        }

        [Test]
        public void Add_solutions()
        {
            _deliverToHomeSolutions.Received().WriteTo(_deliverToHomeProposal);
        }
    }
}