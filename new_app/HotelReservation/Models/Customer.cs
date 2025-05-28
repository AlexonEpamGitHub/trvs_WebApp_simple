using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public required string Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public required string Email { get; set; } = string.Empty;
        
        // Navigation property
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}