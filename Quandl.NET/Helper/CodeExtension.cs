using Quandl.NET.Model.Enum;
using System;

namespace Quandl.NET.Helper
{
    internal static class CodeExtension
    {
        public static Tuple<string, string> ToPair(this DatatableCode code)
        {
            var pair = code.ToEnumMemberValue().Split('_');
            return new Tuple<string, string>(pair[0], pair[1]);
        }

        public static Tuple<string, string> ToPair(this DatasetCode code)
        {
            var pair = code.ToEnumMemberValue().Split('_');
            return new Tuple<string, string>(pair[0], pair[1]);
        }
    }
}