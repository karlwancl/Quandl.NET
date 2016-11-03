using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Exception
{
    public class QuandlException : System.Exception
    {
        private string _code, _message;

        public QuandlException(string code, string message)
        {
            _code = code;
            _message = message;
        }

        public QuandlException(QuandlError error)
        {
            if (error == null)
                throw new ArgumentNullException(nameof(error));

            _code = error.Code;
            _message = error.Message;
        }

        public string Code => _code;

        public override string Message => _message;
    }
}
