using _2.Data.Infrastructure.Interface;

namespace _2.Data.Infrastructure.Implement
{
    public class DbFactory : Disposable, IDbFactory
    {
        private MyDbContext _myDbContext;

        public MyDbContext Init()
        {
            return this._myDbContext ?? (this._myDbContext = new MyDbContext());
        }

        protected override void DisposeCore()
        {
            if (this._myDbContext != null)
                this._myDbContext.Dispose();
        }
    }
}