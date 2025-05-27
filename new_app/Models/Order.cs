using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace new_app.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }
        
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        
        [Required]
        public Hotel Hotel { get; set; }
        
        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Ordered")]
        public DateTime DateOrdered { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Number of Days")]
        [Range(1, 365, ErrorMessage = "Stay duration must be between 1 and 365 days")]
        public int NumberOfDays { get; set; }

        [Display(Name = "Full Price")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FullPrice { get; set; }
    }
}