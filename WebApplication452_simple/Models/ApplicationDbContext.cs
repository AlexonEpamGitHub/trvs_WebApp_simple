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

            // Fluent API configuration for Hotel
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.Property(h => h.Name)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(h => h.Address)
                      .HasMaxLength(200);
                entity.HasOne(h => h.Country)
                      .WithMany(c => c.Hotels)
                      .HasForeignKey(h => h.CountryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Fluent API configuration for Country
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasMany(c => c.Hotels)
                      .WithOne(h => h.Country)
                      .HasForeignKey(h => h.CountryId);
            });
        }
    }
}