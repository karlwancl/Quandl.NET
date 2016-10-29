using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quandl.NET;

namespace Quandl.NET.Tests
{
    class Program
    {
        const string apiKey = "M185pFZuSebc4Qr5MRz2";

        static void Main(string[] args)
        {
            var client = new QuandlClient(apiKey);
            var result = client.Database.GetListOfDatabasesAsync().Result;
            Console.WriteLine(result.Databases);
            Console.ReadLine();
        }
    }
}
