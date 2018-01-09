using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bermuda.Model;
using Bermuda.Dal.Dao;
using Bermuda.Dal.MsSql;

namespace Bermuda.Bll
{
    public class TopicJoinService
    {
        private static ITopicJoinDao iTopicJoinDao = (ITopicJoinDao)DaoFactory.GetInstance<TopicJoinDao>();

        /// <summary>
        /// 添加话题参与记录
        /// </summary>
        /// <param name="topicJoin">实体对象</param>
        /// <returns>是否插入成功</returns>
        public static Boolean AddTopicJoin(TopicJoin topicJoin)
        {
            return iTopicJoinDao.AddTopicJoin(topicJoin);
        }

        /// <summary>
        /// 通过参与话题的动态 ID 列表
        /// </summary>
        /// <param name="topicId">话题 ID</param>
        /// <returns>动态 ID 列表</returns>
        public static List<Int64> GetCurrentIdListByTopicId(Int64 topicId)
        {
            return iTopicJoinDao.GetCurrentIdListByTopicId(topicId);
        }
    }
}
