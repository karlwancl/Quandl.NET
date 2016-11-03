using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Exception
{
    public class QuandlErrorAggregate
    {
        public QuandlErrorAggregate(QuandlError quandl_error)
        {
            QuandlError = quandl_error;
        }

        public QuandlError QuandlError { get; private set; }
    }

    public class QuandlError
    {
        private string _code, _message;

        public QuandlError(string code, string message)
        {
            _code = code;
            _message = message;
        }

        public string Code => _code;

        public string Message => _message;
    }
}
