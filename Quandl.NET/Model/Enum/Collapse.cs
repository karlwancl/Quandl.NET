using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Quandl.NET.Model.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Collapse
    {
        [EnumMember(Value = "none")]
        None,

        [EnumMember(Value = "daily")]
        Daily,

        [EnumMember(Value = "weekly")]
        Weekly,

        [EnumMember(Value = "monthly")]
        Monthly,

        [EnumMember(Value = "quarterly")]
        Quarterly,

        [EnumMember(Value = "annual")]
        Annual
    }
}