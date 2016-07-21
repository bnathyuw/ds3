using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DeliverySolutions.OutOfProcess.Specs
{
    [Binding]
    public class CheckEndpointsAreRespondingSteps
    {
        private readonly HttpClient _httpClient;
        private string _healthcheckUrl = "http://localhost:58459/v1/healthcheck";
        private HttpResponseMessage _response;

        public CheckEndpointsAreRespondingSteps()
        {
            _httpClient = new HttpClient();
        }

        [When(@"I hit the healthcheck endpoint")]
        public void WhenIHitTheHealthcheckEndpoint()
        {
            GetHealthcheck().Wait();
        }

        private async Task GetHealthcheck()
        {
            _response = await _httpClient.GetAsync(_healthcheckUrl);
        }

        [Then(@"I should get a healthcheck response")]
        public void ThenIShouldGetAHealthcheckResponse()
        {
            HealthcheckResponseShouldBeOk().Wait();
        }

        private async Task HealthcheckResponseShouldBeOk()
        {
            Assert.That(_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
