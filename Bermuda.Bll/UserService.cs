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
    public class UserService
    {
        private static IUserDao iUserDao = (IUserDao)DaoFactory.GetInstance<UserDao>();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>实体对象</returns>
        public static User SignIn(String username, String password)
        {
            return iUserDao.SignIn(username, password);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user">实体对象</param>
        /// <returns>布尔值</returns>
        public static Boolean SignUp(User user)
        {
            return iUserDao.SignUp(user);
        }

        /// <summary>
        /// 通过主键 ID 获取用户对象
        /// </summary>
        /// <param name="id">用户 ID</param>
        /// <returns>User 对象或 null</returns>
        public static List<User> GetUserById(Int64 id)
        {
            return iUserDao.GetUserById(id);
        }

        /// <summary>
        /// 重设用户密码
        /// </summary>
        /// <param name="id">用户 ID</param>
        /// <param name="newPwd">新密码</param>
        /// <returns>是否成功</returns>
        public static Boolean UpdatePwd(Int64 id, String newPwd)
        {
            return iUserDao.UpdatePwd(id, newPwd);
        }

        /// <summary>
        /// 通过邮箱查找到对应的用户
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns>用户对象</returns>
        public static User GetUserByEmail(String email)
        {
            return iUserDao.GetUserByEmail(email);
        }

        /// <summary>
        /// 更新用户昵称
        /// </summary>
        /// <param name="id">用户 ID</param>
        /// <param name="newNameValue">新值</param>
        /// <returns>是否成功</returns>
        public static Boolean UpdateName(Int64 id, String newNameValue)
        {
            return iUserDao.UpdateById<String>(id, "name", newNameValue);
        }

        /// <summary>
        /// 更新用户手机号码
        /// </summary>
        /// <param name="id">用户 ID</param>
        /// <param name="newNameValue">新值</param>
        /// <returns>是否成功</returns>
        public static Boolean UpdatePhoneNumber(Int64 id, String newPhoneNumberValue)
        {
            return iUserDao.UpdateById<String>(id, "phone_number", newPhoneNumberValue);
        }

        /// <summary>
        /// 更新用户邮箱
        /// </summary>
        /// <param name="id">用户 ID</param>
        /// <param name="newNameValue">新值</param>
        /// <returns>是否成功</returns>
        public static Boolean UpdateEmail(Int64 id, String newEmailValue)
        {
            return iUserDao.UpdateById<String>(id, "email", newEmailValue);
        }

        /// <summary>
        /// 更新用户身份类型
        /// </summary>
        /// <param name="id">用户 ID</param>
        /// <param name="newNameValue">新值</param>
        /// <returns>是否成功</returns>
        public static Boolean UpdateType(Int64 id, String newTypeValue)
        {
            return iUserDao.UpdateById<String>(id, "type", newTypeValue);
        }
    }
}
