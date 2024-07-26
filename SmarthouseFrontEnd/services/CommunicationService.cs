using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace smarthouse.Services
{

    public class CommunicationService
    {
        private static readonly HttpClient client = new HttpClient();
        public CommunicationService (IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public async Task SendHttpGet(string IPAddress, string route, string requestBody)
        {
             try
            {
                // Create the request message
                var request = new HttpRequestMessage(HttpMethod.Get, $"{IPAddress}/{route}");

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
