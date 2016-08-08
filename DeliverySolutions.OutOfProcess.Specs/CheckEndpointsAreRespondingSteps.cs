using TechTalk.SpecFlow;
using static DeliverySolutions.OutOfProcess.Specs.Request.DthRequestBuilder;

namespace DeliverySolutions.OutOfProcess.Specs
{
    [Binding]
    public class CheckEndpointsAreRespondingSteps
    {
        private const string HealthcheckUrl = "http://localhost:58459/v1/healthcheck";
        private const string DthUrl = "http://localhost:58459/v1/deliver-to-home/";
        private readonly Api _api;

        public CheckEndpointsAreRespondingSteps(Api api)
        {
            _api = api;
        }

        [When(@"I hit the healthcheck endpoint")]
        public void WhenIHitTheHealthcheckEndpoint()
        {
            _api.Get(HealthcheckUrl).Wait();
        }

        [Then(@"I should get a healthcheck response")]
        public void ThenIShouldGetAHealthcheckResponse()
        {
            _api.ResponseShouldGiveHttpOk();
            _api.ResponseShouldConformToHealthcheckContract().Wait();
        }

        [When(@"I request deliver-to-home solutions")]
        public void WhenIRequestDeliver_To_HomeSolutions()
        {
            _api.Post(DthUrl, ADthRequest.Build()).Wait();
        }

        [Then(@"I should receive delivery-to-home solutions")]
        public void ThenIShouldReceiveDelivery_To_HomeSolutions()
        {
            _api.ResponseShouldGiveHttpOk();
            _api.ResponseShouldConformToDthContract().Wait();
        }

    }
}
