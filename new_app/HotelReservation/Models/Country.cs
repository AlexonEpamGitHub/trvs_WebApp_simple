using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        // Navigation property for related hotels
        public ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}