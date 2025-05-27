using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication452_simple.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Required]
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        [Required]
        public DateTime DateOrdered { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [NotMapped]
        public int NumberOfDays => (EndDate - StartDate).Days;

        [Column(TypeName = "decimal(18, 2)")]
        public double FullPrice { get; set; }
    }
}