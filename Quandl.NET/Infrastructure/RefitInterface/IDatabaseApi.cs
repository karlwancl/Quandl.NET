using Quandl.NET.Core;
using Quandl.NET.Core.Enum;
using Quandl.NET.Core.Response;
using Quandl.NET.Infrastructure.Attribute;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Infrastructure.RefitInterface
{
    interface IDatabaseApi
    {
        [CsvOnly, Get("/databases/{database_code}/data")]
        Task<Stream> GetEntireDatabaseAsync([AliasAs("database_code")]string databaseCode, [AliasAs("download_type")]DownloadType? downloadType, [AliasAs("api_key")]string apiKey);

        [Get("/databases/{database_code}.{return_format}")]
        Task<GetDatabaseMetadataResponse> GetDatabaseMetadataAsync([AliasAs("database_code")]string databaseCode, [AliasAs("return_format")]ReturnFormat returnFormat, [AliasAs("api_key")]string apiKey);

        [Get("/databases.{return_format}")]
        Task<GetListOfDatabasesResponse> GetListOfDatabasesAsync([AliasAs("return_format")]ReturnFormat returnFormat, [AliasAs("per_page")]int? perPage, int? page, [AliasAs("api_key")]string apiKey);

        [CsvOnly, Get("/databases/{database_code}/codes.csv")]
        Task<Stream> GetListOfDatabaseContentsAsync([AliasAs("database_code")]string databaseCode, [AliasAs("api_key")]string apiKey);

        [Get("/databases.{return_format}")]
        Task<SearchForDatabasesResponse> SearchForDatabasesAsync([AliasAs("return_format")]ReturnFormat returnFormat, string query, [AliasAs("per_page")]int? perPage, int? page, [AliasAs("api_key")]string apiKey);
    }
}
