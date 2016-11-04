using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Model
{
    public class DatatableMetadata
    {
        public DatatableMetadata(string vendor_code, string datatable_code, string name, string description, List<Column> columns,
            List<string> filters, List<string> primary_key, bool? premium, Status status)
        {
            VendorCode = vendor_code;
            DatatableCode = datatable_code;
            Name = name;
            Description = description;
            Columns = columns;
            Filters = filters;
            PrimaryKey = primary_key;
            Premium = premium;
            Status = status;
        }

        public string VendorCode { get; private set; }

        public string DatatableCode { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public List<Column> Columns { get; private set; }

        public List<string> Filters { get; private set; }

        public List<string> PrimaryKey { get; private set; }

        public bool? Premium { get; private set; }

        public Status Status { get; private set; }
    }
}
