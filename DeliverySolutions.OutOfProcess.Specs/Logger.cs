using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliverySolutions.OutOfProcess.Specs
{
    public class Logger
    {
        public static async Task LogResponse(HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStringAsync();

            Console.WriteLine(
                $@"<<<<<
HTTP {(int) response.StatusCode} {response.StatusCode}
{response.Headers}
{body}
<<<<<");
        }

        public static void LogRequest(string url, HttpClient httpClient)
        {
            Console.WriteLine($@">>>>>
GET {url} HTTP/1.1
{httpClient.DefaultRequestHeaders}
>>>>>");
        }

        public static void LogRequest(string url, string body, HttpClient httpClient)
        {
            Console.WriteLine($@">>>>>
GET {url} HTTP/1.1
{httpClient.DefaultRequestHeaders}
{body}
>>>>>");
        }
    }
}