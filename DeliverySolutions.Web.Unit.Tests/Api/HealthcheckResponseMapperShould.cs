using DeliverySolutions.Web.Api;
using DeliverySolutions.Web.Domain;
using NUnit.Framework;

namespace DeliverySolutions.Web.Unit.Tests.Api
{
    [TestFixture]
    public class HealthcheckResponseMapperShould
    {
        private const int DatabaseStatus = 43;
        private HealthcheckResponseMapper _healthcheckResponseMapper;

        [SetUp]
        public void SetUp()
        {
            _healthcheckResponseMapper = new HealthcheckResponseMapper();
        }

        [Test]
        public void Map_database_status()
        {
            var healthcheckResponse = _healthcheckResponseMapper.MapResponse(new Health(DatabaseStatus));

            Assert.That(healthcheckResponse.DatabaseStatus, Is.EqualTo(DatabaseStatus));
        }
    }
}