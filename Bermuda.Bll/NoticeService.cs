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
    public class NoticeService
    {
        private static INoticeDao iNoticeDao = (INoticeDao)DaoFactory.GetInstance<NoticeDao>();

        /// <summary>
        /// 添加失物招领启示记录
        /// </summary>
        /// <param name="notice">实体对象</param>
        /// <returns>布尔值：添加是否成功</returns>
        public static Boolean AddNotice(Notice notice)
        {
            return iNoticeDao.AddNotice(notice);
        }

        /// <summary>
        /// 选择一定数目的失物招领启示，无参数时选择全部
        /// </summary>
        /// <param name="number">失物招领启示数量</param>
        /// <returns>Notice 对象列表</returns>
        public static DataTable SelectNotice(params Int32[] number)
        {
            return iNoticeDao.SelectNotice(number);
        }

        /// <summary>
        /// 查询失物启示，无参数时选择全部
        /// </summary>
        /// <param name="number">失物招领启示数量</param>
        /// <returns>数据表或 null</returns>
        public static DataTable SelectLostNotice(params Int32[] number)
        {
            return iNoticeDao.SelectLostNotice(number);
        }

        /// <summary>
        /// 查询招领启示，无参数时选择全部
        /// </summary>
        /// <param name="number">招领启示数量</param>
        /// <returns>数据表或 null</returns>
        public static DataTable SelectFoundNotice(params Int32[] number)
        {
            return iNoticeDao.SelectFoundNotice(number);
        }

        /// <summary>
        /// 根据 ID 获取对应的数据
        /// </summary>
        /// <param name="id">启示编号</param>
        /// <returns>数据表</returns>
        public static DataTable SelectNoticeById(Int64 id)
        {
            return iNoticeDao.SelectNoticeById(id);
        }

        /// <summary>
        /// 根据用户 ID 获取对应的数据
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns>数据表或 null</returns>
        public static DataTable SelectNoticeByUserId(Int64 userId)
        {
            return iNoticeDao.SelectNoticeByUserId(userId);
        }

        /// <summary>
        /// 根据种类 ID 获取对应的启示数据
        /// </summary>
        /// <param name="speciesId"></param>
        /// <returns>数据表或 null</returns>
        public static DataTable SelectNoticeBySpeciesId(Int64 speciesId)
        {
            return iNoticeDao.SelectNoticeBySpeciesId(speciesId);
        }

        /// <summary>
        /// 获取助人排行榜，按帮助别人成功找回物品的次数排
        /// </summary>
        /// <returns>数据表</returns>
        public static DataTable GetBmdTop()
        {
            return iNoticeDao.GetBmdTop();
        }

        /// <summary>
        /// 获取单个字段的
        /// </summary>
        /// <param name="id">记录编号</param>
        /// <param name="field">字段名</param>
        /// <returns>字段的值</returns>
        public static T GetFieldValue<T>(Int64 id, String selectedField)
        {
            return iNoticeDao.GetFieldValue<T>(id, selectedField);
        }

        /// <summary>
        /// 通过用户 ID（外键）获取单个字段的
        /// </summary>
        /// <typeparam name="T">所选字段的数据类型</typeparam>
        /// <param name="userId">用户 ID</param>
        /// <param name="selectedField">选中的字段名</param>
        /// <returns>字段值</returns>
        public static T GetFieldValueByUserId<T>(Int64 userId, String selectedField)
        {
            return iNoticeDao.GetFieldValueByUserId<T>(userId, selectedField);
        }

        /// <summary>
        /// 获取用户发布的启示数量
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns>启示数量</returns>
        public static Int32 GetNoticeCountOfUser(Int64 userId)
        {
            return iNoticeDao.GetFieldValueByUserId<Int32>(userId, "COUNT(id)");
        }

        /// <summary>
        /// 获取用户成功帮助别人的次数
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns>成功帮助别人的次数</returns>
        public static Int32 GetHelpingCount(Int64 userId)
        {
            return iNoticeDao.GetHelpingCount(userId);
        }

        /// <summary>
        /// 获取用户成功找回东西的次数
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns>成功找回东西的次数</returns>
        public static Int32 GetBackingCount(Int64 userId)
        {
            return iNoticeDao.GetBackingCount(userId);
        }
    }
}
