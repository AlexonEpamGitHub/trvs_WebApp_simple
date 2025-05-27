using Microsoft.EntityFrameworkCore;
using new_app.Models;

namespace new_app.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for each model/entity
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Country and Hotel relationship (One Country -> Many Hotels)
            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.Country)
                .WithMany(c => c.Hotels)
                .HasForeignKey(h => h.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Customer and Order relationship (One Customer -> Many Orders)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Set table names explicitly
            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Hotel>().ToTable("Hotels");
            modelBuilder.Entity<Order>().ToTable("Orders");
        }
    }
}