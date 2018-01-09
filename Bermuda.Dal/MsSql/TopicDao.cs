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
using Bermuda.Common;

namespace Bermuda.Dal.MsSql
{
    public class TopicDao : ITopicDao
    {
        private readonly Connector connector = DbKit.GetConnector("DefaultDb");

        #region Override

        public List<Topic> GetTopicByTop(Int32 number)
        {
            String sql = number >= 0 ? 
                String.Format(@"SELECT TOP {0} * 
                                FROM [topic] 
                                WHERE [is_passed] = 1
                                ORDER BY [join_count] DESC", number) :
                @"SELECT * 
                  FROM [topic]
                  WHERE [is_passed] = 1 
                  ORDER BY [join_count] DESC";

            DataTable dataTable = connector.GetDataTable(sql);

            return BaseUtil.GetEntityList<Topic>(dataTable);

            // return list;
        }


        public List<Topic> GetAllTopic()
        {
            //List<Topic> list = new List<Topic>();

            //string sql = @"SELECT * FROM [topic]  WHERE [is_passed] = 1 ORDER BY [create_date] DESC";

            //DataTable dataTable = connector.GetDataTable(sql);

            //list = BaseUtil.GetEntityList<Topic>(dataTable); // 获取实体对象列表

            //return list;

            return this.GetTopicByTop(-1); // -1 表示查询所有
        }

        public DataTable GetTopicNameAndId()
        {
            String sql = @"SELECT [id], [name] FROM [topic]";

            DataTable dataTable = connector.GetDataTable(sql);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        public Boolean AddTopic(Topic topic)
        {
            String sql = @"INSERT INTO [topic]([name], [user_id], [detail], [create_date], [img])
                           VALUES(@name, @user_id, @detail, @create_date, @img)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name",              topic.Name),
                new SqlParameter("@user_id",         topic.UserId),
                new SqlParameter("@detail",          topic.Detail),
                new SqlParameter("@create_date", topic.CreateDate),
                new SqlParameter("@img",                topic.Img)
            };

            // 此插入不需要验证重名记录，由管理员审核
            Int32 line = (Int32)connector.Execute("non", sql, parameters);

            return line <= 0 ? false : true;
        }

        public DataTable GetTopicById(Int64 id)
        {
            String sql = @"SELECT [topic].*,
                             [bmd_user].[name] AS [user_name],
                             [bmd_user].[avatar] AS [user_avatar]
                           FROM [bmd_user], [topic]
                           WHERE [bmd_user].[id] = [topic].[user_id]
                             AND [topic].[id] = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            DataTable dataTable = connector.GetDataTable(sql, parameters);

            return (dataTable != null && dataTable.Rows.Count != 0) ? dataTable : null;
        }

        #endregion
    }
}
