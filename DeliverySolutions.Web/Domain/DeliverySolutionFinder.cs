namespace DeliverySolutions.Web.Domain
{
    public interface SolutionCollector
    {
        void AddSolution(string solution);
    }

    public interface DeliverToHomeProposal : SolutionCollector
    {
        void SetAssignmentId(string assignmentId);
        void SetDeliveryAddressId(int deliveryAddressId);
    }

    public interface DeliverToHomeSolutions
    {
        void WriteDeliverToHomeSolutionsTo(SolutionCollector solutionCollector);
    }

    public class DeliverySolutionFinder
    {
        private readonly DeliverToHomeSolutions _deliverToHomeSolutions;

        public DeliverySolutionFinder(DeliverToHomeSolutions deliverToHomeSolutions)
        {
            _deliverToHomeSolutions = deliverToHomeSolutions;
        }

        public virtual void FindDthSolutions(DeliverToHomeProposal proposal, Bag bag)
        {
            proposal.SetAssignmentId(bag.AssignmentId);
            proposal.SetDeliveryAddressId(bag.DeliveryAddressId);
            _deliverToHomeSolutions.WriteDeliverToHomeSolutionsTo(proposal);
        }
    }
}