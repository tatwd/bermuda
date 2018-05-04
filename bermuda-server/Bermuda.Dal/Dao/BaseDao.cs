namespace Bermuda.Dal.Dao
{
    using Context;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class BaseDao<T> where T : class, new()
    {
        protected DbContext context = DbContextFactory.GetDbContext();

        public IQueryable<T> Select(Expression<Func<T, bool>> whereLambda)
        {
            IQueryable<T> query;

            try
            {
                // context.Configuration.ProxyCreationEnabled = false;
                query = context.Set<T>().Where(whereLambda);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                query = default(IQueryable<T>);
            }

            return query;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().AddOrUpdate(entity);
        }

        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
