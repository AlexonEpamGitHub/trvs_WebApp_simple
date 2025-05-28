using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Check-In Date")]
        public DateTime CheckInDate { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Check-Out Date")]
        public DateTime CheckOutDate { get; set; }
        
        [Required]
        public int CustomerId { get; set; }
        
        // Navigation property should be nullable
        public Customer? Customer { get; set; }
        
        [Required]
        public int HotelId { get; set; }
        
        // Navigation property should be nullable
        public Hotel? Hotel { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
    }
}