using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Application.Entities.Base
{
    public class User : IdentityUser<Guid>
    {
        [Url(ErrorMessage = "Profile photo must be a valid URL.")]
        public string ProfilePhotoUrl { get; set; } = string.Empty;
    }
}
