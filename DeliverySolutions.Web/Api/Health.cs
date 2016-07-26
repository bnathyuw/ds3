using System.Collections.Generic;

namespace DeliverySolutions.Web.Api
{
    public class Health
    {
        public IEnumerable<Check> Checks { get; private set; }

        public Health(IEnumerable<Check> checks)
        {
            Checks = checks;
        }
    }
}