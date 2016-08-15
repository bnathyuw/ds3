namespace DeliverySolutions.Web.Domain
{
    public interface SolutionCollector
    {
        void AddSolution(string solution);
    }

    public interface DeliverToHomeSolutionsBuilder : SolutionCollector
    {
        void SetAssignmentId(string assignmentId);
        void SetDeliveryAddressId(int deliveryAddressId);
    }

    public class DeliverySolutionFinder
    {
        private readonly Infra.DeliverySolutions _deliverySolutions;

        public DeliverySolutionFinder(Infra.DeliverySolutions deliverySolutions)
        {
            _deliverySolutions = deliverySolutions;
        }

        public virtual void FindDthSolutions(DeliverToHomeSolutionsBuilder deliverToHomeSolutionsBuilder, string assignmentId, int addressId)
        {
            deliverToHomeSolutionsBuilder.SetAssignmentId(assignmentId);
            deliverToHomeSolutionsBuilder.SetDeliveryAddressId(addressId);
            _deliverySolutions.WriteDeliverToHomeSolutionsTo(deliverToHomeSolutionsBuilder);

        }
    }
}