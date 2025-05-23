using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace new_app.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(3)]
        public string Code { get; set; }

        // Navigation property for Hotels
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}