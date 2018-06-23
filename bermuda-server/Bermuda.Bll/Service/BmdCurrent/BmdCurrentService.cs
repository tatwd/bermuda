namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using Model;
    using System.Linq;
    using System;

    public class BmdCurrentService
        : BaseService<BmdCurrent, IBmdCurrentDao>, IBmdCurrentService
    {
        public bool AddCurrentAndJoinTopics(BmdCurrent current, Int64[] topicIds)
            => idao.AddCurrentAndJoinTopics(current, topicIds);

        public IQueryable<BmdCurrent> GetAll() => idao.GetAll();
    }
}
