namespace new_app.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign key relationship
        public ICollection<Hotel> Hotels { get; set; }
    }
}