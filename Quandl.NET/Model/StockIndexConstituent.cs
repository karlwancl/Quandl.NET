namespace Quandl.NET.Model
{
    public class StockIndexConstituent
    {
        public StockIndexConstituent(string ticker, string name, string free_code, string premium_code)
        {
            Ticker = ticker;
            Name = name;
            FreeCode = free_code;
            PremiumCode = premium_code;
        }

        public string Ticker { get; private set; }

        public string Name { get; private set; }

        public string FreeCode { get; private set; }

        public string PremiumCode { get; private set; }
    }
}