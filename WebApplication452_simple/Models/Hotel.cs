using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [Range(1, 5)]
        public int Stars { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 1000)]
        public decimal PricePerNight { get; set; }

        [Required]
        public bool IsAllInclusive { get; set; }
    }
}