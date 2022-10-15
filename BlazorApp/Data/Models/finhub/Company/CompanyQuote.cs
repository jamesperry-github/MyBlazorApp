using Newtonsoft.Json;

namespace BlazorApp.Data.Models.finhub.Company
{
    public class CompanyQuote
    {
        //"c": 0,
        [JsonProperty("c")]
        public decimal? CurrentPrice { get; set; }
        //"d": null,
        [JsonProperty("d")]
        public decimal? PriceChange { get; set; }
        //"dp": null,
        [JsonProperty("dp")]
        public decimal? PercentChange { get; set; }
        //"h": 0,
        [JsonProperty("h")]
        public decimal? HighPriceOfTheDay { get; set; }
        //"l": 0,
        [JsonProperty("l")]
        public decimal? LowPriceOfTheDay { get; set; }
        //"o": 0,
        [JsonProperty("o")]
        public decimal? OpenPriceOfTheDay { get; set; }
        //"pc": 0,
        [JsonProperty("pc")]
        public decimal? PreviousClosePrice { get; set; }
        //"t": 0
        [JsonProperty("t")]
        public decimal? t { get; set; }
    }
}
//c - Current price
//d - Change
//dp - Percent change
//h - High price of the day
//l - Low price of the day
//o - Open price of the day
//pc - Previous close price