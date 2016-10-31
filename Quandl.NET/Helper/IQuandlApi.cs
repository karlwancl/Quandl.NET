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

namespace Quandl.NET.Helper
{
    interface IDatabaseApi
    {
        [Get("/databases/{database_code}/data")]
        Task<HttpContent> GetAsync(string database_code, DownloadType? download_type, string api_key);

        [Get("/databases/{database_code}.{return_format}")]
        Task<HttpContent> GetMetadataAsync(string database_code, ReturnFormat return_format, string api_key);

        [Get("/databases.{return_format}")]
        Task<HttpContent> GetListAsync(ReturnFormat return_format, string query, int? per_page, int? page, string api_key);

        [Get("/databases/{database_code}/codes.csv")]
        Task<HttpContent> GetDatasetListAsync(string database_code, string api_key);
    }

    interface IDatatableApi
    {
        //[Get("/datatables/{datatable_code}.{format}")]
        //Task<HttpContent> GetAsync(string datatable_code, ReturnFormat format, Dictionary<string, string> rowFilter, [AliasAs("qopts.columns")]string columnFilter, [AliasAs("qopts.export")]bool? full_result, [AliasAs("qopts.cursor_id")]int? next_cursor_id, string api_key);

        [Get("/datatables/{datatable_code_1}/{datatable_code_2}.{format}")]
        Task<HttpContent> GetAsync(string datatable_code_1, string datatable_code_2, ReturnFormat format, Dictionary<string, string> rowFilter, [AliasAs("qopts.columns")]string columnFilter, [AliasAs("qopts.export")]bool? full_result, [AliasAs("qopts.cursor_id")]int? next_cursor_id, string api_key);
    }

    interface IDatasetApi
    {
        [Get("/datasets/{database_code}/{dataset_code}/data.{return_format}")]
        Task<HttpContent> GetAsync(string database_code, string dataset_code, ReturnFormat return_format, string api_key);

        [Get("/datasets/{database_code}/{dataset_code}/metadata.{return_format}")]
        Task<HttpContent> GetMetadataAsync(string database_code, string dataset_code, ReturnFormat return_format, string api_key);

        [Get("/datasets/{database_code}/{dataset_code}.{return_format}")]
        Task<HttpContent> GetDataAndMetadataAsync(string database_code, string dataset_code, ReturnFormat return_format, int? limit, int? column_index,
            DateTime? start_date, DateTime? end_date, Order? order, Collapse? collapse, Transform? transform, string api_key);

        [Get("/datasets.{return_format}")]
        Task<HttpContent> GetListAsync(ReturnFormat return_format, string query, string database_code, int? per_page, int? page, string api_key);
    }
}
