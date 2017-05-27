using Flurl;
using Flurl.Http;
using Quandl.NET.Helper;
using Quandl.NET.Model.Response;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Quandl.NET
{
    public class Tables : QuandlApiBase
    {
        public Tables(string apiKey) : base(apiKey)
        {
        }

        /// <summary>
        /// You can filter on both rows and columns by appending both filter types to your API request.
        /// <a href="https://docs.quandl.com/docs/in-depth-usage-1#section-filter-rows-and-columns">Reference</a>
        /// </summary>
        /// <param name="datatableCode">Short code for datatable</param>
        /// <param name="rowFilterCriteria">Criteria to filter row, value is ampersand-seperated.</param>
        /// <param name="columnFilterCriteria">Criteria to filter column, value is comma-seperated.</param>
        /// <param name="perPage">The number of results per page that can be returned, to a maximum of 10,000 rows. (Large tables will be displayed over several pages.)</param>
        /// <param name="cursorId">Each API call returns a unique cursor ID that identifies the next page of the table. Including the cursor ID in your API call will allow you to page through the table. A null cursor ID means that the current page will be the last page of the table. For more on downloading entire tables, click here.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Filtered table</returns>
        public async Task<TableResponse> GetAsync(string datatableCode, string rowFilterCriteria = null, string columnFilterCriteria = null,
                                                  int? perPage = null, int? cursorId = null, CancellationToken token = default(CancellationToken))
        {
            try
            {
                return await $"{Constant.HostUri}/datatables/{datatableCode}.json"
                    .SetQueryParamForEach(Filter.Parse(rowFilterCriteria))
                    .SetQueryParam("qopts.columns", columnFilterCriteria)
                    .SetQueryParam("qopts.per_page", perPage)
                    .SetQueryParam("qopts.cursor_id", cursorId)
                    .SetQueryParam("api_key", _apiKey)
                    .GetAsync(token)
                    .ReceiveJson<TableResponse>()
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// You can filter on both rows and columns by appending both filter types to your API request.
        /// <a href="https://docs.quandl.com/docs/in-depth-usage-1#section-filter-rows-and-columns">Reference</a>
        /// </summary>
        /// <param name="datatableCode">Short code for datatable</param>
        /// <param name="returnFormat">Return format</param>
        /// <param name="rowFilterCriteria">Criteria to filter row, value is ampersand-seperated.</param>
        /// <param name="columnFilterCriteria">Criteria to filter column, value is comma-seperated.</param>
        /// <param name="export">Good for large queries; the data requested will be packaged into a zip file for download.</param>
        /// <param name="perPage">The number of results per page that can be returned, to a maximum of 10,000 rows. (Large tables will be displayed over several pages.)</param>
        /// <param name="cursorId">Each API call returns a unique cursor ID that identifies the next page of the table. Including the cursor ID in your API call will allow you to page through the table. A null cursor ID means that the current page will be the last page of the table. For more on downloading entire tables, click here.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Filtered table</returns>
        public async Task<Stream> GetAsync(string datatableCode, ReturnFormat returnFormat, string rowFilterCriteria = null, string columnFilterCriteria = null,
                                           bool? export = null, int? perPage = null, int? cursorId = null, CancellationToken token = default(CancellationToken))
        {
            try
            {
                return await $"{Constant.HostUri}/datatables/{datatableCode}.{returnFormat.ToEnumMemberValue()}"
                    .SetQueryParamForEach(Filter.Parse(rowFilterCriteria))
                    .SetQueryParam("qopts.columns", columnFilterCriteria)
                    .SetQueryParam("qopts.export", export)
                    .SetQueryParam("qopts.per_page", perPage)
                    .SetQueryParam("qopts.cursor_id", cursorId)
                    .SetQueryParam("api_key", _apiKey)
                    .GetAsync(token)
                    .ReceiveStream()
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// Get table metadata
        /// <a href="https://docs.quandl.com/docs/in-depth-usage-1#section-get-table-metadata">Reference</a>
        /// </summary>
        /// <param name="datatableCode">Short code for datatable</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Table metadata</returns>
        public async Task<TableMetadataResponse> GetMetadataAsync(string datatableCode, CancellationToken token = default(CancellationToken))
        {
            try
            {
                return await $"{Constant.HostUri}/datatables/{datatableCode}/metadata.json"
                    .SetQueryParam("api_key", _apiKey)
                    .GetAsync(token)
                    .ReceiveJson<TableMetadataResponse>()
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// Get table metadata
        /// <a href="https://docs.quandl.com/docs/in-depth-usage-1#section-get-table-metadata">Reference</a>
        /// </summary>
        /// <param name="datatableCode">Short code for datatable</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Table metadata</returns>
        public async Task<Stream> GetMetadataAsync(string datatableCode, ReturnFormat returnFormat, CancellationToken token = default(CancellationToken))
        {
            try
            {
                return await $"{Constant.HostUri}/datatables/{datatableCode}/metadata.{returnFormat.ToEnumMemberValue()}"
                    .SetQueryParam("api_key", _apiKey)
                    .GetAsync(token)
                    .ReceiveStream()
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// An API call that does not include any filter will, by default, attempt to download the entire table.
        /// <a href="https://docs.quandl.com/docs/in-depth-usage-1#section-download-an-entire-table">Reference</a>
        /// </summary>
        /// <returns>Entire table</returns>
        /// <param name="datatableCode">Short code for datatable</param>
        /// <param name="token">Cancellation token</param>
        public async Task<Stream> DownloadAsync(string datatableCode, CancellationToken token = default(CancellationToken))
        {
            try
            {
                return await $"{Constant.HostUri}/datatables/{datatableCode}"
                    .SetQueryParam("qopts.export", true.ToString())
                    .SetQueryParam("api_key", _apiKey)
                    .GetAsync(token)
                    .ReceiveStream()
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToQuandlException();
            }
        }
    }
}