using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quandl.NET;
using System.IO;

namespace Quandl.NET.Tests
{
    class Program
    {
        const string apiKey = "M185pFZuSebc4Qr5MRz2";

        static void Main(string[] args)
        {
            var client = new QuandlClient(apiKey);
            Console.WriteLine("The request is sending...");

            //var result = client.Database.GetMetadataAsync("WIKI").Result;

            //var result = client.Database.GetListAsync(new List<string> { "stock", "price" }, 5, 1).Result;

            //var rowFilter = new Dictionary<string, List<string>>();
            //rowFilter.Add("isin", new List<string> { "FI0009000681", "DE0007236101" });

            //var columnFilter = new List<string>();
            //columnFilter.Add("isin");
            //columnFilter.Add("company");

            //var result = client.Datatable.GetAsync("INQ/EE", rowFilter, columnFilter).Result;

            //var result = client.Dataset.GetAsync("WIKI", "FB").Result;

            //var result = client.Dataset.GetMetadataAsync("WIKI", "FB").Result;

            //var result = client.Dataset.GetDataAndMetadataAsync("WIKI", "FB", columnIndex: 4, startDate: new DateTime(2014, 1, 1),
            //    endDate: new DateTime(2014, 12, 31), collapse: Model.Enum.Collapse.Monthly, transform: Model.Enum.Transform.Rdiff, order: Model.Enum.Order.Descending).Result;

            //var result = client.Dataset.GetListAsync(new List<string> {"crude","oil"}, "ODA", 1, 1).Result;

            //var result = client.Database.GetZipAsync("WIKI", Model.Enum.DownloadType.Partial).Result;
            //var result = client.Database.GetMetadataCsvAsync("WIKI").Result;
            //var result = client.Database.GetListCsvAsync(new List<string> { "stock", "price" }).Result;
            //var result = client.Database.GetDatasetListZipAsync("YC").Result;
            //var result = client.Datatable.GetCsvAsync("INQ/EE", rowFilter, columnFilter).Result;
            //var result = client.Dataset.GetCsvAsync("WIKI", "FB").Result;
            //var result = client.Dataset.GetCsvAsync("WIKI", "FB").Result;
            //var result = client.Dataset.GetMetadataAsync("WIKI", "FB").Result;
            //var result = client.Dataset.GetMetadataCsvAsync("WIKI", "FB").Result;
            //var result = client.Dataset.GetDataAndMetadataCsvAsync("WIKI", "FB", columnIndex: 4, startDate: new DateTime(2014, 1, 1),
            //    endDate: new DateTime(2014, 12, 31), collapse: Model.Enum.Collapse.Monthly, transform: Model.Enum.Transform.Rdiff, order: Model.Enum.Order.Ascending).Result;
            //var result = client.Dataset.GetListCsvAsync(new List<string> { "crude", "oil" }, "ODA", 1, 1).Result;
            //using (result)
            //using (var fs = File.Create("test.csv"))
            //{
            //    result.CopyTo(fs);
            //}

            Console.WriteLine("Process completed!");
        }
    }
}
