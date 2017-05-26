namespace Quandl.NET.Model
{
    public class TableMeta
    {
        public TableMeta(int? next_cursor_id)
        {
            NextCursorId = next_cursor_id;
        }

        public int? NextCursorId { get; private set; }
    }
}