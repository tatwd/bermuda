using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Bermuda.Model;

namespace Bermuda.Dal.Dao
{
    public interface ISpeciesDao
    {
        /// <summary>
        /// 获取热门分类
        /// </summary>
        /// <returns>Species 列表</returns>
        List<Species> GetHotSpecies();

        /// <summary>
        /// 通过种类 ID （主键）获取对应的种类对象列表
        /// </summary>
        /// <param name="id">种类 ID</param>
        /// <returns>种类对象列表或 null</returns>
        List<Species> GetSpeciesById(Int64 id);

    }
}
