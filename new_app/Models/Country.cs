using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace new_app.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Name of the country

        [Required]
        [MaxLength(10)]
        public string Code { get; set; } // Country code (e.g., ISO standards)

        // Optional navigation property for related data
        public ICollection<Hotel> Hotels { get; set; } // Relationship with Hotels (if applicable)
    }
}