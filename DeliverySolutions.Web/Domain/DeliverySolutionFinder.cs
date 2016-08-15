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

        public virtual void FindDthSolutions(DeliverToHomeProposal proposal, string assignmentId, int addressId)
        {
            proposal.SetAssignmentId(assignmentId);
            proposal.SetDeliveryAddressId(addressId);
            _deliverToHomeSolutions.WriteDeliverToHomeSolutionsTo(proposal);
        }
    }
}