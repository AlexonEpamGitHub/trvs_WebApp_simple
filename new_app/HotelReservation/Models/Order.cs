using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        public DateTime BookingDate { get; set; }
        
        [Required]
        public DateTime CheckInDate { get; set; }
        
        [Required]
        public DateTime CheckOutDate { get; set; }
        
        [Required]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        
        [Required]
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        
        [Required]
        public double TotalPrice { get; set; }
    }
}