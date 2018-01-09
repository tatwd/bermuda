using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bermuda.Model;

namespace Bermuda.Dal.Dao
{
    public interface ITopicJoinDao
    {
        /// <summary>
        /// 添加话题参与记录
        /// </summary>
        /// <param name="topicJoin">实体对象</param>
        /// <returns>是否插入成功</returns>
        Boolean AddTopicJoin(TopicJoin topicJoin);

        /// <summary>
        /// 通过参与话题的动态列表
        /// </summary>
        /// <param name="id">话题 ID</param>
        /// <returns>动态 ID 列表</returns>
        List<Int64> GetCurrentIdListByTopicId(Int64 id);
    }
}
