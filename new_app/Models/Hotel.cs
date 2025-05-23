using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace new_app.Models
{
    public class Hotel
    {
        // Primary key
        [Key]
        public int Id { get; set; }

        // Hotel name is required and should not exceed 255 characters
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        // Address of the hotel
        [Required]
        [MaxLength(500)]
        public string Address { get; set; } = string.Empty;

        // City where the hotel is located
        [Required]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        // Foreign key to the Country model
        [Required]
        public int CountryId { get; set; }

        // Navigation property for Country
        public Country? Country { get; set; }

        // Hotel rating (e.g., stars)
        public double? Rating { get; set; }

        // Amenities as a comma-separated string
        public string? Amenities { get; set; }
    }
}