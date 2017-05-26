using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Quandl.NET.Helper;

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
            var data = client.Tables.GetAsync("ETFG/FUND", "ticker=SPY,IWM,GLD&date<2014-01-07", "ticker,date,shares_outstanding").Result;
            Assert.Equal("ticker", data.Datatable.Columns.First().Name);
        }

        [Fact]
        public void GetMetadataTest()
        {
            var client = new QuandlClient(My.ApiKey);
            var data = client.Tables.GetMetadataAsync("AR/MWCS").Result;
            Assert.Equal("MarketWorks Futures Settlement CME", data.Datatable.Name);
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
        public void UsefulDataAndListsTest()
        {
            var result = UsefulDataAndLists.GetSP500IndexConstituentsAsync().Result;
            Assert.True(true);
        }
    }
}
