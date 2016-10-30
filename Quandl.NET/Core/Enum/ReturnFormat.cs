using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Quandl.NET.Core.Enum
{
    public enum ReturnFormat
    {
        [EnumMember(Value = "json")]
        Json,
        [EnumMember(Value = "xml")]
        Xml,
        [EnumMember(Value = "csv")]
        Csv
    }
}
