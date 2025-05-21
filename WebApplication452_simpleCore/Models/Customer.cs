using System.ComponentModel.DataAnnotations;

namespace WebApplication452_simple.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}