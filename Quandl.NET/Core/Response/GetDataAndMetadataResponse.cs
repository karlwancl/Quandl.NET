using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Core.Response
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
