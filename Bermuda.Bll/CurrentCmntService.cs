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
    public class CurrentCmntService
    {
        
        private static ICurrentCmntDao iDao = (ICurrentCmntDao)DaoFactory.GetInstance<CurrentCmntDao>();

        /// <summary>
        /// 通过动态 ID 获取对应的评论
        /// </summary>
        /// <param name="currentId"></param>
        /// <returns></returns>
        public static DataTable GetCurrentCmntByCurrentId(Int64 currentId)
        {
            return iDao.GetCurrentCmntByCurrentId(currentId);
        }

        /// <summary>
        /// 添加动态评论记录
        /// </summary>
        /// <param name="cmnt">实体对象</param>
        /// <returns>布尔值：是否添加成功</returns>
        public static Boolean AddCurrentCmnt(CurrentCmnt cmnt)
        {
            return iDao.AddCurrentCmnt(cmnt);
        }
    }
}
