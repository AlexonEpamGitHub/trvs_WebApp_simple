using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace new_app.Models
{
    public class Hotel
    {
        // Primary key property for Hotel entity
        [Key]
        public int Id { get; set; }

        // Name of the hotel with required validation
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Foreign key for related Country entity
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        // Navigation property for Country
        public Country Country { get; set; }

        // City where the hotel is located
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        // Star rating of the hotel (nullable and restricted range 1-5)
        [Range(1, 5)]
        public double? Stars { get; set; }

        // Price per night (marked as currency)
        [Required]
        [DataType(DataType.Currency)]
        public double PricePerNight { get; set; }

        // Indicates whether the hotel is all-inclusive
        public bool IsAllInclusive { get; set; }
    }
}