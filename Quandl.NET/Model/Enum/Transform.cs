using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Quandl.NET.Model.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Transform
    {
        [EnumMember(Value = "none")]
        None,

        [EnumMember(Value = "diff")]
        Diff,

        [EnumMember(Value = "rdiff")]
        Rdiff,

        [EnumMember(Value = "rdiff_from")]
        RdiffFrom,

        [EnumMember(Value = "cumul")]
        Cumul,

        [EnumMember(Value = "normalize")]
        Normalize
    }
}