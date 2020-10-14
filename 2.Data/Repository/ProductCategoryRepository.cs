using _1.Core.Domain;
using _2.Data.Infrastructure.Implement;
using _2.Data.Infrastructure.Interface;

namespace _2.Data.Repository
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}