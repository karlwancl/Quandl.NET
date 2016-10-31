using Newtonsoft.Json;
using Quandl.NET.Model;
using Quandl.NET.Model.Enum;
using Quandl.NET.Model.Response;
using Quandl.NET.Refit;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET
{
    static class Constant
    {
        public const string HostUri = "https://www.quandl.com/api/v3";
    }

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
        /// <a href="https://www.quandl.com/docs/api?csv#get-entire-database">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="downloadType">If “partial”, returns last day of data. If “complete”, returns entire database. Default is “complete”.</param>
        /// <returns>Stream of zipped csv file (.zip)</returns>
        public async Task<Stream> GetZipAsync(string databaseCode, DownloadType? downloadType = null)
        {
            var content = await _api.GetAsync(databaseCode, downloadType, _apiKey);
            return await content.ReadAsStreamAsync();
        }

        /// <summary>
        /// Use this call to get metadata for a specified database.
        /// <a href="https://www.quandl.com/docs/api?json#get-database-metadata">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <returns>Get database metadata response</returns>
        public async Task<GetDatabaseMetadataResponse> GetMetadataAsync(string databaseCode)
        {
            var content = await _api.GetMetadataAsync(databaseCode, ReturnFormat.Json, _apiKey);
            var json = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetDatabaseMetadataResponse>(json);
        }

        /// <summary>
        /// Use this call to get metadata for a specified database.
        /// <a href="https://www.quandl.com/docs/api?csv#get-database-metadata">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetMetadataCsvAsync(string databaseCode)
        {
            var content = await _api.GetMetadataAsync(databaseCode, ReturnFormat.Csv, _apiKey);
            return await content.ReadAsStreamAsync();
        }

        /// <summary>
        /// You can search for specific databases on Quandl using this API route. The API will return all databases related to your query.
        /// <a href="https://www.quandl.com/docs/api?json#search-for-databases">Reference</a>
        /// </summary>
        /// <param name="query">Search keywords. Separate multiple keywords with a + character.</param>
        /// <param name="perPage">Number of search results per page</param>
        /// <param name="page">Page number to return</param>
        /// <returns>Get database list response</returns>
        public async Task<GetDatabaseListResponse> GetListAsync(string query = null, int? perPage = null, int? page = null)
        {
            var content = await _api.GetListAsync(ReturnFormat.Json, query, perPage, page, _apiKey);
            var json = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetDatabaseListResponse>(json);
        }

        /// <summary>
        /// You can search for specific databases on Quandl using this API route. The API will return all databases related to your query.
        /// <a href="https://www.quandl.com/docs/api?csv#search-for-databases">Reference</a>
        /// </summary>
        /// <param name="query">Search keywords. Separate multiple keywords with a + character.</param>
        /// <param name="perPage">Number of search results per page</param>
        /// <param name="page">Page number to return</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetListCsvAsync(string query = null, int? perPage = null, int? page = null)
        {
            var content = await _api.GetListAsync(ReturnFormat.Csv, query, perPage, page, _apiKey);
            return await content.ReadAsStreamAsync();
        }

        /// <summary>
        /// For databases that support the datasets API route, this call gets a list of available datasets within the database, in the form of a zipped CSV file.
        /// <a href="https://www.quandl.com/docs/api?csv#get-list-of-database-contents">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <returns>Stream of zipped csv file (.zip)</returns>
        public async Task<Stream> GetDatasetListZipAsync(string databaseCode)
        {
            var content = await _api.GetDatasetListAsync(databaseCode, _apiKey);
            return await content.ReadAsStreamAsync();
        }
    }

    public class DatatableApi : QuandlApiBase
    {
        private IDatatableApi _api;

        public DatatableApi(string apiKey) : base(apiKey)
        {
            _api = RestService.For<IDatatableApi>(Constant.HostUri,
                new RefitSettings
                {
                    UrlParameterFormatter = new LowercaseEnumUrlParameterFormatter()
                });
        }

        // TODO: Test if using dictionary for query map works
        /// <summary>
        /// This API call returns a datatable, subject to a limit of 10,000 rows.
        /// <a href="https://www.quandl.com/docs/api?json#search-for-databases">Reference</a>
        /// </summary>
        /// <param name="datatableCode1">first part of short code for datatable</param>
        /// <param name="datatableCode2">second part of short code for datatable</param>
        /// <param name="rowFilter">Criteria to filter row</param>
        /// <param name="columnFilter">Criteria to filter column</param>
        /// <returns>Get datatable response</returns>
        public async Task<GetDatatableResponse> GetAsync(string datatableCode1, string datatableCode2, Dictionary<string, string> rowFilter = null, string columnFilter = null)
        {
            var content =  await _api.GetAsync(datatableCode1, datatableCode2, ReturnFormat.Json, rowFilter, columnFilter, null, _apiKey);
            var json = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetDatatableResponse>(json);
        }

        // TODO: Test if using dictionary for query map works
        /// <summary>
        /// This API call returns a datatable, subject to a limit of 10,000 rows.
        /// <a href="https://www.quandl.com/docs/api?csv#search-for-databases">Reference</a>
        /// </summary>
        /// <param name="datatableCode1">first part of short code for datatable</param>
        /// <param name="datatableCode2">second part of short code for datatable</param>
        /// <param name="rowFilter">Criteria to filter row</param>
        /// <param name="columnFilter">Criteria to filter column</param>
        /// <param name="fullResult">Flag to display full result</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetCsvAsync(string datatableCode1, string datatableCode2, Dictionary<string, string> rowFilter = null, string columnFilter = null, bool? fullResult = null)
        {
            var content = await _api.GetAsync(datatableCode1, datatableCode2, ReturnFormat.Csv, rowFilter, columnFilter, fullResult, _apiKey);
            return await content.ReadAsStreamAsync();
        }
    }

    public class DatasetApi : QuandlApiBase
    {
        private IDatasetApi _api;

        public DatasetApi(string apiKey) : base(apiKey)
        {
            _api = RestService.For<IDatasetApi>(Constant.HostUri,
                new RefitSettings
                {
                    UrlParameterFormatter = new LowercaseEnumUrlParameterFormatter()
                });
        }

        /// <summary>
        /// This call returns data from a specified dataset.
        /// <a href="https://www.quandl.com/docs/api?json#get-data">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="datasetCode">short code for dataset</param>
        /// <returns>Get dataset response</returns>
        public async Task<GetDatasetResponse> GetAsync(string databaseCode, string datasetCode)
        {
            var content = await _api.GetAsync(databaseCode, datasetCode, ReturnFormat.Json, _apiKey);
            var json = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetDatasetResponse>(json);
        }

        /// <summary>
        /// This call returns data from a specified dataset.
        /// <a href="https://www.quandl.com/docs/api?csv#get-data">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="datasetCode">short code for dataset</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetCsvAsync(string databaseCode, string datasetCode)
        {
            var content = await _api.GetAsync(databaseCode, datasetCode, ReturnFormat.Csv, _apiKey);
            return await content.ReadAsStreamAsync();
        }

        /// <summary>
        /// This call returns metadata for a specified dataset.
        /// <a href="https://www.quandl.com/docs/api?json#get-metadata">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="datasetCode">short code for dataset</param>
        /// <returns>Get dataset metadata response</returns>
        public async Task<GetDatasetMetadataResponse> GetMetadataAsync(string databaseCode, string datasetCode)
        {
            var content = await _api.GetMetadataAsync(databaseCode, datasetCode, ReturnFormat.Json, _apiKey);
            var json = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetDatasetMetadataResponse>(json);
        }

        /// <summary>
        /// This call returns metadata for a specified dataset.
        /// <a href="https://www.quandl.com/docs/api?csv#get-metadata">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="datasetCode">short code for dataset</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetMetadataCsvAsync(string databaseCode, string datasetCode)
        {
            var content = await _api.GetMetadataAsync(databaseCode, datasetCode, ReturnFormat.Csv, _apiKey);
            return await content.ReadAsStreamAsync();
        }

        /// <summary>
        /// This call returns data and metadata for a given dataset. 
        /// <a href="https://www.quandl.com/docs/api?json#get-data-and-metadata">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="datasetCode">short code for dataset</param>
        /// <param name="limit">Use limit=n to get the first n rows of the dataset. Use limit=1 to get just the latest row.</param>
        /// <param name="columnIndex">Request a specific column. Column 0 is the date column and is always returned. Data begins at column 1.</param>
        /// <param name="startDate">Retrieve data rows on and after the specified start date.</param>
        /// <param name="endDate">Retrieve data rows up to and including the specified end date.</param>
        /// <param name="order">Return data in ascending or descending order of date. Default is “desc”.</param>
        /// <param name="collapse">Change the sampling frequency of the returned data. Default is “none” i.e. data is returned in its original granularity.</param>
        /// <param name="transform">Perform elementary calculations on the data prior to downloading. Default is “none”. Calculation options are described below.</param>
        /// <returns>Get data and metadata response</returns>
        public async Task<GetDataAndMetadataResponse> GetDataAndMetadataAsync(string databaseCode, string datasetCode, int? limit = null, int? columnIndex = null,
            DateTime? startDate = null, DateTime? endDate = null, Order? order = null, Collapse? collapse = null, Transform? transform = null)
        {
            var content = await _api.GetDataAndMetadataAsync(databaseCode, datasetCode, ReturnFormat.Json, limit, columnIndex, startDate, endDate, order, collapse, transform, _apiKey);
            var json = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetDataAndMetadataResponse>(json);
        }

        /// <summary>
        /// This call returns data and metadata for a given dataset. 
        /// <a href="https://www.quandl.com/docs/api?json#get-data-and-metadata">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="datasetCode">short code for dataset</param>
        /// <param name="limit">Use limit=n to get the first n rows of the dataset. Use limit=1 to get just the latest row.</param>
        /// <param name="columnIndex">Request a specific column. Column 0 is the date column and is always returned. Data begins at column 1.</param>
        /// <param name="startDate">Retrieve data rows on and after the specified start date.</param>
        /// <param name="endDate">Retrieve data rows up to and including the specified end date.</param>
        /// <param name="order">Return data in ascending or descending order of date. Default is “desc”.</param>
        /// <param name="collapse">Change the sampling frequency of the returned data. Default is “none” i.e. data is returned in its original granularity.</param>
        /// <param name="transform">Perform elementary calculations on the data prior to downloading. Default is “none”. Calculation options are described below.</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetDataAndMetadataCsvAsync(string databaseCode, string datasetCode, int? limit = null, int? columnIndex = null,
            DateTime? startDate = null, DateTime? endDate = null, Order? order = null, Collapse? collapse = null, Transform? transform = null)
        {
            var content = await _api.GetDataAndMetadataAsync(databaseCode, datasetCode, ReturnFormat.Csv, limit, columnIndex, startDate, endDate, order, collapse, transform, _apiKey);
            return await content.ReadAsStreamAsync();
        }

        /// <summary>
        /// You can search for individual datasets on Quandl using this API route. 
        /// <a href="https://www.quandl.com/docs/api?json#dataset-search">Reference</a>
        /// </summary>
        /// <param name="query">Your search query. Separate multiple items with “+”.</param>
        /// <param name="databaseCode">Restrict search results to a specific database.</param>
        /// <param name="perPage">Number of search results per page.</param>
        /// <param name="page">Page number to return.</param>
        /// <returns>Get dataset response</returns>
        public async Task<GetDatasetListResponse> GetListAsync(string query, string databaseCode = null, int? perPage = null, int? page = null)
        {
            var content = await _api.GetListAsync(ReturnFormat.Json, query, databaseCode, perPage, page, _apiKey);
            var json = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetDatasetListResponse>(json);
        }

        /// <summary>
        /// You can search for individual datasets on Quandl using this API route. 
        /// <a href="https://www.quandl.com/docs/api?csv#dataset-search">Reference</a>
        /// </summary>
        /// <param name="query">Your search query. Separate multiple items with “+”.</param>
        /// <param name="databaseCode">Restrict search results to a specific database.</param>
        /// <param name="perPage">Number of search results per page.</param>
        /// <param name="page">Page number to return.</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetListCsvAsync(string query, string databaseCode = null, int? perPage = null, int? page = null)
        {
            var content = await _api.GetListAsync(ReturnFormat.Csv, query, databaseCode, perPage, page, _apiKey);
            return await content.ReadAsStreamAsync();
        }
    }
}
