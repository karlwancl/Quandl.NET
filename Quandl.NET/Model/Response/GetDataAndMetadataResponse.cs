namespace Quandl.NET.Model.Response
{
    public class GetDataAndMetadataResponse
    {
        public GetDataAndMetadataResponse(DatasetDataAndMetadata dataset)
        {
            Dataset = dataset;
        }

        public DatasetDataAndMetadata Dataset { get; private set; }
    }
}