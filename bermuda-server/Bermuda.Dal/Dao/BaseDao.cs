namespace Bermuda.Dal.Dao
{
    using Context;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data.Entity;

    public abstract class BaseDao<T>
        where T : class, new()
    {
        DbContext context = DbContextFactory.GetDbContext();

        public IQueryable<T> Select(Expression<Func<T, bool>> whereLambda)
        {
            IQueryable<T> query;

            try
            {
                // context.Configuration.ProxyCreationEnabled = false;
                query = context.Set<T>().Where(whereLambda);
            }
            catch (Exception)
            {
                query = null;
            }

            return query;
        }
    }
}
