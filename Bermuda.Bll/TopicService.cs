using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Bermuda.Model;
using Bermuda.Dal.Dao;
using Bermuda.Dal.MsSql;

namespace Bermuda.Bll
{
    public class TopicService
    {
        private static ITopicDao iTopicDao = (ITopicDao)DaoFactory.GetInstance<TopicDao>();

        /// <summary>
        /// 获取前几名的热门话题，按照参与度（join_count）
        /// </summary>
        /// <param name="number">话题数</param>
        /// <returns>Topic 类型的数据列表</returns>
        public static List<Topic> GetTopicByTop(Int32 number)
        {
            return iTopicDao.GetTopicByTop(number);
        }

        /// <summary>
        /// 查询所有话题
        /// </summary>
        /// <returns>话题列表</returns>
        public static List<Topic> GetAllTopic()
        {
            return iTopicDao.GetAllTopic();
        }

        /// <summary>
        /// 获取话 ID 题名
        /// </summary>
        /// <returns>数据表：包括 ID 和标题</returns>
        public static DataTable GetTopicNameAndId()
        {
            return iTopicDao.GetTopicNameAndId();
        }

        /// <summary>
        /// 添加话题记录
        /// </summary>
        /// <param name="topic">实体对象：Topic</param>
        /// <returns>布尔值：是否成功</returns>
        public static Boolean AddTopic(Topic topic)
        {
            return iTopicDao.AddTopic(topic);
        }

        /// <summary>
        /// 通过话题 ID （主键）获取对应的话题数据
        /// </summary>
        /// <param name="id">话题 ID</param>
        /// <returns>数据表或 null</returns>
        public static DataTable GetTopicById(Int64 id)
        {
            return iTopicDao.GetTopicById(id);
        }
    }
}
