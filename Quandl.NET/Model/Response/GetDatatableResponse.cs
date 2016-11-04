namespace Quandl.NET.Model.Response
{
    public class GetDatatableResponse
    {
        public GetDatatableResponse(Datatable datatable, DatatableMeta meta)
        {
            Datatable = datatable;
            Meta = meta;
        }

        public Datatable Datatable { get; private set; }

        public DatatableMeta Meta { get; private set; }
    }
}