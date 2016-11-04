using Refit;
using System;
using System.Reflection;

namespace Quandl.NET.Helper
{
    internal class AdvancedUrlParameterFormatter : IUrlParameterFormatter
    {
        public string Format(object value, ParameterInfo parameterInfo)
        {
            if (value == null)
                return null;

            return value is Enum ? ((Enum)value).ToEnumMemberValue() : value.ToString();
        }
    }
}