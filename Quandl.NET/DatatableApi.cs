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
    public class DatatableApi : QuandlApiBase
    {
        private IDatatableApi _api;
        private IDatatableApiNonRefit _apiNonRefit;

        public DatatableApi(string apiKey) : base(apiKey)
        {
            _api = RestService.For<IDatatableApi>(Constant.HostUri,
                new RefitSettings { UrlParameterFormatter = new AdvancedUrlParameterFormatter() });

            _apiNonRefit = new DatatableApiNonRefit();
        }

        /// <summary>
        /// This API call returns a datatable, subject to a limit of 10,000 rows.
        /// <a href="https://www.quandl.com/docs/api?json#get-entire-datatable">Reference</a>
        /// </summary>
        /// <param name="code">Datatable code</param>
        /// <param name="rowFilter">Criteria to filter row</param>
        /// <param name="columnFilter">Criteria to filter column</param>
        /// <param name="nextCursorId">Next cursor id</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Get datatable response</returns>
        public async Task<GetDatatableResponse> GetAsync(DatatableCode code, Dictionary<string, List<string>> rowFilter = null,
            List<string> columnFilter = null, int? nextCursorId = null, CancellationToken token = default(CancellationToken))
            => await GetAsync(code.ToPair().Item1, code.ToPair().Item2, rowFilter, columnFilter, nextCursorId, token);

        /// <summary>
        /// This API call returns a datatable, subject to a limit of 10,000 rows.
        /// <a href="https://www.quandl.com/docs/api?json#get-entire-datatable">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="datatableCode">short code for datatable</param>
        /// <param name="rowFilter">Criteria to filter row</param>
        /// <param name="columnFilter">Criteria to filter column</param>
        /// <param name="nextCursorId">Next cursor id</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Get datatable response</returns>
        public async Task<GetDatatableResponse> GetAsync(string databaseCode, string datatableCode, Dictionary<string, List<string>> rowFilter = null,
            List<string> columnFilter = null, int? nextCursorId = null, CancellationToken token = default(CancellationToken))
        {
            var correctedRowFilter = rowFilter?.ToDictionary(kvp => kvp.Key, kvp => string.Join(",", kvp.Value));
            string correctedColumnFilter = columnFilter != null ? string.Join(",", columnFilter) : null;

            using (var content = await _apiNonRefit.GetAsync(databaseCode, datatableCode, ReturnFormat.Json, correctedRowFilter, correctedColumnFilter,
                null, nextCursorId, _apiKey, token).ConfigureAwait(false))
            {
                var json = await content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<GetDatatableResponse>(json);
            }
        }

        /// <summary>
        /// This API call returns a datatable, subject to a limit of 10,000 rows.
        /// <a href="https://www.quandl.com/docs/api?csv#get-entire-datatable">Reference</a>
        /// </summary>
        /// <param name="code">Datatable code</param>
        /// <param name="rowFilter">Criteria to filter row</param>
        /// <param name="columnFilter">Criteria to filter column</param>
        /// <param name="fullResult">Flag to display full result</param>
        /// <param name="nextCursorId">Next cursor id</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetCsvAsync(DatatableCode code, Dictionary<string, List<string>> rowFilter = null,
            List<string> columnFilter = null, bool? fullResult = null, int? nextCursorId = null, CancellationToken token = default(CancellationToken))
            => await GetCsvAsync(code.ToPair().Item1, code.ToPair().Item2, rowFilter, columnFilter, fullResult, nextCursorId, token);

        /// <summary>
        /// This API call returns a datatable, subject to a limit of 10,000 rows.
        /// <a href="https://www.quandl.com/docs/api?csv#get-entire-datatable">Reference</a>
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="datatableCode">short code for datatable</param>
        /// <param name="rowFilter">Criteria to filter row</param>
        /// <param name="columnFilter">Criteria to filter column</param>
        /// <param name="fullResult">Flag to display full result</param>
        /// <param name="nextCursorId">Next cursor id</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetCsvAsync(string databaseCode, string datatableCode, Dictionary<string, List<string>> rowFilter = null,
            List<string> columnFilter = null, bool? fullResult = null, int? nextCursorId = null, CancellationToken token = default(CancellationToken))
        {
            var correctedRowFilter = rowFilter?.ToDictionary(kvp => kvp.Key, kvp => string.Join(",", kvp.Value));
            var correctedColumnFilter = columnFilter != null ? string.Join(",", columnFilter) : null;
            var correctedNextCursorId = fullResult == null ? nextCursorId : null;

            var content = await _apiNonRefit.GetAsync(databaseCode, datatableCode, ReturnFormat.Csv, correctedRowFilter, correctedColumnFilter,
                fullResult, correctedNextCursorId, _apiKey, token).ConfigureAwait(false);

            return await content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// This API call returns datatable's metadata
        /// </summary>
        /// <param name="code">Datatable code</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Get datatable metadata response</returns>
        public async Task<GetDatatableMetadataResponse> GetMetadataAsync(DatatableCode code, CancellationToken token = default(CancellationToken))
            => await GetMetadataAsync(code.ToPair().Item1, code.ToPair().Item2, token);

        /// <summary>
        /// This API call returns datatable's metadata
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="datatableCode">short code for datatable</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Get datatable metadata response</returns>
        public async Task<GetDatatableMetadataResponse> GetMetadataAsync(string databaseCode, string datatableCode, CancellationToken token = default(CancellationToken))
        {
            using (var content = await _api.GetMetadataAsync(databaseCode, datatableCode, ReturnFormat.Json, _apiKey, token).ConfigureAwait(false))
            {
                var json = await content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<GetDatatableMetadataResponse>(json);
            }
        }

        /// <summary>
        /// This API call returns datatable's metadata
        /// </summary>
        /// <param name="code">Datatable code</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetMetadataCsvAsync(DatatableCode code, CancellationToken token = default(CancellationToken))
            => await GetMetadataCsvAsync(code.ToPair().Item1, code.ToPair().Item2, token);

        /// <summary>
        /// This API call returns datatable's metadata
        /// </summary>
        /// <param name="databaseCode">short code for database</param>
        /// <param name="datatableCode">short code for datatable</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of csv file (.csv)</returns>
        public async Task<Stream> GetMetadataCsvAsync(string databaseCode, string datatableCode, CancellationToken token = default(CancellationToken))
        {
            try
            {
                var content = await _api.GetMetadataAsync(databaseCode, datatableCode, ReturnFormat.Csv, _apiKey, token).ConfigureAwait(false);
                return await content.ReadAsStreamAsync().ConfigureAwait(false);
            }
            catch (Refit.ApiException ex)
            {
                throw ex.ToQuandlException();
            }
        }
    }
}
