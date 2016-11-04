using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Exception
{
    public class QuandlException : System.Exception
    {
        private string _code;

        public QuandlException(string code, string message) : base(message)
        {
            _code = code;
        }

        public string Code => _code;
    }
}
