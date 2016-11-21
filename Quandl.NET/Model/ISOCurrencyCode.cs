using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Model
{
    public class ISOCurrencyCode
    {
        public ISOCurrencyCode(string country, string currency, string alphabetic_code, string numeric_code)
        {
            Country = country;
            Currency = currency;
            AlphabeticCode = alphabetic_code;
            NumericCode = numeric_code;
        }

        public string Country { get; private set; }

        public string Currency { get; private set; }

        public string AlphabeticCode { get; private set; }

        public string NumericCode { get; private set; }
    }
}
