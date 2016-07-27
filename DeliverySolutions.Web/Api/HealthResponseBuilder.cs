using System.Collections.Generic;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api
{
    public class HealthResponseBuilder : BuildHealth
    {
        private readonly List<Check> _checks = new List<Check>();
        private string _serviceVersion = "";

        public void AddCheck(string name, string value)
        {
            _checks.Add(new Check(name, value));
        }

        public virtual Health Build()
        {
            return new Health(_checks, _serviceVersion);
        }

        public void WithServiceVersion(string serviceVersion)
        {
            _serviceVersion = serviceVersion;
        }
    }
}