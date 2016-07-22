using TechTalk.SpecFlow;

namespace DeliverySolutions.OutOfProcess.Specs
{
    [Binding]
    public class CheckEndpointsAreRespondingSteps
    {
        private string _healthcheckUrl = "http://localhost:58459/v1/healthcheck";
        private readonly Api _api;

        public CheckEndpointsAreRespondingSteps(Api api)
        {
            _api = api;
        }

        [When(@"I hit the healthcheck endpoint")]
        public void WhenIHitTheHealthcheckEndpoint()
        {
            _api.Get(_healthcheckUrl).Wait();
        }

        [Then(@"I should get a healthcheck response")]
        public void ThenIShouldGetAHealthcheckResponse()
        {
            _api.HealthcheckResponseShouldBeOk().Wait();
        }
    }
}
