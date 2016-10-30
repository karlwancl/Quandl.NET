using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Model
{
    public class DatabaseMetadata
    {
        public DatabaseMetadata(int id, string name, string database_code, string description, int datasets_count, long downloads,
            bool premium, string image)
        {
            Id = id;
            Name = name;
            DatabaseCode = database_code;
            Description = description;
            DatasetsCount = datasets_count;
            Downloads = downloads;
            Premium = premium;
            Image = image;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string DatabaseCode { get; private set; }

        public string Description { get; private set; }

        public int DatasetsCount { get; private set; }

        public long Downloads { get; private set; }

        public bool Premium { get; private set; }

        public string Image { get; private set; }
    }
}
