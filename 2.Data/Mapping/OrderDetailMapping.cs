using _1.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Data.Mapping
{
    public class OrderDetailMapping:EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMapping()
        {
            ToTable("OrderDetail");
            HasKey(x => x.Id);
            HasRequired(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
        }
    }
}
