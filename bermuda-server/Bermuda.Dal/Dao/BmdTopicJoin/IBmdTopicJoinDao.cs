namespace Bermuda.Dal.Dao
{
    using Model;
    using System;
    using System.Linq;

    public interface IBmdTopicJoinDao : IBaseDao<BmdTopicJoin>
    {
        // add native methods here

        IQueryable<BmdTopicJoin> GetTopicJoinsByTopicId(Int64 topicId);

        IQueryable<BmdCurrent> GetCurrentsByTopicId(Int64 topicId);
    }
}
