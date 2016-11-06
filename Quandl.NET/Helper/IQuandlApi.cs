using Quandl.NET.Model.Enum;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Quandl.NET.Helper
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    internal interface IDatabaseApi
    {
        [Get("/databases/{database_code}/data")]
        Task<HttpResponseMessage> GetAsync([Path]string database_code, DownloadType? download_type, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/databases/{database_code}.{return_format}")]
        Task<HttpResponseMessage> GetMetadataAsync([Path]string database_code, [Path]string return_format, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/databases.{return_format}")]
        Task<HttpResponseMessage> GetListAsync([Path]string return_format, string query, int? per_page, int? page, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/databases/{database_code}/codes.csv")]
        Task<HttpResponseMessage> GetDatasetListAsync([Path]string database_code, string api_key, CancellationToken token = default(CancellationToken));
    }

    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    internal interface IDatatableApi
    {
        [Get("/datatables/{database_code}/{datatable_code}/metadata.{return_format}")]
        Task<HttpResponseMessage> GetMetadataAsync([Path]string database_code, [Path]string datatable_code, [Path]string return_format, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/datatables/{database_code}/{datatable_code}.{return_format}")]
        Task<HttpResponseMessage> GetAsync([Path]string database_code, [Path]string datatable_code, [Path]string return_format, [QueryMap]Dictionary<string, string> row_filter, [Query("qopts.columns")]string column_filter, 
            [Query("qopts.export")]bool? full_result, [Query("qopts.cursor_id")]int? next_cursor_id, string api_key, CancellationToken token = default(CancellationToken));
    }

    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    internal interface IDatasetApi
    {
        [Get("/datasets/{database_code}/{dataset_code}/data.{return_format}")]
        Task<HttpResponseMessage> GetAsync([Path]string database_code, [Path]string dataset_code, [Path]string return_format, int? limit, int? column_index,
            DateTime? start_date, DateTime? end_date, Order? order, Collapse? collapse, Transform? transform, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/datasets/{database_code}/{dataset_code}/metadata.{return_format}")]
        Task<HttpResponseMessage> GetMetadataAsync([Path]string database_code, [Path]string dataset_code, [Path]string return_format, int? limit, int? column_index,
            DateTime? start_date, DateTime? end_date, Order? order, Collapse? collapse, Transform? transform, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/datasets/{database_code}/{dataset_code}.{return_format}")]
        Task<HttpResponseMessage> GetDataAndMetadataAsync([Path]string database_code, [Path]string dataset_code, [Path]string return_format, int? limit, int? column_index,
            DateTime? start_date, DateTime? end_date, Order? order, Collapse? collapse, Transform? transform, string api_key, CancellationToken token = default(CancellationToken));

        [Get("/datasets.{return_format}")]
        Task<HttpResponseMessage> GetListAsync([Path]string return_format, string query, string database_code, int? per_page, int? page, string api_key, CancellationToken token = default(CancellationToken));
    }
}