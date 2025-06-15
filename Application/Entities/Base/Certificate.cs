using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Entities.Base
{
    public class Certificate
    {
        [Key]
        public Guid CertificatedId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [Required]
        public Guid ActivityId { get; set; }

        [ForeignKey(nameof(ActivityId))]
        public virtual Activity Activity { get; set; }

        [Required]
        public Guid IssuedByCompanyId { get; set; }

        [ForeignKey(nameof(IssuedByCompanyId))]
        public virtual User CompanyUser { get; set; }

        [Required(ErrorMessage = "Issue date is required.")]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Certificate URL is required.")]
        [Url(ErrorMessage = "CertificateUrl must be a valid URL.")]
        public string CertificateUrl { get; set; }
    }
}
