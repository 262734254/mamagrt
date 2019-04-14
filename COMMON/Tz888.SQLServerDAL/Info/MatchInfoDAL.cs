using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
 
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL.Info
{
    /// <summary>
    /// 信息匹配
    /// </summary>
    public class MatchInfoDAL : IDAL.Info.IMatchInfo
    {

        #region-- 定制匹配列表 [通用FUNCTION方式] ---------------
        /// <summary>
        /// 定制匹配列表
        /// </summary>
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
            DataView dv = null;
            string FunParm = "(" + InfoID.ToString() + ",'" + "2008-5-26" + "'," + TotalCount.ToString() + ")";
            Tz888.SQLServerDAL.Conn dal = new Tz888.SQLServerDAL.Conn();
            switch (MatchType)
            {
                //资本资源 对资本资源
                case "CC":
                    dv = dal.GetListFN(
                        "dbo.Capital_Capital_Ralation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref TotalCount).DefaultView;
                    break;
                    //资本资源对招商
                case "CM":
                    dv = dal.GetListFN(
                        "dbo.CAPITAL_MERCHNAT_RALATION" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref TotalCount).DefaultView;
                    break;
                    //资本对融资
                case "CP":
                    dv = dal.GetListFN(
                        "dbo.CAPITAL_PROJECT_RALATION" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref TotalCount).DefaultView;
                    break;
                    //融资对融资
                case "PP":
                    dv = dal.GetListFN(
                        "dbo.Project_Project_Ralation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref TotalCount).DefaultView;
                    break;
                    //融资对资本资源
                case "PC":
                    dv = dal.GetListFN(
                        "dbo.PROJECT_CAPITAL_RALATION" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref TotalCount).DefaultView;
                    break;
                    //融资对招商
                case "PM":
                    dv = dal.GetListFN(
                        "dbo.PROJECT_MERCHNAT_RALATION" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref TotalCount).DefaultView;
                    break;
                    //招商对招商
                case "MM":
                    dv = dal.GetListFN(
                        "dbo.Merchant_Merchant_Ralation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref TotalCount).DefaultView;
                    break;
                    //招商对融资
                case "MP":
                    dv = dal.GetListFN(
                        "dbo.MERCHNAT_PROJECT_RALATION" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref TotalCount).DefaultView;
                    break;
                    //招商对资本资源
                case "MC":
                    dv = dal.GetListFN(
                        "dbo.MERCHNAT_CAPITAL_RALATION" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref TotalCount).DefaultView;
                    break;
                default:
                    break;
            }

            return dv;

        }
        #endregion

        #region  统计信息匹配数目
        /// <summary>
        /// 统计信息匹配数目
        /// </summary> 
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(long InfoID, string MatchType, string Criteria)
        {
            Tz888.SQLServerDAL.Conn dal = new Tz888.SQLServerDAL.Conn();
            string FunParm = "(" + InfoID.ToString() + ",'" + DateTime.Now.ToString() + "',100)";

            int count = 0;
            switch (MatchType)
            {
                case "CC":
                    count = dal.GetCountFN(
                        "dbo.Capital_Capital_Ralation" + FunParm,
                        "InfoID",
                        Criteria);
                    break;
                case "CM":
                    count = dal.GetCountFN(
                        "dbo.CAPITAL_MERCHNAT_RALATION" + FunParm,
                        "InfoID",
                        Criteria);
                    break;
                case "CP":
                    count = dal.GetCountFN(
                        "dbo.CAPITAL_PROJECT_RALATION" + FunParm,
                        "InfoID",
                        Criteria);
                    break;
                case "PP":
                    count = dal.GetCountFN(
                        "dbo.Project_Project_Ralation" + FunParm,
                        "InfoID",
                        Criteria);
                    break;
                case "PC":
                    count = dal.GetCountFN(
                        "dbo.PROJECT_CAPITAL_RALATION" + FunParm,
                        "InfoID",
                        Criteria);
                    break;
                case "PM":
                    count = dal.GetCountFN(
                        "dbo.PROJECT_MERCHNAT_RALATION" + FunParm,
                        "InfoID",
                        Criteria);
                    break;
                case "MM":
                    count = dal.GetCountFN(
                        "dbo.Merchant_Merchant_Ralation" + FunParm,
                        "InfoID",
                        Criteria);
                    break;
                case "MP":
                    count = dal.GetCountFN(
                        "dbo.MERCHNAT_PROJECT_RALATION" + FunParm,
                        "InfoID",
                        Criteria);
                    break;
                case "MC":
                    count = dal.GetCountFN(
                        "dbo.MERCHNAT_CAPITAL_RALATION" + FunParm,
                        "InfoID",
                        Criteria);
                    break;
                default:
                    break;
            }
            return count;
        }
        #endregion

        #region 某一用户发布的信息
        /// <summary>
        /// 获取某一用户发布的其他信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public DataView dvGetUserOtherInfo(string InfoID)
        {        
            SqlParameter[] parameters = { new SqlParameter("@InfoID", SqlDbType.BigInt, 8) };
            parameters[0].Value = InfoID;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.RunProcedure("GetUseOtherResource", parameters, "ds");
            return ds.Tables[0].DefaultView;

        }
        #endregion

        #region 某一条信息有多少人收藏，同时更新hit次数
        /// <summary>
        /// 某一条信息有多少人关注,同时更新用户的点击次数
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public DataView dvViewCollectCount(string InfoID)
        {
            SqlParameter[] parameters = { new SqlParameter("@InfoID", SqlDbType.BigInt, 8) };
            parameters[0].Value = InfoID;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.RunProcedure("ViewCollectCount", parameters, "ds");
            return ds.Tables[0].DefaultView;

        }
        #endregion
    }
}
