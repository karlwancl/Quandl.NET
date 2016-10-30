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
using System.Threading.Tasks;

namespace Quandl.NET.Refit
{
    interface IDatabaseApi
    {
        [Get("/databases/{database_code}/data")]
        Task<HttpContent> GetEntireDatabaseAsync(string database_code, DownloadType? download_type, string api_key);

        [Get("/databases/{database_code}.{return_format}")]
        Task<GetDatabaseMetadataResponse> GetDatabaseMetadataAsync(string database_code, ReturnFormat return_format, string api_key);

        [Get("/databases.{return_format}")]
        Task<GetListOfDatabasesResponse> GetListOfDatabasesAsync(ReturnFormat return_format, string query, int? per_page, int? page, string api_key);

        [Get("/databases/{database_code}/codes.csv")]
        Task<HttpContent> GetListOfDatabaseContentsAsync(string database_code, string api_key);
    }

    interface IDatatableApi
    {
        [Get("/datatables/{datatable_code}.{format}")]
        Task<GetDatatableResponse> GetDatatableAsync(string datatable_code, ReturnFormat format, Dictionary<string, string> rowFilter, [AliasAs("qopts.columns")]string columnFilter, string api_key);
    }

    interface IDatasetApi
    {
        [Get("/datasets/{database_code}/{dataset_code}/data.{return_format}")]
        Task<GetDataResponse> GetDataAsync(string database_code, string dataset_code, ReturnFormat return_format, string api_key);

        [Get("/datasets/{database_code}/{dataset_code}/metadata.{return_format}")]
        Task<GetDatasetMetadataResponse> GetDatasetMetadataAsync(string database_code, string dataset_code, ReturnFormat return_format, string api_key);

        [Get("/datasets/{database_code}/{dataset_code}.{return_format}")]
        Task<GetDataAndMetadataResponse> GetDataAndMetadataAsync(string database_code, string dataset_code, ReturnFormat return_format, int? limit, int? column_index,
            DateTime? start_date, DateTime? end_date, Order? order, Collapse? collapse, Transform? transform, string api_key);

        [Get("/datasets.{return_format}")]
        Task<GetDatasetResponse> GetDatasetAsync(ReturnFormat return_format, string query, string database_code, int? per_page, int? page, string api_key);
    }
}
