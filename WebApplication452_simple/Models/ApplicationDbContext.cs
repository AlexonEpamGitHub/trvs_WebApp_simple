using Microsoft.EntityFrameworkCore;

namespace WebApplication452_simple.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId); // Example primary key mapping
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100); // Example property mapping
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(h => h.HotelId); // Example primary key mapping
                entity.Property(h => h.Name).IsRequired().HasMaxLength(200); // Example property mapping
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(co => co.CountryId); // Example primary key mapping
                entity.Property(co => co.Name).IsRequired().HasMaxLength(100); // Example property mapping
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderId); // Example primary key mapping
                entity.Property(o => o.Description).HasMaxLength(500); // Example property mapping
            });
        }
    }
}