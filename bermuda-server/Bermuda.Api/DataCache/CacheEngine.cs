using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Bermuda.Api.DataCache
{
    public class CacheEngine
    {
        private static Cache dataCache = new Cache();

        public static T GetData<T>(string key, Func<T> func)
        {
            if(dataCache[key] == null)
            {
                T t = func();
                dataCache.Insert(key, t);
            }
            return (T)dataCache[key];
        }
    }
}
