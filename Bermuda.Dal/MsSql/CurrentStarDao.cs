using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Bermuda.Model;
using Bermuda.Dal.Dao;
using Bermuda.Dal.Helper;

namespace Bermuda.Dal.MsSql
{
    public class CurrentStarDao : ICurrentStarDao
    {
        private readonly Connector connector = DbKit.GetConnector("DefaultDb");

        #region Override
        public Boolean AddCurrentStar(CurrentStar currentSatr)
        {
            String sql = @"INSERT INTO [current_star]([current_id], [user_id], [star_date])
                          VALUES(@current_id, @user_id, @star_date)";

            String query = @"SELECT COUNT([id]) 
                             FROM [current_star] 
                             WHERE [current_id] = @current_id 
                               AND [user_id] = @user_id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@current_id", currentSatr.CurrentId),
                new SqlParameter("@user_id",       currentSatr.UserId),
                new SqlParameter("@star_date",   currentSatr.StarDate)
            };

            Int32 line = -1;

            if ((Int32)connector.Execute("scalar", query, parameters) == 0)
            {
                line = (Int32)connector.Execute("non", sql, parameters);
            }

            return line <= 0 ? false : true;
        }

        #endregion
    }
}
