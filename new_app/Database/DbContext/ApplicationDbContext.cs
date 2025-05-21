using Microsoft.EntityFrameworkCore;

namespace new_app.Database.DbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define DbSet properties for your entities
        public DbSet<ExampleModel> Examples { get; set; }

        // Add more DbSet properties as you add more models
        // Example: public DbSet<AnotherModel> AnotherModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships and constraints here
            modelBuilder.Entity<ExampleModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            // Add configurations for other models here
            // Example:
            // modelBuilder.Entity<AnotherModel>(entity =>
            // {
            //     entity.HasKey(e => e.Id);
            //     entity.Property(e => e.Description).HasMaxLength(250);
            // });
        }

        public static ApplicationDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("YourConnectionStringHere"); // Replace with your actual connection string
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

    // Example model for reference
    public class ExampleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Example of another model (add as needed)
    // public class AnotherModel
    // {
    //     public int Id { get; set; }
    //     public string Description { get; set; }
    // }
}