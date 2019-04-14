using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Web;
using Tz888.IDAL;

namespace Tz888.DALFactory
{
	/// <summary>
	/// 缓存相关的操作类
	/// </summary>
	public class DataCache
	{
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey">缓存对象的关键字</param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {

            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey">缓存对象的关键字</param>
        /// <param name="objObject">需要缓存的对象</param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }
	}
}
