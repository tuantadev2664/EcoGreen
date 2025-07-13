using System.ComponentModel.DataAnnotations;

namespace Application.Request.Activity
{
    public class ActivitySearchRequest
    {
        // Search parameters
        public string? SearchTerm { get; set; } // Search in title, description, location
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public Guid? CreatedByCompanyId { get; set; }
        public bool? IsApproved { get; set; }

        // Date range filters
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        // Amount of people filters
        public int? MinPeople { get; set; }
        public int? MaxPeople { get; set; }

        // Pagination
        [Range(1, int.MaxValue, ErrorMessage = "Page must be greater than 0")]
        public int Page { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "PageSize must be between 1 and 100")]
        public int PageSize { get; set; } = 10;

        // Sorting
        public string? SortBy { get; set; } = "Date"; // Default sort by Date
        public SortDirection SortDirection { get; set; } = SortDirection.Desc; // Default newest first
    }


    public static class ActivitySortFields
    {
        public const string Title = "Title";
        public const string Description = "Description";
        public const string Location = "Location";
        public const string Date = "Date";
        public const string AmountOfPeople = "AmountOfPeople";
        public const string IsApproved = "IsApproved";
        public const string CreatedByCompanyId = "CreatedByCompanyId";

        public static readonly string[] ValidFields = {
            Title, Description, Location, Date, AmountOfPeople, IsApproved, CreatedByCompanyId
        };

        public static bool IsValidSortField(string? field)
        {
            return !string.IsNullOrEmpty(field) && ValidFields.Contains(field, StringComparer.OrdinalIgnoreCase);
        }
    }
}