using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Models
{
    /// <summary>
    /// Represents a customer entity within the application.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the customer.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the customer.
        /// </summary>
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Navigation property for a collection of orders placed by the customer.
        /// </summary>
        public ICollection<Order> Orders { get; set; }
    }
}