using System;
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

            ////var result = client.Datatable.GetCsvAsync("WIKI", "PRICES").Result;
            //var result = client.Datatable.GetMetadataAsync("WIKI", "PRICES").Result;
            //using (result)
            //using (var fs = File.Create("test.csv"))
            //{
            //    result.CopyTo(fs);
            //}

            Console.WriteLine("Process completed!");
        }
    }
}