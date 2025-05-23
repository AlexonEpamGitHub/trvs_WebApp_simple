using System;
using System.ComponentModel.DataAnnotations;

namespace new_app.Models
{
    public class Customer
    {
        public int Id { get; set; } // Primary key

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } // Name with validation

        public DateTime? Birthdate { get; set; } // Optional birthdate
    }
}