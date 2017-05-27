using Flurl;
using Flurl.Http;
using Quandl.NET.Helper;
using Quandl.NET.Model.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Quandl.NET
{
    [Obsolete("Quandl has recently reorganized the api, please use Timeseries or Tables class for api call, this class will be removed in later patch")]
    public class DatasetApi : QuandlApiBase
    {
        public DatasetApi(string apiKey) : base(apiKey)
        {
        }

        /// <summary>
        /// This call returns data from a specified dataset.
        /// <a href="https://www.quandl.com/docs/api?json#get-data">Reference</a>
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
        /// <param name="token">Cancellation token</param>
        /// <returns>Get dataset response</returns>
        [Obsolete("Please replace it with GetDataAsync() method from Timeseries class")]
        public async Task<TimeseriesDataResponse> GetAsync(string databaseCode, string datasetCode, int? limit = null, int? columnIndex = null,
            DateTime? startDate = null, DateTime? endDate = null, Order? order = null, Collapse? collapse = null, Transform? transform = null, CancellationToken token = default(CancellationToken))
        {
            try
            {
                return await $"{Constant.HostUri}/datasets/{databaseCode}/{datasetCode}/data.json"
                    .SetQueryParam("limit", limit)
                    .SetQueryParam("column_index", columnIndex)
                    .SetQueryParam("start_date", startDate?.ToString("yyyy-MM-dd"))
                    .SetQueryParam("end_date", endDate?.ToString("yyyy-MM-dd"))
                    .SetQueryParam("order", order.ToEnumMemberValue())
                    .SetQueryParam("collapse", collapse.ToEnumMemberValue())
                    .SetQueryParam("transform", transform.ToEnumMemberValue())
                    .SetQueryParam("api_key", _apiKey)
                    .GetAsync(token)
                    .ReceiveJson<TimeseriesDataResponse>()
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// This call returns data from a specified dataset.
        /// <a href="https://www.quandl.com/docs/api?csv#get-data">Reference</a>
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
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of csv file (.csv)</returns>
        [Obsolete("Please replace it with GetDataAsync() method from Timeseries class")]
        public async Task<Stream> GetCsvAsync(string databaseCode, string datasetCode, int? limit = null, int? columnIndex = null,
            DateTime? startDate = null, DateTime? endDate = null, Order? order = null, Collapse? collapse = null, Transform? transform = null, CancellationToken token = default(CancellationToken))
        {
            try
            {
                return await $"{Constant.HostUri}/datasets/{databaseCode}/{datasetCode}/data.csv"
                    .SetQueryParam("limit", limit)
                    .SetQueryParam("column_index", columnIndex)
                    .SetQueryParam("start_date", startDate?.ToString("yyyy-MM-dd"))
                    .SetQueryParam("end_date", endDate?.ToString("yyyy-MM-dd"))
                    .SetQueryParam("order", order.ToEnumMemberValue())
                    .SetQueryParam("collapse", collapse.ToEnumMemberValue())
                    .SetQueryParam("transform", transform.ToEnumMemberValue())
                    .SetQueryParam("api_key", _apiKey)
                    .GetAsync(token)
                    .ReceiveStream()
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// This call returns metadata for a specified dataset.
        /// <a href="https://www.quandl.com/docs/api?json#get-metadata">Reference</a>
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
        /// <param name="token">Cancellation token</param>
        /// <returns>Get dataset metadata response</returns>
        [Obsolete("Please replace it with GetMetadataAsync() method from Timeseries class")]
        public async Task<TimeseriesMetadataResponse> GetMetadataAsync(string databaseCode, string datasetCode, int? limit = null, int? columnIndex = null,
            DateTime? startDate = null, DateTime? endDate = null, Order? order = null, Collapse? collapse = null, Transform? transform = null, CancellationToken token = default(CancellationToken))
        {
            try
            {
                return await $"{Constant.HostUri}/datasets/{databaseCode}/{datasetCode}/metadata.json"
                    .SetQueryParam("limit", limit)
                    .SetQueryParam("column_index", columnIndex)
                    .SetQueryParam("start_date", startDate?.ToString("yyyy-MM-dd"))
                    .SetQueryParam("end_date", endDate?.ToString("yyyy-MM-dd"))
                    .SetQueryParam("order", order.ToEnumMemberValue())
                    .SetQueryParam("collapse", collapse.ToEnumMemberValue())
                    .SetQueryParam("transform", transform.ToEnumMemberValue())
                    .SetQueryParam("api_key", _apiKey)
                    .GetAsync(token)
                    .ReceiveJson<TimeseriesMetadataResponse>()
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// This call returns metadata for a specified dataset.
        /// <a href="https://www.quandl.com/docs/api?csv#get-metadata">Reference</a>
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
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of csv file (.csv)</returns>
        [Obsolete("Please replace it with GetMetadataAsync() method from Timeseries class")]
        public async Task<Stream> GetMetadataCsvAsync(string databaseCode, string datasetCode, int? limit = null, int? columnIndex = null,
            DateTime? startDate = null, DateTime? endDate = null, Order? order = null, Collapse? collapse = null, Transform? transform = null, CancellationToken token = default(CancellationToken))
        {
            try
            {
                return await $"{Constant.HostUri}/datasets/{databaseCode}/{datasetCode}/metadata.csv"
                    .SetQueryParam("limit", limit)
                    .SetQueryParam("column_index", columnIndex)
                    .SetQueryParam("start_date", startDate?.ToString("yyyy-MM-dd"))
                    .SetQueryParam("end_date", endDate?.ToString("yyyy-MM-dd"))
                    .SetQueryParam("order", order.ToEnumMemberValue())
                    .SetQueryParam("collapse", collapse.ToEnumMemberValue())
                    .SetQueryParam("transform", transform.ToEnumMemberValue())
                    .SetQueryParam("api_key", _apiKey)
                    .GetAsync(token)
                    .ReceiveStream()
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToQuandlException();
            }
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
        /// <param name="token">Cancellation token</param>
        /// <returns>Get data and metadata response</returns>
        [Obsolete("Please replace it with GetDataAndMetadataAsync() method from Timeseries class")]
        public async Task<TimeseriesDataAndMetadataResponse> GetDataAndMetadataAsync(string databaseCode, string datasetCode, int? limit = null, int? columnIndex = null,
            DateTime? startDate = null, DateTime? endDate = null, Order? order = null, Collapse? collapse = null, Transform? transform = null, CancellationToken token = default(CancellationToken))
        {
            try
            {
                return await $"{Constant.HostUri}/datasets/{databaseCode}/{datasetCode}.json"
                    .SetQueryParam("limit", limit)
                    .SetQueryParam("column_index", columnIndex)
                    .SetQueryParam("start_date", startDate?.ToString("yyyy-MM-dd"))
                    .SetQueryParam("end_date", endDate?.ToString("yyyy-MM-dd"))
                    .SetQueryParam("order", order.ToEnumMemberValue())
                    .SetQueryParam("collapse", collapse.ToEnumMemberValue())
                    .SetQueryParam("transform", transform.ToEnumMemberValue())
                    .SetQueryParam("api_key", _apiKey)
                    .GetAsync(token)
                    .ReceiveJson<TimeseriesDataAndMetadataResponse>()
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// This call returns data and metadata for a given dataset.
        /// <a href="https://www.quandl.com/docs/api?csv#get-data-and-metadata">Reference</a>
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
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of csv file (.csv)</returns>
        [Obsolete("Please replace it with GetDataAndMetadataAsync() method from Timeseries class")]
        public async Task<Stream> GetDataAndMetadataCsvAsync(string databaseCode, string datasetCode, int? limit = null, int? columnIndex = null,
            DateTime? startDate = null, DateTime? endDate = null, Order? order = null, Collapse? collapse = null, Transform? transform = null, CancellationToken token = default(CancellationToken))
        {
            try
            {
                return await $"{Constant.HostUri}/datasets/{databaseCode}/{datasetCode}.csv"
                    .SetQueryParam("limit", limit)
                    .SetQueryParam("column_index", columnIndex)
                    .SetQueryParam("start_date", startDate?.ToString("yyyy-MM-dd"))
                    .SetQueryParam("end_date", endDate?.ToString("yyyy-MM-dd"))
                    .SetQueryParam("order", order.ToEnumMemberValue())
                    .SetQueryParam("collapse", collapse.ToEnumMemberValue())
                    .SetQueryParam("transform", transform.ToEnumMemberValue())
                    .SetQueryParam("api_key", _apiKey)
                    .GetAsync(token)
                    .ReceiveStream()
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// You can search for individual datasets on Quandl using this API route.
        /// <a href="https://www.quandl.com/docs/api?json#dataset-search">Reference</a>
        /// </summary>
        /// <param name="query">Your search query</param>
        /// <param name="databaseCode">Restrict search results to a specific database.</param>
        /// <param name="perPage">Number of search results per page.</param>
        /// <param name="page">Page number to return.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Get dataset response</returns>
        [Obsolete("This api will no longer be supported")]
        public async Task<GetDatasetListResponse> GetListAsync(List<string> query, string databaseCode = null, int? perPage = null, int? page = null, CancellationToken token = default(CancellationToken))
        {
            try
            {
                var massagedQuery = query != null ? string.Join("+", query) : null;
                return await $"{Constant.HostUri}/datasets.json"
                    .SetQueryParam("query", query)
                    .SetQueryParam("database_code", databaseCode)
                    .SetQueryParam("per_page", perPage)
                    .SetQueryParam("page", page)
                    .SetQueryParam("api_key", _apiKey)
                    .GetAsync(token)
                    .ReceiveJson<GetDatasetListResponse>()
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToQuandlException();
            }
        }

        /// <summary>
        /// You can search for individual datasets on Quandl using this API route.
        /// <a href="https://www.quandl.com/docs/api?csv#dataset-search">Reference</a>
        /// </summary>
        /// <param name="query">Your search query. Separate multiple items with “+”.</param>
        /// <param name="databaseCode">Restrict search results to a specific database.</param>
        /// <param name="perPage">Number of search results per page.</param>
        /// <param name="page">Page number to return.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Stream of csv file (.csv)</returns>
        [Obsolete("This api will no longer be supported")]
        public async Task<Stream> GetListCsvAsync(List<string> query, string databaseCode = null, int? perPage = null, int? page = null, CancellationToken token = default(CancellationToken))
        {
            try
            {
                var massagedQuery = query != null ? string.Join("+", query) : null;
                return await $"{Constant.HostUri}/datasets.csv"
                    .SetQueryParam("query", query)
                    .SetQueryParam("database_code", databaseCode)
                    .SetQueryParam("per_page", perPage)
                    .SetQueryParam("page", page)
                    .SetQueryParam("api_key", _apiKey)
                    .GetAsync(token)
                    .ReceiveStream()
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException ex)
            {
                throw ex.ToQuandlException();
            }
        }
    }
}