namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using Model;
    using System.Linq;
    using System;

    public class BmdCurrentService
        : BaseService<BmdCurrent, IBmdCurrentDao>, IBmdCurrentService
    {
        public bool AddCurrentAndJoinTopics(BmdCurrent current,
            Int64 topicId1, Int64? topicId2, Int64? topicId3)
            => idao.AddCurrentAndJoinTopics(current, topicId1, topicId2, topicId3);

        public IQueryable<BmdCurrent> GetAll() => idao.GetAll();
    }
}
