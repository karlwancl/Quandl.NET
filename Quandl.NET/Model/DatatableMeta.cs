using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Model
{
    public class DatatableMeta
    {
        public DatatableMeta(int? next_cursor_id)
        {
            NextCursorId = next_cursor_id;
        }

        public int? NextCursorId { get; private set; }
    }
}
