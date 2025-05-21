using System.ComponentModel.DataAnnotations;

namespace new_app.Models.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string SupportEmail { get; set; }

        [Required]
        [EmailAddress]
        public string MarketingEmail { get; set; }
    }
}