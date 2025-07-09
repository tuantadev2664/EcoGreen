using System.ComponentModel.DataAnnotations;

namespace Application.Entities.DTOs
{
    public class CreateActivityRequest
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title can't exceed 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description can't exceed 1000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(200, ErrorMessage = "Location can't exceed 200 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Amount of people is required.")]
        public int AmountOfPeople { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required]
        public Guid CreatedByCompanyId { get; set; }

        public bool IsApproved { get; set; }
    }
} 