using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Bermuda.Model;
using Bermuda.Dal.Dao;
using Bermuda.Dal.Helper;

namespace Bermuda.Dal.MsSql
{
    public class SpeciesDao : ISpeciesDao
    {
        private readonly Connector connector = DbKit.GetConnector("DefaultDb");

        /// <summary>
        /// 将 DataTable 转换成 List<Species>
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>对象列表或 null</returns>
        private List<Species> GetSpeciesList(DataTable dataTable)
        {
            List<Species> list = new List<Species>();

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Species species = new Species
                    {
                        Id          = Convert.ToInt64(row["id"]),
                        Name        = Convert.ToString(row["name"]),
                        Img         = Convert.ToString(row["img"]),
                        NoticeCount = Convert.ToInt64(row["notice_count"])
                    };

                    list.Add(species);
                }
            }
            else
            {
                list = null;
            }

            return list;
        }

        #region Override
        public List<Species> GetHotSpecies()
        {
            List<Species> list = new List<Species>();

            // 所有 
            String sql = "SELECT * FROM [species] ORDER BY [notice_count] DESC";

            DataTable dataTable = connector.GetDataTable(sql);

            return GetSpeciesList(dataTable);
        }

        public List<Species> GetSpeciesById(Int64 id)
        {
            String sql = "SELECT * FROM [species] WHERE [id] = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            DataTable dataTable = connector.GetDataTable(sql, parameters);

            return GetSpeciesList(dataTable);
        }

        #endregion
    }
}
