using System.ComponentModel.DataAnnotations;

namespace WebApplication8_simple.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        public Customer? Customer { get; set; }
        
        [Required]
        public int CustomerId { get; set; }
        
        public Hotel? Hotel { get; set; }
        
        [Required]
        public int HotelId { get; set; }
        
        [Required]
        public DateTime CheckInDate { get; set; }
        
        [Required]
        public DateTime CheckOutDate { get; set; }
        
        [Required]
        [Range(1, 10)]
        public int RoomCount { get; set; }
    }
}