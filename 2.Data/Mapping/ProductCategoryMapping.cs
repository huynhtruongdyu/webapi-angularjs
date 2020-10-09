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
            HasMany(x => x.Products).WithRequired(x => x.ProductCategory).HasForeignKey(x => x.Id);
        }
    }
}