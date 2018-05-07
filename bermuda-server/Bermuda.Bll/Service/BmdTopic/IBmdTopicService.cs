namespace Bermuda.Bll.Service
{
    using Model;
    using System.Collections.Generic;

    public interface IBmdTopicService : IBaseService<BmdTopic>
    {
        // add native methods here
        
        /// <summary>
        /// Get all hot topics
        /// </summary>
        /// <returns></returns>
        IList<BmdTopic> GetHotTopics();

        /// <summary>
        /// Get hot topics with count
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        IList<BmdTopic> GetHotTopics(int count);
    }
}
