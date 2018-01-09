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
    public class CurrentReplyDao : ICurrentReplyDao
    {
        private readonly Connector connector = DbKit.GetConnector("DefaultDb");

        #region Override

        public DataTable GetCurrentReplyByCmntId(Int64 cmntId)
        {
            // 待优化 - 可用函数实现
            String sql = @"SELECT [reply_info].*,
                             [aims_info].[aims_user_id], 
                             [aims_info].[aims_user_name]
                           FROM 
                           (
                             SELECT [a].*, [b].name AS [user_name]
                             FROM [current_reply] AS [a]
                             JOIN [bmd_user] AS [b]
                             ON [a].[user_id] = [b].[id]
                           ) AS [reply_info]
                           LEFT JOIN
                           (
                             SELECT [a].[id],
                               [b].[user_id] AS [aims_user_id],
	                           '@' + [c].[name] AS [aims_user_name]
                             FROM [current_reply] AS [a]
                             LEFT JOIN [current_reply] AS [b]
                             LEFT JOIN [bmd_user] AS [c]
                             ON [b].[user_id] = [c].[id]
                             ON [a].[aims_id] = [b].[id]
                           ) AS [aims_info]
                           ON [reply_info].[id] = [aims_info].[id]
                           WHERE [reply_info].[cmnt_id] = @cmnt_id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@cmnt_id", cmntId)
            };

            DataTable dataTable = connector.GetDataTable(sql, parameters);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        public Boolean AddCurrentReply(CurrentReply reply)
        {
            String         sql        = null;
            SqlParameter[] parameters = null;

            if (reply.AimsId != 0) // 回复评论的回复
            {
                sql = @"INSERT INTO [current_reply]([cmnt_id], [aims_id], [user_id], [contents], [reply_date]) 
                        VALUES(@cmnt_id, @aims_id, @user_id, @contents, @reply_date)";

                parameters = new SqlParameter[]
                {
                    new SqlParameter("@cmnt_id",       reply.CmntId),
                    new SqlParameter("@aims_id",       reply.AimsId),
                    new SqlParameter("@user_id",       reply.UserId),
                    new SqlParameter("@contents",    reply.Contents),
                    new SqlParameter("@reply_date", reply.ReplyDate)
                };

            }
            else
            {
                sql = @"INSERT INTO [current_reply]([cmnt_id], [user_id], [contents], [reply_date])
                        VALUES(@cmnt_id, @user_id, @contents, @reply_date)";

                parameters = new SqlParameter[]
                {
                    new SqlParameter("@cmnt_id",       reply.CmntId),
                    new SqlParameter("@user_id",       reply.UserId),
                    new SqlParameter("@contents",    reply.Contents),
                    new SqlParameter("@reply_date", reply.ReplyDate)
                };
            }

            Int32 line = (Int32)connector.Execute("non", sql, parameters);

            return line <= 0 ? false : true;
        }

        #endregion

    }
}
