using System.ComponentModel.DataAnnotations;

namespace Application.Request.Post
{
    public class CreatePostRequest
    {
        [Required(ErrorMessage = "Content is required.")]
        [StringLength(1000, ErrorMessage = "Content can't exceed 1000 characters.")]
        public string Content { get; set; }

        [Required]
        public Guid UserId { get; set; }

    }
}
