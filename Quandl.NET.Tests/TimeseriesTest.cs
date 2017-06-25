using System;
using System.Linq;
using Xunit;

namespace Quandl.NET.Tests
{
    public class TimeseriesTest
    {
        // Test account api key
        const string ApiKey = "Sys3z7hfYmzjiXPxwfQJ";

        [Fact]
        public void GetDataTest()
        {
            var client = new QuandlClient(ApiKey);
            var result = client.Timeseries.GetDataAsync("WIKI", "FB").Result;
            Assert.Equal("Date", result.DatasetData.ColumnNames.First());
        }

        [Fact]
        public void GetDataTest2()
        {
            var client = new QuandlClient(ApiKey);
            var result = client.Timeseries.GetDataAsync("WIKI", "FB",
                                                      columnIndex: 4,
                                                      startDate: new DateTime(2014, 1, 1),
                                                      endDate: new DateTime(2014, 12, 31),
                                                      collapse: Collapse.Monthly,
                                                      transform: Transform.Rdiff)
                             .Result;
            Assert.Equal("Date", result.DatasetData.ColumnNames.First());
        }

        [Fact]
        public void GetMetadataTest()
        {
            var client = new QuandlClient(ApiKey);
            var result = client.Timeseries.GetMetadataAsync("WIKI", "FB").Result;
            Assert.Contains("Facebook", result.Dataset.Name);
        }

        [Fact]
        public void GetDataAndMetadataTest()
        {
            var client = new QuandlClient(ApiKey);
            var data = client.Timeseries.GetDataAndMetadataAsync("WIKI", "FB",
                                                      columnIndex: 4,
                                                      startDate: new DateTime(2014, 1, 1),
                                                      endDate: new DateTime(2014, 12, 31),
                                                      collapse: Collapse.Monthly,
                                                      transform: Transform.Rdiff)
                             .Result;
            Assert.Equal("Date", data.Dataset.ColumnNames.First());
        }

        [Fact]
        public void GetDatabaseMetadataAsync()
        {
            var client = new QuandlClient(ApiKey);
            var result = client.Timeseries.GetDatabaseMetadataAsync("WIKI").Result;
            Assert.Equal("Wiki EOD Stock Prices", result.Database.Name);
            Assert.Contains("End of day stock prices", result.Database.Description);
        }

        // Need to use premium account in order to test
        [Fact]
        public void GetEntireDatabaseTest()
        {
            //var client = new QuandlClient(ApiKey);
            //using (var stream = client.Timeseries.GetEntireDatabaseAsync("SCF", Model.Enum.DownloadType.Full).Result)
            //using (var fs = File.Create(""))
            //{
            //    stream.CopyTo(fs);
            //    Assert.True(stream.Length > 0);
            //}
        }
    }
}