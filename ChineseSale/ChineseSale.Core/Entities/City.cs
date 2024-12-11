using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Core.Entities
{
    [Table("Cities")]

    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string CityName { get; set; }
    }
}
