using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Quandl.NET.Exception;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quandl.NET.Helper
{
    internal static class FlurlExtension
    {
        public static async Task<System.Exception> ToQuandlExceptionAsync(this FlurlHttpException ex)
        {
            var str = await ex.GetResponseStringAsync();
            if (!string.IsNullOrWhiteSpace(str) && str.Contains("quandl_error"))
            {
                dynamic content = JsonConvert.DeserializeObject(str);
                return new QuandlException(content.quandl_error.code.ToString(), content.quandl_error.message.ToString());
            }
            return ex;
        }

        public static Url SetQueryParamForEach(this string url, Dictionary<string, string> dict)
        {
            if (dict == null)
                return url;

            Url urlToReturn = url;
            foreach (var kvp in dict)
            {
                urlToReturn = urlToReturn.SetQueryParam(kvp.Key, kvp.Value);
            }
            return urlToReturn;
        }
    }
}