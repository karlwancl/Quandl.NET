using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Model
{
    public class FuturesMetadata
    {
        public FuturesMetadata(string symbol, string exchange, string quandl_code, string name, string session_type, 
            bool active, decimal terminal_point_value, long full_point_value, string currency, string contract_size)
        {
            Symbol = symbol;
            Exchange = exchange;
            QuandlCode = quandl_code;
            Name = name;
            SessionType = session_type;
            Active = active;
            TerminalPointValue = terminal_point_value;
            FullPointValue = full_point_value;
            Currency = currency;
            ContractSize = contract_size;
        }

        public string Symbol { get; private set; }

        public string Exchange { get; private set; }

        public string QuandlCode { get; private set; }

        public string Name { get; private set; }

        public string SessionType { get; private set; }

        public bool Active { get; private set; }

        public decimal TerminalPointValue { get; private set; }

        public long FullPointValue { get; private set; }

        public string Currency { get; private set; }

        public string ContractSize { get; private set; }
    }
}
