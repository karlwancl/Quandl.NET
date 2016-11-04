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