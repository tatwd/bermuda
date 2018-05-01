namespace Bermuda.Dal.Dao
{
    using System;

    // 可以利用单利模式
    public class DaoFactory
    {
        public static IBaseDao<T> GetDao<T>()
            where T : class, new()
        {
            string className = String.Format("Bermuda.Dal.Dao.{0}Dao", typeof(T).Name);
            Type type = Type.GetType(className);
            return (IBaseDao<T>)Activator.CreateInstance(type);
        }
    }
}
