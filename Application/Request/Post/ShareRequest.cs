using System.ComponentModel.DataAnnotations;

namespace Application.Request.Post
{
    public class ShareRequest
    {
        [Required]
        public Guid PostId { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
