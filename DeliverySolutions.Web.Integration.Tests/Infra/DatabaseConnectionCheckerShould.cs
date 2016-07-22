using NUnit.Framework;

namespace DeliverySolutions.Web.Integration.Tests.Infra
{
    [TestFixture]
    public class DatabaseConnectionCheckerShould
    {
        private DatabaseConnectionChecker _databaseConnectionChecker;

        [SetUp]
        public void SetUp()
        {
            _databaseConnectionChecker = new DatabaseConnectionChecker();
        }

        [Test]
        public void Connect_to_database()
        {
            Assert.That(_databaseConnectionChecker.Check(), Is.EqualTo(1));
        }
    }
}