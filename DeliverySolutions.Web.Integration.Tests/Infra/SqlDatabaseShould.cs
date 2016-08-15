using DeliverySolutions.Web.Domain;
using DeliverySolutions.Web.Infra;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Integration.Tests.Infra
{
    [TestFixture]
    public class SqlDatabaseShould
    {
        private Database _databaseConnectionChecker;
        private DatabaseStatus _health;

        [SetUp]
        public void SetUp()
        {
            _databaseConnectionChecker = new SqlDatabase();
            _health = Substitute.For<Health>();
        }

        [Test]
        public void Write_connection_status_to_health()
        {
            _databaseConnectionChecker.WriteStatusTo(_health);

            _health.Received().SetDatabaseStatus(true);
        }
    }
}