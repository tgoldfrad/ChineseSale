using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Core.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [MaxLength(50)]
        public string ProductName { get; set; }

        public string Description { get; set; }
        public int ProductPrice { get; set; }
        public int NumWinners { get; set; }
        [MaxLength(50)]
        public string DonatedBy { get; set; }
    }
}
