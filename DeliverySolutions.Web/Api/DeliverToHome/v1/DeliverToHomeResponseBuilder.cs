﻿using System.Collections.Generic;
using System.Linq;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Api.DeliverToHome.v1
{
    public class DeliverToHomeResponseBuilder : DeliverToHomeProposal
    {
        private string _assignmentId;
        private int _deliveryAddressId;
        private readonly List<string> _solutions = new List<string>();

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

        public virtual void WithAssignmentId(string assignmentId)
        {
            _assignmentId = assignmentId;
        }

        public virtual void WithAddressId(int addressId)
        {
            _deliveryAddressId = addressId;
        }
    }
}