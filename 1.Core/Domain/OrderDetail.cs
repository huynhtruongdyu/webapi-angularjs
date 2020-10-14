using System.ComponentModel.DataAnnotations.Schema;

namespace _1.Core.Domain
{
    public class OrderDetail : BaseEntity
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int Amount { get; set; }
        public decimal Total { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}