using Microsoft.EntityFrameworkCore;
using new_app.Models;

namespace new_app.Data
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

            // Hotel configuration
            modelBuilder.Entity<Hotel>()
                .Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Hotel>()
                .Property(h => h.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Hotel>()
                .Property(h => h.Stars)
                .IsRequired();

            modelBuilder.Entity<Hotel>()
                .Property(h => h.PricePerNight)
                .IsRequired();

            modelBuilder.Entity<Hotel>()
                .Property(h => h.IsAllInclusive)
                .IsRequired();

            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.Country)
                .WithMany()
                .HasForeignKey(h => h.CountryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Customer configuration
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Order configuration
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey("CustomerId")
                .IsRequired();

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Hotel)
                .WithMany()
                .HasForeignKey("HotelId")
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.DateOrdered)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.StartDate)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.EndDate)
                .IsRequired();

            // Configure FullPrice and NumberOfDays as computed properties
            modelBuilder.Entity<Order>()
                .Property(o => o.FullPrice)
                .HasComputationExpression("DATEDIFF(day, [StartDate], [EndDate]) * (SELECT [PricePerNight] FROM [Hotels] WHERE [Id] = [HotelId])");

            modelBuilder.Entity<Order>()
                .Property(o => o.NumberOfDays)
                .HasComputationExpression("DATEDIFF(day, [StartDate], [EndDate])");
        }
    }
}