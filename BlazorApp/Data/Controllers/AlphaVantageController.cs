using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using BlazorApp.Data.Services;
using BlazorApp.Data.Models;

namespace BlazorApp.Data.Controllers
{
    // ** API DOCUMENTATION: https://www.alphavantage.co/documentation/
    //OF2K61IX5M3VB914
    public class AlphaVantageController
    {
        private string baseUrl = "https://www.alphavantage.co";
        private string api_key = "OF2K61IX5M3VB914";
        // (*) DAILY TIME SERIES
        // /query?function=TIME_SERIES_DAILY&symbol=IBM&outputsize=full&apikey=demo
        public async void test0(string ticketSymbol)
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                string url = $"{baseUrl}/query?function=TIME_SERIES_DAILY&symbol={ticketSymbol}&outputsize=full&apikey={api_key}";
                //var jsondata = await new FinhubService().requestFinhubJson(url);
                //dynamic parsedResp = JArray.Parse(jsondata);
                //info = JObject.Parse(jsondata).ToObject<CompanyInfo>();
                string jsondata = "";
                try
                {
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
                }
                catch (Exception)
                {
                    throw;
                }

                Console.WriteLine("");
            }
            catch (Exception)
            {
                throw;
            }
            //return await Task.FromResult(list);
        }
    }
}
