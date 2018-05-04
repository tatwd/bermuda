namespace Bermuda.Dal.Dao
{
    using Model;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IBmdNoticeDao : IBaseDao<BmdNotice>
    {
        // add native methods here

        string Show();

        // 分页查询
        IQueryable<BmdNotice> GetNoticeByPage<type>(int pageSize, int pageIndex,
            Expression<Func<BmdNotice, type>> orderByLambda,
            Expression<Func<BmdNotice, bool>> whereLambda,
            bool isAsc);
    }
}
