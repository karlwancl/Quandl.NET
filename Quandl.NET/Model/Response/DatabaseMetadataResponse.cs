namespace Quandl.NET.Model.Response
{
    public class DatabaseMetadataResponse
    {
        public DatabaseMetadataResponse(DatabaseMetadata database)
        {
            Database = database;
        }

        public DatabaseMetadata Database { get; private set; }
    }
}