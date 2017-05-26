using System.Collections.Generic;

namespace Quandl.NET.Model.Response
{
    public class GetDatasetListResponse
    {
        public GetDatasetListResponse(List<TimeseriesMetadata> datasets, Meta meta)
        {
            Datasets = datasets;
            Meta = meta;
        }

        public List<TimeseriesMetadata> Datasets { get; private set; }

        public Meta Meta { get; private set; }
    }
}