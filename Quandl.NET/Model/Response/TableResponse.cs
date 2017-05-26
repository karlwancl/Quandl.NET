namespace Quandl.NET.Model.Response
{
    public class TableResponse
    {
        public TableResponse(Table datatable, TableMeta meta)
        {
            Datatable = datatable;
            Meta = meta;
        }

        public Table Datatable { get; private set; }

        public TableMeta Meta { get; private set; }
    }
}