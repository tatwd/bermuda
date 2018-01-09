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
    public class FollowDao : IFollowDao
    {
        private readonly Connector connector = DbKit.GetConnector("DefaultDb");

        #region Override

        public Boolean Following(Follow follower)
        {
            String sql   = @"INSERT INTO [follow] 
                             VALUES(@user_id, @following_id)";

            String query = @"SELECT COUNT([id]) 
                             FROM [follow] 
                             WHERE [user_id] = @user_id 
                               AND [following_id] = @following_id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@user_id",           follower.UserId),
                new SqlParameter("@following_id", follower.FollowingId)
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
