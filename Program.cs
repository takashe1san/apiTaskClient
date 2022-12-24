using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace apiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string url    = "http://127.0.0.1:8000/api/users";
            string urlPar = "";

            using var client = new HttpClient();

            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Get data resonse

            var response = client.GetAsync(urlPar).Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body

                var dataObject = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine(dataObject);
            }
        }
    }
}
