namespace HotelReservation.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}