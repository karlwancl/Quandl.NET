namespace Quandl.NET.Model
{
    public class ISO3LetterCountryCode
    {
        public ISO3LetterCountryCode(string country, string world_bank_code)
        {
            Country = country;
            WorldBankCode = world_bank_code;
        }

        public string Country { get; private set; }

        public string WorldBankCode { get; private set; }
    }
}