using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Laundry.Entity.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
