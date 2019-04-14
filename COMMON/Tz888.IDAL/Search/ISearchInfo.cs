using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.IDAL.Search
{
    public interface ISearchInfo
    {
        DataView InfoListDataBind(
          string MenuType,
          string LoginName,
          string Criteria,
          ref long CurrentPage,
          long PageRows,
          out long PageCount);

        DataView GetInfoListByRecycle(
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            );

        DataView GetInfoListBySelf(
            string Criteria,
            string loginName,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            );

        DataTable GetMainInfoTabList(string fields, string where, bool orderType, int pageSize, int pageCur, bool isJustCount);


        DataView GetInfoList(
            string SelectStr,
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            );

        DataView GetInfoList(
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            );

        DataView GetInfoFrontList2(
            string SelectCol,
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            );

        DataView GetInfoFrontList(
            string SelectCol,
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            );

        DataView GetRefreshList(
            string SelectCol,
            string Criteria,
            string Sort,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);

        DataView GetPointCount(long InfoID);

        #region-- 判断信息是否有效 ---------------
        int IsValidInfo(string loginName, string infoID);
        #endregion

        string getCommentNum(long InfoID);


        #region-- 评论信息列表 ---------------
        /// <summary>
        /// 评论信息列表
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>查询列表</returns>
        DataView InfoCommentList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);

        #endregion

        #region-- 代理商站点招商、投资、融资查询列表 ---------------
        /// <summary>
        /// 代理商站点招商、投资、融资查询列表
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>头条查询列表</returns>
        DataView GetAgentMCPList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);

        #endregion

        #region-- 网站精华查询列表 ---------------
        /// <summary>
        /// 网站精华查询列表
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>头条查询列表</returns>
        DataView GetWebTrendList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);
        #endregion


        #region 获得某条的信息,通过属性返回数据
        /// <summary>
        /// 获得某条的信息,通过属性返回数据
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        bool HasGetInfoItemForManage(long InfoID);
        #endregion

        Tz888.Model.Search.SearchInfo objGetSearchInfoByInfoID(long InfoID);


        #region 获取全部的信息列表“显示在网站前台”
        /// <summary>
        /// 获取全部的信息列表“显示在网站前台”
        /// </summary>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>返回全部的信息列表，查询记录的总页数</returns>
        DataView GetInfoListForFrontView(
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            );
        #endregion


        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>查询列表</returns>
        DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);


        /// <summary>
        /// 获取全部的信息列表
        /// </summary>
        /// <param name="mySql">连接数据库类</param>
        /// <param name="FNStrName">函数字符串</param>
        /// <param name="Key">关键字</param>
        /// <param name="SelectStr">选择列字符串</param>
        /// <param name="Criteria">查询条件</param>
        /// <param name="Sort">排序字符串</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">通过该查询条件，返回的查询记录的总页数</param>
        /// <returns>返回当前页的信息列表</returns>
        DataView GetList(
            string FNStrName,
            string Key,
            string SelectStr,
            string Criteria,
            string Sort,
            ref long CurrentPage,
            long PageSize,
            ref long TotalCount
            );

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        bool InsertKeyWord(string Keyword, string InfoTypeID);


        
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        bool InsertKeywordForMember(string Keyword, string InfoTypeID, string LoginName);

       
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>查询列表</returns>
        DataView GetListForMemberKeyword(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);



        #region  查询相关关键字列表

        DataView GetRelateKeyword(string Keyword, string InfoTypeID);
        #endregion

          /// <summary>
        /// 获取投资的查询结果列表
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="SortBy"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        DataView GetSearchResultCapital(
            string SelectCol,
            string Criteria,            
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            );

         /// <summary>
        /// 获取DataSet类型的投资查询结果列表
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        DataSet dsGetSearchResultCapital(
            string SelectCol,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            );

         /// <summary>
        /// 获取DataSet类型的融资查询结果列表
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        DataSet dsGetSearchResultProject(
            string SelectCol,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            );

        /// <summary>
        /// 获取DataSet类型的招商查询结果列表
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        DataSet dsGetSearchResultMerchant(
            string SelectCol,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            );
        ///<summary>
        ///获取DateSet类型的资讯查询结果列表
        ///</summary>
        ///<param name="SelectCol"></param>
        ///<param name="Criteria"></param>
        ///<param name="CurrentPage"></param>
        ///<param name="PageSize"></param>
        ///<param name="PageCount"></param>
        ///<returns></returns>
        DataTable  dsGetSearchResultNews(
            string SelectCol,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount //返回该查询有多少条记录
            );
    }
}
