using Newtonsoft.Json;

namespace BlazorApp.Data.Models.alphaVantage.Company
{
    // Daily Price Points in 5min Span
    public class TimeSeries
    {
        public DateTime date { get; set; }
        public decimal? open { get; set; }
        public decimal? high { get; set; }
        public decimal? low { get; set; }
        public decimal? close { get; set; }
        public decimal? volume { get; set; }
    }
    // Meta Data
    public class MetaData
    {
        [JsonProperty("1. Information")]
        public string Information { get; set; }

        [JsonProperty("2. Symbol")]
        public string Symbol { get; set; }

        [JsonProperty("3. Last Refreshed")]
        public string LastRefreshed { get; set; }

        [JsonProperty("4. Output Size")]
        public string OutputSize { get; set; }

        [JsonProperty("5. Time Zone")]
        public string TimeZone { get; set; }
    }
}
//
//{
//"1. Information": "Daily Prices (open, high, low, close) and Volumes",
//"2. Symbol": "GME",
//"3. Last Refreshed": "2022-10-14",
//"4. Output Size": "Full size",
//"5. Time Zone": "US/Eastern"
//}

//"1. open": "25.7700",
//"2. high": "26.3700",
//"3. low": "24.6300",
//"4. close": "24.6300",
//"5. volume": "2778436"

//"date" : "2022-10-19 16:00:00",
//"open" : 143.86000000,
//"low" : 143.82000000,
//"high" : 144.04000000,
//"close" : 143.92000000,
//"volume" : 553600