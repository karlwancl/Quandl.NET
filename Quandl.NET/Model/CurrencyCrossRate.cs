namespace Quandl.NET.Model
{
    public class CurrencyCrossRate
    {
        public CurrencyCrossRate(string currency, string source, string to_usd, string to_gbp, string to_eur)
        {
            Currency = currency;
            Source = source;
            ToUSD = to_usd;
            ToGBP = to_gbp;
            ToEUR = to_eur;
        }

        public string Currency { get; private set; }

        public string Source { get; private set; }

        public string ToUSD { get; private set; }

        public string ToGBP { get; private set; }

        public string ToEUR { get; private set; }
    }
}