using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Additional properties and annotations can be added as needed
    }
}