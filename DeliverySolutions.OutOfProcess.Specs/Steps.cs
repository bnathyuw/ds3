using System;
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
        private string _body;

        public CheckEndpointsAreRespondingSteps()
        {
            _httpClient = new HttpClient();
        }

        [When(@"I hit the healthcheck endpoint")]
        public void WhenIHitTheHealthcheckEndpoint()
        {
            Get(_healthcheckUrl).Wait();
        }

        private async Task Get(string url)
        {
            Console.WriteLine($@">>>>>
GET {url} HTTP/1.1
{_httpClient.DefaultRequestHeaders}
>>>>>");
            _response = await _httpClient.GetAsync(url);
            _body = await _response.Content.ReadAsStringAsync();
            Console.WriteLine($@"<<<<<
HTTP {(int)_response.StatusCode} {_response.StatusCode}
{_response.Headers}
{_body}
<<<<<");
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
