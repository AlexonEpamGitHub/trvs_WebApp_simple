using System;

namespace WebApplication452_simple.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        // Additional properties can be added here

        // Ensure compatibility with .NET 8 features, such as nullability
        public DateTime? DateOfBirth { get; set; }

        // Example method
        public int GetAge()
        {
            if (DateOfBirth == null)
            {
                throw new InvalidOperationException("DateOfBirth is not set.");
            }

            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Value.Year;

            if (DateOfBirth.Value.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}