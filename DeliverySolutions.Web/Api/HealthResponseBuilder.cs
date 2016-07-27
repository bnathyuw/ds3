using System.Collections.Generic;
using System.Linq;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api
{
    public class HealthResponseBuilder : BuildHealth
    {
        private readonly List<Check> _checks = new List<Check>();
        private string _serviceVersion = "";

        public void AddCheck(string name, bool isSuccessful)
        {
            _checks.Add(new Check(name, isSuccessful));
        }

        public void WithServiceVersion(string serviceVersion)
        {
            _serviceVersion = serviceVersion;
        }

        public virtual Health Build()
        {
            return new Health(_checks, _serviceVersion, _checks.All(c => c.IsSuccessful));
        }
    }
}