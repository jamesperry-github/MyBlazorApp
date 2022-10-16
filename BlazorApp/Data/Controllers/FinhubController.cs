using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using BlazorApp.Data.Services;
using BlazorApp.Data.Models;
using BlazorApp.Data.Models.finhub.Company;
using BlazorApp.Data.Models.finhub.Market;

namespace BlazorApp.Data.Controllers
{
    // ** API DOCUMENTATION: https://finnhub.io/docs/api/introduction
    //X-Finnhub-Secret: cc6k1gqad3i394r9cps0
    //X-Finnhub-Secret: sandbox_cc6k1gqad3i394r9cpsg
    public class FinhubController
    {
        private string baseUrl = "https://finnhub.io/api/v1";
        // (*) Market-wide news
        // /news?category=general
        public async Task<List<MarketNews[]>> GetMarketNews()
        {
            List<MarketNews> list = new List<MarketNews>();
            List<MarketNews[]> pairedList = new List<MarketNews[]>();
            try
            {
                string url = $"{baseUrl}/news?category=general&token=cc6k1gqad3i394r9cps0";
                var jsondata = await new FinhubService().requestJson(url);
                dynamic parsedResp = JArray.Parse(jsondata);
                //// each news story
                foreach (var item in parsedResp)
                {
                    list.Add(new MarketNews
                    {
                        category = item["category"],
                        dateTime = item["dateTime"],
                        headline = item["headline"],
                        id = item["id"],
                        image = item["image"],
                        related = item["related"],
                        source = item["source"],
                        summary = item["summary"],
                        url = item["url"],
                    });
                }

                if(list.Count > 0)
                {
                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        if (list.Count % 2 == 0)
                        {
                            //is even... add empty for even pairs
                            list.Add(new MarketNews());
                        }
                        if (i != null)
                        {
                            if(i % 2 == 0)
                            {
                                MarketNews[]? pair = new MarketNews[] { list[i], list[i + 1] };
                                pairedList.Add(pair);
                            }
                        }
                    }
                }
                //Console.WriteLine("");
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(pairedList);
        }
        // (*) Upcoming IPOs
        // /calendar/ipo?from=2020-01-01&to=2020-04-30&token=cc6k1gqad3i394r9cps0
        public async void test()
        {
            List<UpcomingIPO> list = new List<UpcomingIPO>();
            try
            {
                string url = $"{baseUrl}/calendar/ipo?from=2020-01-01&to=2020-04-30&token=cc6k1gqad3i394r9cps0";
                var jsondata = await new FinhubService().requestJson(url);
                dynamic parsedResp = JObject.Parse(jsondata)["ipoCalendar"].ToList();
                //// each IPO
                foreach (var item in parsedResp)
                {
                    list.Add(new UpcomingIPO
                    {
                        date = item["date"],
                        exchange = item["exchange"],
                        name = item["name"],
                        numberOfShares = item["numberOfShares"],
                        price = item["price"],
                        status = item["status"],
                        symbol = item["symbol"],
                        totalSharesValue = item["totalSharesValue"],
                    });
                }

                Console.WriteLine("");
            }
            catch (Exception)
            {
                throw;
            }
            //return await Task.FromResult(info);
        }
        // (*) Lookup tickers in US
        // /stock/symbol?exchange=US
        public async Task<List<Stock>> GetStockList()
        {
            List<Stock> list = new List<Stock>();
            try
            {
                string url = $"{baseUrl}/stock/symbol?exchange=US&token=cc6k1gqad3i394r9cps0";
                var jsondata = await new FinhubService().requestJson(url);
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
        // (*) Company data from ticker
        // /stock/profile2?symbol=AAPL&token=cc6k1gqad3i394r9cps0
        public async Task<CompanyInfo> GetCompanyInfo(string tickerSymbol)
        {
            CompanyInfo info = new CompanyInfo();
            try
            {
                string url = $"{baseUrl}/stock/profile2?symbol={tickerSymbol}&token=cc6k1gqad3i394r9cps0";
                var jsondata = await new FinhubService().requestJson(url);
                info = JObject.Parse(jsondata).ToObject<CompanyInfo>();
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(info);
        }
        // (*) Company news from ticker and time interval
        // /company-news?symbol=AAPL&from=2021-09-01&to=2021-09-09&token=cc6k1gqad3i394r9cps0
        public async Task<List<CompanyNews>> GetCompanyNews(string tickerSymbol)
        {
            List<CompanyNews> list = new List<CompanyNews>();
            try
            {
                string url = $"{baseUrl}/company-news?symbol={tickerSymbol}&from=2021-09-01&to=2021-09-09&token=cc6k1gqad3i394r9cps0";
                var jsondata = await new FinhubService().requestJson(url);
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
        // (*) Company financials on ticker
        // /stock/metric?symbol=AAPL&metric=all&token=cc6k1gqad3i394r9cps0
        public async Task<CompanyFinancials> GetCompanyFinancials(string tickerSymbol)
        {
            CompanyFinancials info = new CompanyFinancials();
            try
            {
                string url = $"{baseUrl}/stock/metric?symbol={tickerSymbol}&metric=all&token=cc6k1gqad3i394r9cps0";
                var jsondata = await new FinhubService().requestJson(url);
                info = JObject.Parse(jsondata)["metric"].ToObject<CompanyFinancials>();
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(info);
        }
        // (*) Ticker quotes
        // /quote?symbol=AAPL
        public async Task<CompanyQuote> GetCompanyQuote(string tickerSymbol)
        {
            CompanyQuote info = new CompanyQuote();
            try
            {
                string url = $"{baseUrl}/quote?symbol={tickerSymbol}&token=cc6k1gqad3i394r9cps0";
                var jsondata = await new FinhubService().requestJson(url);
                info = JObject.Parse(jsondata).ToObject<CompanyQuote>();
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(info);
        }
        // (*) Ticker candles
        // /stock/candle?symbol=GME&resolution=D&from=1641089347&to=1665623347&token=cc6k1gqad3i394r9cps0
        public async Task<CompanyCandles?> GetCompanyCandles(string tickerSymbol, long fromDate, long toDate)
        {
            CompanyCandles info = new CompanyCandles();
            try
            {
                string url = $"{baseUrl}/stock/candle?symbol={tickerSymbol}&resolution=D&from={fromDate}&to={toDate}&token=cc6k1gqad3i394r9cps0";
                var jsondata = await new FinhubService().requestJson(url);
                info = JObject.Parse(jsondata).ToObject<CompanyCandles>();
                Console.WriteLine("");
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(info);
        }
        // (*) Company insider transaction on ticker and limit of 100
        // /stock/insider-transactions?symbol=AAPL&limit=100&token=cc6k1gqad3i394r9cps0
        public async void test3()
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                //string url = $"{baseUrl}/quote?symbol={tickerSymbol}";
                //var jsondata = await new FinhubService().requestJson(url);
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
        // (*) Company insider sentiment on ticket and time interval
        // /stock/insider-sentiment?symbol=TSLA&from=2015-01-01&to=2022-03-01&token=cc6k1gqad3i394r9cps0
        public async void test4()
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                //string url = $"{baseUrl}/quote?symbol={tickerSymbol}";
                //var jsondata = await new FinhubService().requestJson(url);
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
        // (*) Upcoming IPOs on time interval
        // /calendar/ipo?from=2020-01-01&to=2020-04-30&token=cc6k1gqad3i394r9cps0
        public async void test5()
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                //string url = $"{baseUrl}/quote?symbol={tickerSymbol}";
                //var jsondata = await new FinhubService().requestJson(url);
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
        // (*) Ticker technical indicators
        // /indicator?symbol=symbol=AAPL&resolution=D&from=1583098857&to=1584308457&indicator=sma&timeperiod=3&token=cc6k1gqad3i394r9cps0
        public async void test8()
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                //string url = $"{baseUrl}/quote?symbol={tickerSymbol}";
                //var jsondata = await new FinhubService().requestJson(url);
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
        // (*) Ticker social sentiment
        // /stock/social-sentiment?symbol=GME&token=cc6k1gqad3i394r9cps0
        public async void test9()
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                //string url = $"{baseUrl}/quote?symbol={tickerSymbol}";
                //var jsondata = await new FinhubService().requestJson(url);
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
        // (*) TIcker political lobbying
        // /stock/lobbying?symbol=AAPL&from=2021-01-01&to=2022-12-31&token=cc6k1gqad3i394r9cps0
        public async void test0()
        {
            //List<Stock> list = new List<Stock>();
            try
            {
                //string url = $"{baseUrl}/quote?symbol={tickerSymbol}";
                //var jsondata = await new FinhubService().requestJson(url);
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
