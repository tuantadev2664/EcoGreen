using System.ComponentModel.DataAnnotations;

namespace Application.Request.Post
{
    public class UpdatePostRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public string? MediaUrl { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }

}
