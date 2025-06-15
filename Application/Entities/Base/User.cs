using System.ComponentModel.DataAnnotations;

namespace Application.Entities.Base
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name can't exceed 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [RegularExpression("^(Member|Company|Admin)$", ErrorMessage = "Role must be 'Member', 'Company', or 'Admin'.")]
        public string Role { get; set; }

        [Url(ErrorMessage = "Profile photo must be a valid URL.")]
        public string ProfilePhotoUrl { get; set; }
    }
}
