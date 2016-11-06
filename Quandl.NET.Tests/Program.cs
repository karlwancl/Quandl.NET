using Quandl.NET.Model.Enum;
using System;
using System.Collections.Generic;
using System.IO;

namespace Quandl.NET.Tests
{
    internal class Program
    {
        private const string apiKey = "M185pFZuSebc4Qr5MRz2";

        private static void Main(string[] args)
        {
            var client = new QuandlClient(apiKey);
            Console.WriteLine("The request is sending...");

            var result = client.Database.GetZipAsync("WIKI", DownloadType.Partial).Result;

            //var result = client.Database.GetListAsync().Result;
            //var result = client.Database.GetListCsvAsync().Result;
            //var result = client.Database.GetMetadataAsync("WIKI").Result;
            //var result = client.Database.GetMetadataCsvAsync("WIKI").Result;
            //var result = client.Database.GetDatasetListZipAsync("WIKI").Result;
            //var result = client.Datatable.GetAsync("INQ", "EE").Result;
            //var result = client.Datatable.GetCsvAsync("INQ", "EE").Result;
            //var result = client.Datatable.GetMetadataAsync("WIKI", "PRICES").Result;
            //var result = client.Datatable.GetMetadataCsvAsync("INQ", "EE").Result;

            //var rowFilter = new Dictionary<string, List<string>>();
            //rowFilter.Add("isin", new List<string> { "FI0009000681", "DE0007236101" });

            //var columnFilter = new List<string> { "isin", "company" };

            //var result = client.Datatable.GetCsvAsync("INQ", "EE", rowFilter, columnFilter).Result;

            //var result = client.Dataset.GetCsvAsync("WIKI", "FB").Result;
            //var result = client.Dataset.GetMetadataCsvAsync("WIKI", "FB").Result;
            //var result = client.Dataset.GetDataAndMetadataCsvAsync("WIKI", "FB", columnIndex: 4, startDate: new DateTime(2014, 1, 1), endDate: new DateTime(2014, 12, 31), collapse: Model.Enum.Collapse.Daily, transform: Model.Enum.Transform.Rdiff).Result;
            //var query = new List<string> { "crude", "oil" };
            //var result = client.Dataset.GetListCsvAsync(query, "ODA", 1, 1).Result;

            using (result)
            using (var fs = File.Create("test.zip"))
            {
                result.CopyTo(fs);
            }

            Console.WriteLine("Process completed!");
        }
    }
}