using System;
using System.Web;
using System.Web.Caching;


    public class AppCache
    {
        public static Cache _cache;
        private AppCache() { }

        public static bool IsExist(string key)
        {
            _cache = HttpContext.Current.Cache;
            if (_cache[key] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Add(string key, object obj)
        {
            _cache.Add(key, obj, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        public static void Add(string key, object obj, string file)
        {
            _cache.Add(key, obj, new CacheDependency(file), Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        public static void Remove(string key)
        {
            _cache.Remove(key);
        }

        public static object Get(string key)
        {
            return _cache[key];
        }
        /// <summary>
        /// 加时间限制的cache 6 hours
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="obj">值,对象类型</param>
        public static void AddCache(string key, object obj)
        {
            //_cache.Add(key, obj, null, DateTime.Now.AddHours(6), TimeSpan.Zero, CacheItemPriority.High, null);
            _cache.Add(key, obj, null, DateTime.Now.AddSeconds(1), TimeSpan.Zero, CacheItemPriority.High, null);
        }
        /// <summary>
        /// 加时间限制的cache，单位小时

        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="hours"></param>
        public static void AddCache(string key, object obj, int hours)
        {
           // _cache.Add(key, obj, null, DateTime.Now.AddHours(hours), TimeSpan.Zero, CacheItemPriority.High, null);
            _cache.Add(key, obj, null, DateTime.Now.AddSeconds(1), TimeSpan.Zero, CacheItemPriority.High, null);
        }
    }