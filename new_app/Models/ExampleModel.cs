using System;
using System.ComponentModel.DataAnnotations;

namespace NewApp.Models
{
    /// <summary>
    /// Represents an example entity in the application.
    /// </summary>
    public class ExampleModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the example entity.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the example entity.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the example entity.
        /// </summary>
        [Required]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Navigation property for related entities.
        /// </summary>
        public virtual ICollection<RelatedEntity> RelatedEntities { get; set; }
    }
}