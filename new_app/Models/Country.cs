using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace new_app.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Country name

        // Navigation property
        public ICollection<Hotel> Hotels { get; set; }

        public Country()
        {
            Hotels = new List<Hotel>();
        }
    }
}