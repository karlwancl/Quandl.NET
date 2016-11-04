namespace Quandl.NET.Model.Response
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