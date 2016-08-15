using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Integration.Tests.Infra
{
    [TestFixture]
    public class DeliverySolutionsShould
    {
        [Test]
        public void Foo()
        {
            var deliverySolutions = new Web.Infra.DeliverySolutions();

            var foo = Substitute.For<DeliverToHomeSolutionsBuilder>();
            deliverySolutions.WriteDeliverToHomeSolutionsTo(foo);

            foo.Received().AddSolution("Snail");
            foo.Received().AddSolution("Snail");
        }
    }
}