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
    public class CurrentCmntDao : ICurrentCmntDao
    {
        private readonly Connector connector = DbKit.GetConnector("DefaultDb");

        #region Override
        
        public DataTable GetCurrentCmntByCurrentId(Int64 currentId)
        {
            String sql = @"SELECT [bmd_user].[avatar] AS [user_avatar],
                             [bmd_user].[name] AS [user_name],
                             [current_cmnt].*
                           FROM [bmd_user], [current_cmnt]
                           WHERE [bmd_user].[id] = [current_cmnt].[user_id]
                             AND [current_cmnt].[current_id] = @current_id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@current_id", currentId)
            };

            DataTable dataTable = connector.GetDataTable(sql, parameters);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        public Boolean AddCurrentCmnt(CurrentCmnt cmnt)
        {
            String sql = @"INSERT INTO [current_cmnt]([current_id], [user_id], [contents], [cmnt_date])
                          VALUES(@current_id, @user_id, @contents, @cmnt_date)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@current_id", cmnt.CurrentId),
                new SqlParameter("@user_id",       cmnt.UserId),
                new SqlParameter("@contents",    cmnt.Contents),
                new SqlParameter("@cmnt_date",   cmnt.CmntDate)
            };

            Int32 line = (Int32)connector.Execute("non", sql, parameters);

            return line <= 0 ? false : true;
        }

        #endregion
    }
}
