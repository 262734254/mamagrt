using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL.Search;


namespace Tz888.BLL.Search
{
    public class SearchInfo
    {
        private readonly ISearchInfo dal = DataAccess.CreateISearchInfo();

        public const string AuditingStatus_UnApprove = "待审";
        public const string AuditingStatus_Approve = "已审";
        public const string AuditingStatus_UndoApprove = "审核未通过";


        #region 构造函数
        public SearchInfo()
        {

        }
        #endregion




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
            DataView dv;
            switch (MenuType)
            {
                case "Callback":
                    dv = dal.GetInfoListByRecycle(
                        Criteria,
                        ref CurrentPage,
                        PageRows,
                        ref lgPageCount);
                    break;

                case "MyPub":
                    dv = dal.GetInfoListBySelf(
                        Criteria,
                        LoginName,
                        ref CurrentPage,
                        PageRows,
                        ref lgPageCount);
                    break;

                default:
                    dv = null;
                    break;
            }

            if (!dv.Table.Columns.Contains("TitleDesc"))
            {
                dv.Table.Columns.Add("TitleDesc", typeof(string));
            }
            if (!dv.Table.Columns.Contains("AuditingStatusDesc"))
            {
                dv.Table.Columns.Add("AuditingStatusDesc", typeof(string));
            }

            for (int i = 0; i < dv.Count; i++)
            {
                dv[i]["TitleDesc"] = "[" + dv[i]["InfoTypeName"].ToString().Trim() +
                    "]" + dv[i]["Title"].ToString().Trim();

                switch (Convert.ToByte(dv[i]["AuditingStatus"]))
                {
                    case 0:
                        dv[i]["AuditingStatusDesc"] = "待审";
                        break;

                    case 1:
                        dv[i]["AuditingStatusDesc"] = "已审";
                        break;

                    case 2:
                    default:
                        dv[i]["AuditingStatusDesc"] = "审核未通过";
                        break;
                }
            }

            PageCount = lgPageCount;

            return (dv);

        }
        #endregion






        #region 信息排序 HasOrderBy
        /// <summary>
        /// 信息排序
        /// </summary>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        public virtual bool HasOrderBy()
        {
            //Invest.DataClass.Information Theifm = new Invest.DataClass.Information();
            //Theifm.InfoID = InfoID;
            //Theifm.IndexOrderNum = IndexOrderNum;
            //Theifm.IndexTopValidateDate = IndexTopValidateDate;
            //Theifm.IndexPicInfoNum = IndexPicInfoNum;
            //Theifm.InfoTypeOrderNum = InfoTypeOrderNum;
            //Theifm.InfoTypeTopValidateDate = InfoTypeTopValidateDate;
            //Theifm.InfoTypePicInfoNum = InfoTypePicInfoNum;
            //Theifm.LoginName = LoginName;
            //return( Theifm.HasOrderBy() );
            return false;
        }
        #endregion



        #region 查询信息类型编码
        /// <summary>
        /// 查询信息类型类别编码
        /// </summary>
        /// <param name="InfoTypeID">信息类型编号</param>		
        /// <returns>信息类型类别编码</returns>
        private string GetInfoTypeCode(string InfoTypeID)
        {
            //string ReturnValue = "";
            //try
            //{
            //    long CurrentPage = 1;
            //    long PageCount = 0;

            //    Invest.DataClass.SysSet.SetInfoType obj = new Invest.DataClass.SysSet.SetInfoType();	
            //    DataView dv =obj.GetList(
            //        "InfoCode",
            //        "(InfoTypeID='" + InfoTypeID + "')",
            //        "InfoTypeID ASC",
            //        ref CurrentPage,
            //        -1,
            //        ref PageCount);

            //    if( dv != null && dv.Count == 1 )
            //    {
            //        ReturnValue = dv[0][0].ToString().Trim();
            //    }
            //    else
            //    {
            //        throw new Exception( "查询出错!" );
            //    }
            //}
            //catch(Exception err)
            //{
            //    throw err;
            //}

            //return ReturnValue;
            return "";
        }
        #endregion

        #region 匹配信息查询
        /// <summary>
        /// 匹配信息查询
        /// </summary>
        /// <returns></returns>
        public virtual DataView MatchInfoListDataBind(
            string MatchType,
            long InfoID,
            string SelectCol,
            string Criteria,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            long lgPageCount = 0;

            DataView dv;
            dv = GetMatchList(
                MatchType,
                InfoID,
                SelectCol,
                Criteria,
                "degree, frontDisplayTime desc",
                ref CurrentPage,
                PageRows,
                ref lgPageCount);

            PageCount = lgPageCount;

            return (dv);

        }
        #endregion

        #region 代理商信息查询
        /// <summary>
        /// 代理商信息查询
        /// </summary>
        /// <returns></returns>
        public virtual DataView AgentInfoListDataBind(
            string MenuType,
            string LoginName,
            string Criteria,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            long lgPageCount = 0;

            DataView dv;
            string SelectCol = "*";
            string OrderBy = "publishT DESC, InfoID ASC";
            switch (MenuType)
            {
                case "View":
                    dv = dal.GetList(
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageRows,
                        ref lgPageCount);
                    break;

                case "PublishView":
                    dv = dal.GetList(
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageRows,
                        ref lgPageCount);
                    break;

                default:
                    dv = null;
                    break;
            }

            if (!dv.Table.Columns.Contains("TitleDesc"))
            {
                dv.Table.Columns.Add("TitleDesc", typeof(string));
            }
            if (!dv.Table.Columns.Contains("AuditingStatusDesc"))
            {
                dv.Table.Columns.Add("AuditingStatusDesc", typeof(string));
            }

            for (int i = 0; i < dv.Count; i++)
            {
                dv[i]["TitleDesc"] = "[" + dv[i]["InfoTypeName"].ToString().Trim() +
                    "]" + dv[i]["Title"].ToString().Trim();

                switch (Convert.ToByte(dv[i]["AuditingStatus"]))
                {
                    case 0:
                        dv[i]["AuditingStatusDesc"] = "待审";
                        break;

                    case 1:
                        dv[i]["AuditingStatusDesc"] = "已审";
                        break;

                    case 2:
                    default:
                        dv[i]["AuditingStatusDesc"] = "审核未通过";
                        break;
                }
            }

            PageCount = lgPageCount;

            return (dv);

        }
        #endregion

        #region 信息查询
        /// <summary>
        /// 信息查询-为前台显示列表
        /// </summary>
        /// <returns></returns>
        public virtual DataView InfoForFrontStageList(
            string SelectType, //查询类型
            string Criteria,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            long lgPageCount = 0;

            DataView dv = null;
            switch (SelectType)
            {
                case "InfoLatest": //查询最新的信息
                    dv = dal.GetInfoListForFrontView(
                        Criteria,
                        ref CurrentPage,
                        PageRows,
                        ref lgPageCount);
                    break;
                default:
                    break;
            }
            PageCount = lgPageCount;

            return (dv);

        }
        #endregion

        #region 查询某条信息的主表信息
        public bool HasGetInfoItemForManage(long InfoID)
        {

            bool HasGet = dal.HasGetInfoItemForManage(InfoID);
            //主信息

            return HasGet;
        }
        #endregion

        #region 查询某条信息的主表信息
        public Tz888.Model.Search.SearchInfo objGetSearchInfoByInfoID(long InfoID)
        {
            Tz888.Model.Search.SearchInfo sI = new Tz888.Model.Search.SearchInfo();
            sI = dal.objGetSearchInfoByInfoID(InfoID);
            return sI;
        }
        #endregion

        #region 前台信息查询(会员管理中使用)
        /// <summary>
        /// 前台信息查询-为前台显示列表(会员管理中使用)
        /// </summary>
        /// <returns></returns>
        public virtual DataView GetFrontList(
            string Criteria,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            if (Criteria != "")
            {
                Criteria = Criteria + " AND AuditingStatus=1";
            }
            else
            {
                Criteria = "AuditingStatus=1";
            }

            long lgPageCount = 0;


            DataView dv = dal.GetList(
                        "*",
                        Criteria,
                        "publishT DESC, InfoID ASC",
                        ref CurrentPage,
                        PageRows,
                        ref lgPageCount);

            PageCount = lgPageCount;

            return (dv);
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
        public DataView GetWebTrendList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {

            return (dal.GetWebTrendList(
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
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
            return dal.InfoCommentList(SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref PageCount);
        }
        #endregion


        #region 评论次数

        public string getCommentNum(long InfoId)
        {
            string num = dal.getCommentNum(InfoId);
            return num;
        }
        #endregion


        #region-- 判断信息是否有效 ---------------
        public bool IsValidInfo(
            string loginName,//登录名
            string infoID  //信息ID
            )
        {
            bool bl = false;
            int returnVal;
            returnVal = dal.IsValidInfo(loginName, infoID);
            switch (returnVal)
            {
                case 0:
                    throw new Exception("此信息需要会员登录后才能查看!");

                case 1:
                    bl = true;//可以查看
                    break;
                case 2:
                    throw new Exception("此信息是核心信息,若要获取该信息详细资料，请申请精准匹配服务!");

                case 3:
                    throw new Exception("此信息的联系方式需要付费才能查看!");

                default:
                    bl = true;
                    break;
            }
            return bl;
        }
        #endregion



        #region　获取信息查看的点数
        public DataView GetPointCount(
            long InfoID)
        {

            return (dal.GetPointCount(InfoID));
        }
        #endregion



        #region 信息查询
        public virtual DataView GetInfoFrontList(
            string SelectStr,
            string Criteria,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            long lgPageCount = 0;

            DataView dv;

            dv = dal.GetInfoFrontList(
                SelectStr,
                Criteria,
                ref CurrentPage,
                PageRows,
                ref lgPageCount);

            PageCount = lgPageCount;
            return (dv);

        }
        #endregion

        #region 信息查询
        public virtual DataView GetInfoFrontList2(
            string SelectStr,
            string Criteria,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            long lgPageCount = 0;

            DataView dv;

            dv = dal.GetInfoFrontList2(
                SelectStr,
                Criteria,
                ref CurrentPage,
                PageRows,
                ref lgPageCount);

            PageCount = lgPageCount;
            return (dv);

        }
        #endregion

        #region 信息查询
        public virtual DataView GetInfoList(
            string SelectStr,
            string Criteria,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            long lgPageCount = 0;

            DataView dv;

            dv = dal.GetInfoList(
                SelectStr,
                Criteria,
                ref CurrentPage,
                PageRows,
                ref lgPageCount);

            PageCount = lgPageCount;
            return (dv);

        }
        #endregion


        #region 信息查询
        /// <summary>
        /// 获取的投资的查询结果列表
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageRows"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public virtual DataView GetSearchResultCapital(
            string SelectStr,
            string Criteria,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            long lgPageCount = 0;

            DataView dv;

            dv = dal.GetSearchResultCapital(
                SelectStr,
                Criteria,
                ref CurrentPage,
                PageRows,
                ref lgPageCount);

            PageCount = lgPageCount;
            return (dv);

        }
        #endregion




        #region 信息查询

        /// <summary>
        /// 获取的DataSet类型的投资查询结果列表
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageRows"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public DataSet dsGetSearchResultCapital(
            string SelectStr,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            long lgPageCount = 0;

            DataSet ds;

            ds = dal.dsGetSearchResultCapital(
                SelectStr,
                Criteria,
                SortBy,
                ref CurrentPage,
                PageRows,
                ref lgPageCount);

            PageCount = lgPageCount;
            return (ds);

        }


        /// <summary>
        /// 获取的DataSet类型的投资查询结果列表
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageRows"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public DataSet dsGetSearchResultProject(
            string SelectStr,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            long lgPageCount = 0;

            DataSet ds;

            ds = dal.dsGetSearchResultProject(
                SelectStr,
                Criteria,
                SortBy,
                ref CurrentPage,
                PageRows,
                ref lgPageCount);

            PageCount = lgPageCount;
            return (ds);

        }


        /// <summary>
        /// 获取的DataSet类型的投资查询结果列表
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageRows"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public DataSet dsGetSearchResultMerchant(
            string SelectStr,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            long lgPageCount = 0;

            DataSet ds;

            ds = dal.dsGetSearchResultMerchant(
                SelectStr,
                Criteria,
                SortBy,
                ref CurrentPage,
                PageRows,
                ref lgPageCount);

            PageCount = lgPageCount;
            return (ds);

        }


        ///<summary>
        /// 获取的DataSet类型的资讯查询结果列表
        ///</summary>
        ///<param name="SelectStr"></param>
        ///<param name="Criteria"></param>
        ///<param name="CurrentPage"></param>
        ///<param name="PageRows"></param>
        ///<param name="PageCount"></param>
        ///<returns></returns>
        public DataTable dsGetSearchResultNews(
            string SelectStr,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageRows,
            out long PageCount
            )
        {
            long lgPageCount = 0;

            DataTable  dt;
            dt = dal.dsGetSearchResultNews(
                SelectStr,
                Criteria,
                SortBy,
                ref CurrentPage,
                PageRows,
                ref lgPageCount);
            PageCount = lgPageCount;
            return (dt);
        }

        #endregion











        /// <summary>
        ///  获取主表原始信息,以InfoID为排序字段 kevin 2007-07-17
        /// </summary>
        /// <param name="fields">要获取的列(当isJustCount=1时此参数无效)</param>
        /// <param name="where">条件</param>bbb
        /// <param name="orderType">true为降序,false为升序(当isJustCount=1时此参数无效)</param>
        /// <param name="pageSize">每页大小(当isJustCount=1时此参数无效)</param>
        /// <param name="pageCur">当前页(当isJustCount=1时此参数无效)</param>
        /// <param name="isJustCount">true为计算总数,否则不计算</param>
        /// <returns></returns>
        public DataTable GetMainInfoTabList(string fields, string where, bool orderType, int pageSize, int pageCur, bool isJustCount)
        {

            return dal.GetMainInfoTabList(fields, where, orderType, pageSize, pageCur, isJustCount);
        }





        #region-- 定制匹配列表 [通用FUNCTION方式] ---------------
        /// <summary>
        /// 定制匹配列表
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>查询列表</returns>
        public virtual DataView GetMatchList(
            string MatchType,
            long InfoID,
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            DataView dv = null;
            string FunParm = "(" + InfoID.ToString() + ",'" + DateTime.Now.ToString() + "')";

            switch (MatchType)
            {
                case "CC":
                    dv = dal.GetList(
                        "dbo.CapitalCapitalRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "CM":
                    dv = dal.GetList(
                        "dbo.CapitalMerchantRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;
                case "CP":
                    dv = dal.GetList(
                        "dbo.CapitalProjectRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "CI":
                    dv = dal.GetList(
                        "dbo.CapitalNewsRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "CT":
                    dv = dal.GetList(
                        "dbo.CapitalTechnologyRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "MM":
                    dv = dal.GetList(
                        "dbo.MerchantMerchantRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "MC":
                    dv = dal.GetList(
                        "dbo.MerchantCapitalRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "MP":
                    dv = dal.GetList(
                        "dbo.MerchantProjectRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;
                case "MI":
                    dv = dal.GetList(
                        "dbo.MerchantNewsRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "MT":
                    dv = dal.GetList(
                        "dbo.MerchantTechnologyRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "PP":
                    dv = dal.GetList(
                        "dbo.ProjectProjectRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "PM":
                    dv = dal.GetList(
                        "dbo.ProjectMerchantRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;
                case "PC":
                    dv = dal.GetList(
                        "dbo.ProjectCapitalRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);

                    break;
                case "PI":
                    dv = dal.GetList(
                        "dbo.ProjectNewsRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);

                    break;

                case "PT":
                    dv = dal.GetList(
                        "dbo.ProjectTechnologyRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);

                    break;

                case "IP":
                    dv = dal.GetList(
                        "dbo.NewsProjectRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);

                    break;

                case "IC":
                    dv = dal.GetList(
                        "dbo.NewsCapitalRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);

                    break;

                case "IM":
                    dv = dal.GetList(
                        "dbo.NewsMerchantRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "IT":
                    dv = dal.GetList(
                        "dbo.NewsTechnologyRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "II":
                    dv = dal.GetList(
                        "dbo.NewsNewsRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "TP":
                    dv = dal.GetList(
                        "dbo.TechnologyProjectRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "TC":
                    dv = dal.GetList(
                        "dbo.TechnologyCapitalRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "TM":
                    dv = dal.GetList(
                        "dbo.TechnologyMerchantRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "TI":
                    dv = dal.GetList(
                        "dbo.TechnologyNewsRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "TT":
                    dv = dal.GetList(

                        "dbo.TechnologyTechnologyRalation" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;
                case "CCM":
                    dv = dal.GetList(
                        "dbo.CapitalCapitalRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "CMM":
                    dv = dal.GetList(
                        "dbo.CapitalMerchantRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;
                case "CPM":
                    dv = dal.GetList(
                        "dbo.CapitalProjectRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "CIM":
                    dv = dal.GetList(
                        "dbo.CapitalNewsRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "CTM":
                    dv = dal.GetList(
                        "dbo.CapitalTechnologyRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "MMM":
                    dv = dal.GetList(
                        "dbo.MerchantMerchantRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "MCM":
                    dv = dal.GetList(
                        "dbo.MerchantCapitalRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "MPM":
                    dv = dal.GetList(
                        "dbo.MerchantProjectRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;
                case "MIM":
                    dv = dal.GetList(
                        "dbo.MerchantNewsRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "MTM":
                    dv = dal.GetList(
                        "dbo.MerchantTechnologyRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "PPM":
                    dv = dal.GetList(
                        "dbo.ProjectProjectRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "PMM":
                    dv = dal.GetList(
                        "dbo.ProjectMerchantRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;
                case "PCM":
                    dv = dal.GetList(
                        "dbo.ProjectCapitalRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);

                    break;
                case "PIM":
                    dv = dal.GetList(
                        "dbo.ProjectNewsRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);

                    break;

                case "PTM":
                    dv = dal.GetList(
                        "dbo.ProjectTechnologyRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);

                    break;

                case "IPM":
                    dv = dal.GetList(
                        "dbo.NewsProjectRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);

                    break;

                case "ICM":
                    dv = dal.GetList(
                        "dbo.NewsCapitalRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);

                    break;

                case "IMM":
                    dv = dal.GetList(
                        "dbo.NewsMerchantRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "ITM":
                    dv = dal.GetList(
                        "dbo.NewsTechnologyRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "IIM":
                    dv = dal.GetList(
                        "dbo.NewsNewsRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "TPM":
                    dv = dal.GetList(
                        "dbo.TechnologyProjectRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "TCM":
                    dv = dal.GetList(
                        "dbo.TechnologyCapitalRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "TMM":
                    dv = dal.GetList(
                        "dbo.TechnologyMerchantRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "TIM":
                    dv = dal.GetList(
                        "dbo.TechnologyNewsRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                case "TTM":
                    dv = dal.GetList(
                        "dbo.TechnologyTechnologyRalation_More" + FunParm,
                        "InfoID",
                        SelectCol,
                        Criteria,
                        OrderBy,
                        ref CurrentPage,
                        PageSize,
                        ref PageCount);
                    break;

                default:
                    break;
            }

            return dv;

        }
        #endregion

        #region-- 添加查询的关键字 -------------------
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public bool InsertKeyword(string mstrKeyword, string mstrInfoTypeID)
        {
            bool blRet = false;

            //根据判断，如果输入的关键词的长度过于长，将不进入用户键入关键词搜集
            int KeywordLengthRequest = 20;

            if (KeywordLengthRequest < mstrKeyword.Length
                || mstrKeyword.Length == 0)
            {
                //超过限制时，就不添加进入用户关键词表
                return (blRet);
            }

            //string[] KeyWords = mstrKeyword.Trim().Split(' ');
            //for (int i = 0; i < KeyWords.Length; i++)
            //{
            //    blRet = dal.InsertKeyWord(KeyWords[i].Trim(), mstrInfoTypeID);
            //}
            //将关键词的拆分移到存储过程中进行,另:mstrInfoTypeID为0表示所用类型
            blRet = dal.InsertKeyWord(mstrKeyword, mstrInfoTypeID);
            return (blRet);
        }
        #endregion

        #region-- 添加 -------------------
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public bool InsertKeywordForMember(string Keyword, string InfoTypeID, string LoginName)
        {
            bool blRet = false;


            //根据判断，如果输入的关键词的长度过于长，将不进入用户键入关键词搜集
            int KeywordLengthRequest = 20;

            if (KeywordLengthRequest < Keyword.Length
                || Keyword.Length == 0)
            {
                //超过限制时，就不添加进入用户关键词表
                return (blRet);
            }

            string[] KeyWords = Keyword.Trim().Split(' ');
            for (int i = 0; i < KeyWords.Length; i++)
            {
                blRet = dal.InsertKeywordForMember(KeyWords[i].Trim(), InfoTypeID, LoginName);
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
        public DataView GetListForMemberKeyword(string LoginName)
        {
            bool blRet = false;
            string SelectCol = "*";
            string Criteria = "LoginName = '" + LoginName.Trim() + "'";
            string OrderBy = "RecordTime";
            long CurrentPage = 1;
            long PageSize = 5;
            long PageCount = 0;
            return dal.GetListForMemberKeyword(SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref PageCount);
        }
        #endregion


        #region  查询相关关键字列表

        public DataView GetRelateKeyword(string InfoTypeID, string Keyword)
        {
            bool blRet = false;
            return dal.GetRelateKeyword(Keyword, InfoTypeID);
        }

        #endregion

        /// <summary>
        /// 获取DataSet类型的投资查询结果列表
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public DataTable dsGetCapitalAreaIDByInfoID(
           string InfoID
            )
        {
            long CurrentPage = 1;
            long PageSize = 20;
            long PageCount = 0;
            Tz888.BLL.Common.CommonFunction mCF = new Tz888.BLL.Common.CommonFunction();
            return (mCF.GetDTFromTableOrView(
                "CapitalInfoArea_Viw",
                InfoID,
                "*",
                "InfoID=" + InfoID,
                "InfoID desc",
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }

    }
}
