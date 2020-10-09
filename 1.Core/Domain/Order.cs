using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.Core.Domain
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "NVARCHAR")]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR")]
        public string Address { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }

        [MaxLength(32)]
        [Required]
        public string Phone { get; set; }

        public decimal Total { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}