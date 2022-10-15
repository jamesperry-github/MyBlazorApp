namespace BlazorApp.Data.Models.finhub.Company
{
    public class CompanyNews
    {
        public int NewsId { get; set; }
        public string category { get; set; }
        public string datetime { get; set; }
        public string headline { get; set; }
        public string id { get; set; }
        public string image { get; set; }
        public string related { get; set; }
        public string source { get; set; }
        public string summary { get; set; }
        public string url { get; set; }

        public CompanyNews()
        {

        }
    }
}
