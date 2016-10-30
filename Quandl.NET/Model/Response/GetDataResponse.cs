using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Model.Response
{
    public class GetDataResponse
    {
        public GetDataResponse(DatasetData dataset_data)
        {
            DatasetData = dataset_data;
        }

        public DatasetData DatasetData { get; private set; }
    }
}
