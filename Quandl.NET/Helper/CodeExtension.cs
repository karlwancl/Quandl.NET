using Quandl.NET.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Helper
{
    static class CodeExtension
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
