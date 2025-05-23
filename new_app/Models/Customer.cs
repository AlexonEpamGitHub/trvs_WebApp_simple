using System;
using System.ComponentModel.DataAnnotations;

namespace NewApp.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}