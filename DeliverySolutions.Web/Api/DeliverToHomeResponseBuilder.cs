using System.Collections.Generic;
using System.Linq;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api
{
    public class DeliverToHomeResponseBuilder : DeliverToHomeProposal
    {
        private string _assignmentId;
        private int _deliveryAddressId;
        private readonly List<string> _solutions = new List<string>();

        public virtual void SetAssignmentId(string assignmentId)
        {
            _assignmentId = assignmentId;
        }

        public virtual void SetDeliveryAddressId(int deliveryAddressId)
        {
            _deliveryAddressId = deliveryAddressId;
        }

        public void AddSolution(string solution)
        {
            _solutions.Add(solution);
        }

        public virtual DeliverToHomeResponse Build()
        {
            return new DeliverToHomeResponse
            {
                AssignmentId = _assignmentId,
                DeliveryAddressId = _deliveryAddressId,
                Items =
                    new[]
                    {
                        new ResponseItem
                        {
                            DeliverySolutions = _solutions.Select(solution => new DeliverySolution()).ToArray()
                        }
                    }
            };
        }
    }
}