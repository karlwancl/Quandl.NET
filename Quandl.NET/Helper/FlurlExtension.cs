using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Quandl.NET.Exception;
using System.Collections.Generic;

namespace Quandl.NET.Helper
{
    internal static class FlurlExtension
    {
        public static QuandlException ToQuandlException(this FlurlHttpException ex)
        {
            dynamic content = JsonConvert.DeserializeObject(ex.GetResponseString());
            return new QuandlException(content.quandl_error.code.ToString(), content.quandl_error.message.ToString());
        }

        public static Url SetQueryParamForEach(this string url, Dictionary<string, string> dict)
        {
            Url urlToReturn = url;
            foreach (var kvp in dict)
            {
                urlToReturn = urlToReturn.SetQueryParam(kvp.Key, kvp.Value);
            }
            return urlToReturn;
        }
    }
}