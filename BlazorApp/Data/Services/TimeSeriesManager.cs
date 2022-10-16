using BlazorApp.Data.Models.alphaVantage.Company;

namespace BlazorApp.Data.Services;
public class TimeSeriesManager
{
    // storing in memory instead of DB for this scenario
    // static to prevent Dictionary object from being created every request
    private static readonly Dictionary<string, TimeSeries> _timeSeries = new();
    private static readonly Dictionary<string, Dictionary<string, TimeSeries>> _series = new();
    public void CreateRecord(TimeSeries item)
    {
        _timeSeries.Add(item.date.ToString(), item);
    }
    public List<TimeSeries> GetRecordList()
    {
        return _timeSeries.Values.ToList();
    }
    public void storeTicker(string symbol)
    {
        _timeSeries.Add(symbol, new TimeSeries());
    }
    public string GetTicker()
    {
        return _timeSeries.Last().Key;
    }
}