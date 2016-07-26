namespace DeliverySolutions.Web.Api
{
    public struct Check
    {
        public string Name { get; }
        public string Value { get; }

        public Check(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}