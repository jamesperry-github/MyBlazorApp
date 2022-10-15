namespace BlazorApp.Data.Models.finhub.Company
{
    public class CompanyCandles
    {
        //    "c": [38.21],
        public List<decimal?> c { get; set; }
        //    "h": [39.845],
        public List<decimal?> h { get; set; }
        //    "l": [37.3025],
        public List<decimal?> l { get; set; }
        //    "o": [37.3075],
        public List<decimal?> o { get; set; }
        //    "s": "ok",
        public string s { get; set; }
        //    "t": [1641168000],
        public List<long?> t { get; set; }
        //    "v": [5668004]
        public List<long?> v { get; set; }

        public CompanyCandles()
        {

        }
    }
}
//c
//List of close prices for returned candles.

//h
//List of high prices for returned candles.

//l
//List of low prices for returned candles.

//o
//List of open prices for returned candles.

//s
//Status of the response. This field can either be ok or no_data.

//t
//List of timestamp for returned candles.

//v
//List of volume data for returned candles.
