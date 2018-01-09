using System;
using System.Collections;
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
    public class UserDao : IUserDao
    {
        private readonly Connector connector = DbKit.GetConnector("DefaultDb");
        
        /// <summary>
        /// 查询操作 - 支持带条件或单条件或多条件关系是 AND 的操作
        /// </summary>
        /// <param name="selectItem">查询项</param>
        /// <param name="hashtable">查询条件参数的哈希表</param>
        /// <returns>数据表</returns>
        private DataTable Select(String selectItem, Hashtable hashtable)
        {
            List<User> listUser = new List<User>();
            
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat("SELECT {0} FROM [bmd_user]", selectItem);

            if (hashtable.Count != 0)
            {
                sql.AppendFormat("{0}", " WHERE ");

                SqlParameter[] parameters = new SqlParameter[hashtable.Count];

                // 设置带安全参数的 SQL 语句

                int count = 0;

                foreach (string key in hashtable.Keys)
                {
                    string appendStr = count == 0 ? "{0} = @{0}" : " AND {0} = @{0}";

                    sql.AppendFormat(appendStr, key, hashtable[key]);

                    // 设置安全参数
                    parameters[count] = new SqlParameter("@" + key, hashtable[key]);

                    count++;
                }

                return connector.GetDataTable(sql.ToString(), parameters);
                
            }
            else
            {
                return connector.GetDataTable(sql.ToString());
            }

            //return listUser != null ? listUser: null;
        }

        /// <summary>
        /// 将数据表（只有一条记录时）转化成 User 对象
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>User 对象</returns>
        private List<User> DataTableToUser(DataTable dataTable)
        {
            List<User> list = new List<User>();

            if (dataTable != null && dataTable.Rows.Count != 0) // data table 中只有一条记录时
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    User user = new User();

                    user.Id             = (Int64)row["id"];
                    user.Name           = row["name"].ToString();
                    user.PhoneNumber    = row["phone_number"].ToString();
                    user.Email          = row["email"].ToString();
                    user.Type           = row["type"].ToString();
                    user.Pwd            = row["pwd"].ToString();
                    user.Avatar         = row["avatar"].ToString();
                    user.Rate           = (Int32)row["rate"];
                    user.FollowingCount = (Int64)row["following_count"];
                    user.FollowerCount  = (Int64)row["follower_count"];

                    list.Add(user);
                }
            }
            else
            {
                list = null;
            }

            return list;
        }

        /// <summary>
        /// 更新单个字段的值
        /// </summary>
        /// <typeparam name="T">字段数据类型</typeparam>
        /// <param name="id">主键 ID</param>
        /// <param name="field">字段名</param>
        /// <param name="value">新值</param>
        /// <returns></returns>
        private Boolean UpdateField<T>(Int64 id, String field, T value)
        {
            String sql = String.Format("UPDATE [bmd_user] SET [{0}] = @{0} WHERE [id] = @id", field);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@" + field, value),
                new SqlParameter("@id", id)
            };

            Int32 line = (Int32)connector.Execute("non", sql, parameters);

            return line <= 0 ? false : true;

        }

        #region Override

        public User SignIn(String name, String pwd)
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add("name", name);
            hashtable.Add("pwd",   pwd);

            DataTable dataTable = this.Select("*", hashtable);

            List<User> list = this.DataTableToUser(dataTable); // 这个 list 只可能有 1 项或为 null

            return list != null ? list[0] : null;
        }

        public bool SignUp(User user)
        {
            // throw new NotImplementedException();

            String sql   = @"INSERT INTO [bmd_user]([name], [email], [pwd])
                             VALUES(@name, @email, @pwd)";

            String query = @"SELECT COUNT([id]) 
                             FROM [bmd_user] 
                             WHERE [name] = @name
                                 OR [email] = @email"; // 不重复昵称或邮箱

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@name",   user.Name),
                new SqlParameter("@email", user.Email),
                new SqlParameter("@pwd",     user.Pwd)
            };

            Int32 line = -1;

            if ((Int32)connector.Execute("scalar", query, parameter) <= 0) // 判断用户是否存在
            {
                line = (Int32)connector.Execute("non", sql, parameter);    // 添加用户到数据库
            }

            return line <= 0 ? false : true;
        }

        public List<User> GetUserById(Int64 id)
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add("id", id);

            DataTable dataTable = Select("*", hashtable);

            return this.DataTableToUser(dataTable);
        }

        public User GetUserByEmail(String email)
        {
            Hashtable hashTable = new Hashtable();

            hashTable.Add("email", email);

            DataTable dataTable = this.Select("*", hashTable);

            List<User> list = this.DataTableToUser(dataTable);

            return list != null ? list[0] : null; // 邮箱唯一性
        }

        public Boolean UpdatePwd(Int64 id, String newPwd)
        {
            return this.UpdateField<String>(id, "pwd", newPwd);
        }

        public Boolean UpdateById<T>(Int64 id, String field, T newValue)
        {
            return this.UpdateField<T>(id, field, newValue);
        }

        #endregion
    }
}
