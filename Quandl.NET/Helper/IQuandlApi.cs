using Quandl.NET.Model;
using Quandl.NET.Model.Enum;
using Quandl.NET.Model.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quandl.NET.Helper
{
    interface IDatabaseApi
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

    interface IDatatableApi
    {
        // Fallback to HttpClient since refit doesn't support dynamic query parameters & url parameter with slash
    }

    interface IDatasetApi
    {
        [Get("/datasets/{database_code}/{dataset_code}/data.{return_format}")]
        Task<HttpContent> GetAsync(string database_code, string dataset_code, ReturnFormat return_format, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/datasets/{database_code}/{dataset_code}/metadata.{return_format}")]
        Task<HttpContent> GetMetadataAsync(string database_code, string dataset_code, ReturnFormat return_format, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/datasets/{database_code}/{dataset_code}.{return_format}")]
        Task<HttpContent> GetDataAndMetadataAsync(string database_code, string dataset_code, ReturnFormat return_format, int? limit, int? column_index,
            DateTime? start_date, DateTime? end_date, Order? order, Collapse? collapse, Transform? transform, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/datasets.{return_format}")]
        Task<HttpContent> GetListAsync(ReturnFormat return_format, string query, string database_code, int? per_page, int? page, string api_key, CancellationToken token = default(CancellationToken));
    }
}
