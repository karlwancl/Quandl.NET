using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Core.Response
{
    public class GetDatabaseMetadataResponse
    {
        public GetDatabaseMetadataResponse(Metadata database)
        {
            Database = database;
        }

        public Metadata Database { get; private set; } 
    }
}
