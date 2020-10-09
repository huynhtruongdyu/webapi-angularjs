using _1.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Data.Mapping
{
    public class OrderMapping:EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            ToTable("Order");
            HasKey(x => x.Id);
            HasOptional(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
        }
    }
}
