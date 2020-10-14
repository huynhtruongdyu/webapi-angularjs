using _2.Data.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace _2.Data.Infrastructure.Implement
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region properties

        private MyDbContext myDbContext;
        private DbSet<T> dbSet;

        protected IDbFactory _dbFactory
        {
            get;
            private set;
        }

        protected MyDbContext MyDbContext
        {
            get { return this.myDbContext ?? (this.myDbContext = this._dbFactory.Init()); }
        }

        #endregion properties

        #region constructur

        protected RepositoryBase(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
            this.dbSet = MyDbContext.Set<T>();
        }

        #endregion constructur

        #region method

        public virtual T Add(T entity)
        {
            return this.dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            this.dbSet.Attach(entity);
            this.myDbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual T Delete(T entity)
        {
            return this.dbSet.Remove(entity);
        }

        public virtual T Delete(int entityID)
        {
            var entity = this.dbSet.Find(entityID);
            return this.dbSet.Remove(entity);
        }

        public virtual void DeteleMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = this.dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                this.dbSet.Remove(obj);
            }
        }

        public bool CheckContain(Expression<Func<T, bool>> predicate)
        {
            return this.myDbContext.Set<T>().Count<T>(predicate) > 0;
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return this.dbSet.Count(where);
        }

        public virtual IEnumerable<T> GetAll(string[] includes = null)
        {
            //Handle includes for associated objects if aplicable
            if (includes != null && includes.Count() > 0)
            {
                var query = this.myDbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }
            return this.myDbContext.Set<T>().AsQueryable();
        }

        public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;
            if (includes != null && includes.Count() > 0)
            {
                var query = this.myDbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet = filter != null ? query.Where<T>(filter).AsQueryable() : query.AsQueryable();
            }
            else
                _resetSet = filter != null ? this.myDbContext.Set<T>().Where<T>(filter).AsQueryable() : this.myDbContext.Set<T>().AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public virtual T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = this.myDbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }
            return this.myDbContext.Set<T>().FirstOrDefault(expression);
        }

        public virtual T GetSingleById(int entityID)
        {
            return this.dbSet.Find(entityID);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return this.dbSet.Where(where).ToList();
        }

        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = this.myDbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).AsQueryable<T>();
            }

            return this.myDbContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        #endregion method
    }
}