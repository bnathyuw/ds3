using System;

namespace DeliverySolutions.OutOfProcess.Specs.Response
{
    public class DeliverySolution
    {
        public string FulfilmentCentre { get; set; }
        public bool IsBacked { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime AvailableUntil { get; set; }
        public DateTime AtRiskFrom { get; set; }
        public DateTime ShouldArriveBy { get; set; }
        public Attribute[] Attributes { get; set; }
    }
}