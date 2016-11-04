using Newtonsoft.Json;
using Quandl.NET.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Helper
{
    static class RefitExtension
    {
        public static QuandlException ToQuandlException(this Refit.ApiException ex)
        {
            dynamic content = JsonConvert.DeserializeObject(ex.Content);
            return new QuandlException(content.quandl_error.code.ToString(), content.quandl_error.message.ToString());
        }
    }
}
