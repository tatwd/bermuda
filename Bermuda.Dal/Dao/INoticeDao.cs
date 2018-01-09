using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Bermuda.Model;

namespace Bermuda.Dal.Dao
{
    public interface INoticeDao
    {
        /// <summary>
        /// 添加失物招领启示记录
        /// </summary>
        /// <param name="notice">实体对象</param>
        /// <returns>布尔值：添加是否成功</returns>
        Boolean AddNotice(Notice notice);

        /// <summary>
        /// 查询失物招领启示，无参数时选择全部
        /// </summary>
        /// <param name="number">失物招领启示数量</param>
        /// <returns>数据表或 null</returns>
        DataTable SelectNotice(params Int32[] number);

        /// <summary>
        /// 查询失物启示，无参数时选择全部
        /// </summary>
        /// <param name="number">失物招领启示数量</param>
        /// <returns>数据表或 null</returns>
        DataTable SelectLostNotice(params Int32[] number);

        /// <summary>
        /// 查询招领启示，无参数时选择全部
        /// </summary>
        /// <param name="number">招领启示数量</param>
        /// <returns>数据表或 null</returns>
        DataTable SelectFoundNotice(params Int32[] number);

        /// <summary>
        /// 根据 ID 获取对应的数据
        /// </summary>
        /// <param name="id">启示编号</param>
        /// <returns>数据表或 null</returns>
        DataTable SelectNoticeById(Int64 id);

        /// <summary>
        /// 根据用户 ID 获取对应的数据
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns>数据表或 null</returns>
        DataTable SelectNoticeByUserId(Int64 userId);

        /// <summary>
        /// 根据种类 ID 获取对应的启示数据
        /// </summary>
        /// <param name="speciesId"></param>
        /// <returns>数据表或 null</returns>
        DataTable SelectNoticeBySpeciesId(Int64 speciesId);

        /// <summary>
        /// 获取助人排行榜，按帮助别人成功找回物品的次数排
        /// </summary>
        /// <returns>数据表或 null</returns>
        DataTable GetBmdTop();

        /// <summary>
        /// 通过主键 ID 获取单个字段的
        /// </summary>
        /// <typeparam name="T">所选字段的数据类型</typeparam>
        /// <param name="id">记录 ID</param>
        /// <param name="selectedField">选中的字段名</param>
        /// <returns>字段的值</returns>
        T GetFieldValue<T>(Int64 id, String selectedField);

        /// <summary>
        /// 通过用户 ID（外键）获取单个字段的
        /// </summary>
        /// <typeparam name="T">所选字段的数据类型</typeparam>
        /// <param name="userId">用户 ID</param>
        /// <param name="selectedField">选中的字段名</param>
        /// <returns></returns>
        T GetFieldValueByUserId<T>(Int64 userId, String selectedField);

        /// <summary>
        /// 获取用户成功帮助别人的次数
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns>成功帮助别人的次数</returns>
        Int32 GetHelpingCount(Int64 userId);

        /// <summary>
        /// 获取用户成功找回东西的次数
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns>成功找回东西的次数</returns>
        Int32 GetBackingCount(Int64 userId);
    }
}
