using System;
using System.Linq;
using Xunit;

namespace Quandl.NET.Tests
{
    public class TablesTest
    {
        // Test account api key
        const string ApiKey = "Sys3z7hfYmzjiXPxwfQJ";

        [Fact]
        public void GetTest()
        {
            var client = new QuandlClient(ApiKey);
            var result = client.Tables.GetAsync("ETFG/FUND", "ticker=SPY,IWM,GLD&date<2014-01-07", "ticker,date,shares_outstanding").Result;
            Assert.Equal("ticker", result.Datatable.Columns.First().Name);
        }

        [Fact]
        public void GetMetadataTest()
        {
            var client = new QuandlClient(ApiKey);
            var result = client.Tables.GetMetadataAsync("AR/MWCS").Result;
            Assert.Equal("MarketWorks Futures Settlement CME", result.Datatable.Name);
        }

        [Fact]
        public void DownloadTest()
        {
            var client = new QuandlClient(ApiKey);
            using (var stream = client.Tables.DownloadAsync("WIKI/PRICES").Result)
            {
                Assert.True(stream.Length > 0);
            }
        }

  //      [Fact]
  //      public void QuandlTest()
  //      {
  //          var result = Quandl.GetSP500IndexConstituentsAsync().Result;
  //          Assert.Equal("Apple Inc.", result.First(r => r.Ticker == "AAPL").Name);

  //          var result2 = Quandl.GetFuturesMetadataAsync().Result;
  //          Assert.Equal("Mini European 3.5% Fuel Oil Barges FOB Rdam (Platts)", result2.First(r => r.Symbol == "0D").Name);

  //          var result3 = Quandl.GetCommoditiesAsync().Result;
  //          Assert.Equal("Milk, Non-Fat Dry, Chicago", result3.First(r => r.Code == "WSJ/MILK").Name);

  //          var result4 = Quandl.GetISOCurrencyCodesAsync().Result;
  //          Assert.Equal("Euro", result4.First(r => r.Country == "AUSTRIA").Currency);

		//}
    }
}