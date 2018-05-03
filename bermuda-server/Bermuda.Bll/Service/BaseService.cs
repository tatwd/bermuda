namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using System;

    public abstract class BaseService<S, T>
        where S : class, new()
        where T : IBaseDao<S>
    {
        protected static T idao
        {
            get
            {
                return (T)DaoFactory<S>.DaoInstance;
            }
        }

        // other services here

        public bool Update(S entity)
        {
            idao.Update(entity);
            return idao.SaveChanges();
        }
    }
}
