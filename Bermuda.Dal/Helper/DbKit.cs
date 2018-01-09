using System;                 // must
using System.Data;            // must
using System.Data.SqlClient;  // must
using System.Configuration;   // must

namespace Bermuda.Dal.Helper
{
    // 抽象工厂模式（Abstract factory pattern） + 反射（Reflection）
    //

    // Summary:
    //   DbKit - 数据库助手，即连接器生产工厂
    //
    public class DbKit
    {
        // Summary:
        //   连接器类名
        //   如果在配置文件中设置了数据库类型（DbType）的节点，则可依下列方法从中读取：
        //    
        //   private static string ConnectorClassName
        //   {
        //       set
        //       {
        //           string className = ConfigurationManager.AppSettings["DbType"]; // 获取配置文件中的数据库类型
        //
        //           if (className.Equals("MSSQL", StringComparison.CurrentCultureIgnoreCase)) // 忽略大小写
        //           {
        //               value = "DbKit.MsSqlConnector"; // for mssql
        //           }
        //           else (className.Equals("MYSQL", StringComparison.CurrentCultureIgnoreCase))
        //           {
        //               value = "DbKit.MySqlConnector"; // for mysql
        //           }
        //       }
        //       get
        //       {
        //           return ConnectorClassName;
        //       }
        //   }
        //
        private static readonly string ConnectorClassName = typeof(MsSqlConnector).ToString();

        // Summary:
        //   获取当前程序集全名，只读
        // private static readonly string AssemblyName = Assembly.GetExecutingAssembly().FullName;

        // Summary:
        //   根据数据库类型，获取一个通用连接数据库对象
        //
        // Parameters:
        //   dbConnStrName:
        //     在配置文件中设置的数据库连接字符串名称，可变参数数组
        //
        public static Connector GetConnector(params string[] dbConnStrName)
        {
            // Must using System.Reflection
            // return (Connector)Assembly.Load(AssemblyName).CreateInstance(ConnectorClassName); // 利用 Assembly 反射创建一个连接器

            //
            // 反射实现带参类的创建

            Type classType = Type.GetType(ConnectorClassName); // 获取构造类型

            object[] parameter = (dbConnStrName.Length == 1) ? dbConnStrName : null; // 设置构造函数参数，最多传入一个参数

            return (Connector)Activator.CreateInstance(classType, parameter); // 利用用 Activator 反射创建类
        }

        // -------------------------------------
        // Extend other connector creators here.
        // -------------------------------------

        // User ...
    }

    public interface Connector
    {
        // TODO
        // Summary:
        //   设置安全参数
        //
        // void SetParameter(...)

        // Summary:
        //   执行 SQL 语句并返回结果
        //
        // Parameters:
        //   executeType:
        //     字符串，表示执行类型， 有三个值：
        //     "Non"    - ExecuteNonQuery
        //     "Reader" - ExecuteReader
        //     "Scalar" - ExecuteScalar
        //     "Xml"    - ExecuteXmlReader
        //
        //   cmdText:
        //     表示 SQL 语句，支持带安全参数
        //
        //   cmdParams:
        //     安全参数数组
        //
        // Returns:
        //   返回对应的结果，类型为object
        //
        object Execute(string executeType, string cmdText, params object[] cmdParams);

        // Summary:
        //   执行SQL语句或存储过程并返回结果
        //
        // Parameters:
        //   executeType:
        //     字符串，表示执行类型， 有三个值：
        //     "Non"    - ExecuteNonQuery
        //     "Reader" - ExecuteReader
        //     "Scalar" - ExecuteScalar
        //     "Xml"    - ExecuteXmlReader
        //
        //   cmdText:
        //     表示 SQL 语句或存储过程名，支持带安全参数
        //
        //   cmdType:
        //     CommandType类型，设置命令的类型
        //
        //   cmdParams:
        //     安全参数数组
        //
        // Returns:
        //   返回对应的结果，类型为object
        //
        object Execute(string executeType, string cmdText, CommandType cmdType, params object[] cmdParams);

        // Summary:
        //   断开模式下，获取数据表（DataTable）
        //
        // Parameters:
        //   cmdText:
        //     表示 SQL 语句，支持带安全参数
        //
        //   cmdParams:
        //     安全参数数组
        // 
        // Returns:
        //   返回数据表
        DataTable GetDataTable(string cmdText, params object[] cmdParams);

        // Summary:
        //   断开模式下，获取数据表（DataTable）
        //   支持存储过程
        //
        // Parameters:
        //   cmdText:
        //     表示 SQL 语句或存储过程名，支持带安全参数
        //
        //   cmdType:
        //     CommandType类型，设置命令的类型
        //
        //   cmdParams:
        //     安全参数数组
        // 
        // Returns:
        //   返回数据表
        DataTable GetDataTable(string cmdText, CommandType cmdType, params object[] cmdParams);

        // Summary:
        //   断开模式下，获取数据集（DataSet）
        //   支持存储过程
        //
        // Parameters:
        //   cmdText:
        //     表示 SQL 语句或存储过程名，支持带安全参数
        //
        //   cmdParams:
        //     安全参数数组
        // 
        // Returns:
        //   返回数据集
        DataSet GetDataSet(string cmdText, params object[] cmdParams);

        // Summary:
        //   断开模式下，获取数据集（DataSet）
        //   支持存储过程
        //
        // Parameters:
        //   cmdText:
        //     表示 SQL语句或存储过程名，支持带安全参数
        //
        //   cmdType:
        //     CommandType 类型，设置命令的类型
        //
        //   cmdParams:
        //     安全参数数组
        // 
        // Returns:
        //   返回数据集
        DataSet GetDataSet(string cmdText, CommandType cmdType, params object[] cmdParams);

        // ---------
        // TODO LIST
        // ---------

        // Crezy idea! ^-^

        // Summary:
        //   断开模式下删除数据行
        //
        // void DeleteRow(string cmdText, params object[] cmdParams);

        // Summary:
        //   断开模式下管理数据
        //
        // object ExecuteDisc(...)

        // TODO: GetData/GetXml/GetJson ?
    }

    public class MsSqlConnector : Connector
    {
        // Summary:
        //   连接对象，私有
        private SqlConnection dbConnection { set; get; }

        // Summary:
        //   连接字符串，私有
        private string dbConnectionString { set; get; }

        // Summary:
        //   获取连接字符串，私有方法
        //
        // Parameters:
        //   dbConnStrName:
        //     数据库连接字符串名，在配置文件中
        private void setDbConnectionString(string dbConnStrName)
        {
            if (dbConnectionString != "")
            {
                dbConnectionString = ConfigurationManager.ConnectionStrings[dbConnStrName].ConnectionString; // 从配置文件中获取连接字符串
            }
        }

        // Summary:
        //   创建连接对象，私有方法
        //
        private void setDbConnection()
        {
            if (dbConnection == null)
            {
                dbConnection = new SqlConnection(dbConnectionString);
            }
        }

        // Summary:
        //   打开数据库，私有方法
        private void openDb()
        {
            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Open();
            }
        }

        // Summary:
        //   关闭数据库，私有方法
        private void closeDb()
        {
            if (dbConnection.State != ConnectionState.Closed)
            {
                dbConnection.Close();
            }
        }

        public MsSqlConnector() { }

        // Summary:
        //   带参构造函数
        //
        // Parameters:
        //   dbConnStrName:
        //     数据库连接字符串名，在配置文件中
        public MsSqlConnector(string dbConnStrName)
        {
            setDbConnectionString(dbConnStrName);
            setDbConnection();
        }

        // Summary:
        //   获取执行 SQL 语句的结果，私有方法
        //
        // Parameters:
        //   executeType:
        //     执行类型
        //
        //   cmd:
        //     命令对象
        //
        //   cmdParams:
        //     安全参数数组
        //
        // Returns:
        //   返回执行结果，类型为 object
        private object getResult(string executeType, SqlCommand cmd, params object[] cmdParams)
        {
            object result = null;

            // 设置 SqlParameter
            if (cmdParams.Length != 0)
            {
                cmd.Parameters.AddRange((SqlParameter[])cmdParams);
            }

            // 按执行类型执行 SQL 语句
            //
            if (executeType.Equals("Non", StringComparison.CurrentCultureIgnoreCase))
            {
                result = cmd.ExecuteNonQuery();

                closeDb();
            }
            else if (executeType.Equals("Reader", StringComparison.CurrentCultureIgnoreCase))
            {
                result = cmd.ExecuteReader(CommandBehavior.CloseConnection); // 执行后关闭连接
            }
            else if (executeType.Equals("Scalar", StringComparison.CurrentCultureIgnoreCase))
            {
                result = cmd.ExecuteScalar();

                closeDb();
            }
            else if (executeType.Equals("Xml", StringComparison.CurrentCultureIgnoreCase))
            {
                result = cmd.ExecuteXmlReader();

                closeDb();
            }

            // 清除 SqlParameter
            if (cmd.Parameters.Count != 0)
            {
                cmd.Parameters.Clear();
            }

            return result;
        }

        // Override
        public object Execute(string executeType, string cmdText, params object[] cmdParams)
        {
            // executeType ? Non, Reader, Scalar, Xml

            return Execute(executeType, cmdText, CommandType.Text, cmdParams);

        }

        // Override
        public object Execute(string executeType, string cmdText, CommandType cmdType, params object[] cmdParams)
        {
            using (SqlCommand cmd = new SqlCommand(cmdText, dbConnection))
            {
                object result = null;

                cmd.CommandType = cmdType; // 设置命令类型

                openDb(); // 打开数据库

                result = getResult(executeType, cmd, cmdParams); // 获取结果

                cmd.Cancel(); // 取消执行

                return result;
            }
        }

        // Override
        public DataTable GetDataTable(string cmdText, params object[] cmdParams)
        {
            return GetDataTable(cmdText, CommandType.Text, cmdParams);
        }

        // Override
        public DataTable GetDataTable(string cmdText, CommandType cmdType, params object[] cmdParams)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand(cmdText, dbConnection);

                cmd.CommandType = cmdType;

                if (cmdParams.Length != 0)
                {
                    cmd.Parameters.AddRange((SqlParameter[])cmdParams); // 添加安全参数
                }

                adapter.SelectCommand = cmd;

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // Override
        public DataSet GetDataSet(string cmdText, params object[] cmdParams)
        {
            return GetDataSet(cmdText, CommandType.Text, cmdParams);
        }

        // Override
        public DataSet GetDataSet(string cmdText, CommandType cmdType, params object[] cmdParams)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand(cmdText, dbConnection);

                cmd.CommandType = cmdType;

                if (cmdParams.Length != 0)
                {
                    cmd.Parameters.AddRange((SqlParameter[])cmdParams); // 添加安全参数
                }

                adapter.SelectCommand = cmd;

                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet);

                return dataSet;
            }
        }

    }
}