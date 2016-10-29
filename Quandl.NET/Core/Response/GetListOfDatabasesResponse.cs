using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Core.Response
{
    public class GetListOfDatabasesResponse
    {
        public GetListOfDatabasesResponse(List<Metadata> databases, Meta meta)
        {
            Databases = databases;
            Meta = meta;
        }

        public List<Metadata> Databases { get; private set; }

        public Meta Meta { get; private set; }
    }
}
