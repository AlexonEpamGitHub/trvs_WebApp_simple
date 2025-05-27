using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace new_app.Models
{
    public class Country
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }

        // Navigation property for related hotels
        public ICollection<Hotel> Hotels { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Code})";
        }
    }
}