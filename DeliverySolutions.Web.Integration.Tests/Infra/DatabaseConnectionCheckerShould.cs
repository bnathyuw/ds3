using DeliverySolutions.Web.Domain;
using DeliverySolutions.Web.Infra;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Integration.Tests.Infra
{
    [TestFixture]
    public class DatabaseConnectionCheckerShould
    {
        private DatabaseConnectionChecker _databaseConnectionChecker;
        private BuildHealth _health;

        [SetUp]
        public void SetUp()
        {
            _databaseConnectionChecker = new DatabaseConnectionChecker();
            _health = Substitute.For<BuildHealth>();
        }

        [Test]
        public void Write_connection_status_to_health()
        {
            _databaseConnectionChecker.WriteDatabaseStatusTo(_health);

            _health.Received().AddCheck("Can connect to database", "1");
        }
    }
}