using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.IDAL.Info;
using Tz888.DALFactory;

namespace Tz888.BLL.Info
{
    public class MatchInfoBLL
    {
        private readonly IMatchInfo dal = DataAccess.CreateMatchInfo();

        #region 定制匹配列表
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
        public DataView GetMatchList(
            string MatchType,
            long InfoID,
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long TotalCount)
        {
            return dal.GetMatchList(MatchType, InfoID, SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref TotalCount);
        }
        #endregion

        #region 统计信息匹配数目
        /// <summary>
        /// 统计信息匹配数目
        /// </summary> 
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(long InfoID, string MatchType, string Criteria)
        {
            return dal.GetCount(InfoID, MatchType, Criteria);
        }
        #endregion

        #region 获取某一用户发布的其他信息
        /// <summary>
        /// 获取某一用户发布的其他信息
        /// </summary>        
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public DataView dvGetOtherInfoOfUser(string InfoID)
        {
            return dal.dvGetUserOtherInfo(InfoID);
        }
        #endregion

        #region
        /// <summary>
       /// 某一条信息有多少人收藏，同时更新hit次数
       /// </summary>
       /// <param name="InfoID"></param>
       /// <returns></returns>
        public DataView dvViewCollectionCount(string InfoID)
        {
            return dal.dvViewCollectCount(InfoID);
        }
        #endregion


    }
}
