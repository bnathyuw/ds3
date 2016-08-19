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

    public class DeliverToHomeSolutionFinder
    {
        private readonly DeliverToHomeSolutions _deliverToHomeSolutions;

        public DeliverToHomeSolutionFinder(DeliverToHomeSolutions deliverToHomeSolutions)
        {
            _deliverToHomeSolutions = deliverToHomeSolutions;
        }

        public virtual void WriteDeliverToHomeSolutionsTo(DeliverToHomeProposal deliverToHomeProposal)
        {
            _deliverToHomeSolutions.WriteTo(deliverToHomeProposal);
        }
    }
}