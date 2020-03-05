using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Laundry.Entity.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Rates> Rates { get; set; }
    }
}
