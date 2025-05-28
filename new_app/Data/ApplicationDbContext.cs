using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Hotel> Hotels { get; set; } = default!;
        public DbSet<Country> Countries { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        // Optional: Configure entity relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Add any fluent API configurations here if needed
        }
    }
}