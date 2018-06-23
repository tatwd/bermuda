namespace Bermuda.Bll.Service
{
    using Model;
    using System;
    using System.Linq;

    public interface IBmdCurrentService : IBaseService<BmdCurrent>
    {
        // add native methods here

        IQueryable<BmdCurrent> GetAll();
        bool AddCurrentAndJoinTopics(BmdCurrent current, Int64[] topicIds);
    }
}
