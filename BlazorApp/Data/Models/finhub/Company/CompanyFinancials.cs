using Newtonsoft.Json;

namespace BlazorApp.Data.Models.finhub.Company
{
    public class CompanyFinancials
    {
        //    "10DayAverageTradingVolume": 3.37355,
        [JsonProperty("10DayAverageTradingVolume")]
        public decimal? DayAverageTradingVolume10 { get; set; }
        //  "13WeekPriceReturnDaily": -21.11405,
        [JsonProperty("13WeekPriceReturnDaily")]
        public decimal? WeekPriceReturnDaily13 { get; set; }
        //  "26WeekPriceReturnDaily": -30.63821,
        [JsonProperty("26WeekPriceReturnDaily")]
        public decimal? WeekPriceReturnDaily26 { get; set; }
        //  "3MonthAverageTradingVolume": 145.06317,
        [JsonProperty("3MonthAverageTradingVolume")]
        public decimal? MonthAverageTradingVolume3 { get; set; }
        //  "52WeekHigh": 63.9225,
        [JsonProperty("52WeekHigh")]
        public decimal? WeekHigh52 { get; set; }
        //  "52WeekHighDate": "2021-11-03",
        [JsonProperty("52WeekHighDate")]
        public DateTime WeekHighDate52 { get; set; }
        //  "52WeekLow": 19.3975,
        [JsonProperty("52WeekLow")]
        public decimal? WeekLow52 { get; set; }
        //  "52WeekLowDate": "2022-03-14",
        [JsonProperty("52WeekLowDate")]
        public DateTime WeekLowDate52 { get; set; }
        //  "52WeekPriceReturnDaily": -41.08761,
        [JsonProperty("52WeekPriceReturnDaily")]
        public decimal? WeekPriceReturnDaily52 { get; set; }
        //  "5DayPriceReturnDaily": 0.87545,
        [JsonProperty("5DayPriceReturnDaily")]
        public decimal? DayPriceReturnDaily5 { get; set; }
        //  "assetTurnoverAnnual": 2.01299,
        public decimal? assetTurnoverAnnual { get; set; }
        //  "assetTurnoverTTM": 1.91162,
        public decimal? assetTurnoverTTM { get; set; }
        //  "beta": -0.30285,
        public decimal? beta { get; set; }
        //  "bookValuePerShareAnnual": 5.27833,
        public decimal? bookValuePerShareAnnual { get; set; }
        //  "bookValuePerShareQuarterly": 4.41941,
        public decimal? bookValuePerShareQuarterly { get; set; }
        //  "bookValueShareGrowth5Y": -1.10351,
        public decimal? bookValueShareGrowth5Y { get; set; }
        //  "capitalSpendingGrowth5Y": -15.35651,
        public decimal? TenDayAverageTradingVolume { get; set; }
        //  "cashFlowPerShareAnnual": -1.04718,
        public decimal? cashFlowPerShareAnnual { get; set; }
        //  "cashFlowPerShareTTM": -1.46897,
        public decimal? cashFlowPerShareTTM { get; set; }
        //  "cashPerSharePerShareAnnual": 4.18775,
        public decimal? cashPerSharePerShareAnnual { get; set; }
        //  "cashPerSharePerShareQuarterly": 2.9898,
        public decimal? cashPerSharePerShareQuarterly { get; set; }
        //  "currentDividendYieldTTM": null,
        public decimal? currentDividendYieldTTM { get; set; }
        //  "currentEv/freeCashFlowAnnual": null,
        [JsonProperty("currentEv/freeCashFlowAnnual")]
        public decimal? currentEvfreeCashFlowAnnual { get; set; }
        //  "currentEv/freeCashFlowTTM": null,
        [JsonProperty("currentEv/freeCashFlowTTM")]
        public decimal? currentEvfreeCashFlowTTM { get; set; }
        //  "currentRatioAnnual": 1.91836,
        public decimal? currentRatioAnnual { get; set; }
        //  "currentRatioQuarterly": 2.16559,
        public decimal? currentRatioQuarterly { get; set; }
        //  "dividendGrowthRate5Y": null,
        public decimal? dividendGrowthRate5Y { get; set; }
        //  "dividendPerShare5Y": null,
        public decimal? dividendPerShare5Y { get; set; }
        //  "dividendPerShareAnnual": null,
        public decimal? dividendPerShareAnnual { get; set; }
        //  "dividendYield5Y": null,
        public decimal? dividendYield5Y { get; set; }
        //  "dividendYieldIndicatedAnnual": null,
        public decimal? dividendYieldIndicatedAnnual { get; set; }
        //  "dividendsPerShareTTM": null,
        public decimal? dividendsPerShareTTM { get; set; }
        //  "ebitdPerShareTTM": -1.46469,
        public decimal? ebitdPerShareTTM { get; set; }
        //  "ebitdaCagr5Y": null,
        public decimal? ebitdaCagr5Y { get; set; }
        //  "ebitdaInterimCagr5Y": null,
        public decimal? ebitdaInterimCagr5Y { get; set; }
        //  "epsBasicExclExtraItemsAnnual": -1.31302,
        public decimal? epsBasicExclExtraItemsAnnual { get; set; }
        //  "epsBasicExclExtraItemsTTM": -1.71043,
        public decimal? epsBasicExclExtraItemsTTM { get; set; }
        //  "epsExclExtraItemsAnnual": -1.31302,
        public decimal? epsExclExtraItemsAnnual { get; set; }
        //  "epsExclExtraItemsTTM": -1.71043,
        public decimal? epsExclExtraItemsTTM { get; set; }
        //  "epsGrowth3Y": null,
        public decimal? epsGrowth3Y { get; set; }
        //  "epsGrowth5Y": null,
        public decimal? epsGrowth5Y { get; set; }
        //  "epsGrowthQuarterlyYoy": -68.45653,
        public decimal? epsGrowthQuarterlyYoy { get; set; }
        //  "epsGrowthTTMYoy": -644.2801,
        public decimal? epsGrowthTTMYoy { get; set; }
        //  "epsInclExtraItemsAnnual": -1.31302,
        public decimal? epsInclExtraItemsAnnual { get; set; }
        //  "epsInclExtraItemsTTM": -1.71043,
        public decimal? epsInclExtraItemsTTM { get; set; }
        //  "epsNormalizedAnnual": -1.25818,
        public decimal? epsNormalizedAnnual { get; set; }
        //  "focfCagr5Y": -44.07121,
        public decimal? focfCagr5Y { get; set; }
        //  "grossMargin5Y": 27.06191,
        public decimal? grossMargin5Y { get; set; }
        //  "grossMarginAnnual": 22.42335,
        public decimal? grossMarginAnnual { get; set; }
        //  "grossMarginTTM": 21.06383,
        public decimal? grossMarginTTM { get; set; }
        //  "inventoryTurnoverAnnual": 6.1455,
        public decimal? inventoryTurnoverAnnual { get; set; }
        //  "inventoryTurnoverTTM": 7.19261,
        public decimal? inventoryTurnoverTTM { get; set; }
        //  "longTermDebt/equityAnnual": 2.5273,
        [JsonProperty("longTermDebt/equityAnnual")]
        public decimal? longTermDebtEquityAnnual { get; set; }
        //  "longTermDebt/equityQuarterly": 2.38928,
        [JsonProperty("longTermDebt/equityQuarterly")]
        public decimal? longTermDebtEquityQuarterly { get; set; }
        //  "marketCapitalization": 7719.829,
        public decimal? marketCapitalization { get; set; }
        //  "monthToDatePriceReturnDaily": 0.87545,
        public decimal? monthToDatePriceReturnDaily { get; set; }
        //  "netIncomeEmployeeAnnual": -31775,
        public decimal? netIncomeEmployeeAnnual { get; set; }
        //  "netIncomeEmployeeTTM": -43291.67,
        public decimal? netIncomeEmployeeTTM { get; set; }
        //  "netInterestCoverageAnnual": -28.672,
        public decimal? netInterestCoverageAnnual { get; set; }
        //  "netInterestCoverageTTM": -79.72308,
        public decimal? netInterestCoverageTTM { get; set; }
        //  "netMarginGrowth5Y": null,
        public decimal? netMarginGrowth5Y { get; set; }
        //  "netProfitMargin5Y": -4.78911,
        public decimal? netProfitMargin5Y { get; set; }
        //  "netProfitMarginAnnual": -6.34369,
        public decimal? netProfitMarginAnnual { get; set; }
        //  "netProfitMarginTTM": -8.56568,
        public decimal? netProfitMarginTTM { get; set; }
        //  "operatingMargin5Y": -3.73995,
        public decimal? operatingMargin5Y { get; set; }
        //  "operatingMarginAnnual": -6.42687,
        public decimal? operatingMarginAnnual { get; set; }
        //  "operatingMarginTTM": -8.75859,
        public decimal? operatingMarginTTM { get; set; }
        //  "payoutRatioAnnual": null,
        public decimal? payoutRatioAnnual { get; set; }
        //  "payoutRatioTTM": null,
        public decimal? payoutRatioTTM { get; set; }
        //  "pbAnnual": 4.80266,
        public decimal? pbAnnual { get; set; }
        //  "pbQuarterly": 5.73606,
        public decimal? pbQuarterly { get; set; }
        //  "pcfShareTTM": null,
        public decimal? pcfShareTTM { get; set; }
        //  "peBasicExclExtraTTM": null,
        public decimal? peBasicExclExtraTTM { get; set; }
        //  "peExclExtraAnnual": null,
        public decimal? peExclExtraAnnual { get; set; }
        //  "peExclExtraHighTTM": 11.60519,
        public decimal? peExclExtraHighTTM { get; set; }
        //  "peExclExtraTTM": null,
        public decimal? peExclExtraTTM { get; set; }
        //  "peExclLowTTM": 6.59645,
        public decimal? peExclLowTTM { get; set; }
        //  "peInclExtraTTM": null,
        public decimal? peInclExtraTTM { get; set; }
        //  "peNormalizedAnnual": null,
        public decimal? peNormalizedAnnual { get; set; }
        //  "pfcfShareAnnual": null,
        public decimal? pfcfShareAnnual { get; set; }
        //  "pfcfShareTTM": null,
        public decimal? pfcfShareTTM { get; set; }
        //  "pretaxMargin5Y": -4.2481,
        public decimal? pretaxMargin5Y { get; set; }
        //  "pretaxMarginAnnual": -6.57827,
        public decimal? pretaxMarginAnnual { get; set; }
        //  "pretaxMarginTTM": -8.79322,
        public decimal? pretaxMarginTTM { get; set; }
        //  "priceRelativeToS&P50013Week": -15.48488,
        [JsonProperty("priceRelativeToS&P50013Week")]
        public decimal? priceRelativeToSP50013Week { get; set; }
        //  "priceRelativeToS&P50026Week": -28.78446,
        [JsonProperty("priceRelativeToS&P50026Week")]
        public decimal? priceRelativeToSP50026Week { get; set; }
        //  "priceRelativeToS&P5004Week": -2.0439,
        [JsonProperty("priceRelativeToS&P5004Week")]
        public decimal? priceRelativeToSP5004Week { get; set; }
        //  "priceRelativeToS&P500Ytd": -10.5165,
        [JsonProperty("priceRelativeToS&P500Ytd")]
        public decimal? priceRelativeToSP500Ytd { get; set; }
        //  "psAnnual": 1.28435,
        public decimal? psAnnual { get; set; }
        //  "psTTM": 1.27287,
        public decimal? psTTM { get; set; }
        //  "ptbvAnnual": 4.85402,
        public decimal? ptbvAnnual { get; set; }
        //  "ptbvQuarterly": 5.74606,
        public decimal? ptbvQuarterly { get; set; }
        //  "quickRatioAnnual": 1.24293,
        public decimal? quickRatioAnnual { get; set; }
        //  "receivablesTurnoverAnnual": 71.81243,
        public decimal? receivablesTurnoverAnnual { get; set; }
        //  "receivablesTurnoverTTM": 72.15824,
        public decimal? receivablesTurnoverTTM { get; set; }
        //  "revenueEmployeeAnnual": 500891.7,
        public decimal? revenueEmployeeAnnual { get; set; }
        //  "revenueEmployeeTTM": 505408.3,
        public decimal? revenueEmployeeTTM { get; set; }
        //  "revenueGrowth3Y": -10.14568,
        public decimal? revenueGrowth3Y { get; set; }
        //  "revenueGrowth5Y": -5.47475,
        public decimal? revenueGrowth5Y { get; set; }
        //  "revenueGrowthQuarterlyYoy": -4.00541,
        public decimal? revenueGrowthQuarterlyYoy { get; set; }
        //  "revenueGrowthTTMYoy": 8.55379,
        public decimal? revenueGrowthTTMYoy { get; set; }
        //  "revenuePerShareAnnual": 20.698,
        public decimal? revenuePerShareAnnual { get; set; }
        //  "revenuePerShareTTM": 19.96675,
        public decimal? revenuePerShareTTM { get; set; }
        //  "revenueShareGrowth5Y": 1.53131,
        public decimal? revenueShareGrowth5Y { get; set; }
        //  "roaRfy": -12.76981,
        public decimal? roaRfy { get; set; }
        //  "roaa5Y": -8.84947,
        public decimal? roaa5Y { get; set; }
        //  "roae5Y": -25.239,
        public decimal? roae5Y { get; set; }
        //  "roaeTTM": -32.51447,
        public decimal? currentroaeTTMEvfreeCashFlowAnnual { get; set; }
        //  "roeRfy": -37.39702,
        public decimal? roeRfy { get; set; }
        //  "roeTTM": -16.37432,
        public decimal? roeTTM { get; set; }
        //  "roi5Y": -15.89326,
        public decimal? roi5Y { get; set; }
        //  "roiAnnual": -23.28905,
        public decimal? roiAnnual { get; set; }
        //  "roiTTM": -24.62902,
        public decimal? roiTTM { get; set; }
        //  "tangibleBookValuePerShareAnnual": 5.23847,
        public decimal? tangibleBookValuePerShareAnnual { get; set; }
        //  "tangibleBookValuePerShareQuarterly": 4.41941,
        public decimal? tangibleBookValuePerShareQuarterly { get; set; }
        //  "tbvCagr5Y": 136.0529,
        public decimal? tbvCagr5Y { get; set; }
        //  "totalDebt/totalEquityAnnual": 2.78315,
        [JsonProperty("totalDebt/totalEquityAnnual")]
        public decimal? totalDebtTotalEquityAnnual { get; set; }
        //  "totalDebt/totalEquityQuarterly": 3.05173,
        [JsonProperty("totalDebt/totalEquityQuarterly")]
        public decimal? totalDebtTotalEquityQuarterly { get; set; }
        //  "yearToDatePriceReturnDaily": -31.66655
        public decimal? yearToDatePriceReturnDaily { get; set; }

        public CompanyFinancials()
        {

        }
    }
}
//    "10DayAverageTradingVolume": 3.37355,
//  "13WeekPriceReturnDaily": -21.11405,
//  "26WeekPriceReturnDaily": -30.63821,
//  "3MonthAverageTradingVolume": 145.06317,
//  "52WeekHigh": 63.9225,
//  "52WeekHighDate": "2021-11-03",
//  "52WeekLow": 19.3975,
//  "52WeekLowDate": "2022-03-14",
//  "52WeekPriceReturnDaily": -41.08761,
//  "5DayPriceReturnDaily": 0.87545,
//  "assetTurnoverAnnual": 2.01299,
//  "assetTurnoverTTM": 1.91162,
//  "beta": -0.30285,
//  "bookValuePerShareAnnual": 5.27833,
//  "bookValuePerShareQuarterly": 4.41941,
//  "bookValueShareGrowth5Y": -1.10351,
//  "capitalSpendingGrowth5Y": -15.35651,
//  "cashFlowPerShareAnnual": -1.04718,
//  "cashFlowPerShareTTM": -1.46897,
//  "cashPerSharePerShareAnnual": 4.18775,
//  "cashPerSharePerShareQuarterly": 2.9898,
//  "currentDividendYieldTTM": null,
//  "currentEv/freeCashFlowAnnual": null,
//  "currentEv/freeCashFlowTTM": null,
//  "currentRatioAnnual": 1.91836,
//  "currentRatioQuarterly": 2.16559,
//  "dividendGrowthRate5Y": null,
//  "dividendPerShare5Y": null,
//  "dividendPerShareAnnual": null,
//  "dividendYield5Y": null,
//  "dividendYieldIndicatedAnnual": null,
//  "dividendsPerShareTTM": null,
//  "ebitdPerShareTTM": -1.46469,
//  "ebitdaCagr5Y": null,
//  "ebitdaInterimCagr5Y": null,
//  "epsBasicExclExtraItemsAnnual": -1.31302,
//  "epsBasicExclExtraItemsTTM": -1.71043,
//  "epsExclExtraItemsAnnual": -1.31302,
//  "epsExclExtraItemsTTM": -1.71043,
//  "epsGrowth3Y": null,
//  "epsGrowth5Y": null,
//  "epsGrowthQuarterlyYoy": -68.45653,
//  "epsGrowthTTMYoy": -644.2801,
//  "epsInclExtraItemsAnnual": -1.31302,
//  "epsInclExtraItemsTTM": -1.71043,
//  "epsNormalizedAnnual": -1.25818,
//  "focfCagr5Y": -44.07121,
//  "grossMargin5Y": 27.06191,
//  "grossMarginAnnual": 22.42335,
//  "grossMarginTTM": 21.06383,
//  "inventoryTurnoverAnnual": 6.1455,
//  "inventoryTurnoverTTM": 7.19261,
//  "longTermDebt/equityAnnual": 2.5273,
//  "longTermDebt/equityQuarterly": 2.38928,
//  "marketCapitalization": 7719.829,
//  "monthToDatePriceReturnDaily": 0.87545,
//  "netIncomeEmployeeAnnual": -31775,
//  "netIncomeEmployeeTTM": -43291.67,
//  "netInterestCoverageAnnual": -28.672,
//  "netInterestCoverageTTM": -79.72308,
//  "netMarginGrowth5Y": null,
//  "netProfitMargin5Y": -4.78911,
//  "netProfitMarginAnnual": -6.34369,
//  "netProfitMarginTTM": -8.56568,
//  "operatingMargin5Y": -3.73995,
//  "operatingMarginAnnual": -6.42687,
//  "operatingMarginTTM": -8.75859,
//  "payoutRatioAnnual": null,
//  "payoutRatioTTM": null,
//  "pbAnnual": 4.80266,
//  "pbQuarterly": 5.73606,
//  "pcfShareTTM": null,
//  "peBasicExclExtraTTM": null,
//  "peExclExtraAnnual": null,
//  "peExclExtraHighTTM": 11.60519,
//  "peExclExtraTTM": null,
//  "peExclLowTTM": 6.59645,
//  "peInclExtraTTM": null,
//  "peNormalizedAnnual": null,
//  "pfcfShareAnnual": null,
//  "pfcfShareTTM": null,
//  "pretaxMargin5Y": -4.2481,
//  "pretaxMarginAnnual": -6.57827,
//  "pretaxMarginTTM": -8.79322,
//  "priceRelativeToS&P50013Week": -15.48488,
//  "priceRelativeToS&P50026Week": -28.78446,
//  "priceRelativeToS&P5004Week": -2.0439,
//  "priceRelativeToS&P500Ytd": -10.5165,
//  "psAnnual": 1.28435,
//  "psTTM": 1.27287,
//  "ptbvAnnual": 4.85402,
//  "ptbvQuarterly": 5.74606,
//  "quickRatioAnnual": 1.24293,
//  "receivablesTurnoverAnnual": 71.81243,
//  "receivablesTurnoverTTM": 72.15824,
//  "revenueEmployeeAnnual": 500891.7,
//  "revenueEmployeeTTM": 505408.3,
//  "revenueGrowth3Y": -10.14568,
//  "revenueGrowth5Y": -5.47475,
//  "revenueGrowthQuarterlyYoy": -4.00541,
//  "revenueGrowthTTMYoy": 8.55379,
//  "revenuePerShareAnnual": 20.698,
//  "revenuePerShareTTM": 19.96675,
//  "revenueShareGrowth5Y": 1.53131,
//  "roaRfy": -12.76981,
//  "roaa5Y": -8.84947,
//  "roae5Y": -25.239,
//  "roaeTTM": -32.51447,
//  "roeRfy": -37.39702,
//  "roeTTM": -16.37432,
//  "roi5Y": -15.89326,
//  "roiAnnual": -23.28905,
//  "roiTTM": -24.62902,
//  "tangibleBookValuePerShareAnnual": 5.23847,
//  "tangibleBookValuePerShareQuarterly": 4.41941,
//  "tbvCagr5Y": 136.0529,
//  "totalDebt/totalEquityAnnual": 2.78315,
//  "totalDebt/totalEquityQuarterly": 3.05173,
//  "yearToDatePriceReturnDaily": -31.66655