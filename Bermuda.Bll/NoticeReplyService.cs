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
    public class NoticeReplyService
    {
        private static INoticeReplyDao iNoticeReplyDao = (INoticeReplyDao)DaoFactory.GetInstance<NoticeReplyDao>();

        /// <summary>
        /// 获取对应评论的回复记录
        /// </summary>
        /// <param name="id">评论编号</param>
        /// <returns>数据表</returns>
        public static DataTable GetNoticeReplyById(Int64 id)
        {
            return iNoticeReplyDao.GetNoticeReplyById(id);
        }

        /// <summary>
        /// 添加启示评论回复
        /// </summary>
        /// <param name="reply">实体对象</param>
        /// <returns>布尔值：是否成功</returns>
        public static Boolean AddNoticeReply(NoticeReply reply)
        {
            return iNoticeReplyDao.AddNoticeReply(reply);
        }
    }
}
