using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Core.Response
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
