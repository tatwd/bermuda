using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Bermuda.Model;

namespace Bermuda.Dal.Dao
{
    public interface INoticeReplyDao
    {
        /// <summary>
        /// 获取对应评论的回复记录
        /// </summary>
        /// <param name="id">评论编号</param>
        /// <returns>数据表</returns>
        DataTable GetNoticeReplyById(Int64 id);

        /// <summary>
        /// 添加启示评论回复
        /// </summary>
        /// <param name="reply">实体对象</param>
        /// <returns>布尔值：是否成功</returns>
        Boolean AddNoticeReply(NoticeReply reply);
    }
}
