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
    public enum Order
    {
        [EnumMember(Value = "asc")]
        Ascending,
        [EnumMember(Value = "desc")]
        Descending
    }
}
