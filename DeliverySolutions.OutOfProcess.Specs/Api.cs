using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using DeliverySolutions.OutOfProcess.Specs.Response;
using NUnit.Framework;

namespace DeliverySolutions.OutOfProcess.Specs
{
    public class Api
    {
        private readonly HttpClient _httpClient;
        private HttpResponseMessage _response;

        public Api()
        {
            _httpClient = new HttpClient();
        }

        public async Task Get(string url)
        {
            Logger.LogRequest(url, _httpClient);

            _response = await _httpClient.GetAsync(url);

            await Logger.LogResponse(_response);
        }

        public void ResponseShouldGiveHttpOk()
        {
            Assert.That(_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        public async Task ResponseShouldConformToHealthcheckContract()
        {
            var body = await _response.Content.ReadAsStringAsync();
            var healthcheckResponse = Json.Decode(body);

            Assert.That(healthcheckResponse.ServiceVersion, Does.Match("\\d+\\.\\d+\\.\\d+\\.\\d+"));
            Assert.That(healthcheckResponse.Checks, Is.Not.Empty);
            foreach (var check in healthcheckResponse.Checks)
            {
                Assert.That(check.Name, Does.Match(".*"));
                Assert.That(check.IsSuccessful, Is.TypeOf<bool>());
            }
        }

        public async Task Post(string url, object content)
        {
            var body = Json.Encode(content);
            Logger.LogRequest(url, body, _httpClient);

            _response = await _httpClient.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));

            await Logger.LogResponse(_response);
        }

        public async Task ResponseShouldConformToDthContract()
        {
            var body = await _response.Content.ReadAsStringAsync();
            Json.Decode<DthResponse>(body);
        }
    }
}