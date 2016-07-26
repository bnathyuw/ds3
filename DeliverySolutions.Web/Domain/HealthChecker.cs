namespace DeliverySolutions.Web.Domain
{
    public class HealthChecker
    {
        private readonly DatabaseConnectionChecker _databaseConnectionChecker;

        public HealthChecker(DatabaseConnectionChecker databaseConnectionChecker)
        {
            _databaseConnectionChecker = databaseConnectionChecker;
        }

        public virtual void WriteHealthTo(BuildHealth healthBuilder)
        {
            _databaseConnectionChecker.WriteDatabaseStatusTo(healthBuilder);
        }
    }
}