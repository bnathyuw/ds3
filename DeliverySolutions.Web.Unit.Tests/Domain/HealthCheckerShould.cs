using DeliverySolutions.Web.Domain;
using NSubstitute;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Domain
{
    [TestFixture]
    public class HealthCheckerShould
    {
        private HealthChecker _healthChecker;
        private BuildHealth _healthBuilder;
        private DatabaseConnectionChecker _databaseConnectionChecker;
        private AssemblyVersioner _assemblyVersioner;

        [SetUp]
        public void SetUp()
        {
            _databaseConnectionChecker = Substitute.For<DatabaseConnectionChecker>();
            _healthBuilder = Substitute.For<BuildHealth>();
            _assemblyVersioner = Substitute.For<AssemblyVersioner>();
            _healthChecker = new HealthChecker(_databaseConnectionChecker, _assemblyVersioner);
        }

        [Test]
        public void Pass_the_assembly_version_to_health()
        {
            _healthChecker.WriteHealthTo(_healthBuilder);

            _assemblyVersioner.Received().WriteVersionTo(_healthBuilder);
        }

        [Test]
        public void Write_database_status_to_health()
        {
            _healthChecker.WriteHealthTo(_healthBuilder);

            _databaseConnectionChecker.Received().WriteDatabaseStatusTo(_healthBuilder);
        }
    }
}