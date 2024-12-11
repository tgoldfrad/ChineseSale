using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Core.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DonorId { get; set; }
        [ForeignKey(nameof(DonorId))]
        public Donor Donor { get; set; }
        public DateTime OrderDate { get; set; }
        public bool PaymentIsOrdered { get; set; }
        public bool? IsTaxReceipt { get; set; }
        [MaxLength(100)]
        public string? NameReceipt { get; set; }
        public int OrderFinalPayment { get; set; }
        public string Remarks { get; set; }
    }
}
