using System;
using System.Collections.Generic;

namespace Quandl.NET.Model
{
    public class TimeseriesMetadata
    {
        public TimeseriesMetadata(int id, string database_code, string dataset_code, string name, string description,
            DateTime? refreshed_at, DateTime? newest_available_date, DateTime? oldest_available_date, List<string> column_names,
            string frequency, string type, bool? premium, int database_id)
        {
            Id = id;
            DatabaseCode = database_code;
            DatasetCode = dataset_code;
            Name = name;
            Description = description;
            RefreshedAt = refreshed_at;
            NewestAvailableDate = newest_available_date;
            OldestAvailableDate = oldest_available_date;
            ColumnNames = column_names;
            Frequency = frequency;
            Type = type;
            Premium = premium;
            DatabaseId = database_id;
        }

        public int Id { get; private set; }

        public string DatabaseCode { get; private set; }

        public string DatasetCode { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime? RefreshedAt { get; private set; }

        public DateTime? NewestAvailableDate { get; private set; }

        public DateTime? OldestAvailableDate { get; private set; }

        public List<string> ColumnNames { get; private set; }

        public string Frequency { get; private set; }

        public string Type { get; private set; }

        public bool? Premium { get; private set; }

        public int DatabaseId { get; private set; }
    }
}