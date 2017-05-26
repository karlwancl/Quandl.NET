using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.IO;

namespace Quandl.NET.Tests
{
    public class TimeseriesTest
    {
        [Fact]
        public void GetDataTest()
        {
            var client = new QuandlClient(My.ApiKey);
            var data = client.Timeseries.GetDataAsync("WIKI", "FB").Result;
            Assert.Equal("Date", data.DatasetData.ColumnNames.First().ToString());
        }

        [Fact]
        public void GetDataTest2()
        {
            var client = new QuandlClient(My.ApiKey);
            var data = client.Timeseries.GetDataAsync("WIKI", "FB", 
                                                      columnIndex: 4, 
                                                      startDate: new DateTime(2014, 1, 1), 
                                                      endDate: new DateTime(2014, 12, 31), 
                                                      collapse: Model.Enum.Collapse.Monthly, 
                                                      transform: Model.Enum.Transform.Rdiff)
                             .Result;
            Assert.Equal("Date", data.DatasetData.ColumnNames.First().ToString());
        }

        [Fact]
        public void GetMetadataTest()
        {
            var client = new QuandlClient(My.ApiKey);
            var data = client.Timeseries.GetMetadataAsync("EOD", "FB").Result;
            Assert.Contains("Facebook", data.Dataset.Name);
        }

		[Fact]
		public void GetDataAndMetadataTest()
		{
			var client = new QuandlClient(My.ApiKey);
			var data = client.Timeseries.GetDataAndMetadataAsync("WIKI", "FB",
													  columnIndex: 4,
													  startDate: new DateTime(2014, 1, 1),
													  endDate: new DateTime(2014, 12, 31),
													  collapse: Model.Enum.Collapse.Monthly,
													  transform: Model.Enum.Transform.Rdiff)
							 .Result;
			Assert.Equal("Date", data.Dataset.ColumnNames.First().ToString());
		}

        [Fact]
        public void GetDatabaseMetadataAsync()
        {
            var client = new QuandlClient(My.ApiKey);
            var data = client.Timeseries.GetDatabaseMetadataAsync("WIKI").Result;
            Assert.Equal("Wiki EOD Stock Prices", data.Database.Name);
            Assert.Contains("End of day stock prices", data.Database.Description);
        }

        // Need to use premium account in order to test
        [Fact]
        public void GetEntireDatabaseTest()
        {
            //var client = new QuandlClient(My.ApiKey);
            //using (var stream = client.Timeseries.GetEntireDatabaseAsync("SCF", Model.Enum.DownloadType.Full).Result)
            //using (var fs = File.Create(""))
            //{
            //    stream.CopyTo(fs);
            //    Assert.True(stream.Length > 0);
            //}
        }
    }
}
