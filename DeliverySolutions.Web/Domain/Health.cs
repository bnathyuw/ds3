namespace DeliverySolutions.Web.Domain
{
    public class Health
    {
        public Health(int databaseStatus)
        {
            DatabaseStatus = databaseStatus;
        }

        public int DatabaseStatus { get; }
    }
}