using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bermuda.Model;

namespace Bermuda.Dal.Dao
{
    public interface IUserDao
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>实体对象</returns>
        User SignIn(String name, String pwd);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user">实体对象</param>
        /// <returns>布尔值</returns>
        Boolean SignUp(User user);

        /// <summary>
        /// 通过主键 ID 获取用户对象
        /// </summary>
        /// <param name="id">用户 ID</param>
        /// <returns>User 对象或 null</returns>
        List<User> GetUserById(Int64 id);

        /// <summary>
        /// 重设用户密码
        /// </summary>
        /// <param name="id">用户 ID</param>
        /// <param name="newPwd">新密码</param>
        /// <returns>是否成功</returns>
        Boolean UpdatePwd(Int64 id, String newPwd);

        /// <summary>
        /// 通过用户 ID （主键）更新对应的字段值
        /// </summary>
        /// <typeparam name="T">字段类型</typeparam>
        /// <param name="id">用户 ID</param>
        /// <param name="field">字段名</param>
        /// <param name="newValue">新值</param>
        /// <returns>是否成功</returns>
        Boolean UpdateById<T>(Int64 id, String field, T newValue);

        /// <summary>
        /// 通过邮箱查找到对应的用户
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns>用户对象</returns>
        User GetUserByEmail(String email);

    }
}
