namespace Quandl.NET.Model.Response
{
    public class GetDatasetResponse
    {
        public GetDatasetResponse(DatasetData dataset_data)
        {
            DatasetData = dataset_data;
        }

        public DatasetData DatasetData { get; private set; }
    }
}