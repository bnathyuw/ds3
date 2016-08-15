using DeliverySolutions.Web.Domain.DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Domain
{
    public interface BuildHealth
    {
        void AddCheck(string name, bool isSuccessful);
        void WithServiceVersion(string serviceVersion);
    }

    namespace DeliverySolutions.Web.Domain
    {
        public interface Database
        {
            void WriteStatusTo(BuildHealth healthBuilder);
        }
    }

    public interface Application
    {
        void WriteVersionTo(BuildHealth healthBuilder);
    }

    public class HealthChecker
    {
        private readonly Database _databaseConnectionChecker;
        private readonly Application _application;

        public HealthChecker(Database databaseConnectionChecker, Application application)
        {
            _databaseConnectionChecker = databaseConnectionChecker;
            _application = application;
        }

        public virtual void WriteHealthTo(BuildHealth healthBuilder)
        {
            _application.WriteVersionTo(healthBuilder);
            _databaseConnectionChecker.WriteStatusTo(healthBuilder);
        }
    }
}