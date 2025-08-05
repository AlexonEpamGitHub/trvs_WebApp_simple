using Microsoft.EntityFrameworkCore;

namespace WebApplicationCore.Models
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
            
            // Additional model configurations can be added here
            // For example:
            // modelBuilder.Entity<Hotel>()
            //     .HasOne(h => h.Country)
            //     .WithMany()
            //     .HasForeignKey(h => h.CountryId)
            //     .IsRequired();
        }
    }
}