using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DeliverySolutions.OutOfProcess.Specs
{
    public class Api
    {
        private readonly HttpClient _httpClient;
        private HttpResponseMessage _response;
        private string _body;

        public Api()
        {
            _httpClient = new HttpClient();
        }

        public async Task Get(string url)
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

        public async Task HealthcheckResponseShouldBeOk()
        {
            Assert.That(_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}