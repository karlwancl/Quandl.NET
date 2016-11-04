using System.Collections.Generic;

namespace Quandl.NET.Model
{
    public class Datatable
    {
        public Datatable(List<object[]> data, List<Column> columns)
        {
            Data = data;
            Columns = columns;
        }

        public List<object[]> Data { get; private set; }

        public List<Column> Columns { get; private set; }
    }
}