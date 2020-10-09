using _1.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace _2.Data.Mapping
{
    public class ProductCategoryMapping : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryMapping()
        {
            ToTable("ProductCategory");
            HasKey(x => x.Id);
            HasMany(x => x.Products).WithOptional(x => x.ProductCategory).HasForeignKey(x => x.Id);
        }
    }
}