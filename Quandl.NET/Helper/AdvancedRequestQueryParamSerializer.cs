using RestEase;
using System;
using System.Collections.Generic;

namespace Quandl.NET.Helper
{
    public class AdvancedRequestQueryParamSerializer : IRequestQueryParamSerializer
    {
        public IEnumerable<KeyValuePair<string, string>> SerializeQueryCollectionParam<T>(string name, IEnumerable<T> values)
        {
            if (values == null)
                yield break;

            foreach (var value in values)
            {
                if (value != null)
                    yield return new KeyValuePair<string, string>(name, value is Enum ? ((Enum)(object)value).ToEnumMemberValue() : value.ToString());
            }
        }

        public IEnumerable<KeyValuePair<string, string>> SerializeQueryParam<T>(string name, T value)
        {
            if (value == null)
                yield break;

            yield return new KeyValuePair<string, string>(name, value is Enum ? ((Enum)(object)value).ToEnumMemberValue() : value.ToString());
        }
    }
}