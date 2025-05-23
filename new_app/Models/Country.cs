using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace new_app.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(3)]
        public string CountryCode { get; set; }

        // Navigation property for related Hotels
        public ICollection<Hotel>? Hotels { get; set; }
    }
}