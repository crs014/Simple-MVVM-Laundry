using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laundry.Entity.Models
{
    public class TransactionDetail
    {
        [Key, Column(Order = 0)]
        public int RatesId { get; set; }

        [Key, Column(Order = 1)]
        public int TransactionId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("RatesId")]
        public virtual Rates Rates { get; set; }
    
        [ForeignKey("TransactionId")]
        public virtual Transaction Transaction { get; set; }
    }
}
