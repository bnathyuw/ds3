namespace DeliverySolutions.OutOfProcess.Specs.Response
{
    public class Item
    {
        public int VariantId { get; set; }
        public bool HasExclusions { get; set; }
        public DeliverySolution[] DeliverySolutions { get; set; }
    }
}