using _1.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace _2.Data.Mapping
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            ToTable("Product");
            HasKey(x => x.Id);
            HasOptional(x => x.ProductCategory).WithMany(x => x.Products).HasForeignKey(x => x.Id);
        }
    }
}