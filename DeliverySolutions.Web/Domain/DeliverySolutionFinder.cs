using System.Collections.Generic;

namespace DeliverySolutions.Web.Domain
{
    public class DeliverySolutionFinder
    {
        private readonly Infra.DeliverySolutions _deliverySolutions;

        public DeliverySolutionFinder(Infra.DeliverySolutions deliverySolutions)
        {
            _deliverySolutions = deliverySolutions;
        }

        public virtual void FindDthSolutions(DeliverToHomeSolutionsBuilder deliverToHomeSolutionsBuilder, string assignmentId, int addressId, IEnumerable<int> variantIds)
        {
            deliverToHomeSolutionsBuilder.SetAssignmentId(assignmentId);
            deliverToHomeSolutionsBuilder.SetDeliveryAddressId(addressId);
            _deliverySolutions.WriteDeliverToHomeSolutionsTo(deliverToHomeSolutionsBuilder, variantIds, addressId);

        }
    }
}