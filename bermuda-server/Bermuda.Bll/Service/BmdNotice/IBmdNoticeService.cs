namespace Bermuda.Bll.Service
{
    using Model;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IBmdNoticeService : IBaseService<BmdNotice>
    {
        // add native methods here

        IQueryable<BmdNotice> GetNoticeByPage<type>(int pageSize, int pageIndex,
            Expression<Func<BmdNotice, type>> orderByLambda,
            Expression<Func<BmdNotice, bool>> whereLambda,
            bool isAsc = false);
    }
}
