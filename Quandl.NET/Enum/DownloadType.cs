using System.Runtime.Serialization;

namespace Quandl.NET
{
    public enum DownloadType
    {
        [EnumMember(Value = "partial")]
        Partial,

        [EnumMember(Value = "full")]
        Full
    }
}