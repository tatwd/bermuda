using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Bermuda.Model;

namespace Bermuda.Dal.Dao
{
    public interface ICurrentDao
    {
        /// <summary>
        /// 获取热门动态
        /// </summary>
        /// <returns>数据表</returns>
        DataTable GetHotCurrent();

        /// <summary>
        /// 通过动态 ID（主键）获取单个字段的值
        /// </summary>
        /// <typeparam name="T">所选字段的数据类型</typeparam>
        /// <param name="userId">用户 ID</param>
        /// <param name="selectedField">选中的字段名</param>
        /// <returns></returns>
        T GetFieldValueById<T>(Int64 id, String selectedFieid);

        /// <summary>
        /// 通过用户 ID（外键）获取单个字段的值
        /// </summary>
        /// <typeparam name="T">所选字段的数据类型</typeparam>
        /// <param name="userId">用户 ID</param>
        /// <param name="selectedField">选中的字段名</param>
        /// <returns></returns>
        T GetFieldValueByUserId<T>(Int64 userId, string selectedField);
        
        /// <summary>
        /// 通过主键 ID 获取对应的动态
        /// </summary>
        /// <param name="id">动态 ID</param>
        /// <returns>数据表或 null</returns>
        DataTable GetCurrentById(Int64 id);

        /// <summary>
        /// 通过用户 ID（外键）获取对应的动态
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns>数据表或 null</returns>
        DataTable GetCurrentByUserId(Int64 userId);

        /// <summary>
        /// 通过话题 ID 来获取对应的动态
        /// </summary>
        /// <param name="topicId">话题 ID</param>
        /// <returns>数据表或 null</returns>
        DataTable GetCurrentByTopicId(Int64 topicId);

        /// <summary>
        /// 添加动态记录
        /// </summary>
        /// <param name="current">动态对象</param>
        /// <returns>是否添加成功</returns>
        Boolean AddCurrent(Current current);

        /// <summary>
        /// 获取刚添加的动态 ID
        /// </summary>
        /// <param name="addingCurrent">刚添加的动态对象</param>
        /// <returns>动态 ID</returns>
        Int64 GetAddingCurrentId(Current addingCurrent);
    }
}
