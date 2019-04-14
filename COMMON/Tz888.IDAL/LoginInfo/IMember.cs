using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.LoginInfo
{
    public interface IMember
    {
        /// <summary>
        /// 取得会员信息
        /// </summary>
        /// <returns></returns>
        DataView GetMerberInfo(
            string strSelect,
            string strCriteria,
            string strSort, ref  
            long intCurrentPage,
            long intCurrentPageSize,
            ref long intTotalCount);

        /// <summary>
        /// 设置会员刷新时间
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="IsRefresh"></param>
        /// <returns></returns>
        bool RefreshMemberInfo(string LoginName, int IsRefresh);


        /// <summary>
        /// 获得需要刷新的信息列表
        /// </summary>
        /// <param name="InfoTypeID">信息类型</param>
        /// <param name="LoginName">发布人</param>
        /// <returns>返回信息列表</returns>
        DataView GetRefreshList(string LoginName, string InfoTypeID);
    }
}
