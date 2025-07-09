namespace Application.Entities.DTOs
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int TotalRecords { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
        public bool HasNextPage => Page < TotalPages;
        public bool HasPreviousPage => Page > 1;

        // Search and sort info
        public string? SearchTerm { get; set; }
        public string? SortBy { get; set; }
        public string? SortDirection { get; set; }

        public static PagedResult<T> Create(IEnumerable<T> data, int totalRecords, int page, int pageSize, 
            string? searchTerm = null, string? sortBy = null, string? sortDirection = null)
        {
            return new PagedResult<T>
            {
                Data = data,
                TotalRecords = totalRecords,
                Page = page,
                PageSize = pageSize,
                SearchTerm = searchTerm,
                SortBy = sortBy,
                SortDirection = sortDirection
            };
        }
    }
} 