namespace Bermuda.Dal.Dao
{
    using Model;
    using System.Linq;
    using System;

    public class BmdCurrentDao
        : BaseDao<BmdCurrent>, IBmdCurrentDao
    {
        public bool AddCurrentAndJoinTopics(BmdCurrent current, Int64[] topicIds)
        {
            var bmdContext = context as BmdDbEntities;
            var result = 0;

            switch (topicIds.Length)
            {
                case 2:
                    result = bmdContext.JoinTopicsProc(
                        current.UserId, current.Title, current.Text, current.BriefText, topicIds[0], topicIds[1], null);
                    break;
                case 3:
                    result = bmdContext.JoinTopicsProc(
                        current.UserId, current.Title, current.Text, current.BriefText, topicIds[0], topicIds[1], topicIds[2]);
                    break;
                default:
                    result = bmdContext.JoinTopicsProc(
                        current.UserId, current.Title, current.Text, current.BriefText, topicIds[0], null, null);
                    break;
            }

            return result >= 2; // 至少影响 2 行
        }

        public IQueryable<BmdCurrent> GetAll () => 
            this.Select(x => x.Id > 0 && x.UserId > 0);
    }
}
