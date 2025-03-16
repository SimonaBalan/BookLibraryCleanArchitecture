namespace BookLibraryCleanArchitecture.Server.Models.ApiParameters
{
    public class PaginatedListQueryParameters
    {
        public string SortDirection { get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string SortColumn { get; set; } = "";

        public Dictionary<string, string> Filters { get; set; } = null;
    }
}
