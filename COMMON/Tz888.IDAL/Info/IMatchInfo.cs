using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    public interface IMatchInfo
    {
        /// <summary>
        /// 定制匹配列表
        /// </summary>
        /// <param name="MatchType">匹配类型</param>
        /// <param name="InfoID">匹配信息ID</param>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>查询列表</returns>
        DataView GetMatchList(
            string MatchType,
            long InfoID,
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long TotalCount);

        /// <summary>
        /// 统计信息匹配数目
        /// </summary> 
        /// <param name="strWhere"></param>
        /// <returns></returns>
        int GetCount(long InfoID, string MatchType, string Criteria);

        /// <summary>
        /// 获取某一用户的其他信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        DataView dvGetUserOtherInfo(string InfoID);

         #region 某一条信息有多少人关注
        /// <summary>
        /// 某一条信息有多少人收藏,同时更新用户的点击次数
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        DataView dvViewCollectCount(string InfoID);
        #endregion
    }
}
