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
    public class CurrentReplyService
    {
        private static ICurrentReplyDao iDao = (ICurrentReplyDao)DaoFactory.GetInstance<CurrentReplyDao>();

        /// <summary>
        /// 通过评论 ID 找到对应的回复记录
        /// </summary>
        /// <param name="cmntId">评论 ID</param>
        /// <returns>数据表或 null</returns>
        public static DataTable GetCurrentReplyByCmntId(Int64 cmntId)
        {
            return iDao.GetCurrentReplyByCmntId(cmntId);
        }

        public static Boolean AddCurrentReply(CurrentReply reply)
        {
            return iDao.AddCurrentReply(reply);
        }
    }
}
