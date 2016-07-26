namespace DeliverySolutions.Web
{
    public interface BuildHealth
    {
        void AddCheck(string name, string value);
        void WithServiceVersion(string serviceVersion);
    }
}