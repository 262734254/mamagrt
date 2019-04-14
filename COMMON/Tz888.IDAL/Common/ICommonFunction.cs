using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
 

namespace Tz888.IDAL.Common
{
    public interface ICommonFunction
    {
        /// <summary>
        /// 获取全部的信息列表
        /// </summary>        
        /// <param name="FNStrName">函数字符串</param>
        /// <param name="Key">关键字</param>
        /// <param name="SelectStr">选择列字符串</param>
        /// <param name="Criteria">查询条件</param>
        /// <param name="Sort">排序字符串</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">通过该查询条件，返回的查询记录的总页数</param>
        /// <returns>返回当前页的信息列表</returns>
        DataView GetList(string FNStrName, string Key, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount);

        /// <summary>
        /// 获取全部的信息列表
        /// </summary>       
        /// <param name="SPName">存储过程的名字</param>
        /// <param name="SelectStr">选择列字符串</param>
        /// <param name="Criteria">查询条件</param>
        /// <param name="Sort">排序字符串</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">通过该查询条件，返回的查询记录的总页数</param>
        /// <returns>返回当前页的信息列表</returns>
        DataView GetListSet(string SPName, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount);

         /// 
        /// <summary>
        /// 获取带有置顶数的查询结果列表
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="FristTopNum"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>

        DataView GetListSetForFirstTopNum(string SPName, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, int FristTopNum, ref long TotalCount);


        /// <summary>
        /// 获取全部的信息列表
        /// </summary>       
        /// <param name="SPName">存储过程的名字</param>
        /// <param name="SelectStr">选择列字符串</param>
        /// <param name="Criteria">查询条件</param>
        /// <param name="Sort">排序字符串</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">通过该查询条件，返回的查询记录的总页数</param>
        /// <returns>返回当前页的信息列表</returns>
        DataTable GetDataTable(string SPName, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount);
        
 

         /// <summary>
        /// 
        /// </summary>
        /// <param name="TableViewName">表名</param>
        /// <param name="Key">主键</param>
        /// <param name="SelectStr">查询字段</param>
        /// <param name="Criteria">条件</param>
        /// <param name="Sort">排序字段</param>
        /// <param name="CurrentPage">当前页</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">总记录</param>
        /// <returns></returns>
        DataTable GetDTFromTableOrView(string TableViewName, string Key, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount);


        /// <summary>
        /// 获取带有置顶数的查询结果列表
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="FristTopNum"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>

        DataSet dsGetTopFirstNumContactBySP(string SPName,string InfoID);



    }     
}
