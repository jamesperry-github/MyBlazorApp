using BlazorApp.Data.Models.alphaVantage.Company;

namespace BlazorApp.Data.Services;
public class TimeSeriesManager
{
    // static to prevent Dictionary object from being created every request ... store each stock
    private static readonly Dictionary<string, string> ticker = new();
    private static readonly Dictionary<string, TimeSeries> _dayTimeSeries = new();
    private static readonly Dictionary<string, TimeSeries> _weekTimeSeries = new();
    private static readonly Dictionary<string, TimeSeries> _monthTimeSeries = new();
    private static readonly Dictionary<string, TimeSeries> _yearTimeSeries = new();
    // main storage
    private static readonly Dictionary<string, List<TimeSeries>> _timeSeries = new();

    public string CreateRecord(TimeSeries item, string duration, string tickerSymbol)
    {
        switch (duration)
        {
            case "Day":
                _dayTimeSeries.Add($"{item.date}-{duration}-{tickerSymbol}", item);
                return duration;
            case "Week":
                _weekTimeSeries.Add($"{item.date}-{duration}-{tickerSymbol}", item);
                return duration;
            case "Month":
                _monthTimeSeries.Add($"{item.date}-{duration}-{tickerSymbol}", item);
                return duration;
            case "Year":
                _yearTimeSeries.Add($"{item.date}-{duration}-{tickerSymbol}", item);
                return duration;
            default:
                Console.WriteLine();
                return duration;
        }
    }
    public void CreateStorage(string duration, List<TimeSeries> list)
    {
        _timeSeries.Add(duration, list);
    }
    public List<TimeSeries> GetRecordList(string duration)
    {
        List<TimeSeries> list = new();
        switch (duration)
        {
            case "Day":
                return _dayTimeSeries.Values.ToList();
            case "Week":
                return _weekTimeSeries.Values.ToList();
            case "Month":
                return _monthTimeSeries.Values.ToList();
            case "Year":
                return _yearTimeSeries.Values.ToList();
            default:
                return list;
        }
    }
    public void storeTicker(string symbol)
    {
        // clear previous ticker
        ticker.Clear();
        // clear previous time series data
        _dayTimeSeries.Clear();
        _weekTimeSeries.Clear();
        _monthTimeSeries.Clear();
        _yearTimeSeries.Clear();
        _timeSeries.Clear();
        // add ticker
        ticker.Add(symbol, symbol);
    }
    public string GetTicker()
    {
        if(ticker.Values.ToList().Count > 0)
        {
            return ticker.First().Key;
        }
        // return random generic value
        return "%%%%%%%**%%%%%%%%";
    }
}