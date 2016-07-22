using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Domain
{
    [TestFixture]
    public class HealthCheckerShould
    {
        private HealthChecker _healthChecker;
        private const int ExpectedDatabaseStatus = 43;

        [SetUp]
        public void SetUp()
        {
            var databaseConnectionChecker = Substitute.For<DatabaseConnectionChecker>();
            databaseConnectionChecker.Check().Returns(ExpectedDatabaseStatus);
            _healthChecker = new HealthChecker(databaseConnectionChecker);
        }

        [Test]
        public void Return_health_with_database_status()
        {
            var health = _healthChecker.CheckHealth();

            Assert.That(health.DatabaseStatus, Is.EqualTo(ExpectedDatabaseStatus));
        }
    }
}