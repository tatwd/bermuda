namespace Bermuda.Bll.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dal.Dao;
    using Model;

    public class BmdTopicService
        : BaseService<BmdTopic, IBmdTopicDao>, IBmdTopicService
    {
        public IList<BmdTopic> GetHotTopics()
        {
            return this.GetHotTopics(-1);
        }

        public IList<BmdTopic> GetHotTopics(int count)
        {
            var hotTopics = idao
                .Select(x => x.IsPassed == 1)
                .OrderByDescending(x => x.JoinCount);

            return count >= 0 
                ? hotTopics.Take(count).ToList() 
                : hotTopics.ToList();
        }

        public BmdTopic GetTopicById(long id)
        {
            return idao.Select(x => x.Id == id).SingleOrDefault();
        }
    }
}
