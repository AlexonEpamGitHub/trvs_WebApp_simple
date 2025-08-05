using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationCore.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Navigation property for related Hotels (added to support EF Core relationships)
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}