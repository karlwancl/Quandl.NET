namespace Quandl.NET.Model.Response
{
    public class TimeseriesMetadataResponse
    {
        public TimeseriesMetadataResponse(TimeseriesMetadata dataset)
        {
            Dataset = dataset;
        }

        public TimeseriesMetadata Dataset { get; private set; }
    }
}