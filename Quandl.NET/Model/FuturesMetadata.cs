using System;

namespace Quandl.NET.Model
{
    public class FuturesMetadata
    {
        public FuturesMetadata(string symbol, string exchange, string quandl_code, string name, string session_type,
            bool active, decimal? terminal_point_value, long? full_point_value, string currency, string contract_size, string units, decimal? minimum_tick_value,
                               decimal? tick_value, string delivery_months, DateTime? start_date, string trading_times, string additional_notes)
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
            Units = units;
            MinimumTickValue = minimum_tick_value;
            TickValue = tick_value;
            DeliveryMonths = delivery_months;
            StartDate = start_date;
            TradingTimes = trading_times;
            AdditionalNotes = additional_notes;
        }

        public string Symbol { get; private set; }

        public string Exchange { get; private set; }

        public string QuandlCode { get; private set; }

        public string Name { get; private set; }

        public string SessionType { get; private set; }

        public bool Active { get; private set; }

        public decimal? TerminalPointValue { get; private set; }

        public long? FullPointValue { get; private set; }

        public string Currency { get; private set; }

        public string ContractSize { get; private set; }

        public string Units { get; private set;}

		public decimal? MinimumTickValue { get; private set; }

		public decimal? TickValue { get; private set; }

		public string DeliveryMonths { get; private set; }

		public DateTime? StartDate { get; private set; }

		public string TradingTimes { get; private set; }

		public string AdditionalNotes { get; private set; }
	}
}