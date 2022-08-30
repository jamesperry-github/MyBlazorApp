namespace BlazorApp.Data.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string DisplaySymbol { get; set; }
        public string Figi { get; set; }
        public string Isin { get; set; }
        public string Mic { get; set; }
        public string ShareClassFIGI { get; set; }
        public string Symbol { get; set; }
        public string Symbol2 { get; set; }
        public string Type { get; set; }

        public Stock()
        {

        }
    }

    public class CompanyInfo
    {
        public int CompanyId { get; set; }
        public string country { get; set; }
        public string currency { get; set; }
        public string exchange { get; set; }
        public string finnhubIndustry { get; set; }
        public string ipo { get; set; }
        public string logo { get; set; }
        public string marketCapitalization { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string shareOutstanding { get; set; }
        public string ticker { get; set; }
        public string weburl { get; set; }
    }
}
