namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class BaseService<S, T>
        where S : class, new()
        where T : IBaseDao<S>
    {
        protected static T idao
        {
            get { return (T)DaoFactory.Get<S>(); }
        }

        // other services here

        public IQueryable<S> Select(Expression<Func<S, bool>> whereLambda)
        {
            return idao.Select(whereLambda);
        }

        public bool Delete(S entity)
        {
            idao.Delete(entity);
            return idao.SaveChanges();
        }

        public bool Update(S entity)
        {
            idao.Update(entity);
            return idao.SaveChanges();
        }

        public bool Insert(S entity)
        {
            idao.Insert(entity);
            return idao.SaveChanges();
        }
    }
}
