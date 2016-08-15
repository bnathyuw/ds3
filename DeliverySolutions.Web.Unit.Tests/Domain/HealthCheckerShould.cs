using DeliverySolutions.Web.Domain;
using DeliverySolutions.Web.Infra;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Domain
{
    [TestFixture]
    public class HealthCheckerShould
    {
        private HealthChecker _healthChecker;
        private Health _healthBuilder;
        private Database _databaseConnectionChecker;
        private Service _thisService;

        [SetUp]
        public void SetUp()
        {
            _databaseConnectionChecker = Substitute.For<SqlDatabase>();
            _healthBuilder = Substitute.For<Health>();
            _thisService = Substitute.For<ThisService>();
            _healthChecker = new HealthChecker(_databaseConnectionChecker, _thisService);
        }

        [Test]
        public void Pass_the_assembly_version_to_health()
        {
            _healthChecker.WriteHealthTo(_healthBuilder);

            _thisService.Received().WriteVersionTo(_healthBuilder);
        }

        [Test]
        public void Write_database_status_to_health()
        {
            _healthChecker.WriteHealthTo(_healthBuilder);

            _databaseConnectionChecker.Received().WriteStatusTo(_healthBuilder);
        }
    }
}