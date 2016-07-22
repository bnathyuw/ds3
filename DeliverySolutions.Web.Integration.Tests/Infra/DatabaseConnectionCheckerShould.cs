using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Integration.Tests.Infra
{
    [TestFixture]
    public class DatabaseConnectionCheckerShould
    {
        private DatabaseConnectionChecker _databaseConnectionChecker;
        private Health _health;

        [SetUp]
        public void SetUp()
        {
            _databaseConnectionChecker = new DatabaseConnectionChecker();
            _health = Substitute.For<Health>();
        }

        [Test]
        public void Write_connection_status_to_health()
        {
            _databaseConnectionChecker.WriteDatabaseStatusTo(_health);

            _health.Received().WithDatabaseStatus(1);
        }
    }
}