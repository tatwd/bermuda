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
    public class NoticeTraceDao : INoticeTraceDao
    {
        private static readonly Connector connector = DbKit.GetConnector("DefaultDb");

        #region Override

        public Boolean AddNoticeTrace(NoticeTrace trace)
        {
            String sql   = "INSERT INTO [notice_trace]([notice_id], [user_id], [trace_date]) VALUES(@notice_id, @user_id, @trace_date)";
            String query = "SELECT COUNT(id) FROM [notice_trace] WHERE [notice_id] = @notice_id AND [user_id] = @user_id";


            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@notice_id",   trace.NoticeId),
                new SqlParameter("@user_id",       trace.UserId),
                new SqlParameter("@trace_date", trace.TraceDate)
            };

            Int32 line = -1;

            if ((Int32)connector.Execute("scalar", query, parameters) == 0) // 判断用户是否已经追踪了该启示
            {
                line = (Int32)connector.Execute("non", sql, parameters);
            }

            return line <= 0 ? false: true;
        }

        #endregion
    }
}
