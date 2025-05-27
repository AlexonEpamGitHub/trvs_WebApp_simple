using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewApp.Models
{
    /// <summary>
    /// Represents a hotel entity with basic details and relationships.
    /// </summary>
    public class Hotel
    {
        /// <summary>
        /// Gets or sets the primary key for the hotel.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the hotel.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the country where the hotel is located.
        /// </summary>
        [MaxLength(50)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the city where the hotel is located.
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the star rating of the hotel.
        /// </summary>
        public int? Stars { get; set; }

        /// <summary>
        /// Gets or sets the price per night for the hotel.
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Navigation property for accessing related bookings/orders.
        /// </summary>
        public ICollection<Order> Bookings { get; set; }
    }
}