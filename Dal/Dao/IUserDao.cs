using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace Dal.Dao
{
    public interface IUserDao
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>实体对象</returns>
        User SignIn(string name, string pwd);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user">实体对象</param>
        /// <returns>布尔值</returns>
        bool SignUp(User user);

    }
}
