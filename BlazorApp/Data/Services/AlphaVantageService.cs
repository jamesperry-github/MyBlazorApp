using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using BlazorApp.Data.Models;

namespace BlazorApp.Data.Services
{
    public class AlphaVantageService
    {
        //private string baseUrl = "https://finnhub.io/api/v1";
        public async Task<string> requestJson(string url)
        {
            string jsondata = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        jsondata = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(jsondata);
        }
    }
}
