using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace HotelReservationSystem.Models
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            
            // Ensure database is created
            await context.Database.EnsureCreatedAsync();
            
            // Check if there are any countries
            if (await context.Countries.AnyAsync())
            {
                return; // DB has been seeded
            }
            
            // Add seed data
            var countries = new Country[]
            {
                new Country { Name = "USA" },
                new Country { Name = "UK" },
                new Country { Name = "France" },
                new Country { Name = "Spain" },
                new Country { Name = "Italy" }
            };
            
            await context.Countries.AddRangeAsync(countries);
            await context.SaveChangesAsync();
        }
    }
}