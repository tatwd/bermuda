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
    public class TopicJoinDao : ITopicJoinDao
    {
        private readonly Connector connector = DbKit.GetConnector("DefaultDb");

        #region Override

        public Boolean AddTopicJoin(TopicJoin topicJoin)
        {
            String sql = @"INSERT INTO [topic_join]([topic_id], [current_id])
                           VALUES(@topic_id, @current_id)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@topic_id",     topicJoin.TopicId),
                new SqlParameter("@current_id", topicJoin.CurrentId)
            };

            Int32 line = (Int32)connector.Execute("non", sql, parameters);

            return line <= 0 ? false : true;
        }

        public List<Int64> GetCurrentIdListByTopicId(Int64 topicId)
        {
            List<Int64> list = new List<Int64>();

            String sql = @"SELECT [current_id] FROM [topic_join] WHERE [topic_id] = @topic_id"; // 找到参与该话题的动态 ID

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@topic_id", topicId)
            };

            DataTable data = connector.GetDataTable(sql, parameters);

            if (data != null && data.Rows.Count != 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    Int64 _currentId = Convert.ToInt64(row["current_id"]);

                    list.Add(_currentId);
                }
            }
            else
            {
                list = null;
            }

            return list;
        }

        #endregion
    }
}
