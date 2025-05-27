using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Hotel> Hotels { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure entity relationships if needed
            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.Country)
                .WithMany(c => c.Hotels)
                .HasForeignKey(h => h.CountryId);
                
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
                
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Hotel)
                .WithMany()
                .HasForeignKey(o => o.HotelId);
        }
    }
}