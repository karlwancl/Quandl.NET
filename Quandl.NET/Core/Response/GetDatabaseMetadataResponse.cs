using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Core.Response
{
    public class GetDatabaseMetadataResponse
    {
        public GetDatabaseMetadataResponse(DatabaseMetadata database)
        {
            Database = database;
        }

        public DatabaseMetadata Database { get; private set; } 
    }
}
