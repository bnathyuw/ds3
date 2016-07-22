namespace DeliverySolutions.Web.Api
{
    public class HealthResponseBuilder : Health
    {
        private int _databaseStatus;

        public virtual void WithDatabaseStatus(int databaseStatus)
        {
            _databaseStatus = databaseStatus;
        }

        public virtual object Build()
        {
            return new
            {
                DatabaseStatus = _databaseStatus
            };
        }
    }
}