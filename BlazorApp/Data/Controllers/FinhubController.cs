using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using BlazorApp.Data.Services;
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
                string url = $"{baseUrl}/stock/symbol?exchange=US&token=cc6k1gqad3i394r9cps0";
                var jsondata = await new FinhubService().requestFinhubJson(url);
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
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(list);
        }
        // (2) Company data from ticker
        // /stock/profile2?symbol=AAPL&token=cc6k1gqad3i394r9cps0
        public async Task<CompanyInfo> GetCompanyInfo(string tickerSymbol)
        {
            CompanyInfo info = new CompanyInfo();
            try
            {
                string url = $"{baseUrl}/stock/profile2?symbol={tickerSymbol}&token=cc6k1gqad3i394r9cps0";
                var jsondata = await new FinhubService().requestFinhubJson(url);
                info = JObject.Parse(jsondata).ToObject<CompanyInfo>();
                Console.WriteLine("");
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(info);
        }
        // (3) Company news from ticker and time interval
        // /company-news?symbol=AAPL&from=2021-09-01&to=2021-09-09&token=cc6k1gqad3i394r9cps0
        public async Task<List<CompanyNews>> GetCompanyNews(string tickerSymbol)
        {
            List<CompanyNews> list = new List<CompanyNews>();
            try
            {
                string url = $"{baseUrl}/company-news?symbol={tickerSymbol}&from=2021-09-01&to=2021-09-09&token=cc6k1gqad3i394r9cps0";
                var jsondata = await new FinhubService().requestFinhubJson(url);
                dynamic parsedResp = JArray.Parse(jsondata);
                //// each news article
                foreach (var item in parsedResp)
                {
                    list.Add(new CompanyNews
                    {
                        category = item["category"],
                        datetime = item["datetime"],
                        headline = item["headline"],
                        id = item["id"],
                        image = item["image"],
                        related = item["related"],
                        source = item["source"],
                        summary = item["summary"],
                        url = item["url"]
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(list);
        }
        // (4) Company financials on ticker
        // /stock/metric?symbol=AAPL&metric=all&token=cc6k1gqad3i394r9cps0
        public async Task<CompanyFinancials> GetCompanyFinancials(string tickerSymbol)
        {
            CompanyFinancials info = new CompanyFinancials();
            try
            {
                string url = $"{baseUrl}/stock/metric?symbol={tickerSymbol}&metric=all&token=cc6k1gqad3i394r9cps0";
                var jsondata = await new FinhubService().requestFinhubJson(url);
                info = JObject.Parse(jsondata)["metric"].ToObject<CompanyFinancials>();
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(info);
        }
        // (5) Ticker quotes
        // /quote?symbol=AAPL
        public async void test(string tickerSymbol)
        {
            CompanyQuote info = new CompanyQuote();
            try
            {
                string url = $"{baseUrl}/quote?symbol={tickerSymbol}&token=cc6k1gqad3i394r9cps0";
                var jsondata = await new FinhubService().requestFinhubJson(url);
                info = JObject.Parse(jsondata).ToObject<CompanyQuote>();
                Console.WriteLine("");
            }
            catch (Exception)
            {
                throw;
            }
            //return await Task.FromResult(info);
        }
        // (6) Company insider transaction on ticker and limit of 100
        // /stock/insider-transactions?symbol=AAPL&limit=100&token=cc6k1gqad3i394r9cps0
        public async void test3()
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                //string url = $"{baseUrl}/quote?symbol={tickerSymbol}";
                //var jsondata = await new FinhubService().requestFinhubJson(url);
                //dynamic parsedResp = JArray.Parse(jsondata);
                //info = JObject.Parse(jsondata).ToObject<CompanyInfo>();
                Console.WriteLine("");
            }
            catch (Exception)
            {
                throw;
            }
            //return await Task.FromResult(list);
        }
        // (7) Company insider sentiment on ticket and time interval
        // /stock/insider-sentiment?symbol=TSLA&from=2015-01-01&to=2022-03-01&token=cc6k1gqad3i394r9cps0
        public async void test4()
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                //string url = $"{baseUrl}/quote?symbol={tickerSymbol}";
                //var jsondata = await new FinhubService().requestFinhubJson(url);
                //dynamic parsedResp = JArray.Parse(jsondata);
                //info = JObject.Parse(jsondata).ToObject<CompanyInfo>();
                Console.WriteLine("");
            }
            catch (Exception)
            {
                throw;
            }
            //return await Task.FromResult(list);
        }
        // (8) Upcoming IPOs on time interval
        // /calendar/ipo?from=2020-01-01&to=2020-04-30&token=cc6k1gqad3i394r9cps0
        public async void test5()
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                //string url = $"{baseUrl}/quote?symbol={tickerSymbol}";
                //var jsondata = await new FinhubService().requestFinhubJson(url);
                //dynamic parsedResp = JArray.Parse(jsondata);
                //info = JObject.Parse(jsondata).ToObject<CompanyInfo>();
                Console.WriteLine("");
            }
            catch (Exception)
            {
                throw;
            }
            //return await Task.FromResult(list);
        }
        // (9) Ticker candles
        // /stock/candle?symbol=AAPL&resolution=1&from=1631022248&to=1631627048&token=cc6k1gqad3i394r9cps0
        public async void test7()
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                //string url = $"{baseUrl}/quote?symbol={tickerSymbol}";
                //var jsondata = await new FinhubService().requestFinhubJson(url);
                //dynamic parsedResp = JArray.Parse(jsondata);
                //info = JObject.Parse(jsondata).ToObject<CompanyInfo>();
                Console.WriteLine("");
            }
            catch (Exception)
            {
                throw;
            }
            //return await Task.FromResult(list);
        }
        // (10) Ticker technical indicators
        // /indicator?symbol=symbol=AAPL&resolution=D&from=1583098857&to=1584308457&indicator=sma&timeperiod=3&token=cc6k1gqad3i394r9cps0
        public async void test8()
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                //string url = $"{baseUrl}/quote?symbol={tickerSymbol}";
                //var jsondata = await new FinhubService().requestFinhubJson(url);
                //dynamic parsedResp = JArray.Parse(jsondata);
                //info = JObject.Parse(jsondata).ToObject<CompanyInfo>();
                Console.WriteLine("");
            }
            catch (Exception)
            {
                throw;
            }
            //return await Task.FromResult(list);
        }
        // (11) Ticker social sentiment
        // /stock/social-sentiment?symbol=GME&token=cc6k1gqad3i394r9cps0
        public async void test9()
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                //string url = $"{baseUrl}/quote?symbol={tickerSymbol}";
                //var jsondata = await new FinhubService().requestFinhubJson(url);
                //dynamic parsedResp = JArray.Parse(jsondata);
                //info = JObject.Parse(jsondata).ToObject<CompanyInfo>();
                Console.WriteLine("");
            }
            catch (Exception)
            {
                throw;
            }
            //return await Task.FromResult(list);
        }
        // (12) TIcker political lobbying
        // /stock/lobbying?symbol=AAPL&from=2021-01-01&to=2022-12-31&token=cc6k1gqad3i394r9cps0
        public async void test0()
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                //string url = $"{baseUrl}/quote?symbol={tickerSymbol}";
                //var jsondata = await new FinhubService().requestFinhubJson(url);
                //dynamic parsedResp = JArray.Parse(jsondata);
                //info = JObject.Parse(jsondata).ToObject<CompanyInfo>();
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
