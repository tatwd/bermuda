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
    public class NoticeTraceService
    {
        private static INoticeTraceDao iNoticeTraceDao = (INoticeTraceDao)DaoFactory.GetInstance<NoticeTraceDao>();

        /// <summary>
        /// 添加追踪记录
        /// </summary>
        /// <param name="trace">实体对象</param>
        /// <returns>布尔值</returns>
        public static Boolean AddNoticeTrace(NoticeTrace trace)
        {
            return iNoticeTraceDao.AddNoticeTrace(trace);
        }
    }
}
