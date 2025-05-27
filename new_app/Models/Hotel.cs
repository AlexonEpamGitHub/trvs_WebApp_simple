using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace new_app.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hotel name is required")]
        [StringLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
        public string Name { get; set; } = string.Empty;

        // Navigation property to related Country entity
        public Country? Country { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City name cannot exceed 50 characters")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Star rating is required")]
        [Range(1, 5, ErrorMessage = "Star rating must be between 1 and 5")]
        public int Stars { get; set; }

        [Required(ErrorMessage = "Price per night is required")]
        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal PricePerNight { get; set; }

        [Required]
        [Display(Name = "All Inclusive")]
        public bool IsAllInclusive { get; set; }
    }
}