using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Reflection;

namespace Bermuda.Dal.Dao
{
    public class DaoFactory
    {

        private static readonly string assemblyName = ConfigurationManager.AppSettings["DalName"].ToString();

        /// <summary>
        /// 利用反射得到对应的接口
        /// </summary>
        /// <typeparam name="T">数据库连接对象</typeparam>
        /// <returns>DAO 接口对象</returns>
        public static object GetInstance<T>()
        {
            return Assembly.Load(assemblyName).CreateInstance(typeof(T).ToString()); // 赋值时需作拆箱处理
        }
    }
}
