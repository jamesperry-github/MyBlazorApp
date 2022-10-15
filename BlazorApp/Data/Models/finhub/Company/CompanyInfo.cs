namespace BlazorApp.Data.Models.finhub.Company
{
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

        public CompanyInfo()
        {

        }
    }
}
