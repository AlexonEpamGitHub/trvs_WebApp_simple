using System.ComponentModel.DataAnnotations;

namespace new_app.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(3)]
        public string CountryCode { get; set; }

        [StringLength(3)]
        public string CurrencyCode { get; set; }
    }
}