namespace Bermuda.Dal.Dao
{
    using Model;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class BmdNoticeDao
        : BaseDao<BmdNotice>, IBmdNoticeDao
    {
        public string Show()
        {
            return ("Hello BmdNotice DAO!");
        }

        // 默认降序排列
        public IQueryable<BmdNotice> GetNoticeByPage<type>(int pageSize, int pageIndex,
            Expression<Func<BmdNotice, type>> orderByLambda,
            Expression<Func<BmdNotice, bool>> whereLambda,
            bool isAsc = false)

        {
            int skipCount = (pageIndex - 1) * pageSize;
            var notices = context
                .Set<BmdNotice>()
                .Where(whereLambda);

            return isAsc
                ? notices
                    .OrderBy(orderByLambda)
                    .Skip(skipCount)
                    .Take(pageSize)
                : notices
                    .OrderByDescending(orderByLambda)
                    .Skip(skipCount)
                    .Take(pageSize);
        }
    }
}
