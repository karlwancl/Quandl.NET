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

            //var result = client.Datatable.GetStreamAsync("INQ", "EE").Result;
            //var result = client.Dataset.GetListStreamAsync("crude+oil", "ODA", 1, 1).Result;
            var result = client.Database.GetDatasetListZipAsync("WIKI").Result;
            //var result = client.Dataset.GetDataAndMetadataStreamAsync("WIKI", "AMAT", 20).Result;
            using (result)
            using (var fs = File.Create("datatable_wiki_amat.zip"))
            {
                result.CopyTo(fs);
            }

            Console.WriteLine("Process completed!");
            Console.ReadLine();
        }
    }
}
