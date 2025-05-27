using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        
        [Required]
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }
        
        public double TotalPrice { get; set; }
    }
}