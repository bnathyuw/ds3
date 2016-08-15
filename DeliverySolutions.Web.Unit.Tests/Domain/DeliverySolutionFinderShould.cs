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
        private DeliverToHomeSolutionsBuilder _deliverToHomeSolutionsBuilder;
        private Web.Infra.DeliverySolutions _deliverySolutions;
        private readonly int[] _variantIds = {345, 456};

        [SetUp]
        public void SetUp()
        {
            _deliverToHomeSolutionsBuilder = Substitute.For<DeliverToHomeSolutionsBuilder>();
            _deliverySolutions = Substitute.For<Web.Infra.DeliverySolutions>();
            _deliverySolutionFinder = new DeliverySolutionFinder(_deliverySolutions);

            _deliverySolutionFinder.FindDthSolutions(_deliverToHomeSolutionsBuilder, AssignmentId, DeliveryAddressId, _variantIds);

        }

        [Test]
        public void Set_assignment_id_on_the_solutions()
        {
            _deliverToHomeSolutionsBuilder.Received().SetAssignmentId(AssignmentId);
        }

        [Test]
        public void Set_address_id_on_the_solutions()
        {
            _deliverToHomeSolutionsBuilder.Received().SetDeliveryAddressId(DeliveryAddressId);
        }

        [Test]
        public void Add_solutions()
        {
            _deliverySolutions.Received().WriteDeliverToHomeSolutionsTo(_deliverToHomeSolutionsBuilder, DeliveryAddressId);
        }
    }
}