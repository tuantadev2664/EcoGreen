using System.ComponentModel.DataAnnotations;

namespace Application.Request.Post
{
    public class PostSearchRequest
    {
        // Search parameters
        public string? SearchTerm { get; set; } // Search in title, description, location
        public string? Content { get; set; }
        public Guid? CreatedByUserId { get; set; }

        // Date range filters
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        // Pagination
        [Range(1, int.MaxValue, ErrorMessage = "Page must be greater than 0")]
        public int Page { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "PageSize must be between 1 and 100")]
        public int PageSize { get; set; } = 10;

        // Sorting
        public string? SortBy { get; set; } = "Date"; // Default sort by Date
        public SortDirection SortDirection { get; set; } = SortDirection.Desc; // Default newest first
    }



    public static class PostSortFields
    {
        public const string Content = "Content";
        public const string CreatedAt = "CreatedAt";
        public const string CreatedByUserId = "CreatedByUserId";

        public static readonly string[] ValidFields = {
            Content, CreatedByUserId,CreatedAt
        };

        public static bool IsValidSortField(string? field)
        {
            return !string.IsNullOrEmpty(field) && ValidFields.Contains(field, StringComparer.OrdinalIgnoreCase);
        }
    }
}
