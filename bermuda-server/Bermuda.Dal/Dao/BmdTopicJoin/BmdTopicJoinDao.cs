namespace Bermuda.Dal.Dao
{
    using Model;
    using System;
    using System.Linq;

    public class BmdTopicJoinDao 
        : BaseDao<BmdTopicJoin>, IBmdTopicJoinDao
    {
        public IQueryable<BmdCurrent> GetCurrentsByTopicId(Int64 topicId)
        {
            var currentIds = this.GetTopicJoinsByTopicId(topicId).Select(x => x.CurrentId.Value);
            var currentContext = context.Set<BmdCurrent>();
            return currentContext.Where(x => currentIds.Contains(x.Id));
        }

        public IQueryable<BmdTopicJoin> GetTopicJoinsByTopicId(Int64 topicId)
        {
            return this.Select(topicJoin => topicJoin.TopicId == topicId);
        }
    }
}
