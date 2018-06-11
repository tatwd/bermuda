namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using Model;
    using System;
    using System.Linq;

    public class BmdTopicJoinService
        : BaseService<BmdTopicJoin, BmdTopicJoinDao>, IBmdTopicJoinService
    {
        public IQueryable<Int64> GetCurrentIdsByTopicId(Int64 topicId)
        {
            return idao.GetTopicJoinsByTopicId(topicId).Select(x => x.CurrentId.Value);
        }

        public IQueryable<BmdCurrent> GetCurrentsByTopicId(Int64 topicId)
        {
            return idao.GetCurrentsByTopicId(topicId);
        }

    }
}
