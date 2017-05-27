using System;
using System.Linq;
using Xunit;

namespace Quandl.NET.Tests
{
    public class TablesTest
    {
        //[Fact]
        //public void FilterTest()
        //{
        //    string filter = "ticker=SPY,IWM,GLD&date<=2014-01-02";
        //    var dict = new Dictionary<string, string>();
        //    dict.Add("ticker","SPY,IWM,GLD");
        //    dict.Add("date.lte","2014-01-02");
        //    Assert.NotStrictEqual(dict, Filter.Parse(filter));
        //}

        [Fact]
        public void GetTest()
        {
            var client = new QuandlClient(My.ApiKey);
            var result = client.Tables.GetAsync("ETFG/FUND", "ticker=SPY,IWM,GLD&date<2014-01-07", "ticker,date,shares_outstanding").Result;
            Console.WriteLine(string.Join(", ", result.Datatable.Columns.Select(c => c.Name)));
            Console.WriteLine(string.Join(", ", result.Datatable.Data.First()));
            Assert.Equal("ticker", result.Datatable.Columns.First().Name);
        }

        [Fact]
        public void GetMetadataTest()
        {
            var client = new QuandlClient(My.ApiKey);
            var result = client.Tables.GetMetadataAsync("AR/MWCS").Result;
            Console.WriteLine($"Name: {result.Datatable.Name}, Filters: {string.Join(", ", result.Datatable.Filters)}, Premium: {result.Datatable.Premium}");
            Assert.Equal("MarketWorks Futures Settlement CME", result.Datatable.Name);
        }

        [Fact]
        public void DownloadTest()
        {
            var client = new QuandlClient(My.ApiKey);
            using (var stream = client.Tables.DownloadAsync("WIKI/PRICES").Result)
            {
                Assert.True(stream.Length > 0);
            }
        }

        [Fact]
        public void QuandlTest()
        {
            //var result = Quandl.GetSP500IndexConstituentsAsync().Result;
            //Console.WriteLine(string.Join(", ", result.Take(10).Select((c => c.Ticker))));

            //var result = Quandl.GetFuturesMetadataAsync().Result;
            //Console.WriteLine(string.Join(", ", result.Take(10).Select(md => md.Symbol)));
            Assert.True(true);

            //var result = Quandl.GetCommoditiesAsync().Result;
            //Console.WriteLine(string.Join("; ", result.Select(r => $"Name: {r.Name}, Sector: {r.Sector}").Take(3)));

            var result = Quandl.GetISOCurrencyCodesAsync().Result;
            Console.WriteLine(string.Join("; ", result.Select(c => $"Code: {c.AlphabeticCode}, Country: {c.Country}, Currency: {c.Currency}").Take(3)));

		}
    }
}