using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using Dal.Dao;
using Dal.Helper;
using System.Data.SqlClient;

namespace Dal.MsSql
{
    public class UserDao : IUserDao
    {

        public static readonly Connector connector = DbKit.GetConnector("DefaultDb");

        private DataTable Select(string selectItem, Hashtable hashtable)
        {
            List<User> listUser = new List<User>();
            
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat("SELECT {0} FROM[bmd_user]", selectItem);

            if (hashtable.Count != 0)
            {
                sql.AppendFormat("{0}", "WHERE ");

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

        public User SignIn(string name, string pwd)
        {
            User user = new User();

            Hashtable hashtable = new Hashtable();

            hashtable.Add("name", name);
            hashtable.Add("pwd",   pwd);

            DataTable dataTable = Select("*", hashtable);

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    user.Id          = (long)row["id"];
                    user.Name        = (string)row["name"];
                    user.PhoneNumber = row["phone_number"].ToString();
                    user.Email       = row["email"].ToString();
                    user.Type        = row["type"].ToString();
                    user.Pwd         = row["pwd"].ToString();
                    user.Avatar      = row["avatar"].ToString();
                    user.Rate        = (int)row["rate"];
                }
            }

            return user;
        }

        public bool SignUp(User user)
        {
            throw new NotImplementedException();
        }
    }
}
