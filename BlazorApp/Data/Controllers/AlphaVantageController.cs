using Newtonsoft.Json.Linq;
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
        // (*) DAILY TIME SERIES
        // /query?function=TIME_SERIES_DAILY&symbol=IBM&outputsize=full&apikey=demo
        public async Task<List<TimeSeries>> GetTimeSeries(string tickerSymbol, string duration)
        {
            if (_tsm.GetRecordList(duration).Count < 1 || tickerSymbol != _tsm.GetTicker())
            {
                try
                {
                    //string url = $"{baseUrl}/query?function=TIME_SERIES_DAILY&symbol={ticketSymbol}&outputsize=full&apikey={api_key}";
                    // TODO: GET ALL THE DATA AND PARSE DATE INTERVALS ******************************* add output size full
                    string url = $"{baseUrl}/query?function=TIME_SERIES_INTRADAY&symbol={tickerSymbol}&interval=5min&outputsize=full&apikey={api_key}";
                    var jsondata = await new AlphaVantageService().requestJson(url);
                    //MetaData metaData = JObject.Parse(jsondata)["Meta Data"].ToObject<MetaData>();
                    dynamic timeSeries = JObject.Parse(jsondata)["Time Series (5min)"].Reverse();
                    // TODO: move to serivce file *******************************
                    if (tickerSymbol != _tsm.GetTicker())
                    {
                        //_tsm.ClearTicker();
                        _tsm.storeTicker(tickerSymbol);
                    }
                    foreach (var item in timeSeries)
                    {
                        _tsm.CreateRecord(new TimeSeries
                        {
                            date = DateTime.Parse(item.Name),
                            open = item.Value["1. open"],
                            high = item.Value["2. high"],
                            low = item.Value["3. low"],
                            close = item.Value["4. close"],
                            volume = item.Value["5. volume"],
                        }, duration, tickerSymbol);
                    }
                    _tsm.CreateStorage(duration, _tsm.GetRecordList(duration));
                    Console.WriteLine("");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return await Task.FromResult(_tsm.GetRecordList(duration));
        }
        // (*) DOWNLOAD TIME SERIES
        // /query?function=TIME_SERIES_DAILY&symbol=IBM&apikey=demo&datatype=csv
    }
}