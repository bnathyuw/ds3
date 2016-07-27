namespace DeliverySolutions.Web.Domain
{
    public interface BuildHealth
    {
        void AddCheck(string name, bool isSuccessful);
        void WithServiceVersion(string serviceVersion);
    }
}