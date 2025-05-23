using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace new_app.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        
        [Required]
        public int HotelId { get; set; }

        [Required]
        public DateTime DateOrdered { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int NumberOfDays { get; set; }

        public double FullPrice { get; set; }

        public Customer Customer { get; set; }

        public Hotel Hotel { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}