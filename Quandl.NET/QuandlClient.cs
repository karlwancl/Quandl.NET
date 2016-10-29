using Quandl.NET.Core;
using Quandl.NET.Core.Enum;
using Quandl.NET.Core.Response;
using Quandl.NET.Infrastructure.Refit;
using Quandl.NET.Infrastructure.RefitInterface;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET
{
    static class Constant { public const string HostUri = "https://www.quandl.com/api/v3"; }

    public class QuandlClient
    {
        public QuandlClient(string apiKey)
        {
            Database = new DatabaseApi(apiKey);
            Datatable = new DatatableApi(apiKey);
            Dataset = new DatasetApi(apiKey);
        }

        public DatabaseApi Database { get; private set; }

        public DatatableApi Datatable { get; private set; }

        public DatasetApi Dataset { get; private set; }
    }

    public abstract class QuandlApiBase
    {
        protected string _apiKey;

        protected QuandlApiBase(string apiKey)
        {
            _apiKey = apiKey;
        }
    }

    public class DatabaseApi : QuandlApiBase
    {
        private IDatabaseApi _api;

        public DatabaseApi(string apiKey) : base(apiKey)
        {
            _api = RestService.For<IDatabaseApi>(Constant.HostUri,
                new RefitSettings
                {
                    UrlParameterFormatter = new LowercaseEnumUrlParameterFormatter()
                });
        }

        /// <summary>
        /// You can download an entire database in a single call using this method. Simply append /data to your database code, to get a zipped CSV file of the entire database.
        /// Reference: https://www.quandl.com/docs/api?csv#get-entire-database
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="downloadType">If “partial”, returns last day of data. If “complete”, returns entire database. Default is “complete”.</param>
        /// <returns>Zipped csv file stream</returns>
        public async Task<Stream> GetEntireDatabaseAsync(string databaseCode, DownloadType? downloadType = null)
            => await _api.GetEntireDatabaseAsync(databaseCode, downloadType, _apiKey);

        /// <summary>
        /// Use this call to get metadata for a specified database.
        /// Reference: https://www.quandl.com/docs/api?json#get-database-metadata
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <returns>Metadata response</returns>
        public async Task<GetDatabaseMetadataResponse> GetDatabaseMetadataAsync(string databaseCode)
            => await _api.GetDatabaseMetadataAsync(databaseCode, ReturnFormat.Json, _apiKey);

        /// <summary>
        /// Use this call to get a list of all databases on Quandl, along with their respective metadata.
        /// Reference: https://www.quandl.com/docs/api?json#get-list-of-databases
        /// </summary>
        /// <param name="perPage">Number of search results per page</param>
        /// <param name="page">Page number to return</param>
        /// <returns>List of databases response</returns>
        public async Task<GetListOfDatabasesResponse> GetListOfDatabasesAsync(int? perPage = null, int? page = null)
            => await _api.GetListOfDatabasesAsync(ReturnFormat.Json, perPage, page, _apiKey);

        /// <summary>
        /// For databases that support the datasets API route, this call gets a list of available datasets within the database, in the form of a zipped CSV file.
        /// Reference: https://www.quandl.com/docs/api?json#get-list-of-database-contents
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <returns>Zipped csv file stream</returns>
        public async Task<Stream> GetListOfDatabaseContentsAsync(string databaseCode)
            => await _api.GetListOfDatabaseContentsAsync(databaseCode, _apiKey);

        /// <summary>
        /// You can search for specific databases on Quandl using this API route. The API will return all databases related to your query.
        /// Reference: https://www.quandl.com/docs/api?json#search-for-databases
        /// </summary>
        /// <param name="query">Search keywords. Separate multiple keywords with a + character.</param>
        /// <param name="perPage">Number of search results per page.</param>
        /// <param name="page">Page number to return.</param>
        /// <returns>Search for databases response</returns>
        public async Task<SearchForDatabasesResponse> SearchForDatabasesAsync(string query, int? perPage = null, int? page = null)
            => await _api.SearchForDatabasesAsync(ReturnFormat.Json, query, perPage, page, _apiKey);
    }

    public class DatatableApi : QuandlApiBase
    {
        public DatatableApi(string apiKey) : base(apiKey) { }
    }

    public class DatasetApi : QuandlApiBase
    {
        public DatasetApi(string apiKey) : base(apiKey) { }
    }
}
