namespace Bermuda.Dal.Dao
{
    using System;

    // 使用单利模式按需获取实例
    public sealed class DaoFactory<T>
        where T : class, new()
    {
        DaoFactory() { }

        public static IBaseDao<T> DaoInstance
        {
            get
            {
                return Nested.instance;
            }
        }

        class Nested
        {
            static Nested() { }

            internal static readonly IBaseDao<T> instance = GetNestedInstance();

            static IBaseDao<T> GetNestedInstance()
            {
                string className = String.Format("Bermuda.Dal.Dao.{0}Dao", typeof(T).Name);
                Type type = Type.GetType(className);
                return (IBaseDao<T>)Activator.CreateInstance(type);
            }
        }
    }
}
