using Microsoft.EntityFrameworkCore;

namespace new_app.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for database tables
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define custom configurations using Fluent API
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(h => h.Id); // Primary key configuration
                entity.Property(h => h.Name)
                      .IsRequired()
                      .HasMaxLength(200);
                entity.HasOne(h => h.Country)
                      .WithMany(c => c.Hotels)
                      .HasForeignKey(h => h.CountryId);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(cu => cu.Id);
                entity.Property(cu => cu.FullName)
                      .IsRequired()
                      .HasMaxLength(150);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.OrderDate)
                      .IsRequired();
                entity.HasOne(o => o.Customer)
                      .WithMany(cu => cu.Orders)
                      .HasForeignKey(o => o.CustomerId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}