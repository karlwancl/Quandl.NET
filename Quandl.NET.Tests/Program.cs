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
            var result = client.Database.GetEntireDatabaseAsync("WIKI", Core.Enum.DownloadType.Complete).Result;
            using (result)
            using (var fs = File.Create("db.zip"))
            {
                //Console.WriteLine($"Start downloading... ({result.} bytes)");
                result.CopyTo(fs);
            }
            //Console.WriteLine("The request is sending...");
            //var result = client.Database.GetListOfDatabaseContentsAsync("WIKI").Result;
            //using (result)
            //using (var fs = File.Create("db_content.zip"))
            //{
            //    Console.WriteLine("Start downloading...");
            //    result.CopyTo(fs);
            //}
            Console.WriteLine("Process completed!");
                //var result = client.Database.GetDatabaseMetadataAsync("WIKI").Result;
                //var databases = client.Database.GetListOfDatabasesAsync().Result;
                //databases?.Databases?.Take(10).ForEach(md => Console.WriteLine($"{md.DatabaseCode}: {md.Description}"));
                Console.ReadLine();
        }
    }
}
