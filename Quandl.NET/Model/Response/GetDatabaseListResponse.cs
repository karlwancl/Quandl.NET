using System.Collections.Generic;

namespace Quandl.NET.Model.Response
{
    public class GetDatabaseListResponse
    {
        public GetDatabaseListResponse(List<DatabaseMetadata> databases, Meta meta)
        {
            Databases = databases;
            Meta = meta;
        }

        public List<DatabaseMetadata> Databases { get; private set; }

        public Meta Meta { get; private set; }
    }
}