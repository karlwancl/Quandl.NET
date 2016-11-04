namespace Quandl.NET.Model.Response
{
    public class GetDatasetMetadataResponse
    {
        public GetDatasetMetadataResponse(DatasetMetadata dataset)
        {
            Dataset = dataset;
        }

        public DatasetMetadata Dataset { get; private set; }
    }
}