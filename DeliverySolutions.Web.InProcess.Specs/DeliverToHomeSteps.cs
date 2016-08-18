using System.Web.Http;
using System.Web.Http.Results;
using DeliverySolutions.Web.Api.DeliverToHome.v1;
using DeliverySolutions.Web.Domain;
using DeliverySolutions.Web.Infra;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DeliverySolutions.Web.InProcess.Specs
{
    [Binding]
    public class DeliverToHomeSteps
    {
        private const string AssignmentId = "123";
        private const int AddressId = 234;
        private const int VariantId1 = 345;
        private const int VariantId2 = 456;
        private Item[] _items;
        private DeliverToHomeResponse _response;

        [Given(@"I have two items in my bag")]
        public void GivenIHaveTwoItemsInMyBag()
        {
            _items = new[] {new Item {VariantId = VariantId1}, new Item {VariantId = VariantId2}};
        }

        [When(@"I look at my shipping methods")]
        public void WhenILookAtMyShippingMethods()
        {
            var deliverToHomeController = new DeliverToHomeController(new DeliverToHomeResponseBuilder(), new DeliverySolutionFinder(new SqlDeliverToHomeSolutions()));
            var result = (OkNegotiatedContentResult<DeliverToHomeResponse>)deliverToHomeController.Post(new DeliverToHomeRequest {AssignmentId = AssignmentId, DeliveryDetails = new DeliveryDetails {AddressId = AddressId}, Items = _items });
            _response = result.Content;
        }

        [Then(@"I should see which methods fit each item")]
        public void ThenIShouldSeeWhichMethodsFitEachItem()
        {
            Assert.That(_response.Items.Length, Is.EqualTo(2));
            Assert.That(_response.Items[0].VariantId, Is.EqualTo(VariantId1));
            Assert.That(_response.Items[1].VariantId, Is.EqualTo(VariantId2));
        }

    }
}