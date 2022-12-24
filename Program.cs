using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;



namespace apiClient
{
    public class Model
    {
        public List<Candidate> items { get; set; }
    }
    public class Candidate
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string type { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string url    = "http://127.0.0.1:8000/api/users";
            string urlPar = "";
            List<Candidate> model1 = null;

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

                model1 = JsonConvert.DeserializeObject<List<Candidate>>(dataObject);
                foreach (var d in model1)
                {
                    Console.WriteLine(d.name);
                }
                Console.WriteLine(dataObject);
            }
        }
    }
}
