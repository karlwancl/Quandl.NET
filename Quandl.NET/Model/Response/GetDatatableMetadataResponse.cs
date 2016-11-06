namespace Quandl.NET.Model.Response
{
    public class GetDatatableMetadataResponse
    {
        private DatatableMetadata _datatable;

        public GetDatatableMetadataResponse(DatatableMetadata datatable)
        {
            _datatable = datatable;
        }

        public DatatableMetadata Datatable => _datatable;
    }
}