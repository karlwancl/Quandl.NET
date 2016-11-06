using System;

namespace Quandl.NET.Model
{
    public class Status
    {
        public Status(DateTime? refreshed_at, string status, string expected_at, string update_frequency)
        {
            RefreshedAt = refreshed_at;
            StatusValue = status;
            ExpectedAt = expected_at;
            UpdateFrequency = update_frequency;
        }

        public DateTime? RefreshedAt { get; private set; }

        public string StatusValue { get; private set; }

        public string ExpectedAt { get; private set; }

        public string UpdateFrequency { get; private set; }
    }
}