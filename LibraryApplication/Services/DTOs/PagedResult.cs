namespace LibraryApplication.Services.DTOs
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public PagedResult(IEnumerable<T> items, int totalCount, int currentPage, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
    }
}
