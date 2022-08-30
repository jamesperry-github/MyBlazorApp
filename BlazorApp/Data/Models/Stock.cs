namespace BlazorApp.Data.Models
{
    public class Stock
    {
        //"currency": "USD",
        //"description": "SLM SOLUTIONS GROUP AG",
        //"displaySymbol": "SLGRF",
        //"figi": "BBG006VZNGL0",
        //"isin": null,
        //"mic": "OOTC",
        //"shareClassFIGI": "BBG0069GK794",
        //"symbol": "SLGRF",
        //"symbol2": "",
        //"type": "Common Stock"
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
}
