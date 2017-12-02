using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using Dal.Dao;
using Dal.MsSql;

namespace Bll
{
    public class UserService
    {
        private static IUserDao iUserDao = (IUserDao)DaoFactory.Get<UserDao>();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>实体对象</returns>
        public static User SignIn(string username, string password)
        {
            return iUserDao.SignIn(username, password);
        }
    }
}
