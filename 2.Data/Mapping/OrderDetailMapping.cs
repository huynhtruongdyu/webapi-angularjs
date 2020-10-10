using _1.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace _2.Data.Mapping
{
    public class OrderDetailMapping : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMapping()
        {
            ToTable("OrderDetail");
            HasKey(x => x.Id);
            HasRequired(x => x.Order);
            HasRequired(x => x.Product);
        }
    }
}