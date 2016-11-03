using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
