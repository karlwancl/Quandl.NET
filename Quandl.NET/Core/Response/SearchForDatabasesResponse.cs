using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Core.Response
{
    public class SearchForDatabasesResponse
    {
        public SearchForDatabasesResponse(List<Metadata> databases)
        {
            Databases = databases;
        }

        public List<Metadata> Databases { get; private set; }
    }
}
