using CsvHelper;
using Flurl.Http;
using Quandl.NET.Model;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;

namespace Quandl.NET
{
    public static class Quandl
    {
        private static IEnumerable<StockIndexConstituent> ParseIndexConstituentsResponse(string responseString)
        {
            var constituents = new List<StockIndexConstituent>();

            var csvReader = new CsvReader(new StringReader(responseString));
            while (csvReader.Read())
            {
                constituents.Add(new StockIndexConstituent
                    (
                        csvReader.GetField(0),
                        csvReader.GetField(1),
                        csvReader.GetField(2),
                        csvReader.GetField(3)
                    ));
            }

            return constituents;
        }

        private static IEnumerable<FuturesMetadata> ParseFutureMetadataResponse(string responseString)
        {
            var metadata = new List<FuturesMetadata>();

            var csvReader = new CsvReader(new StringReader(responseString));
            while (csvReader.Read())
            {
                //Console.WriteLine(string.Join(", ", csvReader.CurrentRecord));
                metadata.Add(new FuturesMetadata
                    (
                        symbol: csvReader.GetField(0),
                        exchange: csvReader.GetField(1),
                        quandl_code: csvReader.GetField(2),
                        name: csvReader.GetField(3),
                        session_type: csvReader.GetField(4),
                        active: csvReader.GetField(5) != "0",
                        terminal_point_value: csvReader.GetField<decimal?>(6),
                        full_point_value: csvReader.GetField<long?>(7),
                        currency: csvReader.GetField(8),
                        contract_size: csvReader.GetField(9),
                                 units: csvReader.GetField(10),
                                 minimum_tick_value: csvReader.GetField<decimal?>(11),
                                 tick_value: csvReader.GetField<decimal?>(12),
                                 delivery_months: csvReader.GetField(13),
                                 start_date: csvReader.GetField<System.DateTime?>(14),
                                 trading_times: csvReader.GetField(15),
                                 additional_notes: csvReader.GetField(16)
                    ));
            }

            return metadata;
        }

        private static IEnumerable<Commodities> ParseCommoditiesResponse(string responseString)
        {
            var commodities = new List<Commodities>();

            var csvReader = new CsvReader(new StringReader(responseString));
            while (csvReader.Read())
            {
                commodities.Add(new Commodities
                    (
                        name: csvReader.GetField(0),
                        code: csvReader.GetField(1),
                        source: csvReader.GetField(2),
                        sector: csvReader.GetField(3)
                    ));
            }

            return commodities;
        }

        private static IEnumerable<ISOCurrencyCode> ParseISOCurrencyCodeResponse(string responseString)
        {
            var isoCurrencyCode = new List<ISOCurrencyCode>();

            var csvReader = new CsvReader(new StringReader(responseString));
            while (csvReader.Read())
            {
                isoCurrencyCode.Add(new ISOCurrencyCode
                    (
                        country: csvReader.GetField(0),
                        currency: csvReader.GetField(1),
                        alphabetic_code: csvReader.GetField(2),
                        numeric_code: csvReader.GetField(3)
                    ));
            }

            return isoCurrencyCode;
        }

        private static IEnumerable<ISO3LetterCountryCode> ParseISO3LetterCountryCodeResponse(string responseString)
        {
            var iso3LetterCountryCode = new List<ISO3LetterCountryCode>();

            var csvReader = new CsvReader(new StringReader(responseString));
            while (csvReader.Read())
            {
                iso3LetterCountryCode.Add(new ISO3LetterCountryCode
                    (
                        country: csvReader.GetField(0),
                        world_bank_code: csvReader.GetField(1)
                    ));
            }

            return iso3LetterCountryCode;
        }

        private static IEnumerable<CurrencyCrossRate> ParseCurrencyCrossRateResponse(string responseString)
        {
            var currencyCrossRates = new List<CurrencyCrossRate>();

            var csvReader = new CsvReader(new StringReader(responseString));
            while (csvReader.Read())
            {
                currencyCrossRates.Add(new CurrencyCrossRate
                    (
                        currency: csvReader.GetField(0),
                        source: csvReader.GetField(1),
                        to_usd: csvReader.GetField(2),
                        to_gbp: csvReader.GetField(3),
                        to_eur: csvReader.GetField(4)
                    ));
            }

            return currencyCrossRates;
        }

        public static async Task<IEnumerable<StockIndexConstituent>> GetSP500IndexConstituentsAsync()
        {
            var responseString =
                await "https://s3.amazonaws.com/static.quandl.com/tickers/SP500.csv"
                .GetAsync()
                .ReceiveString()
                .ConfigureAwait(false);

            return ParseIndexConstituentsResponse(responseString);
        }

        public static async Task<IEnumerable<StockIndexConstituent>> GetDowJonesIndustrialAverageConstituentsAsync()
        {
            var responseString =
                await "https://s3.amazonaws.com/static.quandl.com/tickers/dowjonesA.csv"
                .GetAsync()
                .ReceiveString()
                .ConfigureAwait(false);

            return ParseIndexConstituentsResponse(responseString);
        }

        public static async Task<IEnumerable<StockIndexConstituent>> GetNASDAQCompositeIndexConstituentsAsync()
        {
            var responseString = await "https://s3.amazonaws.com/static.quandl.com/tickers/NASDAQComposite.csv"
                .GetAsync()
                .ReceiveString()
                .ConfigureAwait(false);

            return ParseIndexConstituentsResponse(responseString);
        }

        public static async Task<IEnumerable<StockIndexConstituent>> GetNASDAQ100IndexConstituentsAsync()
        {
            var responseString = await "https://s3.amazonaws.com/static.quandl.com/tickers/nasdaq100.csv"
                .GetAsync()
                .ReceiveString()
                .ConfigureAwait(false);

            return ParseIndexConstituentsResponse(responseString);
        }

        public static async Task<IEnumerable<StockIndexConstituent>> GetNYSECompositeIndexConstituentsAsync()
        {
            var responseString = await "https://s3.amazonaws.com/static.quandl.com/tickers/NYSEComposite.csv"
                .GetAsync()
                .ReceiveString()
                .ConfigureAwait(false);

            return ParseIndexConstituentsResponse(responseString);
        }

        public static async Task<IEnumerable<StockIndexConstituent>> GetFTSE100IndexConstituentsAsync()
        {
            var responseString = await "https://s3.amazonaws.com/static.quandl.com/tickers/FTSE100.csv"
                .GetAsync()
                .ReceiveString()
                .ConfigureAwait(false);

            return ParseIndexConstituentsResponse(responseString);
        }

        public static async Task<IEnumerable<FuturesMetadata>> GetFuturesMetadataAsync()
        {
            var responseString = await "https://s3.amazonaws.com/quandl-static-content/Ticker+CSV%27s/Futures/meta.csv"
                .GetAsync()
                .ReceiveString()
                .ConfigureAwait(false);

            return ParseFutureMetadataResponse(responseString);
        }

        public static async Task<IEnumerable<Commodities>> GetCommoditiesAsync()
        {
            var responseString = await "https://s3.amazonaws.com/quandl-static-content/Ticker+CSV%27s/commodities.csv"
                .GetAsync()
                .ReceiveString()
                .ConfigureAwait(false);

            return ParseCommoditiesResponse(responseString);
        }

        public static async Task<IEnumerable<ISOCurrencyCode>> GetISOCurrencyCodesAsync()
        {
            var responseString = await "https://s3.amazonaws.com/quandl-static-content/Ticker+CSV%27s/Currencies.csv"
                 .GetAsync()
                 .ReceiveString()
                 .ConfigureAwait(false);

            return ParseISOCurrencyCodeResponse(responseString);
        }

        public static async Task<IEnumerable<ISO3LetterCountryCode>> GetISO3LetterCountryCodesAsync()
        {
            var responseString = await "https://s3.amazonaws.com/quandl-static-content/Ticker+CSV%27s/ISOCodes.csv"
                 .GetAsync()
                 .ReceiveString()
                 .ConfigureAwait(false);

            return ParseISO3LetterCountryCodeResponse(responseString);
        }

        public static async Task<IEnumerable<CurrencyCrossRate>> GetCurrencyCrossRatesAsync()
        {
            var responseString = await "https://s3.amazonaws.com/quandl-static-content/Ticker+CSV%27s/currencies.csv"
                 .GetAsync()
                 .ReceiveString()
                 .ConfigureAwait(false);

            return ParseCurrencyCrossRateResponse(responseString);
        }
    }
}