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
            //var result = client.Datatable.GetDatatableAsync("INQ/EE").Result;

            //var result = client.Database.GetEntireDatabaseInCsvAsync("WIKI", Model.Enum.DownloadType.Partial).Result;
            //using (result)
            //using (var fs = File.Create("db.zip"))
            //{
            //    //Console.WriteLine($"Start downloading... ({result.} bytes)");
            //    result.CopyTo(fs);
            //}

            //var result = client.Database.GetDatasetListStreamAsync("WIKI").Result;
            //using (result)
            //using (var fs = File.Create("result.zip"))
            //{
            //    result.CopyTo(fs);
            //}
            var result = client.Database.GetListAsync().Result;
            Console.WriteLine("Process completed!");
            //var result = client.Database.GetDatabaseMetadataAsync("WIKI").Result;
            //var databases = client.Database.GetListOfDatabasesAsync().Result;
            //databases?.Databases?.Take(10).ForEach(md => Console.WriteLine($"{md.DatabaseCode}: {md.Description}"));

            Console.ReadLine();
        }
    }
}
