using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Quandl.NET.Model.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Order
    {
        [EnumMember(Value = "asc")]
        Ascending,

        [EnumMember(Value = "desc")]
        Descending
    }
}