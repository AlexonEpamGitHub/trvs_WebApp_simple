using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewApp.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(3)]
        public string Code { get; set; }

        // Navigation property for related hotels
        public ICollection<Hotel> Hotels { get; set; }
    }
}