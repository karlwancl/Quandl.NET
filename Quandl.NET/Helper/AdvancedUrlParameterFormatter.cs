using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Quandl.NET.Helper
{
    class AdvancedUrlParameterFormatter : IUrlParameterFormatter
    {
        public string Format(object value, ParameterInfo parameterInfo)
        {
            if (value == null)
                return null;

            return value is Enum ? ((Enum)value).ToEnumMemberValue() : value.ToString();
        }
    }
}
