using System;
using System.Collections.Generic;

namespace Quandl.NET.Model
{
    public class TimeseriesData
    {
        public TimeseriesData(int? limit, Transform? transform, int? column_index, List<string> column_names, DateTime? start_date,
            DateTime? end_date, string frequency, List<object[]> data, Collapse? collapse, Order? order)
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
        }

        public int? Limit { get; private set; }

        public Transform? Transform { get; private set; }

        public int? ColumnIndex { get; private set; }

        public List<string> ColumnNames { get; private set; }

        public DateTime? StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public string Frequency { get; private set; }

        public List<object[]> Data { get; private set; }

        public Collapse? Collapse { get; private set; }

        public Order? Order { get; private set; }
    }
}