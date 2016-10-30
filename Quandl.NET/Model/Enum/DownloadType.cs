using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Model.Enum
{
    public enum DownloadType
    {
        [EnumMember(Value = "partial")]
        Partial,
        [EnumMember(Value = "complete")]
        Complete
    }
}
