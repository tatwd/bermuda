namespace Bermuda.Dal.Context
{
    using System.Data.Entity;
    using System.Runtime.Remoting.Messaging;
    using Model;

    class DbContextFactory
    {
        const string CONTEXT_KEY = "BmdDbContext";

        /// <summary>
        /// 创建 EF 上下文对象，已存在就直接取，不存在就创建，保证线程内是唯一
        /// </summary>
        public static DbContext GetDbContext()
        {
            DbContext context = CallContext.GetData(CONTEXT_KEY) as DbContext;

            if(context == null)
            {
                context = new BmdDbEntities();
                CallContext.SetData(CONTEXT_KEY, context);
            }

            return context;
        }
    }
}
