namespace HotelReservationSystem.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}