﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Bermuda.Common
{
    public class BaseUtil
    {
        /// <summary>
        /// 转换含 ViewModel 类型字段的对象
        /// </summary>
        /// <typeparam name="R">结果类型</typeparam>
        /// <typeparam name="T">字段类型</typeparam>
        /// <param name="entity"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public static R DeepParseTo<R, T>(object entity, object propObject)
            where R : class, new()
            where T : class, new()
        {
            if (entity == null)
                return null;

            PropertyInfo[] vmProps = typeof(R).GetProperties();
            Hashtable mapEntries = GetEntriesMap(entity);
            R vm = new R();

            foreach (var prop in vmProps)
            {
                if (prop.PropertyType.Name.Equals(
                    typeof(T).Name, StringComparison.OrdinalIgnoreCase))
                {
                    prop.SetValue(vm, ParseTo<T>(propObject));
                }
                else
                {
                    string field = Pascalify(prop.Name, '_');
                    prop.SetValue(vm, mapEntries[field]);
                }
            }

            return vm;
        }

        /// <summary>
        /// 实体列表转化成 ViewModel 列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static IList<T> ParseToList<T>(IEnumerable entities) where T : class, new()
        {
            // if entities without items
            if (!entities.GetEnumerator().MoveNext())
                return null;

            IList<T> vmlist = new List<T>();

            foreach (var entity in entities)
            {
                vmlist.Add(ParseTo<T>(entity));
            }

            return vmlist;
        }

        /// <summary>
        /// 将实体对象转化成 ViewModel 对象
        /// ViewModel 对象的属性部分对应实体属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static T ParseTo<T>(object entity) where T : class, new()
        {
            if (entity == null)
                return null;

            PropertyInfo[] vmProps = typeof(T).GetProperties();
            Hashtable mapEntries = GetEntriesMap(entity);
            T vm = new T();

            foreach (var prop in vmProps)
            {
                string field = Pascalify(prop.Name, '_');
                prop.SetValue(vm, mapEntries[field]);
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

        /// <summary>
        /// 当前时间的时间戳（13位）
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Int64 GetCurrentTimeStamp()
        {
            Int64 stamp = (DateTime.Now.Ticks - 
                TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0)).Ticks) / 10000;
            return stamp;
        }
    }
}
