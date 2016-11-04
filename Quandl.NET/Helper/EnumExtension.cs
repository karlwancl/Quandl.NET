using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Quandl.NET.Helper
{
    internal static class EnumExtension
    {
        public static string ToEnumMemberValue(this Enum value)
        {
            if (value == null)
                return null;

            string valueToReturn = value.ToString();

            var valueType = value.GetType();

            if (valueType.GetTypeInfo().IsGenericType && valueType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                valueType = valueType.GetGenericArguments()[0];

            var valueEnumMember = valueType.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(fi => fi.Name.Equals(value.ToString()))
                .First()
                .GetCustomAttribute<EnumMemberAttribute>();

            if (valueEnumMember != null && valueEnumMember.IsValueSetExplicitly)
                valueToReturn = valueEnumMember.Value;

            return valueToReturn;
        }
    }
}