using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace new_app.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Country name is required")]
        [MaxLength(255, ErrorMessage = "Country name cannot exceed 255 characters")]
        public string Name { get; set; } = string.Empty;

        // Navigation property for the relationship with Hotel entities
        public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}