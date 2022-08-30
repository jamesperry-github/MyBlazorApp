using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using BlazorApp.Data.Models;

namespace BlazorApp.Data.Controllers
{
    // ** API DOCUMENTATION: https://finnhub.io/docs/api/introduction **
    //X-Finnhub-Secret: cc6k1gqad3i394r9cps0
    //X-Finnhub-Secret: sandbox_cc6k1gqad3i394r9cpsg
    public class FinhubController
    {
        private string baseUrl = "https://finnhub.io/api/v1";
        // (1) Lookup tickers in US
        // /stock/symbol?exchange=US
        public async Task<List<Stock>> GetStockList()
        {
            List<Stock> list = new List<Stock>();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{baseUrl}/stock/symbol?exchange=US&token=cc6k1gqad3i394r9cps0";
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("X-Finnhub-Secret", "cc6k1gqad3i394r9cps0");
                    // create subreddit request
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsondata = await response.Content.ReadAsStringAsync();
                        dynamic parsedResp = JArray.Parse(jsondata);
                        //// each stock ticket
                        foreach (var item in parsedResp)
                        {
                            list.Add(new Stock
                            {
                                Currency = item["currency"],
                                Description = item["description"],
                                DisplaySymbol = item["displaySymbol"],
                                Figi = item["figi"],
                                Isin = item["isin"],
                                Mic = item["mic"],
                                ShareClassFIGI = item["shareClassFIGI"],
                                Symbol = item["symbol"],
                                Symbol2 = item["symbol2"],
                                Type = item["type"]
                            });
                        }
                        //Console.WriteLine("Success.");
                    } 
                    else
                    {
                        Console.WriteLine("Failed.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(list);
        }
        // (2) Company data from ticker
        // /stock/profile2?symbol=AAPL&token=cc6k1gqad3i394r9cps0
        public async void /*Task<List<Stock>>*/ Test(string tickerSymbol)
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{baseUrl}/stock/profile2?symbol={tickerSymbol}&token=cc6k1gqad3i394r9cps0";
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("X-Finnhub-Secret", "cc6k1gqad3i394r9cps0");
                    // create subreddit request
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsondata = await response.Content.ReadAsStringAsync();
                        dynamic parsedResp = JObject.Parse(jsondata);
                        //// each stock ticket
                        //foreach (var item in parsedResp)
                        //{
                        //    list.Add(new Stock
                        //    {
                        //        Currency = item["currency"],
                        //        Description = item["description"],
                        //        DisplaySymbol = item["displaySymbol"],
                        //        Figi = item["figi"],
                        //        Isin = item["isin"],
                        //        Mic = item["mic"],
                        //        ShareClassFIGI = item["shareClassFIGI"],
                        //        Symbol = item["symbol"],
                        //        Symbol2 = item["symbol2"],
                        //        Type = item["type"]
                        //    });
                        //}
                        Console.WriteLine("Success.");
                    }
                    else
                    {
                        Console.WriteLine("Failed.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            //return await Task.FromResult(list);
        }
        // (3) Company news from ticker and time interval
        // /company-news?symbol=AAPL&from=2021-09-01&to=2021-09-09&token=cc6k1gqad3i394r9cps0

        // (4) Company financials on ticker
        // /stock/metric?symbol=AAPL&metric=all&token=cc6k1gqad3i394r9cps0

        // (5) Company insider transaction on ticker and limit of 100
        // /stock/insider-transactions?symbol=AAPL&limit=100&token=cc6k1gqad3i394r9cps0

        // (6) Company insider sentiment on ticket and time interval
        // /stock/insider-sentiment?symbol=TSLA&from=2015-01-01&to=2022-03-01&token=cc6k1gqad3i394r9cps0

        // (7) Upcoming IPOs on time interval
        // /calendar/ipo?from=2020-01-01&to=2020-04-30&token=cc6k1gqad3i394r9cps0

        // (8) Ticker quotes
        // /quote?symbol=AAPL
        //c - Current price
        //d - Change
        //dp - Percent change
        //h - High price of the day
        //l - Low price of the day
        //o - Open price of the day
        //pc - Previous close price

        // (9) Ticker candles
        // /stock/candle?symbol=AAPL&resolution=1&from=1631022248&to=1631627048&token=cc6k1gqad3i394r9cps0

        // (10) Ticker technical indicators
        // /indicator?symbol=symbol=AAPL&resolution=D&from=1583098857&to=1584308457&indicator=sma&timeperiod=3&token=cc6k1gqad3i394r9cps0

        // (11) Ticker social sentiment
        // /stock/social-sentiment?symbol=GME&token=cc6k1gqad3i394r9cps0

        // (12) TIcker political lobbying
        // /stock/lobbying?symbol=AAPL&from=2021-01-01&to=2022-12-31&token=cc6k1gqad3i394r9cps0
    }
}
