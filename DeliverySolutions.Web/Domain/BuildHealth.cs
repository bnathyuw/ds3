namespace DeliverySolutions.Web.Domain
{
    public interface BuildHealth
    {
        void AddCheck(string name, string value);
        void WithServiceVersion(string serviceVersion);
    }
}