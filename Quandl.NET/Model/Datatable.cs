using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public class Column
        {
            public Column(string name, string type)
            {
                Name = name;
                Type = type;
            }

            public string Name { get; private set; }

            public string Type { get; private set; }
        }
    }
}
