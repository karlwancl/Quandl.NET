namespace Quandl.NET.Model
{
    public class Meta
    {
        public Meta(string query, int per_page, int current_page, int? prev_page, int total_pages, int total_count,
            int? next_page, int current_first_item, int current_last_item)
        {
            Query = query;
            PerPage = per_page;
            CurrentPage = current_page;
            PrevPage = prev_page;
            TotalPages = total_pages;
            TotalCount = total_count;
            NextPage = next_page;
            CurrentFirstItem = current_first_item;
            CurrentLastItem = current_last_item;
        }

        public string Query { get; private set; }

        public int PerPage { get; private set; }

        public int CurrentPage { get; private set; }

        public int? PrevPage { get; private set; }

        public int TotalPages { get; private set; }

        public int TotalCount { get; private set; }

        public int? NextPage { get; private set; }

        public int CurrentFirstItem { get; private set; }

        public int CurrentLastItem { get; private set; }
    }
}