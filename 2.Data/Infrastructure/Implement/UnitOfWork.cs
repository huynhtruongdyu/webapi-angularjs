using _2.Data.Infrastructure.Interface;
using _2.Data.Repository.Implement;
using System.Data.Entity;

namespace _2.Data.Infrastructure.Implement
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private MyDbContext _myDbContext;
        private DbContextTransaction _transaction;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        public MyDbContext MyDbContext
        {
            get
            {
                return _myDbContext ?? (_myDbContext = this._dbFactory.Init());
            }
        }

        public void Commit()
        {
            this._transaction.Commit();
        }

        public void CreateTransaction()
        {
            this._transaction = MyDbContext.Database.BeginTransaction();
        }

        public void RollBack()
        {
            this._transaction.Rollback();
            this._transaction.Dispose();
        }

        public void Dispose()
        {
            this._myDbContext.Dispose();
        }
    }
}