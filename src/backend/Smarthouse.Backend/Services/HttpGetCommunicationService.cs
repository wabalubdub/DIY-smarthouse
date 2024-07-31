using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Smarthouse.Backend.Services
{

    public class HttpGetCommunicationService: ICommunicationService
    {
        private static readonly HttpClient client = new HttpClient();
        public HttpGetCommunicationService ()
        {

        }

        private string route{get;set;}
        private string requestBody{get;set;}

        private string port{get;set;}

        private string IPAddress {get;set;}

        public void SetRoute(string route) => this.route = route;

        public void SetRequestBody(string requestBody) => this.requestBody = requestBody;

        public void SetPort(string port) => this.port = port;

        public void SetIPAddress(string ipAddress) => this.IPAddress = ipAddress;
        public async Task Send()
        {
             try
            {
                Console.WriteLine($"http://{IPAddress}:{port}/{route}");
                // Create the request message
                var request = new HttpRequestMessage(HttpMethod.Get, new Uri($"http://{IPAddress}:{port}/{route}"));

                // Add the body content
                if (!string.IsNullOrEmpty(requestBody))
                {
                    request.Content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");
                }

                // Send the request
                HttpResponseMessage response = await client.SendAsync(request);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read the response content
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {responseBody}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
            

        }

    }
}
