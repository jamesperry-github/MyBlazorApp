using Newtonsoft.Json.Linq;using System.Linq;
using System.Net.Http.Headers;
using BlazorApp.Data.Services;
using BlazorApp.Data.Models.alphaVantage.Company;

namespace BlazorApp.Data.Controllers
{
    // ** API DOCUMENTATION: https://www.alphavantage.co/documentation/
    //OF2K61IX5M3VB914
    public class AlphaVantageController
    {
        private string baseUrl = "https://www.alphavantage.co";
        private string api_key = "OF2K61IX5M3VB914";
        private readonly TimeSeriesManager _tsm;
        public AlphaVantageController(TimeSeriesManager tsm)
        {
            // Dependancy Injection
            _tsm = tsm;
        }
        // (*) DAILY TIME SERIES DATA
        // /query?function=TIME_SERIES_DAILY&symbol=IBM&outputsize=full&apikey=demo
        public async Task<List<TimeSeries>> GetDailyTimeSeries(string tickerSymbol, string duration)
        {
            List<TimeSeries> list = new();
            if (_tsm.getRecordList(duration, tickerSymbol).Count < 1 || !_tsm.getTicker(duration, tickerSymbol))
            {
                try
                {
                    //string url = $"{baseUrl}/query?function=TIME_SERIES_INTRADAY&symbol={tickerSymbol}&interval=1min&apikey={api_key}";
                    string url = $"https://financialmodelingprep.com/api/v3/historical-chart/1min/{tickerSymbol.ToUpper()}?apikey=ee56e0140f9ef197ab6284820aabf794";
                    var jsondata = await new TimeSeriesFinanceService().requestJson(url);
                    //dynamic timeSeries = JObject.Parse(jsondata)["Time Series (1min)"].Reverse();
                    dynamic timeSeries = JArray.Parse(jsondata).Reverse();
                    //// each stock ticket
                    _tsm.addStockToStorage(duration, tickerSymbol, timeSeries);
                }
                catch (Exception)
                {
                    return new List<TimeSeries>();
                }
            }
            return await Task.FromResult(_tsm.getRecordList(duration, tickerSymbol));
        }
        // (*) ALL TIME SERIES DATA
        // /query?function=TIME_SERIES_DAILY&symbol=IBM&outputsize=full&apikey=demo
        public async Task<List<TimeSeries>> GetTimeSeries(string tickerSymbol, string duration)
        {
            List<TimeSeries> test = new();
            if (_tsm.getRecordList(duration, tickerSymbol).Count < 1 || !_tsm.getTicker(duration, tickerSymbol))
            {
                try
                {
                    string url = $"{baseUrl}/query?function=TIME_SERIES_DAILY&symbol={tickerSymbol}&outputsize=full&apikey={api_key}";
                    var jsondata = await new TimeSeriesFinanceService().requestJson(url);
                    dynamic timeSeries = JObject.Parse(jsondata)["Time Series (Daily)"].Reverse().ToList();

                    _tsm.addStockToStorage(duration, tickerSymbol, timeSeries);
                    //Console.WriteLine("");
                }
                catch (Exception)
                {
                    return new List<TimeSeries>();
                }
            }
            // ree
            var testlist = _tsm.getRecordList(duration, tickerSymbol);
            if (duration == "Week")
            {
                var nowIdx = testlist.Count - 1;
                var weekIdx = nowIdx - 14;
                for (int i = 0; i < testlist.Count; i++)
                {
                    if (i <= nowIdx && i >= weekIdx)
                    {
                        test.Add(testlist[i]);
                    }
                }
                testlist = test;
                return await Task.FromResult(testlist);
            }
            else if (duration == "Month") //// 168, 744, 8760
            {
                var nowIdx = testlist.Count - 1;
                var monthIdx = nowIdx - 30;
                for (int i = 0; i < testlist.Count; i++)
                {
                    if (i <= nowIdx && i >= monthIdx)
                    {
                        test.Add(testlist[i]);
                    }
                }
                testlist = test;
                return await Task.FromResult(testlist);
            }
            else if (duration == "Year")
            {
                var nowIdx = testlist.Count - 1;
                var monthIdx = nowIdx - 364;
                for (int i = 0; i < testlist.Count; i++)
                {
                    if (i <= nowIdx && i >= monthIdx)
                    {
                        test.Add(testlist[i]);
                    }
                }
                testlist = test;
                return await Task.FromResult(testlist);
            }
            else // all
            {
                //timeSeries;
                return await Task.FromResult(testlist);

            }
        }
        // (*) DOWNLOAD TIME SERIES
        // /query?function=TIME_SERIES_DAILY&symbol=IBM&apikey=demo&datatype=csv
    }
}