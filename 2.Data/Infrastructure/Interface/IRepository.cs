using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _2.Data.Infrastructure.Interface
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        T Delete(int entityID);

        void DeteleMulti(Expression<Func<T, bool>> where);

        T GetSingleById(int entityID);

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        IEnumerable<T> GetAll(string[] includse = null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContain(Expression<Func<T, bool>> predicate);
    }
}