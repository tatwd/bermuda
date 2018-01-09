using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bermuda.Model;

namespace Bermuda.Dal.Dao
{
    public interface INoticeTraceDao
    {
        /// <summary>
        /// 添加追踪记录
        /// </summary>
        /// <param name="trace">实体对象</param>
        /// <returns>布尔值：true 表示成功，false 表示失败</returns>
        Boolean AddNoticeTrace(NoticeTrace trace);
    }
}
