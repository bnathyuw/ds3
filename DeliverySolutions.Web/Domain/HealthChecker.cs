namespace DeliverySolutions.Web.Domain
{
    public class HealthChecker
    {
        private readonly DatabaseConnectionChecker _databaseConnectionChecker;

        public HealthChecker(DatabaseConnectionChecker databaseConnectionChecker)
        {
            _databaseConnectionChecker = databaseConnectionChecker;
        }

        public virtual Health CheckHealth()
        {
            var databaseStatus = _databaseConnectionChecker.Check();
            return new Health(databaseStatus);
        }
    }
}