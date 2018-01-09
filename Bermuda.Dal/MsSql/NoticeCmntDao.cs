using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;
using Bermuda.Model;
using Bermuda.Dal.Dao;
using Bermuda.Dal.Helper;

namespace Bermuda.Dal.MsSql
{
    public class NoticeCmntDao : INoticeCmntDao
    {
        private readonly Connector connector = DbKit.GetConnector("DefaultDb");

        #region Override

        public DataTable GetNoticeCmntById(Int64 id)
        {
            String sql = @"SELECT [bmd_user].[avatar] AS [user_avatar],
                             [bmd_user].[name] AS [user_name],
                             [notice_cmnt].*
                           FROM [bmd_user], [notice_cmnt]
                           WHERE [bmd_user].[id] = [notice_cmnt].[user_id]
                             AND [notice_cmnt].[notice_id] = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            DataTable dataTable = connector.GetDataTable(sql, parameters);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        public bool AddNoticeCmnt(NoticeCmnt cmnt)
        {
            String sql = @"INSERT INTO [notice_cmnt]([notice_id], [user_id], [contents], [cmnt_date])
                          VALUES(@notice_id, @user_id, @contents, @cmnt_date)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@notice_id", cmnt.NoticeId),
                new SqlParameter("@user_id",     cmnt.UserId),
                new SqlParameter("@contents",  cmnt.Contents),
                new SqlParameter("@cmnt_date", cmnt.CmntDate)
            };

            Int32 line = (Int32)connector.Execute("non", sql, parameters); // 可以重复评论

            return line <= 0 ? false : true;
        }

        #endregion
    }
}
