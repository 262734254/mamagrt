using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.IDAL.LoginInfo;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.LoginInfo  
{
    public class Member : IMember
    {
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
            Tz888.SQLServerDAL.Conn dal = new Conn();

            DataTable dt = dal.GetList("MemberInfoVIW",
                        "loginID",
                        strSelect,
                        strCriteria,
                        strSort,
                        ref intCurrentPage,
                        intCurrentPageSize,
                        ref intTotalCount);
            if (dt == null)
                return null;
            return dt.DefaultView;
              
        }

        /// <summary>
        /// 设置会员刷新时间
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="IsRefresh"></param>
        /// <returns></returns>
        public bool RefreshMemberInfo(string LoginName, int IsRefresh)
        {
            int rowsAffected;
            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char,16),				//登录名
											new SqlParameter("@IsRefresh",SqlDbType.Int,4)					//刷新时间 
										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = LoginName;
            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = IsRefresh;

            DbHelperSQL.RunProcedure("MemberRefresh_Update", parameters, out rowsAffected);

            if (rowsAffected > 0)
                return true;
            return false;
        }

        #region 获得需要刷新的信息列表
        /// <summary>
        /// 获得需要刷新的信息列表
        /// </summary>
        /// <param name="InfoTypeID">信息类型</param>
        /// <param name="LoginName">发布人</param>
        /// <returns>返回信息列表</returns>
        public DataView GetRefreshList(string LoginName, string InfoTypeID)
        {

            SqlParameter[] parameters = {	
											new SqlParameter("@LoginName",SqlDbType.Char),
											new SqlParameter("@InfoTypeID",SqlDbType.VarChar)
										};

            parameters[0].Value = LoginName;
            parameters[1].Value = InfoTypeID;

            DataSet ds = DbHelperSQL.RunProcedure("GET_RESOURE_REFRESH_LIST", parameters, "ds");
            try
            {
                return ds.Tables["ds"].DefaultView;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
