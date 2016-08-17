namespace DeliverySolutions.Web.Api.HealthCheck.v1
{
    public struct Check
    {
        public string Name { get; }
        public bool IsSuccessful { get; }

        public Check(string name, bool isSuccessful)
        {
            Name = name;
            IsSuccessful = isSuccessful;
        }
    }
}