namespace DeliverySolutions.Web.Domain
{
    public class HealthChecker
    {
        private readonly DatabaseConnectionChecker _databaseConnectionChecker;
        private readonly AssemblyVersioner _assemblyVersioner;

        public HealthChecker(DatabaseConnectionChecker databaseConnectionChecker, AssemblyVersioner assemblyVersioner)
        {
            _databaseConnectionChecker = databaseConnectionChecker;
            _assemblyVersioner = assemblyVersioner;
        }

        public virtual void WriteHealthTo(BuildHealth healthBuilder)
        {
            _assemblyVersioner.WriteVersionTo(healthBuilder);
            _databaseConnectionChecker.WriteDatabaseStatusTo(healthBuilder);
        }
    }
}