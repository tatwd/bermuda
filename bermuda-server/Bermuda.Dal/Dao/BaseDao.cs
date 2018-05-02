namespace Bermuda.Dal.Dao
{
    using Context;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Linq.Expressions;

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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                query = default(IQueryable<T>);
            }

            return query;
        }

        public void Delete(T entity)
        {
            try
            {
                context.Set<T>().Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update(T entity)
        {
            try
            {
                context.Set<T>().AddOrUpdate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Insert(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool SaveChanges()
        {
            bool isSuccessed = false;

            try
            {
                isSuccessed = context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return isSuccessed;
        }
    }
}
