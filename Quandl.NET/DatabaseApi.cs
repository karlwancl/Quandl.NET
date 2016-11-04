using Newtonsoft.Json;
using Quandl.NET.Helper;
using Quandl.NET.Model.Enum;
using Quandl.NET.Model.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quandl.NET
{
    public class DatabaseApi : QuandlApiBase
    {
        private IDatabaseApi _api;

        public DatabaseApi(string apiKey) : base(apiKey)
        {
            _api = RestService.For<IDatabaseApi>(Constant.HostUri,
                new RefitSettings { UrlParameterFormatter = new AdvancedUrlParameterFormatter() });
        }

        /// <summary>
        /// You can download an entire database in a single call using this method. Simply append /data to your database code, to get a zipped CSV file of the entire database.
        /// <a href="https://www.quandl.com/docs/api?csv#get-entire-database">Reference</a>
        /// </summary>
        /// <param name="code">Database code</param>
        /// <param name="downloadType">If “partial”, returns last day of data. If “complete”, returns entire database. Default is “complete”.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of zipped csv file (.zip)</returns>
        public async Task<Stream> GetZipAsync(DatabaseCode code, DownloadType downloadType = DownloadType.Complete, CancellationToken token = default(CancellationToken))
            => await GetZipAsync(code.ToEnumMemberValue(), downloadType, token);

        /// <summary>
        /// You can download an entire database in a single call using this method. Simply append /data to your database code, to get a zipped CSV file of the entire database.
        /// <a href="https://www.quandl.com/docs/api?csv#get-entire-database">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="downloadType">If “partial”, returns last day of data. If “complete”, returns entire database. Default is “complete”.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of zipped csv file (.zip)</returns>
        public async Task<Stream> GetZipAsync(string databaseCode, DownloadType downloadType = DownloadType.Complete, CancellationToken token = default(CancellationToken))
        {
            try
            {
                var content = await _api.GetAsync(databaseCode, downloadType, _apiKey, token).ConfigureAwait(false);
                return await content.ReadAsStreamAsync().ConfigureAwait(false);
            }
            catch (Refit.ApiException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// Use this call to get metadata for a specified database.
        /// <a href="https://www.quandl.com/docs/api?json#get-database-metadata">Reference</a>
        /// </summary>
        /// <param name="code">Database code</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Get database metadata response</returns>
        public async Task<GetDatabaseMetadataResponse> GetMetadataAsync(DatabaseCode code, CancellationToken token = default(CancellationToken))
            => await GetMetadataAsync(code.ToEnumMemberValue(), token);

        /// <summary>
        /// Use this call to get metadata for a specified database.
        /// <a href="https://www.quandl.com/docs/api?json#get-database-metadata">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Get database metadata response</returns>
        public async Task<GetDatabaseMetadataResponse> GetMetadataAsync(string databaseCode, CancellationToken token = default(CancellationToken))
        {
            try
            {
                using (var content = await _api.GetMetadataAsync(databaseCode, ReturnFormat.Json, _apiKey, token).ConfigureAwait(false))
                {
                    var json = await content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<GetDatabaseMetadataResponse>(json);
                }
            }
            catch (Refit.ApiException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// Use this call to get metadata for a specified database.
        /// <a href="https://www.quandl.com/docs/api?csv#get-database-metadata">Reference</a>
        /// </summary>
        /// <param name="code">Database code</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetMetadataCsvAsync(DatabaseCode code, CancellationToken token = default(CancellationToken))
            => await GetMetadataCsvAsync(code.ToEnumMemberValue(), token);

        /// <summary>
        /// Use this call to get metadata for a specified database.
        /// <a href="https://www.quandl.com/docs/api?csv#get-database-metadata">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetMetadataCsvAsync(string databaseCode, CancellationToken token = default(CancellationToken))
        {
            try
            {
                var content = await _api.GetMetadataAsync(databaseCode, ReturnFormat.Csv, _apiKey, token).ConfigureAwait(false);
                return await content.ReadAsStreamAsync().ConfigureAwait(false);
            }
            catch (Refit.ApiException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// You can search for specific databases on Quandl using this API route. The API will return all databases related to your query.
        /// <a href="https://www.quandl.com/docs/api?json#search-for-databases">Reference</a>
        /// </summary>
        /// <param name="query">Search keywords</param>
        /// <param name="perPage">Number of search results per page</param>
        /// <param name="page">Page number to return</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Get database list response</returns>
        public async Task<GetDatabaseListResponse> GetListAsync(List<string> query = null, int? perPage = null, int? page = null, CancellationToken token = default(CancellationToken))
        {
            try
            {
                var correctedQuery = query != null ? string.Join("+", query) : null;

                using (var content = await _api.GetListAsync(ReturnFormat.Json, correctedQuery, perPage, page, _apiKey, token).ConfigureAwait(false))
                {
                    var json = await content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<GetDatabaseListResponse>(json);
                }
            }
            catch (Refit.ApiException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// You can search for specific databases on Quandl using this API route. The API will return all databases related to your query.
        /// <a href="https://www.quandl.com/docs/api?csv#search-for-databases">Reference</a>
        /// </summary>
        /// <param name="query">Search keywords</param>
        /// <param name="perPage">Number of search results per page</param>
        /// <param name="page">Page number to return</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetListCsvAsync(List<string> query = null, int? perPage = null, int? page = null, CancellationToken token = default(CancellationToken))
        {
            try
            {
                var correctedQuery = query != null ? string.Join("+", query) : null;

                var content = await _api.GetListAsync(ReturnFormat.Csv, correctedQuery, perPage, page, _apiKey, token).ConfigureAwait(false);
                return await content.ReadAsStreamAsync().ConfigureAwait(false);
            }
            catch (Refit.ApiException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// For databases that support the datasets API route, this call gets a list of available datasets within the database, in the form of a zipped CSV file.
        /// <a href="https://www.quandl.com/docs/api?csv#get-list-of-database-contents">Reference</a>
        /// </summary>
        /// <param name="code">Database code</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of zipped csv file (.zip)</returns>
        public async Task<Stream> GetDatasetListZipAsync(DatabaseCode code, CancellationToken token = default(CancellationToken))
            => await GetDatasetListZipAsync(code.ToEnumMemberValue(), token);

        /// <summary>
        /// For databases that support the datasets API route, this call gets a list of available datasets within the database, in the form of a zipped CSV file.
        /// <a href="https://www.quandl.com/docs/api?csv#get-list-of-database-contents">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of zipped csv file (.zip)</returns>
        public async Task<Stream> GetDatasetListZipAsync(string databaseCode, CancellationToken token = default(CancellationToken))
        {
            try
            {
                var content = await _api.GetDatasetListAsync(databaseCode, _apiKey, token).ConfigureAwait(false);
                return await content.ReadAsStreamAsync().ConfigureAwait(false);
            }
            catch (Refit.ApiException ex)
            {
                throw ex.ToQuandlException();
            }
        }
    }
}
