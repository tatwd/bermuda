using System;
using System.Collections;
using System.Reflection;
using System.Text;

namespace Bermuda.Common
{
    public class BaseUtil
    {
        /// <summary>
        /// 将实体对象转化成 ViewModel 对象
        /// ViewModel 对象的属性部分对应实体属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static T ParseTo<T>(object entity) where T : class, new()
        {
            Type vmType = typeof(T);
            PropertyInfo[] vmProps = vmType.GetProperties();
            Hashtable mapEntity = GetEntriesMap(entity);
            T vm = new T();

            foreach (var prop in vmProps)
            {
                string field = Pascalify(prop.Name, '_');
                prop.SetValue(vm, mapEntity[field]);
            }

            return vm;
        }

        /// <summary>
        /// 获取对象的属性和对应值的 Hashtable
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Hashtable GetEntriesMap(object obj)
        {
            Hashtable map = new Hashtable();
            PropertyInfo[] props = obj.GetType().GetProperties();

            foreach (var prop in props)
            {
                map.Add(prop.Name, prop.GetValue(obj));
            }

            return map;
        }

        /// <summary>
        /// 按分割点格式化成遵循 Pascal 命名规则的字符串
        /// <example>
        /// <code>
        ///     // "user_id" => "UserId"
        ///     var formatedStr = Pascalify("user_id", '_');
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Pascalify(string str, params char[] separator)
        {
            String[] strArr = str.Split(separator);

            for (int i = 0, len = strArr.Length; i < len; i++)
            {
                strArr[i] = UpperStart(strArr[i]);
            }

            return String.Join("", strArr); 
        }

        /// <summary>
        /// 字符串首字母大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UpperStart(string str)
        {
            Char[] charArr = str.ToCharArray();

            if (Char.IsLower(charArr[0]))
            {
                charArr[0] = Char.ToUpper(charArr[0]);
            }

            return String.Join("", charArr);
        }
    }
}
