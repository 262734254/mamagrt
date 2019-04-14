using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Search;
using System.Data;
using System.Data.SqlClient;

using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Search
{
    public class SearchInfoDAL:ISearchInfo 
    {
        #region 信息查询
        /// <summary>
        /// 信息查询
        /// </summary>
        /// <returns></returns>
        public virtual DataView InfoListDataBind(
            string MenuType,
            string LoginName,
            string Criteria,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            long lgPageCount = 0;
            PageCount = 0;
            DataView dv = new DataView(); ;
            
            return (dv);

        }
        #endregion


        #region 获取“信息回收”的所有类型的信息
        /// <summary>
        /// 获取“信息回收”的所有类型的信息：不需要继承
        /// </summary>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>返回“信息回收”的所有类型的信息，查询记录的总页数</returns>
        public virtual DataView GetInfoListByRecycle(
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            )
        {
            if (Criteria.Trim() != "")
            {
                Criteria = "(" + Criteria + " AND DelStatus=1)";
            }
            else
            {
                Criteria = "(DelStatus=1)";
            }
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSet(                
                "MainInfoTabList",
                "*",
                Criteria,
                "ApproveTime DESC, InfoID ASC",
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
        #endregion


        #region 获取某个具体的个人发布的信息“我的信息”
        /// <summary>
        /// 获取某个具体的个人发布的信息“我的信息”
        /// </summary>
        /// <param name="loginName">用户的登陆名</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>具体的个人发布的信息列表，查询记录的总页数</returns>
        public virtual DataView GetInfoListBySelf(
            string Criteria,
            string loginName,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            )
        {
            if (Criteria.Trim() != "")
            {
                Criteria = "(" + Criteria + " AND LoginName='" + loginName + "' AND DelStatus=0)";
            }
            else
            {
                Criteria = "(LoginName='" + loginName + "' AND DelStatus=0)";
            }
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSet(                
                "MainInfoTabList",
                "*",
                Criteria,
                "publishT DESC, InfoID ASC",
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
        #endregion


        /// <summary>
        ///  获取主表原始信息,以InfoID为排序字段 kevin 2007-07-17
        /// </summary>
        /// <param name="fields">要获取的列(当isJustCount=1时此参数无效)</param>
        /// <param name="where">条件</param>
        /// <param name="orderType">true为降序,false为升序(当isJustCount=1时此参数无效)</param>
        /// <param name="pageSize">每页大小(当isJustCount=1时此参数无效)</param>
        /// <param name="pageCur">当前页(当isJustCount=1时此参数无效)</param>
        /// <param name="isJustCount">true为计算总数,否则不计算</param>
        /// <returns></returns>
        public DataTable GetMainInfoTabList(string fields, string where, bool orderType, int pageSize, int pageCur, bool isJustCount)
        {
            SqlParameter[] parameters = {	
											new SqlParameter("@strGetFields",SqlDbType.VarChar,1000),
											new SqlParameter("@strWhere",SqlDbType.VarChar,2000),
											new SqlParameter("@OrderType",SqlDbType.Bit),
											new SqlParameter("@PageSize",SqlDbType.Int),
											new SqlParameter("@PageIndex",SqlDbType.Int),
											new SqlParameter("@doCount",SqlDbType.Bit)
										};
            parameters[0].Value = fields;
            parameters[1].Value = where;
            parameters[2].Value = orderType;
            parameters[3].Value = pageSize;
            parameters[4].Value = pageCur;
            parameters[5].Value = isJustCount;

            DataTable dt = null;

            try
            {

                dt = DbHelperSQL.RunProcedure("MainInfoTabSList", parameters,"ds").Tables[0];
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
             
            }
            return dt;

        }



        #region 获取全部的信息列表
        /// <summary>
        /// 获取全部的信息列表
        /// </summary>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>返回全部的信息列表，查询记录的总页数</returns>
        public virtual DataView GetInfoList(
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            )
        {
            if (Criteria.Trim() != "")
            {
                Criteria = "(" + Criteria + " AND DelStatus=0)";
            }
            else
            {
                Criteria = "(DelStatus=0)";
            }
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSet(                
                "MainInfoTabList",
                "*",
                Criteria,
                "ApproveTime DESC, InfoID ASC",
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }

        public virtual DataView GetInfoList(
              string SelectStr,
              string Criteria,
              ref long CurrentPage,
              long PageSize,
              ref long PageCount // 返回该查询有多少条记录
              )
        {
            if (Criteria.Trim() != "")
            {
                Criteria = "(" + Criteria + " AND DelStatus=0)";
            }
            else
            {
                Criteria = "(DelStatus=0)";
            }
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSet(
                "MainInfoTabList",
                SelectStr,
                Criteria,
                "publishT DESC, InfoID ASC",
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }

        #endregion


        /// <summary>
        /// 积分点数优化查询
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public virtual DataView GetInfoFrontList2(
            string SelectCol,
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            )
        {
            if (Criteria.Trim() != "")
            {
                Criteria = "(" + Criteria + " AND DelStatus=0)";
            }
            else
            {
                Criteria = "(DelStatus=0)";
            }
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSet(                
                "MainInfo_Front_Nlist",
                SelectCol,
                Criteria,
                "ApproveTime DESC, InfoID ASC",
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }






        /// <summary>
        /// 获取投资的查询结果列表
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public virtual DataView GetSearchResultCapital(
            string SelectCol,
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            )
        {
            
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSetForFirstTopNum(
                "CapitalInfo_List_NoIndex",
                SelectCol,
                Criteria,
                "MemberGradeID desc,InfoID asc ",
                ref CurrentPage,
                PageSize,
                0,
                ref PageCount));
        }



        /// <summary>
        /// 获取DataSet类型的投资查询结果列表
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public DataSet dsGetSearchResultCapital(
            string SelectCol,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            )
        {

            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.dsGetListSetForFirstTopNum(
                "CapitalInfo_List_NoIndex",
                SelectCol,
                Criteria,
                SortBy,
                ref CurrentPage,
                PageSize,
                0,
                ref PageCount));
        }

        /// <summary>
        /// 获取DataSet类型的融资查询结果列表
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public DataSet dsGetSearchResultProject(
            string SelectCol,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            )
        {

            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.dsGetListSetForFirstTopNum(
                "ProjectInfo_List_NoIndex",
                SelectCol,
                Criteria,
                SortBy,
                ref CurrentPage,
                PageSize,
                0,
                ref PageCount));
        }


        /// <summary>
        /// 获取DataSet类型的招商查询结果列表
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public DataSet dsGetSearchResultMerchant(
            string SelectCol,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            )
        {

            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.dsGetListSetForFirstTopNum(
                "MerchantInfo_List_NoIndex",
                SelectCol,
                Criteria,
                SortBy,
                ref CurrentPage,
                PageSize,
                0,
                ref PageCount));
        }

        /// <summary>
        /// 获取DataSet类型的资讯查询结果列表
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public DataTable  dsGetSearchResultNews(
            string SelectCol,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount
            )
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetDataTable(
                "NewsTabList",
                SelectCol,
                Criteria,
                SortBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }



        public virtual DataView GetInfoFrontList(
            string SelectCol,
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            )
        {
            if (Criteria.Trim() != "")
            {
                Criteria = "(" + Criteria + " AND DelStatus=0)";
            }
            else
            {
                Criteria = "(DelStatus=0)";
            }
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSet(                
                "MainInfoTab_FrontList",
                SelectCol,
                Criteria,
                "ApproveTime DESC, InfoID ASC",
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }

        public virtual DataView GetRefreshList(
            string SelectCol,
            string Criteria,
            string Sort,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSet(                
                "GetRefreshList",
                SelectCol,
                Criteria,
                "FrontDisplayTime DESC",
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }



        #region-- 获取信息查看的点数

        public DataView GetPointCount(
            long InfoID)
        {
            DataView dv = null;


            SqlParameter[] parameters = {	new SqlParameter("@InfoID",SqlDbType.BigInt)
										};
            parameters[0].Value = InfoID;

            try
            {
                DataTable dt = DbHelperSQL.RunProcedure("MainInfoTab_GetPointCount", parameters,"ds").Tables[0];
                dv = dt.DefaultView;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                 
            }

            return dv;

        }
        #endregion


        #region-- 判断信息是否有效 ---------------
        public int IsValidInfo(
            string loginName,
            string infoID
            )
        {
            int bl = 0;

            SqlParameter[] parameters = { 	
											new SqlParameter("@LoginName",SqlDbType.Char,16),			//--登录名
											new SqlParameter("@InfoID",SqlDbType.BigInt,8),				//--信息ID
											new SqlParameter("@RETURNVAL",SqlDbType.Int)
										};

            if (loginName.Trim() != "")
            {
                parameters[0].Value = loginName;
            }
            else
            {
                parameters[0].Value = System.DBNull.Value;
            }

            parameters[1].Value = infoID;
            parameters[2].Direction = ParameterDirection.ReturnValue;

            try
            {

                bl = DbHelperSQL.RunProcReturn("IsValidInfo", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                
            }
            return bl;
        }
        #endregion

        #region  评论次数

        public string getCommentNum(long InfoID)
        {                       
            string strsql = "select * from InfoCommentTab where InfoID=" + InfoID;
            int iRet = 0;
            iRet= DbHelperSQL.ExecuteSql(strsql);
            return iRet.ToString().Trim();
        }
        #endregion


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
        public DataView InfoCommentList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSet(                
                "InfoComment_list",
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
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
        public virtual DataView GetAgentMCPList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSet(                
                "AgentMCP_List",
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
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
        public virtual DataView GetWebTrendList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSet(
                "WebTrend_Front_List",
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
        #endregion


        #region 获得某条的信息,通过属性返回数据
        /// <summary>
        /// 获得某条的信息,通过属性返回数据
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        public virtual bool HasGetInfoItemForManage(long InfoID)
        {
            bool blRet = false;

            try
            {
                long PageCount = 0;
                long CurrentPage = 1;
                Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
                DataView dv = mCF.GetListSet(                    
                    "MainInfoTabList",
                    "*",
                    "(InfoID=" + InfoID.ToString() + ")",
                    "publishT DESC, InfoID ASC",
                    ref CurrentPage,
                    1,
                    ref PageCount);

                if (dv != null && dv.Count == 1)
                {
                    //Fill(dv);
                    blRet = true;
                }
            }
            catch (Exception err)
            {
                throw err;
            }

            return blRet;
        }

        public Tz888.Model.Search.SearchInfo objGetSearchInfoByInfoID(long InfoID)
        {
            Tz888.Model.Search.SearchInfo sI = new Tz888.Model.Search.SearchInfo();
            long PageCount = 0;
            long CurrentPage = 1;
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            DataView dv = mCF.GetListSet(
                "MainInfoTabList",
                "*",
                "(InfoID=" + InfoID.ToString() + ")",
                "publishT DESC, InfoID ASC",
                ref CurrentPage,
                1,
                ref PageCount);

            if (dv != null && dv.Count == 1)
            {
                sI.InfoID = Convert.ToInt64(dv[0]["InfoID"]);
                sI.Title = dv[0]["Title"].ToString().Trim();
                sI.InfoCode = dv[0]["InfoCode"].ToString().Trim();
                sI.PublishDate = Convert.ToDateTime(dv[0]["publishT"]);
                sI.Hit = Convert.ToInt64(dv[0]["Hit"]);
                sI.InfoTypeID = dv[0]["InfoTypeID"].ToString().Trim();
                sI.IsCore = Convert.ToBoolean(dv[0]["IsCore"]);
                sI.IndexOrderNum = Convert.ToInt64(dv[0]["IndexOrderNum"]);
                sI.IndexTopValidateDate = Convert.ToInt32(dv[0]["IndexTopValidateDate"]);
                sI.IndexPicInfoNum = Convert.ToInt64(dv[0]["IndexPicInfoNum"]);
                sI.IndexPicInfoNum = Convert.ToInt64(dv[0]["InfoTypeOrderNum"]);
                sI.InfoTypeTopValidateDate = Convert.ToInt32(dv[0]["InfoTypeTopValidateDate"]);
                sI.InfoTypePicInfoNum = Convert.ToInt64(dv[0]["InfoTypePicInfoNum"]);
                sI.LoginName = dv[0]["LoginName"].ToString().Trim();
                sI.InfoOriginRoleName = dv[0]["InfoOriginRoleName"].ToString().Trim();
                sI.GradeID = dv[0]["GradeID"].ToString().Trim();
                sI.GradeName = dv[0]["GradeName"].ToString().Trim();
                sI.FixPriceID = dv[0]["FixPriceID"].ToString().Trim();
                sI.FixPriceName = dv[0]["FixWorthPointName"].ToString().Trim();
                sI.FeeStatus = Convert.ToByte(dv[0]["FeeStatus"]);
                sI.AuditingStatus = Convert.ToByte(dv[0]["AuditingStatus"]);
                sI.DelStatus = Convert.ToByte(dv[0]["DelStatus"]);
                sI.ApproveBy = Convert.ToString(dv[0]["ApproveBy"]);

                sI.ContentKeyword = dv[0]["ContentKeyword"].ToString().Trim();
                sI.KeyWord = dv[0]["KeyWord"].ToString().Trim();
                sI.Descript = dv[0]["Descript"].ToString().Trim();
                sI.DisplayTitle = dv[0]["DisplayTitle"].ToString().Trim();
                sI.FrontDisplayTime = Convert.ToDateTime(dv[0]["FrontDisplayTime"].ToString().Trim());
                sI.ValidateStartTime = Convert.ToDateTime(dv[0]["ValidateStartTime"].ToString().Trim());
                sI.ValidateTerm = Convert.ToInt32(dv[0]["ValidateTerm"].ToString().Trim());
                if (sI.ValidateTerm == 0)
                {
                    sI.ValidateTerm = 12;
                }
                sI.TemplateID = dv[0]["TemplateID"].ToString().Trim();
                sI.HtmlFile = dv[0]["HtmlFile"].ToString().Trim();
                if (dv[0]["UserEvaluation"].ToString() == null || dv[0]["UserEvaluation"].ToString() == "")
                {
                    sI.UserEvaluation = 0;
                }
                else
                {
                    sI.UserEvaluation = Convert.ToInt32(dv[0]["UserEvaluation"]);
                }

                //新添加主表
                sI.IsIntegralInfo = Convert.ToInt16(dv[0]["IsIntegralInfo"]);
                sI.MainPointCoun = Convert.ToSingle(dv[0]["MainPointCount"]);
                sI.MainEvaluation = Convert.ToInt32(dv[0]["MainEvaluation"]);
            }
            return sI;
        }
        #endregion


        #region 获取全部的信息列表“显示在网站前台”
        /// <summary>
        /// 获取全部的信息列表“显示在网站前台”
        /// </summary>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>返回全部的信息列表，查询记录的总页数</returns>
        public virtual DataView GetInfoListForFrontView(
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // 返回该查询有多少条记录
            )
        {
            if (Criteria.Trim() != "")
            {
                Criteria = "(" + Criteria + " AND DelStatus=0 AND AuditingStatus=1)";
            }
            else
            {
                Criteria = "(DelStatus=0 AND AuditingStatus=1)";
            }
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSet(                
                "MainInfoTabList",
                "*",
                Criteria,
                "publishT DESC, InfoID ASC",
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
        #endregion


        #region-- 查询列表 ---------------
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
        public DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSet(                
                "MainInfoTabList",
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
        #endregion


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
        public DataView GetList(        
            string FNStrName,
            string Key,
            string SelectStr,
            string Criteria,
            string Sort,
            ref long CurrentPage,
            long PageSize,
            ref long TotalCount
            )
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return mCF.GetList(          
                FNStrName,
                Key,
                SelectStr,
                Criteria,
                Sort,
                ref  CurrentPage,
                PageSize,
                ref  TotalCount
                );
        }


        #region-- 添加关键字 -------------------
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public bool InsertKeyWord(string Keyword,string InfoTypeID)
        {
            bool blRet = false;

            SqlParameter[] parameters = {	new SqlParameter("@Keyword",SqlDbType.VarChar,50),
											new SqlParameter("@InfoTypeID",SqlDbType.Char,10)
										};

            parameters[0].Value = Keyword;
            parameters[1].Value = InfoTypeID;

            try
            {
               int iAffectRows = 0;
               DbHelperSQL.RunProcedure("SearchKeywordTab_insert", parameters,out iAffectRows);
               if (iAffectRows > 0)
               {
                   blRet = true;
               }
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                 
            }
            return (blRet);
        }
        #endregion


        #region-- 添加 -------------------
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public bool InsertKeywordForMember(string Keyword,string InfoTypeID,string LoginName)
        {
            bool blRet = false;

            SqlParameter[] parameters = {	new SqlParameter("@Keyword",SqlDbType.VarChar,50),
											new SqlParameter("@InfoTypeID",SqlDbType.Char,20),
											new SqlParameter("@LoginName",SqlDbType.Char,16)
										};

            parameters[0].Value = Keyword;
            parameters[1].Value = InfoTypeID;
            parameters[2].Value = LoginName;

            try
            {
                int iAffectRows = 0;
                DbHelperSQL.RunProcedure("KeywordForMemberTab_insert", parameters, out iAffectRows);
                if (iAffectRows > 0)
                {
                    blRet = true;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                
            }
            return (blRet);
        }
        #endregion

        #region-- 查询列表 ---------------
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
        public DataView GetListForMemberKeyword(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.GetListSet(                
                "KeywordForMemberTabList",
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
        #endregion


        #region  查询相关关键字列表

        public DataView GetRelateKeyword(string Keyword,string InfoTypeID)
        {

            DataTable dt = null;
         
            SqlParameter[] parameters = {	new SqlParameter("@Keyword",SqlDbType.VarChar,50),
												new SqlParameter("@InfoTypeID",SqlDbType.Char,10)
											};

            parameters[0].Value = Keyword;
            parameters[1].Value = InfoTypeID;

            try
            {
             
                dt = DbHelperSQL.RunProcedure("SearchKeywordTab_Relate", parameters,"dt").Tables[0];
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
               
            }
            return (dt.DefaultView);

        }

        #endregion      
    }
}
