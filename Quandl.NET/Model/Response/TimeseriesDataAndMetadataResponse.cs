namespace Quandl.NET.Model.Response
{
    public class TimeseriesDataAndMetadataResponse
    {
        public TimeseriesDataAndMetadataResponse(TimeseriesDataAndMetadata dataset)
        {
            Dataset = dataset;
        }

        public TimeseriesDataAndMetadata Dataset { get; private set; }
    }
}