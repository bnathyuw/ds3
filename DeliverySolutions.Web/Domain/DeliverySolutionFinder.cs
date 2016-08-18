namespace DeliverySolutions.Web.Domain
{
    public interface DeliverToHomeProposal
    {
        void AddSolution(string solution);
    }

    public interface DeliverToHomeSolutions
    {
        void WriteTo(DeliverToHomeProposal deliverToHomeProposal);
    }

    public class DeliverySolutionFinder
    {
        private readonly DeliverToHomeSolutions _deliverToHomeSolutions;

        public DeliverySolutionFinder(DeliverToHomeSolutions deliverToHomeSolutions)
        {
            _deliverToHomeSolutions = deliverToHomeSolutions;
        }

        public virtual void WriteDeliverToHomeSolutionsTo(DeliverToHomeProposal deliverToHomeProposal)
        {
            _deliverToHomeSolutions.WriteTo(deliverToHomeProposal);
        }
    }
}