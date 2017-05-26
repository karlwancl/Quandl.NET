using System;
using System.Runtime.Serialization;

namespace Quandl.NET
{
    public enum ReturnFormat
    {
        [EnumMember(Value= "json")]
        Json,
		[EnumMember(Value = "xml")]
		Xml,
		[EnumMember(Value = "csv")]
		Csv
    }
}