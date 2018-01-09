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
    public class CurrentStarService
    {
        private static ICurrentStarDao iDao = (ICurrentStarDao)DaoFactory.GetInstance<CurrentStarDao>();

        /// <summary>
        /// 添加动态收藏
        /// </summary>
        /// <param name="currentSatr"></param>
        /// <returns></returns>
        public static Boolean AddCurrentStar(CurrentStar currentSatr)
        {
            return iDao.AddCurrentStar(currentSatr);
        }
    }
}
