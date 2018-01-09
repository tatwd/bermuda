using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bermuda.Model;

namespace Bermuda.Dal.Dao
{
    public interface ICurrentStarDao
    {
        /// <summary>
        /// 添加动态收藏
        /// </summary>
        /// <param name="currentSatr"></param>
        /// <returns></returns>
        Boolean AddCurrentStar(CurrentStar currentSatr);
    }
}
