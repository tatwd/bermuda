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
    public class CurrentDao : ICurrentDao
    {
        private readonly Connector connector = DbKit.GetConnector("DefaultDb");

        #region Override

        public DataTable GetHotCurrent()
        {
            String sql = @"SELECT TOP 5 
                             [current].[id] AS [current_id],
                             [user_id],
                             [bmd_user].[name] AS [user_name],
                             [bmd_user].[avatar] AS [user_avatar],
                             [current].[title] AS [current_title],
                             [current].[praise_count] AS [praise_count]
                           FROM [bmd_user], [current]
                           WHERE [bmd_user].[id] = [current].[user_id]
                           ORDER BY [praise_count] DESC";

            DataTable dataTable = connector.GetDataTable(sql);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        public T GetFieldValueById<T>(Int64 id, String selectedFieid)
        {
            String sql = String.Format("SELECT {0} FROM [current] WHERE [id] = @id", selectedFieid);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            T value = (T)connector.Execute("scalar", sql, parameters); // 为空情况？

            return value;
        }

        public T GetFieldValueByUserId<T>(Int64 userId, string selectedField)
        {
            String sql = String.Format("SELECT {0} FROM [current] WHERE [user_id] = @user_id", selectedField);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@user_id", userId)
            };

            T value = (T)connector.Execute("scalar", sql, parameters); // 为空情况？

            return value;
        }

        public DataTable GetCurrentById(Int64 id)
        {
            String sql = @"SELECT [bmd_user].[avatar] AS [user_avatar],
                             [bmd_user].[name] AS [user_name],
                             [current].*
                           FROM [bmd_user], [current]
                           WHERE [bmd_user].[id] = [current].[user_id]
                             AND [current].[id] = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            DataTable dataTable = connector.GetDataTable(sql, parameters);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        public DataTable GetCurrentByUserId(Int64 userId)
        {
            String sql = @"SELECT [bmd_user].[avatar] AS [user_avatar],
                             [bmd_user].[name] AS [user_name],
                             [current].*
                           FROM [bmd_user], [current]
                           WHERE [bmd_user].[id] = [current].[user_id]
                             AND [current].[user_id] = @user_id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@user_id", userId)
            };

            DataTable dataTable = connector.GetDataTable(sql, parameters);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        public Boolean AddCurrent(Current current)
        {
            // 当话题 ID 不为空的情况
            String sql = @"INSERT INTO [current]([user_id], [title], [contents], [publish_date])
                           VALUES(@user_id, @title, @contents, @publish_date)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@user_id",           current.UserId),
                new SqlParameter("@title",              current.Title),
                new SqlParameter("@contents",        current.Contents),
                new SqlParameter("@publish_date", current.PublishDate)
            };

            Int32 line = -1;

            if (GetAddingCurrentId(current) <= 0)
            {
                line = (int)connector.Execute("non", sql, parameters);
            }

            return line <= 0 ? false : true;
        }

        public Int64 GetAddingCurrentId(Current addingCurrent)
        {
            string sql = @"SELECT [id] FROM [current]
                           WHERE [user_id] = @user_id
                             AND [publish_date] = @publish_date
                             AND [title] = @title"; // 不比较内容，代价太大

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@user_id",           addingCurrent.UserId),
                new SqlParameter("@title",              addingCurrent.Title),
                new SqlParameter("@publish_date", addingCurrent.PublishDate)
            };

            object id = connector.Execute("scalar", sql, parameters);

            return id != null ? (Int64)id : -1;
        }

        public DataTable GetCurrentByTopicId(Int64 topicId)
        {
            // Get current-id list of joining the topic from `topic_join` table.

            TopicJoinDao topicJoinDao  = new TopicJoinDao();
            List<Int64>  currentIdList = topicJoinDao.GetCurrentIdListByTopicId(topicId);

            StringBuilder sql = new StringBuilder(
                @"SELECT [bmd_user].[avatar] AS [user_avatar],
                     [bmd_user].[name] AS [user_name],
                     [current].*
                  FROM [bmd_user], [current]
                  WHERE [bmd_user].[id] = [current].[user_id]
                    AND [current].[id] IN");

            if (currentIdList == null) // 该话题参与度为 0
            {
                return null;
            }

            SqlParameter[] parameters = new SqlParameter[currentIdList.Count];

            sql.Append("("); // 添加左括号

            for (int i = 0, length = currentIdList.Count; i < length; i++)
            {
                String formatStr = i == 0 ? "@id{0}" : ", @id{0}";

                sql.AppendFormat(formatStr, i); // 构建 SQL 语句

                parameters[i] = new SqlParameter("@id" + i, currentIdList[i]); // 构建安全参数
            }

            sql.Append(")"); // 添加右括号

            DataTable dataTable = connector.GetDataTable(sql.ToString(), parameters);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        #endregion

    }
}
