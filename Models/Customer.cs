using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        public DateTime? Birthdate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        public ICollection<Order>? Orders { get; set; }
    }
}
