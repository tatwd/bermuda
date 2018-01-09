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
    public class SpeciesService
    {
        private static ISpeciesDao iSpeciesDao = (ISpeciesDao)DaoFactory.GetInstance<SpeciesDao>();

        /// <summary>
        /// 获取热门分类
        /// </summary>
        /// <returns>Species 列表</returns>
        public static List<Species> GetHotSpecies()
        {
            return iSpeciesDao.GetHotSpecies();
        }

        /// <summary>
        /// 通过种类 ID （主键）获取对应的种类对象列表
        /// </summary>
        /// <param name="id">种类 ID</param>
        /// <returns>种类对象列表或 null</returns>
        public static List<Species> GetSpeciesById(Int64 id)
        {
            return iSpeciesDao.GetSpeciesById(id);
        }
    }
}
