using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using BlazorApp.Data.Models;

namespace BlazorApp.Data.Services
{
    public class FinhubService
    {
        //private string baseUrl = "https://finnhub.io/api/v1";
        public async Task<string> requestFinhubJson(string url)
        {
            string jsondata = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Finnhub-Secret", "cc6k1gqad3i394r9cps0");
                // TODO: store objects in memory to avoid re-calls
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    jsondata = await response.Content.ReadAsStringAsync();
                }
            }
            return await Task.FromResult(jsondata);
        }
    }
}
