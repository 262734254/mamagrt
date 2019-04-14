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
	/// ������صĲ�����
	/// </summary>
	public class DataCache
	{
        /// <summary>
        /// ��ȡ��ǰӦ�ó���ָ��CacheKey��Cacheֵ
        /// </summary>
        /// <param name="CacheKey">�������Ĺؼ���</param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {

            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// ���õ�ǰӦ�ó���ָ��CacheKey��Cacheֵ
        /// </summary>
        /// <param name="CacheKey">�������Ĺؼ���</param>
        /// <param name="objObject">��Ҫ����Ķ���</param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }
	}
}
