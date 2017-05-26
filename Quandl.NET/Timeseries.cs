using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Quandl.NET.Helper;
using Quandl.NET.Model.Enum;
using Quandl.NET.Model.Response;

namespace Quandl.NET
{
    public class Timeseries : QuandlApiBase
    {
        public Timeseries(string apiKey) : base(apiKey)
        {
        }

		/// <summary>
		/// You can slice, transform and otherwise customize your time-series dataset prior to download by appending various optional parameters to your query.
		/// <a href="https://docs.quandl.com/docs/in-depth-usage#section-get-filtered-time-series-data">Reference</a>
		/// </summary>
		/// <param name="databaseCode">Code identifying the database to which the dataset belongs.</param>
		/// <param name="datasetCode">Code identifying the dataset.</param>
		/// <param name="limit">Use limit=n to get the first n rows of the dataset. Use limit=1 to get just the latest row.</param>
		/// <param name="columnIndex">Request a specific column. Column 0 is the date column and is always returned. Data begins at column 1.</param>
		/// <param name="startDate">Retrieve data rows on and after the specified start date.</param>
		/// <param name="endDate">Retrieve data rows up to and including the specified end date.</param>
		/// <param name="order">Return data in ascending or descending order of date. Default is desc.</param>
		/// <param name="collapse">Change the sampling frequency of the returned data. Default is none; i.e., data is returned in its original granularity.</param>
		/// <param name="transform">Perform elementary calculations on the data prior to downloading. Default is none. Calculation options are described below.</param>
		/// <param name="token">Cancellation token</param>
		/// <returns>Data from a specified time-series</returns>
        public async Task<TimeseriesDataResponse> GetDataAsync(string databaseCode, string datasetCode, int? limit = null, int? columnIndex = null,
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
		/// You can slice, transform and otherwise customize your time-series dataset prior to download by appending various optional parameters to your query.
		/// <a href="https://docs.quandl.com/docs/in-depth-usage#section-get-filtered-time-series-data">Reference</a>
		/// </summary>
		/// <param name="databaseCode">Code identifying the database to which the dataset belongs.</param>
		/// <param name="datasetCode">Code identifying the dataset.</param>
		/// <param name="returnFormat">Return format</param>
		/// <param name="limit">Use limit=n to get the first n rows of the dataset. Use limit=1 to get just the latest row.</param>
		/// <param name="columnIndex">Request a specific column. Column 0 is the date column and is always returned. Data begins at column 1.</param>
		/// <param name="startDate">Retrieve data rows on and after the specified start date.</param>
		/// <param name="endDate">Retrieve data rows up to and including the specified end date.</param>
		/// <param name="order">Return data in ascending or descending order of date. Default is desc.</param>
		/// <param name="collapse">Change the sampling frequency of the returned data. Default is none; i.e., data is returned in its original granularity.</param>
		/// <param name="transform">Perform elementary calculations on the data prior to downloading. Default is none. Calculation options are described below.</param>
		/// <param name="token">Cancellation token</param>
		/// <returns>Data from a specified time-series</returns>
	    public async Task<Stream> GetDataAsync(string databaseCode, string datasetCode, ReturnFormat returnFormat, int? limit = null, int? columnIndex = null,
			DateTime? startDate = null, DateTime? endDate = null, Order? order = null, Collapse? collapse = null, Transform? transform = null, CancellationToken token = default(CancellationToken))
		{
			try
			{
                return await $"{Constant.HostUri}/datasets/{databaseCode}/{datasetCode}/data.{returnFormat.ToEnumMemberValue()}"
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
		/// This call returns metadata for a specified time-series.
		/// <a href="https://docs.quandl.com/docs/in-depth-usage#section-get-time-series-metadata">Reference</a>
		/// </summary>
		/// <param name="databaseCode">Code identifying the database to which the dataset belongs.</param>
		/// <param name="datasetCode">Code identifying the dataset.</param>
		/// <param name="token">Cancellation token</param>
		/// <returns>Metadata for a specified time-series</returns>
		public async Task<TimeseriesMetadataResponse> GetMetadataAsync(string databaseCode, string datasetCode, CancellationToken token = default(CancellationToken))
		{
			try
			{
				return await $"{Constant.HostUri}/datasets/{databaseCode}/{datasetCode}/metadata.json"
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
		/// This call returns metadata for a specified time-series.
		/// <a href="https://docs.quandl.com/docs/in-depth-usage#section-get-time-series-metadata">Reference</a>
		/// </summary>
		/// <param name="databaseCode">Code identifying the database to which the dataset belongs.</param>
		/// <param name="datasetCode">Code identifying the dataset.</param>
        /// <param name="returnFormat">Return format</param>
		/// <param name="token">Cancellation token</param>
		/// <returns>Metadata for a specified time-series</returns>
		public async Task<Stream> GetMetadataAsync(string databaseCode, string datasetCode, ReturnFormat returnFormat, CancellationToken token = default(CancellationToken))
		{
			try
			{
                return await $"{Constant.HostUri}/datasets/{databaseCode}/{datasetCode}/metadata.{returnFormat.ToEnumMemberValue()}"
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
		/// This call returns data and metadata for a given time-series.
		/// <a href="https://docs.quandl.com/docs/in-depth-usage#section-get-time-series-data-and-metadata">Reference</a>
		/// </summary>
		/// <param name="databaseCode">Code identifying the database to which the dataset belongs.</param>
		/// <param name="datasetCode">Code identifying the dataset.</param>
		/// <param name="limit">Use limit=n to get the first n rows of the dataset. Use limit=1 to get just the latest row.</param>
		/// <param name="columnIndex">Request a specific column. Column 0 is the date column and is always returned. Data begins at column 1.</param>
		/// <param name="startDate">Retrieve data rows on and after the specified start date.</param>
		/// <param name="endDate">Retrieve data rows up to and including the specified end date.</param>
		/// <param name="order">Return data in ascending or descending order of date. Default is desc.</param>
		/// <param name="collapse">Change the sampling frequency of the returned data. Default is none; i.e., data is returned in its original granularity.</param>
		/// <param name="transform">Perform elementary calculations on the data prior to downloading. Default is none. Calculation options are described below.</param>
		/// <param name="token">Cancellation token</param>
		/// <returns>Data and metadata for a given time-series</returns>
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
		/// This call returns data and metadata for a given time-series.
		/// <a href="https://docs.quandl.com/docs/in-depth-usage#section-get-time-series-data-and-metadata">Reference</a>
		/// </summary>
		/// <param name="databaseCode">Code identifying the database to which the dataset belongs.</param>
		/// <param name="datasetCode">Code identifying the dataset.</param>
		/// <param name="returnFormat">Return format</param>
		/// <param name="limit">Use limit=n to get the first n rows of the dataset. Use limit=1 to get just the latest row.</param>
		/// <param name="columnIndex">Request a specific column. Column 0 is the date column and is always returned. Data begins at column 1.</param>
		/// <param name="startDate">Retrieve data rows on and after the specified start date.</param>
		/// <param name="endDate">Retrieve data rows up to and including the specified end date.</param>
		/// <param name="order">Return data in ascending or descending order of date. Default is desc.</param>
		/// <param name="collapse">Change the sampling frequency of the returned data. Default is none; i.e., data is returned in its original granularity.</param>
		/// <param name="transform">Perform elementary calculations on the data prior to downloading. Default is none. Calculation options are described below.</param>
		/// <param name="token">Cancellation token</param>
		/// <returns>Data and metadata for a given time-series</returns>
		public async Task<Stream> GetDataAndMetadataAsync(string databaseCode, string datasetCode, ReturnFormat returnFormat, int? limit = null, int? columnIndex = null, DateTime? startDate = null, 
                                                          DateTime? endDate = null, Order? order = null, Collapse? collapse = null, Transform? transform = null, CancellationToken token = default(CancellationToken))
		{
			try
			{
                return await $"{Constant.HostUri}/datasets/{databaseCode}/{datasetCode}.{returnFormat.ToEnumMemberValue()}"
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
		/// You can retrieve metadata for a specified time-series database.
		/// <a href="https://docs.quandl.com/docs/in-depth-usage#section-get-metadata-for-a-time-series-database">Reference</a>
		/// </summary>
		/// <param name="databaseCode">Code identifying the database to which the dataset belongs.</param>
		/// <param name="token">Cancellation token</param>
		/// <returns>Metadata for a specified time-series database</returns>
        public async Task<DatabaseMetadataResponse> GetDatabaseMetadataAsync(string databaseCode, CancellationToken token = default(CancellationToken))
		{
			try
			{
				return await $"{Constant.HostUri}/databases/{databaseCode}.json"
					.SetQueryParam("api_key", _apiKey)
					.GetAsync(token)
					.ReceiveJson<DatabaseMetadataResponse>()
					.ConfigureAwait(false);
			}
			catch (FlurlHttpException ex)
			{
				throw ex.ToQuandlException();
			}
		}

		/// <summary>
		/// You can retrieve metadata for a specified time-series database.
		/// <a href="https://docs.quandl.com/docs/in-depth-usage#section-get-metadata-for-a-time-series-database">Reference</a>
		/// </summary>
		/// <param name="databaseCode">Code identifying the database to which the dataset belongs.</param>
        /// <param name="returnFormat">Return format</param>
		/// <param name="token">Cancellation token</param>
		/// <returns>Metadata for a specified time-series database</returns>
		public async Task<Stream> GetDatabaseMetadataAsync(string databaseCode, ReturnFormat returnFormat, CancellationToken token = default(CancellationToken))
		{
			try
			{
                return await $"{Constant.HostUri}/databases/{databaseCode}.{returnFormat.ToEnumMemberValue()}"
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
		/// Our time-series API provides users the functionality to download an entire time-series database in a single call.
		/// <a href="https://docs.quandl.com/docs/in-depth-usage#section-get-an-entire-time-series-database">Reference</a>
		/// </summary>
		/// <param name="databaseCode">Code identifying the database to which the dataset belongs.</param>
		/// <param name="downloadType">In addition to functionality to download the entire database, the Time-series API also provides functionality to download a partial file, which includes only the latest available observation for each time-series in the database.</param>
		/// <param name="token">Cancellation token</param>
		/// <returns>Entire time-series database</returns>
        public async Task<Stream> GetEntireDatabaseAsync(string databaseCode, DownloadType downloadType = DownloadType.Full, CancellationToken token = default(CancellationToken))
		{
			try
			{
				return await $"{Constant.HostUri}/databases/{databaseCode}/data"
					.SetQueryParam("download_type", downloadType.ToEnumMemberValue())
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
