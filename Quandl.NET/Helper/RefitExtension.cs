using Newtonsoft.Json;
using Quandl.NET.Exception;

namespace Quandl.NET.Helper
{
    internal static class RefitExtension
    {
        public static QuandlException ToQuandlException(this Refit.ApiException ex)
        {
            dynamic content = JsonConvert.DeserializeObject(ex.Content);
            return new QuandlException(content.quandl_error.code.ToString(), content.quandl_error.message.ToString());
        }
    }
}