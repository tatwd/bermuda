using System;
using System.Web;
using System.Web.Caching;

namespace Bermuda.Api.DataCache
{
    public class CacheEngine
    {
        private static Cache dataCache = new Cache();

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T GetData<T>(string key, Func<T> func)
        {
            if(dataCache[key] == null)
            {
                T t = func();

                // 滑动过期时间缓存，10s 没用缓存就过期
                dataCache.Insert(key, t, null, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(10));
            }
            return (T)dataCache[key];
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        public static void ClearCache()
        {
            var dict = dataCache.GetEnumerator();
            for (int i = 0, len = dataCache.Count; i < len; i++)
            {
                dict.MoveNext();
                dataCache.Remove(dict.Entry.Key.ToString());
            }
        }

    }
}
