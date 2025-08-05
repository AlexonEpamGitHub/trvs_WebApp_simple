using System;
using System.
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication_Core.Models;

public class Country
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; }
}