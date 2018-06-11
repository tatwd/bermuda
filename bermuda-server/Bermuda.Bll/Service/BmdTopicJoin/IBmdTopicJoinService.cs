namespace Bermuda.Bll.Service
{
    using Model;
    using System;
    using System.Linq;

    public interface IBmdTopicJoinService : IBaseService<BmdTopicJoin>
    {
        // add native methods here

        IQueryable<Int64> GetCurrentIdsByTopicId(Int64 topicId);
        IQueryable<BmdCurrent> GetCurrentsByTopicId(Int64 topicId);
    }
}
