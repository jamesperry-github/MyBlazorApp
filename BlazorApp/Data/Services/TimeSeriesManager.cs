using BlazorApp.Data.Models.alphaVantage.Company;

namespace BlazorApp.Data.Services;
public class TimeSeriesManager
{
    // static to prevent Dictionary object from being created every request
    // main storage
    private static readonly Dictionary<string, List<TimeSeries>> _timeSeries = new();
    public void addStockToStorage(string duration, string symbol, dynamic items)
    {
        List<TimeSeries> list = new();
        foreach (var item in items)
        {
            if(duration == "Day")
            {
                list.Add(new TimeSeries
                {
                    date = item["date"],
                    open = item["open"],
                    low = item["low"],
                    high = item["high"],
                    close = item["close"],
                    volume = item["volume"]
                });
            } else
            {
                list.Add(new TimeSeries
                {
                    date = DateTime.Parse(item.Name),
                    open = item.Value["1. open"],
                    high = item.Value["2. high"],
                    low = item.Value["3. low"],
                    close = item.Value["4. close"],
                    volume = item.Value["5. volume"],
                });
            }
        }
        createStorage(duration, symbol, list);
    }
    public void createStorage(string duration, string tickerSymbol, List<TimeSeries> list)
    {
        var tester = duration == "Day" ? "Day" : "other";
        _timeSeries.Add($"{tickerSymbol}-{tester}", list);
    }
    public List<TimeSeries> getRecordList(string duration, string tickerSymbol)
    {
        List<TimeSeries> list = new();
        foreach (var kvp in _timeSeries)
        {
            if(findSymbol(kvp.Key, duration, tickerSymbol))
            {
                return kvp.Value;
            }
        }
        return list;
    }
    public bool getTicker(string duration, string symbol)
    {
        foreach (var kvp in _timeSeries)
        {
            if (findSymbol(kvp.Key, duration, symbol))
            {
                return true;
            }
        }
        return false;
    }
    private bool findSymbol(string stringValue, string duration, string symbol)
    {
        var tester = duration == "Day" ? "Day" : "other";
        if (stringValue.ToLower().Contains(tester.ToLower()) && stringValue.ToLower().Contains(symbol.ToLower()))
        {
            return true;
        }
        return false;
    }
}