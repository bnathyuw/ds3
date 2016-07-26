using System.Collections.Generic;

namespace DeliverySolutions.Web.Api
{
    public class HealthResponseBuilder : BuildHealth
    {
        private readonly List<Check> _checks = new List<Check>();

        public void AddCheck(Check check)
        {
            _checks.Add(check);
        }

        public virtual Health Build()
        {
            return new Health(_checks);
        }
    }
}