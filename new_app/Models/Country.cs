using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace new_app.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(3)]
        public string Code { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<Hotel> Hotels { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Code})";
        }
    }
}