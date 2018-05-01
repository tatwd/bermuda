namespace Bermuda.Dal.Dao
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Base Database Access Object interface
    /// which icludes `CRUD`
    /// </summary>
    public interface IBaseDao<T> 
        where T : class, new() 
    {
        // Select Delete Update Insert

        IQueryable<T> Select(Expression<Func<T, bool>> whereLambda);
    }
}
