using System.ComponentModel.DataAnnotations;

namespace NewApp.Data.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [MaxLength(500)]
        public string Message { get; set; }
    }
}