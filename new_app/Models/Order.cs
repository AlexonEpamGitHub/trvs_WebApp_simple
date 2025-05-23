using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace new_app.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [Required]
        [Range(0, Double.MaxValue, ErrorMessage = "Amount must be non-negative.")]
        public decimal Amount { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Completed,
        Cancelled
    }

    public class LineItem
    {
        [Key]
        public int LineItemId { get; set; }
        
        [Required]
        public int OrderId { get; set; }
        
        [Required]
        public string ProductName { get; set; }
        
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
    }
}