using System;
using System.ComponentModel.DataAnnotations;

namespace new_app.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Hotel Hotel { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOrdered { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public int NumberOfDays
        {
            get
            {
                return (EndDate - StartDate).Days;
            }
        }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal FullPrice { get; set; }
    }
}