using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Reflection;

namespace Bermuda.Common
{
    /// <summary>
    /// 基本工具类 - 定义了一些基本方法
    /// </summary>
    public class BaseUtil
    {
        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="obj">判断对象</param>
        /// <returns>true：为空，false：不为空</returns>
        public static Boolean IsNullObj(Object obj)
        {
            return obj != null ? false : true;
        }

        /// <summary>
        /// 将一个 Object 类型对象转化成一个实体对象
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="obj">Object 类型对象</param>
        /// <returns>实体对象</returns>
        public static T GetEntity<T>(Object obj) where T : class
        {
            return IsNullObj(obj) ? null : (T)obj;
        }

        /// <summary>
        /// 将单个实体对象转化成实体对象列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">实体对象</param>
        /// <returns>实体对象列表</returns>
        public static List<T> GetEntityList<T>(T entity) where T : class
        {
            List<T> list = new List<T>();

            list.Add(entity);

            return list;
        }

        /// <summary>
        /// 获取实体对象列表的第一个对象
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">实体对象列表</param>
        /// <returns>实体对象</returns>
        public static T GetFristEntityOfList<T>(List<T> list) where T : class
        {
            return list[0];
        }

        /// <summary>
        /// TODO: 将实体数据表转化成实体列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entityDataTable">实体数据表</param>
        /// <returns>实体列表或 null</returns>
        public static List<T> GetEntityList<T>(DataTable entityDataTable) where T : class, new()
        {
            List<T> entityList = new List<T>();

            Type entity = typeof(T);
            PropertyInfo[] properInfo = entity.GetProperties();

            List<String> feildNameList = GetDataTableFeildList(entityDataTable); // 获取数据表的字段名列表

            // if (feildNameList.Count <= 0)
            // {
            //     return null;
            // }

            foreach (DataRow row in entityDataTable.Rows)
            {
                T tEntity = new T(); // 实体对象

                // 遍历属性并设置值
                foreach (var prop in properInfo)
                {
                    // 找到对应属性的值
                    foreach (String feildStr in feildNameList)
                    {
                        String str = Splitor(feildStr, '_'); // e.g. "user_id" => "userid"

                        if (str == prop.Name.ToLower())
                        {
                            prop.SetValue(tEntity, row[feildStr]);
                            break;
                        }

                    }
                }

                entityList.Add(tEntity); // 将实体添加到列表中
            }

            return entityList.Count <= 0? null : entityList;
        }

        /// <summary>
        /// 获取数据表字段名字符串列表
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>字段列表</returns>
        public static List<String> GetDataTableFeildList(DataTable dataTable)
        {
            List<String> feildNameList = new List<string>();

            foreach (DataColumn col in dataTable.Columns)
            {
                string colName = col.ColumnName; // 获取列名
                feildNameList.Add(colName);
            }

            return feildNameList;
        }

        /// <summary>
        /// 将规律化分割的字符串格式化
        /// </summary>
        /// <code>
        ///    String str = BaseUtil.Splitor("cmnt_id", '_');  // "cmntId"
        /// </code>
        /// <param name="str"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static String Splitor(String str, params Char[] separator)
        {
            String[] strArr = str.Split('_');
            StringBuilder strBuilder = new StringBuilder();

            foreach (String item in strArr)
            {
                strBuilder.Append(item);
            }

            return strBuilder.ToString();
        }
    }
}
