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
    public class FollowService
    {
        private static IFollowDao iFollowDao = (IFollowDao)DaoFactory.GetInstance<FollowDao>();

        /// <summary>
        /// 关注其他用户
        /// </summary>
        /// <param name="follower">实体对象</param>
        /// <returns>布尔值</returns>
        public static Boolean Following(Follow follower)
        {
            return iFollowDao.Following(follower);
        }
    }
}
