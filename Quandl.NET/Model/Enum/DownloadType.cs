using System.Runtime.Serialization;

namespace Quandl.NET.Model.Enum
{
    public enum DownloadType
    {
        [EnumMember(Value = "partial")]
        Partial,

        [EnumMember(Value = "full")]
        Full
    }
}