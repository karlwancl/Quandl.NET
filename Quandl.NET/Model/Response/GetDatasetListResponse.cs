using System.Collections.Generic;

namespace Quandl.NET.Model.Response
{
    public class GetDatasetListResponse
    {
        public GetDatasetListResponse(List<DatasetMetadata> datasets, Meta meta)
        {
            Datasets = datasets;
            Meta = meta;
        }

        public List<DatasetMetadata> Datasets { get; private set; }

        public Meta Meta { get; private set; }
    }
}