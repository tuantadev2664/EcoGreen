using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Entities.Base
{
    public enum RegistrationStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class Registration
    {
        [Key]
        public Guid RegistrationId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [Required]
        public Guid ActivityId { get; set; }

        [ForeignKey(nameof(ActivityId))]
        public virtual Activity Activity { get; set; }

        [Required]
        public RegistrationStatus Status { get; set; }

        public bool Attended { get; set; }
    }
}
