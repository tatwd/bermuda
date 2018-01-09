using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Bermuda.Model;

namespace Bermuda.Dal.Dao
{
    public interface ICurrentReplyDao
    {
        /// <summary>
        /// 通过评论 ID 找到对应的回复记录
        /// </summary>
        /// <param name="cmntId">评论 ID</param>
        /// <returns>数据表或 null</returns>
        DataTable GetCurrentReplyByCmntId(Int64 cmntId);

        /// <summary>
        /// 添加评论回复记录
        /// </summary>
        /// <param name="reply">回复实体</param>
        /// <returns>布尔值</returns>
        Boolean AddCurrentReply(CurrentReply reply);

    }
}
