using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Core.Entities
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int Amount { get; set; }
        public int FinalPayment { get; set; }
    }
}
