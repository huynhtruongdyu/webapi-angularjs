using _1.Core.Domain;
using _2.Data.Infrastructure.Implement;
using _2.Data.Infrastructure.Interface;

namespace _2.Data.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}