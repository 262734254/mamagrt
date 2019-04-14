using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.LoginInfo;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Login
{
    public class MemberBLL
    {
        private readonly IMember dal = DataAccess.CreateMember();
        /// <summary>
        /// 取得会员信息
        /// </summary>
        /// <returns></returns>
        public DataView GetMerberInfo(
            string strSelect,
            string strCriteria,
            string strSort, ref  
            long intCurrentPage,
            long intCurrentPageSize,
            ref long intTotalCount)
        {
            return dal.GetMerberInfo(
                 strSelect,
                 strCriteria,
                 strSort, 
                 ref intCurrentPage,
                 intCurrentPageSize,
                ref intTotalCount);
        }

        /// <summary>
        /// 设置会员刷新时间
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="IsRefresh"></param>
        /// <returns></returns>
        public bool RefreshMemberInfo(string LoginName, int IsRefresh)
        {
            return dal.RefreshMemberInfo(LoginName, IsRefresh);
        }

        #region 查询需要刷新的信息
        /// <summary>
        /// 查询需要刷新的信息
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="InfoTypeID"></param>
        /// <returns></returns>
        public DataView GetRefreshList(string LoginName, string InfoTypeID)
        {
            return dal.GetRefreshList(LoginName, InfoTypeID);
        }
        #endregion 
    }
}
