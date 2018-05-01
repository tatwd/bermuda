namespace Bermuda.Bll.Service
{
    using Dal.Dao;

    public abstract class BaseService<S, T>
        where S : class, new()
        where T : IBaseDao<S>
    {
        #region 使用单例模式获取 idao 实例 - 按需获取

        // public BaseService() { }

        protected static T idao
        {
            get { return Nested.instance; }
        }

        class Nested
        {
            static Nested() { }
            internal static readonly T instance = (T)DaoFactory.GetDao<S>();
        }

        #endregion
    }
}
