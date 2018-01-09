using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Bermuda.Model;

namespace Bermuda.Dal.Dao
{
    public interface ICurrentCmntDao
    {
        /// <summary>
        /// 通过动态 ID 获取对应的评论
        /// </summary>
        /// <param name="currentId"></param>
        /// <returns>数据表或 null</returns>
        DataTable GetCurrentCmntByCurrentId(Int64 currentId);

        /// <summary>
        /// 添加动态评论记录
        /// </summary>
        /// <param name="cmnt">实体对象</param>
        /// <returns>布尔值：是否添加成功</returns>
        Boolean AddCurrentCmnt(CurrentCmnt cmnt);
    }
}
