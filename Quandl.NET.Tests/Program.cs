using Quandl.NET.Model.Enum;
using Quandl.NET;
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

            var result = client.Dataset.GetAsync("WIKI", "FB").Result;
            //var result = client.Database.GetZipAsync("WIKI", DownloadType.Partial).Result;
            //var result = client.Database.GetDatasetListZipAsync("WIKI").Result;
            //var result = client.Database.GetMetadataAsync("ABCD").Result;
            //var result = client.Database.GetListCsvAsync(new List<string> { "stock", "price" }, 1, 1 ).Result;
            //var result = client.Database.GetMetadataCsvAsync("WIKI").Result;

            //var rowFilter = new Dictionary<string, List<string>>();
            //rowFilter.Add("isin", new List<string> { "FI0009000681", "DE0007236101" });
            //var columnFilter = new List<string> { "isin", "company123" };
            //var result = client.Datatable.GetAsync("INQ", "EE", rowFilter, columnFilter).Result;
            //var result = client.Datatable.GetMetadataCsvAsync("INQ", "EE").Result;
            //var result = client.Datatable.GetMetadataAsync("ABCD", "GG").Result;

            //var result = client.Dataset.GetCsvAsync("WIKI", "FB").Result;
            //var result = client.Dataset.GetMetadataCsvAsync("WIKI", "FB").Result;
            //var result = client.Dataset.GetDataAndMetadataCsvAsync("WIKI", "FB", columnIndex: 4, startDate: new DateTime(2014, 1, 1), endDate: new DateTime(2014, 12, 31), collapse: Model.Enum.Collapse.Daily, transform: Model.Enum.Transform.Rdiff).Result;
            //var query = new List<string> { "crude", "oil" };
            //var result = client.Dataset.GetListCsvAsync(query, "ODA", 1, 1).Result;

            //using (result)
            //using (var fs = File.Create("test.csv"))
            //{
            //    result.CopyTo(fs);
            //}

            //var result = UsefulDataAndLists.GetSP500IndexConstituentsAsync().Result;
            //var result2 = UsefulDataAndLists.GetDowJonesIndustrialAverageConstituentsAsync().Result;
            //var result3 = UsefulDataAndLists.GetCommoditiesAsync().Result;
            //var result4 = UsefulDataAndLists.GetISOCurrencyCodesAsync().Result;
            //var result5 = UsefulDataAndLists.GetISO3LetterCountryCodesAsync().Result;
            //var result6 = UsefulDataAndLists.GetCurrencyCrossRatesAsync().Result;

            Console.WriteLine("Process completed!");
        }
    }
}