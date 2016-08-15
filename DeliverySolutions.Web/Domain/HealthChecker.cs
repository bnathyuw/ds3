namespace DeliverySolutions.Web.Domain
{
    public interface DatabaseStatus
    {
        void SetDatabaseStatus(bool isSuccessful);
    }

    public interface ServiceVersion
    {
        void SetServiceVersion(string serviceVersion);
    }

    public interface Health : DatabaseStatus, ServiceVersion
    {
    }

    public interface Database
    {
        void WriteStatusTo(DatabaseStatus databaseStatus);
    }

    public interface Service
    {
        void WriteVersionTo(ServiceVersion serviceVersion);
    }

    public class HealthChecker
    {
        private readonly Database _databaseConnectionChecker;
        private readonly Service _service;

        public HealthChecker(Database databaseConnectionChecker, Service service)
        {
            _databaseConnectionChecker = databaseConnectionChecker;
            _service = service;
        }

        public virtual void WriteHealthTo(Health health)
        {
            _service.WriteVersionTo(health);
            _databaseConnectionChecker.WriteStatusTo(health);
        }
    }
}