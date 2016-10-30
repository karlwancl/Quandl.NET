using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Model.Response
{
    public class GetDatasetResponse
    {
        public GetDatasetResponse(List<DatasetMetadata> datasets, Meta meta)
        {
            Datasets = datasets;
            Meta = meta;
        }

        public List<DatasetMetadata> Datasets { get; private set; }

        public Meta Meta { get; private set; }
    }
}
