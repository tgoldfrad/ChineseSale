using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Core.Entities
{
    [Table("Donors")]

    public class Donor
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        [MinLength(9)]
        [Required]
        public string Identity { get; set; }
        [MaxLength(50)]
        public string DonorFirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string DonorLastName { get; set; }
        [MaxLength(100)]
        public string DonorAdress { get; set; }
        public int DonorCity { get; set; }
        [ForeignKey(nameof(DonorCity))]
        public City City { get; set; }
        [MaxLength(10)]
        [MinLength(7)]
        public string? DonorTelephone { get; set; }
        public string DonorPhone { get; set; }
    }
}
