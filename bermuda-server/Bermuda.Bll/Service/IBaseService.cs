

namespace Bermuda.Bll.Service
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IBaseService<T> where T : class, new()
    {
        // 基本业务

        IQueryable<T> Select(Expression<Func<T, bool>> whereLambda);

        bool Delete(T entity);

        bool Update(T entity);

        bool Insert(T entity);
    }
}
