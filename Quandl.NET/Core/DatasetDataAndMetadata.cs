using Quandl.NET.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quandl.NET.Core
{
    public class DatasetDataAndMetadata
    {
        public DatasetDataAndMetadata(int? limit, Transform? transform, int? column_index, List<string> column_names, DateTime? start_date,
            DateTime? end_date, string frequency, List<object[]> data, Collapse? collapse, Order? order, int id, string database_code, string dataset_code, 
            string name, string description, DateTime? refreshed_at, DateTime? newest_available_date, DateTime? oldest_available_date, string type, 
            bool? premium, int database_id)
        {
            Limit = limit;
            Transform = transform;
            ColumnIndex = column_index;
            ColumnNames = column_names;
            StartDate = start_date;
            EndDate = end_date;
            Frequency = frequency;
            Data = data;
            Collapse = collapse;
            Order = order;
            Id = id;
            DatabaseCode = database_code;
            DatasetCode = dataset_code;
            Name = name;
            Description = description;
            RefreshedAt = refreshed_at;
            NewestAvailableDate = newest_available_date;
            OldestAvailableDate = oldest_available_date;
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

        public string Type { get; private set; }

        public bool? Premium { get; private set; }

        public int DatabaseId { get; private set; }

        public int? Limit { get; private set; }

        public Transform? Transform { get; private set; }

        public int? ColumnIndex { get; private set; }

        public DateTime? StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public string Frequency { get; private set; }

        public List<object[]> Data { get; private set; }

        public Collapse? Collapse { get; private set; }

        public Order? Order { get; private set; }
    }
}
