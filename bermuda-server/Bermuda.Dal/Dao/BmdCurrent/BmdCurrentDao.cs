namespace Bermuda.Dal.Dao
{
    using Model;
    using System.Linq;
    using System;

    public class BmdCurrentDao
        : BaseDao<BmdCurrent>, IBmdCurrentDao
    {
        public bool AddCurrentAndJoinTopics(BmdCurrent current, 
            Int64 topicId1, Int64? topicId2, Int64? topicId3)
        {
            var result = (context as BmdDbEntities).JoinTopicsProc(
                current.UserId, current.Title, current.Text, topicId1, topicId2, topicId3);
            return result >= 2; // 至少影响 2 行
        }

        public IQueryable<BmdCurrent> GetAll () => 
            this.Select(x => x.Id > 0 && x.UserId > 0);
    }
}
