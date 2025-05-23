// Hotel.cs
using System.ComponentModel.DataAnnotations;

namespace new_app.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Range(1, 5)]
        public int Stars { get; set; }

        [Required]
        [Range(1, 1000)]
        public decimal PricePerNight { get; set; }

        [Required]
        public bool IsAllInclusive { get; set; }
    }
}