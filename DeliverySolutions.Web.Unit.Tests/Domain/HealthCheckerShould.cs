using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Domain
{
    [TestFixture]
    public class HealthCheckerShould
    {
        private HealthChecker _healthChecker;
        private Health _health;
        private DatabaseConnectionChecker _databaseConnectionChecker;

        [SetUp]
        public void SetUp()
        {
            _databaseConnectionChecker = Substitute.For<DatabaseConnectionChecker>();
            _health = Substitute.For<Health>();
            _healthChecker = new HealthChecker(_databaseConnectionChecker);
        }

        [Test]
        public void Writes_database_status_to_health()
        {
            _healthChecker.WriteHealthTo(_health);

            _databaseConnectionChecker.Received().WriteDatabaseStatusTo(_health);
        }
    }
}