using Newtonsoft.Json;
using Quandl.NET.Exception;
using Quandl.NET.Model.Enum;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;

namespace Quandl.NET.Helper
{
    internal interface IDatabaseApi
    {
        [Get("/databases/{database_code}/data")]
        Task<HttpContent> GetAsync(string database_code, DownloadType? download_type, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/databases/{database_code}.{return_format}")]
        Task<HttpContent> GetMetadataAsync(string database_code, ReturnFormat return_format, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/databases.{return_format}")]
        Task<HttpContent> GetListAsync(ReturnFormat return_format, string query, int? per_page, int? page, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/databases/{database_code}/codes.csv")]
        Task<HttpContent> GetDatasetListAsync(string database_code, string api_key, CancellationToken token = default(CancellationToken));
    }

    internal interface IDatatableApi
    {
        [Get("/datatables/{database_code}/{datatable_code}/metadata.{return_format}")]
        Task<HttpContent> GetMetadataAsync(string database_code, string datatable_code, ReturnFormat return_format, string api_key, CancellationToken token = default(CancellationToken));
    }

    /// <summary>
    /// Interface for non-refit implementation, since dynamic query parameters is not available for refit
    /// </summary>
    interface IDatatableApiNonRefit
    {
        Task<HttpContent> GetAsync(string database_code, string datatable_code, ReturnFormat return_format, Dictionary<string, string> row_filter, string column_filter, bool? full_result, int? next_cursor_id, string api_key, CancellationToken token = default(CancellationToken));
    }

    internal class DatatableApiNonRefit : IDatatableApiNonRefit
    {
        public async Task<HttpContent> GetAsync(string database_code, string datatable_code, ReturnFormat return_format, Dictionary<string, string> row_filter, string column_filter, bool? full_result, int? next_cursor_id, string api_key, CancellationToken token = default(CancellationToken))
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                var baseAddress = $"{Constant.HostUri}/datatables/{database_code}/{datatable_code}.{return_format.ToEnumMemberValue()}";

                var queryBuilder = new StringBuilder();

                if (column_filter != null)
                    queryBuilder.Append($"qopts.columns={UrlEncoder.Default.Encode(column_filter)}&");

                if (row_filter != null)
                {
                    foreach (var row in row_filter)
                    {
                        queryBuilder.Append($"{UrlEncoder.Default.Encode(row.Key)}={UrlEncoder.Default.Encode(row.Value)}&");
                    }
                }

                if (full_result.HasValue)
                    queryBuilder.Append($"qopts.export={full_result.Value}&");

                if (next_cursor_id.HasValue)
                    queryBuilder.Append($"qopts.cursor_id={next_cursor_id.Value}&");

                queryBuilder.Append($"api_key={api_key}");

                var response = await client.GetAsync($"{baseAddress}?{queryBuilder}", token).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Maybe a problem of wrong datatable_code in the uri, let's assume it is a wrong datatable_code if it occurs
                        throw new QuandlException("QECx02", "You have submitted an incorrect Quandl code. Please check your Quandl codes and try again.");
                    }
                    else if (response.Content != null)
                    {
                        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        if (!string.IsNullOrEmpty(content) && content.Contains("quandl_error"))
                        {
                            dynamic quandl_error_content = JsonConvert.DeserializeObject(content);
                            throw new QuandlException(quandl_error_content.quandl_error.code.ToString(), quandl_error_content.quandl_error.message.ToString());
                        }
                    }
                }
                response.EnsureSuccessStatusCode();
                return response.Content;
            }
        }
    }

    internal interface IDatasetApi
    {
        [Get("/datasets/{database_code}/{dataset_code}/data.{return_format}")]
        Task<HttpContent> GetAsync(string database_code, string dataset_code, ReturnFormat return_format, int? limit, int? column_index,
            DateTime? start_date, DateTime? end_date, Order? order, Collapse? collapse, Transform? transform, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/datasets/{database_code}/{dataset_code}/metadata.{return_format}")]
        Task<HttpContent> GetMetadataAsync(string database_code, string dataset_code, ReturnFormat return_format, int? limit, int? column_index,
            DateTime? start_date, DateTime? end_date, Order? order, Collapse? collapse, Transform? transform, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/datasets/{database_code}/{dataset_code}.{return_format}")]
        Task<HttpContent> GetDataAndMetadataAsync(string database_code, string dataset_code, ReturnFormat return_format, int? limit, int? column_index,
            DateTime? start_date, DateTime? end_date, Order? order, Collapse? collapse, Transform? transform, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/datasets.{return_format}")]
        Task<HttpContent> GetListAsync(ReturnFormat return_format, string query, string database_code, int? per_page, int? page, string api_key, CancellationToken token = default(CancellationToken));
    }
}