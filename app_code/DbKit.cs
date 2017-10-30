using System;
using System.Reflection;      // must 
using System.Configuration;   // must
using System.Data;            // must
using System.Data.SqlClient;  // must

namespace DbKit
{
    // 抽象工厂模式（Abstract factory pattern） + 反射（Reflection）
    //

    // Summary:
    //   ConnectorFactory - 连接器生产工厂
    //
    public class ConnectorFactory
    {
        // Summary:
        //   连接器类名
        //   如果在Web.config中设置了数据库类型（DbType）的节点，则可依下列方法从中读取：
        //    
        //   private static string ConnectorClassName
        //   {
        //       set
        //       {
        //           string className = ConfigurationManager.AppSettings["DbType"]; // 获取Web.config中的数据库类型
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
        private static readonly string ConnectorClassName = "DbKit.MsSqlConnector";

        // Summary:
        //   获取当前程序集全名，只读
        // private static readonly string AssemblyName = Assembly.GetExecutingAssembly().FullName;

        // Summary:
        //   根据数据库类型，获取一个通用连接数据库对象
        //
        // Parameters:
        //   dbConnStrName:
        //     在Web.config中设置的数据库连接字符串名称，可变参数数组
        //
        public static Connector GetConnector(params string[] dbConnStrName)
        {
            // return (Connector)Assembly.Load(AssemblyName).CreateInstance(ConnectorClassName); // 利用Assembly反射创建一个连接器

            //
            // 反射实现带参类的创建

            Type classType = Type.GetType(ConnectorClassName); // 获取构造类型

            object[] parameter = (dbConnStrName.Length == 1) ? dbConnStrName : null; // 设置构造函数参数，最多传入一个参数

            return (Connector)Activator.CreateInstance(classType, parameter); // 利用用Activator反射创建类
        }

        // -------------------------------------
        // Extend other connector creators here.
        // -------------------------------------

        // User ...
    }

    // Summary
    //   Connector 连接器 - 接口, 定义了一些与ADO.NET相关的通用方法，包含连接模式（Maybe OK）和断开模式（Maybe OK）
    //
    // TODO: 实行异步操作
    //
    public interface Connector
    {
        // Summary:
        //   连接数据库
        void Connect();

        // Summary:
        //   完成连接字符串的获取、连接对象的创建及打开数据库
        //
        // Parameters:
        //   dbConnStrName:
        //     在Web.config中设置的数据库连接字符串名称
        void Connect(string dbConnStrName);

        // Summary:
        //   获取ExecuteReader执行的结果
        //
        // Parameters:
        //   cmdText:
        //     SQL语句字符串
        //
        //   parameter:
        //     SQL参数数组
        //
        // Returns:
        //   返回DataReader数据集
        object GetDataReader(string cmdText, params object[] parameter);

        // Summary:
        //   获取ExecuteScalar执行的结果
        //
        // Parameters:
        //   cmdText:
        //     SQL语句字符串
        //
        //   parameter:
        //     SQL参数数组
        //
        // Returns:
        //   返回一个object类型的数据
        object GetScalar(string cmdText, params object[] parameter);

        // Summary:
        //   利用泛型对数据库数据进行增、删、改、查管理
        // 
        // Parameters:
        //   excuteType:
        //     执行类型，三个值
        //       0 - 执行增、删、改操作并返回受影响行数
        //       1 - 执行单条语句查询并返回第一行第一列
        //       2 - 执行查询语句并返回DataReader数据集
        //
        //   cmdText:
        //     SQL语句，带参或不带参
        //
        //   parameter:
        //     SQL参数数组
        //
        // Returns:
        //   返回T类型数据
        //
        T ManageData<T>(int executeType, string cmdText, params object[] parameter);

        // Summary:
        //   利用泛型对数据库数据进行增、删、改、查管理
        // 
        // Parameters:
        //   excuteType:
        //     执行类型，三个值：
        //       0 - 执行增、删、改操作并返回受影响行数
        //       1 - 执行单条语句查询并返回第一行第一列
        //       2 - 执行查询语句并返回DataReader数据集
        //
        //   procdureName:
        //     存储过程名
        //   
        //   securityType:
        //     安全类型 
        // 
        //   parameter:
        //     SqlParameter参数数组
        //
        //  TODO: how to declare this method?
        //
        // T ManageData<T>(int executeType, string procdureName, string securityType, params object[] parameter);

        // Summary:
        //   断开模式查询数据库，支持带参查询
        //
        // Parameters:
        //   cmdText:
        //     查询语句字符串
        //
        //   parameter:
        //     SQL参数数组
        // 
        // Returns:
        //   返回DataSet数据集
        DataSet GetDataSet(string cmdText, params object[] parameter);

        // Summary:
        //   断开模式下获取数据表
        // 
        // Parameters:
        //   cmdText:
        //     SQL语句字符串
        //
        //   parameters:
        //     SQL参数数组
        //
        // Returns:
        //   返回DataTable数据集
        DataTable GetDataTable(string cmdText, params object[] parameter);

        // Summary:
        //   将设置好的数据表（dataTable）更新到数据库表（tableName）中
        // 
        // Parameters:
        //   tableName:
        //     数据库中表名
        // 
        //   dataRow:
        //     已设置好的数据表行
        void ManageDataOffMode(string manageType, string tableName, params object[] paramter);

        // Summary:
        //   判断数据库中是否已存在该项
        //
        // Parameters:
        //   cmdText:
        //     SQL语句，带参或不带参
        //
        //   parameter:
        //     SQL参数数组
        //
        // Returns:
        //   返回bool值，true表示存在，false表示不存在
        //
        bool HasData(string cmdText, params object[] parameter);

        // Summary:
        //   打开数据库
        void OpenDb();

        // Summary:
        //   关闭数据库
        void CloseDb();

        // Summary:
        //   关闭所有资源
        void CloseAll();
    }

    // Summary:
    //   MsSqlConnector - SqlServer连接器
    //
    public class MsSqlConnector : Connector
    {
        // Summary:
        //   数据库连接对象，私有
        private SqlConnection DbConnection { set; get; }

        // Summary:
        //   连接字符串，私有
        private string ConnectionString { set; get; }

        // Summary:
        //   数据阅读器，私有
        private SqlDataReader DataReader { set; get; }

        // Override
        public void Connect()
        {
            //setConnectionString(dbName); // 设置连接字符串
            
            //DbConnection = new SqlConnection(ConnectionString); // 创建连接对象

            OpenDb();
        }

        // Override
        public void Connect(string dbConnStrName)
        {
            setConnectionString(dbConnStrName); // 设置连接字符串
            setDbConnection();                  // 创建连接对象
            OpenDb();                           // 打开数据库
        }

        // Summary:
        //   从Web.config中获取连接字符串，私有方法
        //
        // Parameters:
        //   dbConnStrName:
        //     在Web.config中设置的数据库连接字符串名称  
        private void setConnectionString(string dbConnStrName)
        {
            if (ConnectionString != "")
            {
                ConnectionString = ConfigurationManager.ConnectionStrings[dbConnStrName].ConnectionString; // 从Web.config中获取连接字符串
            }
        }

        // Summary:
        //   创建连接对象
        private void setDbConnection()
        {
            if (DbConnection == null)
            {
                DbConnection = new SqlConnection(ConnectionString); // 创建连接对象
            }
        }

        // Summary:
        //   设置SqlCommand的参数
        //
        // Parameters:
        //   cmd:
        //     SqlCommand对象，引用参数
        //
        //   parameters:
        //     SQL参数数组
        private void setCommandParameter(ref SqlCommand cmd, params object[] parameter)
        {
            if (parameter.Length != 0)
            {
                SqlParameter[] parameters = (SqlParameter[])parameter; // 设置参数

                cmd.Parameters.AddRange(parameters);
            }
        }

        // Summary:
        //   设置数据行
        // 
        // Parameters:
        //   dataRow:
        //     数据行，引用参数
        //
        //   parameeter:
        //     SQL参数数组
        //
        private void setDataRow(ref DataRow dataRow, params object[] parameter)
        {
            for (int i = 0, length = parameter.Length; i < length; i++)
            {
                dataRow[i + 1] = parameter[i]; // 主键为自增型
            }
        }

        // Override
        public object GetDataReader(string sql, params object[] parameter)
        {
            using (SqlCommand cmd = new SqlCommand(sql, DbConnection))
            {
                if (parameter.Length != 0)
                {
                    SqlParameter[] parameters = (SqlParameter[])parameter; // 设置参数

                    cmd.Parameters.AddRange(parameters);
                }

                DataReader = cmd.ExecuteReader();

                // cmd.Cancel();

                return DataReader;
            }
        }

        // Override
        public object GetScalar(string sql, params object[] parameter)
        {
            using (SqlCommand cmd = new SqlCommand(sql, DbConnection))
            {
                if (parameter.Length != 0)
                {
                    SqlParameter[] parameters = (SqlParameter[])parameter; // 设置参数

                    cmd.Parameters.AddRange(parameters);
                }

                return cmd.ExecuteScalar();
            }
        }

        // Override
        public int SetData(string sql, params object[] parameter)
        {
            using (SqlCommand cmd = new SqlCommand(sql, DbConnection))
            {
                if (parameter.Length != 0)
                {
                    SqlParameter[] parameters = (SqlParameter[])parameter; // 设置参数

                    cmd.Parameters.AddRange(parameters);
                }

                int result = cmd.ExecuteNonQuery(); // 返回受影响的行数

                // cmd.Cancel();

                return result;
            }
        }

        // Override
        public T ManageData<T>(int executeType, string cmdText, params object[] parameter)
        {
            using (SqlCommand cmd = new SqlCommand(cmdText, DbConnection))
            {
                if (parameter.Length != 0)
                {
                    SqlParameter[] parameters = (SqlParameter[])parameter; // 设置参数
                    
                    cmd.Parameters.AddRange(parameters);
                }

                object result = null;

                switch (executeType.ToString()) // 判断执行类型
                {
                    // ExecuteNonQuery
                    case "0":  
                        result = cmd.ExecuteNonQuery();
                        break;

                    // ExecuteScalar
                    case "1":  
                        result = cmd.ExecuteScalar();   
                        result = result == null ? 0 : result; // 判断result是否为空
                        break;

                    // ExecuteReader
                    case "2":
                        DataReader = cmd.ExecuteReader();
                        result = DataReader;
                        break;
                }

                if (cmd.Parameters.Count != 0)
                {
                    cmd.Parameters.Clear(); // 清除SqlParameter
                }

                // cmd.Cancel(); //  终止执行sql

                return (T)result; // 拆箱
            }
        }

        // Override
        public DataSet GetDataSet(string cmdText, params object[] parameter)
        {
            DataSet dataSet = new DataSet();

            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand(cmdText, DbConnection);

                setCommandParameter(ref cmd, parameter); // 设置参数

                adapter.SelectCommand = cmd;

                adapter.Fill(dataSet);
            }

            return dataSet;
        }

        // Override
        public DataTable GetDataTable(string cmdText, params object[] parameter)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand(cmdText, DbConnection);

                setCommandParameter(ref cmd, parameter); // 设置参数

                adapter.SelectCommand = cmd;

                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        // Override
        public void ManageDataOffMode(string manageType, string tableName, params object[] parameter)
        {
            string sql = String.Format("select * from [{0}]", tableName);

            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, DbConnection))
            {
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable); // 填充表

                if (manageType.Equals("insert", StringComparison.CurrentCultureIgnoreCase)) // 插入
                {
                    DataRow newRow = dataTable.NewRow(); // 添加新纪录

                    setDataRow(ref newRow, parameter);   // 设置数据行

                    dataTable.Rows.Add(newRow);          // 添加到表中
                    
                    adapter.Update(dataTable);           // 更新数据库
                }
                else if (manageType.Equals("update", StringComparison.CurrentCultureIgnoreCase))
                {
                    dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] }; // 设置主键

                    DataRow row = dataTable.Rows.Find(parameter[0]);

                    if (row != null)
                    {
                        row.BeginEdit();
                        for (int i = 1, length = parameter.Length; i < length; i++)
                        {
                            row[i] = parameter[i];
                        }
                        row.EndEdit();
                        adapter.Update(dataTable);
                    }

                }
                else if (manageType.Equals("delete", StringComparison.CurrentCultureIgnoreCase))
                {
                    dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] }; // 设置主键
                    DataRow row = dataTable.Rows.Find(parameter[0]);

                    // string selectRow = String.Format("username='{0}'", parameter[0]);
                    // DataRow row = dataTable.Select(selectRow)[0];

                    if (row != null)
                    {
                        row.Delete();
                        adapter.Update(dataTable);
                    }
                }
            }
        }

        // Override
        public bool HasData(string cmdText, params object[] parameter)
        {
            OpenDb();

            bool hasData = (ManageData<int>(1, cmdText, parameter) != 0) ? true : false;

            CloseAll();

            return hasData;
        }

        // Override
        public void OpenDb()
        {
            if (DbConnection.State != ConnectionState.Open)
            {
                DbConnection.Open(); // 打开数据库
            }
        }

        // Override
        public void CloseDb()
        {
            if (DbConnection.State != ConnectionState.Closed)
            {
                DbConnection.Close(); // 关闭数据库
            }
        }

        // Override
        public void CloseReader()
        {
            if (DataReader != null && !DataReader.IsClosed)
            {
                DataReader.Close();
            }
        }

        // Override
        public void CloseAll()
        {
            CloseReader(); // 关闭阅读器

            CloseDb();     // 关闭数据库
        }
        
        // Summary:
        //   无参构造函数
        public MsSqlConnector() { }

        // Summary:
        //   带参的构造函数，构造对象的同时进行连接字符串的获取、连接对象的创建及打开数据库
        //
        // Parameters:
        //   dbConnStrName:
        //      在Web.config中设置的数据库连接字符串名称
        public MsSqlConnector(string dbConnStrName)
        {
            setConnectionString(dbConnStrName); // 设置连接字符串
            setDbConnection();                  // 创建连接对象
        }
    }
}