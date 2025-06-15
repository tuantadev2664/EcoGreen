using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Entities.Base
{
    public class Activity
    {
        [Key]
        public Guid ActivityId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title can't exceed 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description can't exceed 1000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(200, ErrorMessage = "Location can't exceed 200 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required]
        public Guid CreatedByCompanyId { get; set; }

        [ForeignKey(nameof(CreatedByCompanyId))]
        public virtual User CompanyUser { get; set; }

        public bool IsApproved { get; set; }
    }
}
