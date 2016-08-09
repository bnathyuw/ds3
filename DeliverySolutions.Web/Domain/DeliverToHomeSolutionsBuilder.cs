using DeliverySolutions.Web.Infra;

namespace DeliverySolutions.Web.Domain
{
    public interface DeliverToHomeSolutionsBuilder : Foo
    {
        void SetAssignmentId(string assignmentId);
        void SetDeliveryAddressId(int deliveryAddressId);
    }
}