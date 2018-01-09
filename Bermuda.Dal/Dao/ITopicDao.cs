using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Bermuda.Model;

namespace Bermuda.Dal.Dao
{
    public interface ITopicDao
    {
        /// <summary>
        /// 获取前几名的热门话题，按照参与度（join_count）
        /// </summary>
        /// <param name="number">话题数</param>
        /// <returns>Topic 类型的数据列表</returns>
        List<Topic> GetTopicByTop(Int32 number);

        /// <summary>
        /// 查询所有话题
        /// </summary>
        /// <returns>话题列表</returns>
        List<Topic> GetAllTopic();

        /// <summary>
        /// 获取话 ID 题名
        /// </summary>
        /// <returns>数据表：包括 ID 和标题</returns>
        DataTable GetTopicNameAndId();

        /// <summary>
        /// 添加话题记录
        /// </summary>
        /// <param name="topic">实体对象：Topic</param>
        /// <returns>布尔值：是否成功</returns>
        Boolean AddTopic(Topic topic);

        /// <summary>
        /// 通过话题 ID （主键）获取对应的话题数据
        /// </summary>
        /// <param name="id">话题 ID</param>
        /// <returns>数据表或 null</returns>
        DataTable GetTopicById(Int64 id);

    }
}
