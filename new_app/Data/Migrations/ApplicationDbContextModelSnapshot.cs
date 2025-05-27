using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using new_app.Models;

namespace new_app.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .UseIdentityColumns();

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Countries");

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Birthdate);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotels");

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CountryId)
                    .IsRequired();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Stars)
                    .IsRequired();

                entity.Property(e => e.PricePerNight)
                    .IsRequired();

                entity.Property(e => e.IsAllInclusive)
                    .IsRequired();

                entity.HasOne(d => d.Country)
                    .WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.HasKey(e => e.Id);

                entity.Property(e => e.DateOrdered)
                    .IsRequired();

                entity.Property(e => e.StartDate)
                    .IsRequired();

                entity.Property(e => e.EndDate)
                    .IsRequired();

                entity.Property(e => e.NumberOfDays)
                    .IsRequired();

                entity.Property(e => e.FullPrice)
                    .IsRequired();

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey("Customer_Id")
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Hotel)
                    .WithMany()
                    .HasForeignKey("Hotel_Id")
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });
#pragma warning restore 612, 618
        }
    }
}