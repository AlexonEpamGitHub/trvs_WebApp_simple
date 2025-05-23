using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace new_app.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        // Navigation property for related Hotels
        public ICollection<Hotel> Hotels { get; set; }
    }
}