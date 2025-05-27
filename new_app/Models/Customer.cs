using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace new_app.Models
{
    /// <summary>
    /// Represents a customer in the hotel reservation system.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the birthdate of the customer.
        /// </summary>
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? Birthdate { get; set; }
        
        /// <summary>
        /// Gets or sets the collection of orders associated with this customer.
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Order>? Orders { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
    }
}