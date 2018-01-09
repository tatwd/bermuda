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
    public class CurrentService
    {
        private static ICurrentDao iCurrentDao = (ICurrentDao)DaoFactory.GetInstance<CurrentDao>();

        /// <summary>
        /// 获取热门动态
        /// </summary>
        /// <returns>数据表</returns>
        public static DataTable GetHotCurrent()
        {
            return iCurrentDao.GetHotCurrent();
        }

        /// <summary>
        /// 获取用户发布的动态数量
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns>动态数量</returns>
        public static Int32 GetCurrentCountOfUser(Int64 userId)
        {
            return iCurrentDao.GetFieldValueByUserId<Int32>(userId, "COUNT(id)");
        }

        /// <summary>
        /// 通过主键 ID 获取对应的动态
        /// </summary>
        /// <param name="id">动态 ID</param>
        /// <returns>数据表或 null</returns>
        public static DataTable GetCurrentById(Int64 id)
        {
            return iCurrentDao.GetCurrentById(id);
        }

        /// <summary>
        /// 通过用户 ID（外键）获取对应的动态
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns>数据表或 null</returns>
        public static DataTable GetCurrentByUserId(Int64 userId)
        {
            return iCurrentDao.GetCurrentByUserId(userId);
        }

        /// <summary>
        /// 通过话题 ID 来获取对应的动态
        /// </summary>
        /// <param name="topicId">话题 ID</param>
        /// <returns>数据表或 null</returns>
        public static DataTable GetCurrentByTopicId(Int64 topicId)
        {
            return iCurrentDao.GetCurrentByTopicId(topicId);
        }

        /// <summary>
        /// 添加动态记录
        /// </summary>
        /// <param name="current">动态对象</param>
        /// <returns>是否添加成功</returns>
        public static Boolean AddCurrent(Current current)
        {
            return iCurrentDao.AddCurrent(current);
        }

        /// <summary>
        /// 获取刚添加的动态 ID
        /// </summary>
        /// <param name="addingCurrent">刚添加的动态对象</param>
        /// <returns>动态 ID</returns>
        public static Int64 GetAddingCurrentId(Current addingCurrent)
        {
            return iCurrentDao.GetAddingCurrentId(addingCurrent);
        }

        /// <summary>
        /// 获取评论数
        /// </summary>
        /// <param name="id">动态 ID</param>
        /// <returns></returns>
        public static Int64 GetCmntCountById(Int64 id)
        {
            return iCurrentDao.GetFieldValueById<Int64>(id, "[cmnt_count]");
        }
    }
}
