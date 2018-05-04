namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using Model;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class BmdNoticeService
        : BaseService<BmdNotice, IBmdNoticeDao>, IBmdNoticeService
    {
        public string ShowMsg()
        {
            return idao.Show();
        }

        public IQueryable<BmdNotice> GetNoticeByPage<type>(int pageSize, int pageIndex,
            Expression<Func<BmdNotice, type>> orderByLambda,
            Expression<Func<BmdNotice, bool>> whereLambda,
            bool isAsc)
        {
            return idao.GetNoticeByPage(pageSize, pageIndex, orderByLambda, whereLambda, isAsc);
        }
    }
}
