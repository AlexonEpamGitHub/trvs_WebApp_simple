using Microsoft.EntityFrameworkCore;
using new_app.Data.Entities;
using System.Linq;

namespace new_app.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        // Example of a secure query using LINQ for Users
        public IQueryable<User> GetUsersByName(string name)
        {
            return Users.Where(user => user.Name == name);
        }

        // Example of a secure query using LINQ for Contacts
        public IQueryable<Contact> GetContactsByPhoneNumber(string phoneNumber)
        {
            return Contacts.Where(contact => contact.PhoneNumber == phoneNumber);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example configuration for User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            });

            // Example configuration for Contact entity
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
                entity.Property(e => e.Message).HasMaxLength(500);
            });
        }
    }
}