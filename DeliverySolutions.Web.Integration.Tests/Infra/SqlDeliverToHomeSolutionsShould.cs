using DeliverySolutions.Web.Domain;
using DeliverySolutions.Web.Infra;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Integration.Tests.Infra
{
    [TestFixture]
    public class SqlDeliverToHomeSolutionsShould
    {
        [Test]
        public void Write_solutions_from_database_to_proposal()
        {
            var deliverySolutions = new SqlDeliverToHomeSolutions();

            var deliverToHomeProposal = Substitute.For<DeliverToHomeProposal>();
            deliverySolutions.WriteTo(deliverToHomeProposal);

            Received.InOrder(() =>
            {
                deliverToHomeProposal.Received().AddSolution("Express");
                deliverToHomeProposal.Received().AddSolution("Snail");
            });
        }
    }
}