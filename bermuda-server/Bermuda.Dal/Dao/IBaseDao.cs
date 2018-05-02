namespace Bermuda.Dal.Dao
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Base Data Access Object interface
    /// which icludes `CRUD`
    /// </summary>
    public interface IBaseDao<T> 
        where T : class, new() 
    {
        // 查
        IQueryable<T> Select(Expression<Func<T, bool>> whereLambda);

        // 删
        void Delete(T entity);

        // 改
        void Update(T entity);

        // 增
        void Insert(T entity);

        // 涉及多表操作时最后调用
        bool SaveChanges();

    }
}
