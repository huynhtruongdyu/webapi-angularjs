using _1.Core.Domain;
using _2.Data.Infrastructure.Implement;
using _2.Data.Infrastructure.Interface;

namespace _2.Data.Repository
{
    public interface IOrderDetailRepository::IRepository<OrderDetail>
    {
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}