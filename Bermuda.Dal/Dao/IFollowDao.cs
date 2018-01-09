using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bermuda.Model;

namespace Bermuda.Dal.Dao
{
    public interface IFollowDao
    {
        /// <summary>
        /// 关注用户
        /// </summary>
        /// <param name="follower">实体对象</param>
        /// <returns>布尔值</returns>
        Boolean Following(Follow follower);
    }
}
