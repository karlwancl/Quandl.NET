namespace Quandl.NET.Model.Response
{
    public class TimeseriesDataResponse
    {
        public TimeseriesDataResponse(TimeseriesData dataset_data)
        {
            DatasetData = dataset_data;
        }

        public TimeseriesData DatasetData { get; private set; }
    }
}