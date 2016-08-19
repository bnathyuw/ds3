﻿namespace DeliverySolutions.Web.Api.DeliverToHome.v1
{
    public class Response
    {
        public string AssignmentId { get; set; }
        public int DeliveryAddressId { get; set; }
        public ResponseItem[] Items { get; set; }
    }

    public class ResponseItem
    {
        public DeliverySolution[] DeliverySolutions { get; set; }
        public int VariantId { get; set; }
    }

    public class DeliverySolution
    {
    }
}