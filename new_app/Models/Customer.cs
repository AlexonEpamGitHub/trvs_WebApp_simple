using System.ComponentModel.DataAnnotations;

namespace WebApplication.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}