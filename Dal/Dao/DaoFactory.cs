using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Reflection;
using Model;

namespace Dal.Dao
{
    public class DaoFactory
    {
        /// <summary>
        /// 利用反射得到对应的接口
        /// </summary>
        /// <typeparam name="T">数据库连接对象</typeparam>
        /// <returns>接口对象</returns>
        public static object Get<T>()
        {
            return Assembly.Load("Dal").CreateInstance(typeof(T).ToString()); // 赋值时需作拆箱处理
        }
    }
}
