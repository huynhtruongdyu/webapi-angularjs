using _1.Core.Domain;
using _2.Data.Infrastructure.Implement;
using _2.Data.Infrastructure.Interface;

namespace _2.Data.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}