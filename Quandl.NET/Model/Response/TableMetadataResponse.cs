namespace Quandl.NET.Model.Response
{
    public class TableMetadataResponse
    {
        private TableMetadata _datatable;

        public TableMetadataResponse(TableMetadata datatable)
        {
            _datatable = datatable;
        }

        public TableMetadata Datatable => _datatable;
    }
}