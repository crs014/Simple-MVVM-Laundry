using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laundry.Entity.Models
{
    public class Rates
    {
        [Key]
        public int Id { get; set; }

        public int ShirtId { get; set; }
        
        public int ServiceId { get; set; }
        
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Unit { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }

        [ForeignKey("ShirtId")]
        public virtual Shirt Shirt { get; set; }
    }
}
