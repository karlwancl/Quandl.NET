using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Quandl.NET.Helper
{
    internal class DateTimeConverter : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            => string.IsNullOrWhiteSpace(text) ? default(DateTime?) : DateTime.ParseExact(text, "M/d/yyyy", CultureInfo.InvariantCulture);

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => (value as DateTime?) == default(DateTime?) ? string.Empty : ((DateTime)value).ToString("M/d/yyyy");
    }
}
