using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}