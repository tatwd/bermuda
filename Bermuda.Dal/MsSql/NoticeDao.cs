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
    public class NoticeDao : INoticeDao
    {
        private readonly Connector connector = DbKit.GetConnector("DefaultDb");

        /// <summary>
        /// 根据字段来查询数据
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">对应的值</param>
        /// <returns></returns>
        private DataTable SelectNoticeBy(String field, Object value)
        {
            String param = String.Format("@{0}", field);

            String sql = String.Format(
                @"SELECT [bmd_user].[avatar] AS [user_avatar],
                    [bmd_user].[name] AS [user_name],
                    [notice].*
                  FROM [bmd_user], [notice]
                  WHERE [bmd_user].[id] = [notice].[user_id]
                    AND [notice].[{0}] = {1}", field, param);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(param, value)
            };

            DataTable dataTable = connector.GetDataTable(sql, parameters);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        #region Override

        public Boolean AddNotice(Notice notice)
        {
            String sql = @"INSERT INTO [notice]([user_id], [species_id], [type], [title], [place], [lf_date], [img], [contact_way], [detail], [publish_date])
                           VALUES(@user_id, @species_id, @type, @title, @place, @lf_date, @img, @contact_way, @detail, @publish_date)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@user_id",           notice.UserId),
                new SqlParameter("@species_id",     notice.SpeciesId),
                new SqlParameter("@type",                notice.Type),
                new SqlParameter("@title",              notice.Title),
                new SqlParameter("@place",              notice.Place),
                new SqlParameter("@lf_date",           notice.LfDate),
                new SqlParameter("@img",                  notice.Img),
                new SqlParameter("@contact_way",   notice.ContactWay),
                new SqlParameter("@detail",            notice.Detail),
                new SqlParameter("@publish_date", notice.PublishDate)
            };

            Int32 line = (Int32)connector.Execute("non", sql, parameters);

            return line <= 0 ? false : true;
        }

        public DataTable SelectNotice(params Int32[] number)
        {
            String sql = number.Length != 0 ? 
                String.Format(@"SELECT TOP {0} 
                                  [bmd_user].[avatar] AS [user_avatar],
                                  [bmd_user].[name] AS [user_name],
                                  [notice].*
                                FROM [bmd_user], [notice] 
                                WhERE [bmd_user].[id] = [notice].[user_id]
                                ORDER BY [publish_date] DESC", number[0]) :
                @"SELECT [bmd_user].[avatar] AS [user_avatar],
                    [bmd_user].[name] AS [user_name],
                    [notice].*
                  FROM [bmd_user], [notice] 
                  WhERE [bmd_user].[id] = [notice].[user_id] 
                  ORDER BY [publish_date] DESC";

            DataTable dataTable = connector.GetDataTable(sql);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        public DataTable SelectLostNotice(params Int32[] number)
        {
            String sql = number.Length != 0 ?
                String.Format(@"SELECT TOP {0} 
                                  [bmd_user].[avatar] AS [user_avatar],
                                  [bmd_user].[name] AS [user_name],
                                  [notice].*
                                FROM [bmd_user], [notice] 
                                WhERE [bmd_user].[id] = [notice].[user_id]
                                  AND [notice].[type] LIKE N'寻物%'
                                ORDER BY [publish_date] DESC", number[0]) :
                @"SELECT [bmd_user].[avatar] AS [user_avatar],
                    [bmd_user].[name] AS [user_name],
                    [notice].*
                  FROM [bmd_user], [notice] 
                  WhERE [bmd_user].[id] = [notice].[user_id]
                    AND [notice].[type] LIKE N'寻物%'
                  ORDER BY [publish_date] DESC";

            DataTable dataTable = connector.GetDataTable(sql);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        public DataTable SelectFoundNotice(params Int32[] number)
        {
            String sql = number.Length != 0 ?
                String.Format(@"SELECT TOP {0} 
                                  [bmd_user].[avatar] AS [user_avatar],
                                  [bmd_user].[name] AS [user_name],
                                  [notice].*
                                FROM [bmd_user], [notice] 
                                WhERE [bmd_user].[id] = [notice].[user_id]
                                  AND [notice].[type] LIKE N'招领%'
                                ORDER BY [publish_date] DESC", number[0]) :
                @"SELECT [bmd_user].[avatar] AS [user_avatar],
                    [bmd_user].[name] AS [user_name],
                    [notice].*
                  FROM [bmd_user], [notice] 
                  WhERE [bmd_user].[id] = [notice].[user_id] 
                    AND [notice].[type] LIKE N'招领%'
                  ORDER BY [publish_date] DESC";

            DataTable dataTable = connector.GetDataTable(sql);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        public DataTable SelectNoticeById(Int64 id)
        {
            return this.SelectNoticeBy("id", id);
        }

        public DataTable SelectNoticeByUserId(Int64 userId)
        {
            return this.SelectNoticeBy("user_id", userId);
        }

        public DataTable SelectNoticeBySpeciesId(Int64 speciesId)
        {
            return this.SelectNoticeBy("species_id", speciesId);
        }

        public DataTable GetBmdTop()
        {
            String sql = @"SELECT TOP 10 
                             [user_id],
                             [bmd_user].[avatar] AS [user_avatar],
                             [bmd_user].[name] AS [user_name],
                             count([bmd_user].[id]) AS [help_count]
                           FROM [bmd_user], [notice]
                           WHERE [bmd_user].[id] = [notice].[user_id] 
                             AND [notice].[type] = N'招领启示'
                             AND [notice].[status] = N'已领回'
                           Group by [user_id], [bmd_user].[avatar], [bmd_user].[name]";

            DataTable dataTable = connector.GetDataTable(sql);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        public T GetFieldValue<T>(Int64 id, String selectedField)
        {
            String sql = String.Format("SELECT [{0}] FROM [notice] WHERE [id] = @id", selectedField);

            SqlParameter[] parameters = new SqlParameter[] 
            {
                new SqlParameter("@id", id)
            };

            T value = (T)connector.Execute("scalar", sql, parameters); // 为空情况？

            return value;
        }

        public T GetFieldValueByUserId<T>(Int64 userId, String selectedField)
        {
            String sql = String.Format("SELECT {0} FROM [notice] WHERE [user_id] = @user_id", selectedField);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@user_id", userId)
            };

            T value = (T)connector.Execute("scalar", sql, parameters); // 为空情况？

            return value;
        }

        public Int32 GetHelpingCount(Int64 userId)
        {
            String sql = @"SELECT COUNT([id]) 
                           FROM [notice] 
                           WHERE [user_id] = @user_id
                           AND [type] LIKE N'招领%'
                           AND [status] LIKE N'已%'";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@user_id", userId)
            };

            Int32 count = (Int32)connector.Execute("scalar", sql, parameters);

            return count;
        }

        public Int32 GetBackingCount(Int64 userId)
        {
            String sql = @"SELECT COUNT([id]) 
                           FROM [notice] 
                           WHERE [user_id] = @user_id
                             AND [type] LIKE N'寻物%'
                             AND [status] LIKE N'已%'";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@user_id", userId)
            };

            Int32 count = (Int32)connector.Execute("scalar", sql, parameters);

            return count;
        }

        #endregion
    }
}
