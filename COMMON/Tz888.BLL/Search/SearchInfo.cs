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

        public const string AuditingStatus_UnApprove = "����";
        public const string AuditingStatus_Approve = "����";
        public const string AuditingStatus_UndoApprove = "���δͨ��";


        #region ���캯��
        public SearchInfo()
        {

        }
        #endregion




        #region ��Ϣ��ѯ
        /// <summary>
        /// ��Ϣ��ѯ
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
                        dv[i]["AuditingStatusDesc"] = "����";
                        break;

                    case 1:
                        dv[i]["AuditingStatusDesc"] = "����";
                        break;

                    case 2:
                    default:
                        dv[i]["AuditingStatusDesc"] = "���δͨ��";
                        break;
                }
            }

            PageCount = lgPageCount;

            return (dv);

        }
        #endregion






        #region ��Ϣ���� HasOrderBy
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
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



        #region ��ѯ��Ϣ���ͱ���
        /// <summary>
        /// ��ѯ��Ϣ����������
        /// </summary>
        /// <param name="InfoTypeID">��Ϣ���ͱ��</param>		
        /// <returns>��Ϣ����������</returns>
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
            //        throw new Exception( "��ѯ����!" );
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

        #region ƥ����Ϣ��ѯ
        /// <summary>
        /// ƥ����Ϣ��ѯ
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

        #region ��������Ϣ��ѯ
        /// <summary>
        /// ��������Ϣ��ѯ
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
                        dv[i]["AuditingStatusDesc"] = "����";
                        break;

                    case 1:
                        dv[i]["AuditingStatusDesc"] = "����";
                        break;

                    case 2:
                    default:
                        dv[i]["AuditingStatusDesc"] = "���δͨ��";
                        break;
                }
            }

            PageCount = lgPageCount;

            return (dv);

        }
        #endregion

        #region ��Ϣ��ѯ
        /// <summary>
        /// ��Ϣ��ѯ-Ϊǰ̨��ʾ�б�
        /// </summary>
        /// <returns></returns>
        public virtual DataView InfoForFrontStageList(
            string SelectType, //��ѯ����
            string Criteria,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            long lgPageCount = 0;

            DataView dv = null;
            switch (SelectType)
            {
                case "InfoLatest": //��ѯ���µ���Ϣ
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

        #region ��ѯĳ����Ϣ��������Ϣ
        public bool HasGetInfoItemForManage(long InfoID)
        {

            bool HasGet = dal.HasGetInfoItemForManage(InfoID);
            //����Ϣ

            return HasGet;
        }
        #endregion

        #region ��ѯĳ����Ϣ��������Ϣ
        public Tz888.Model.Search.SearchInfo objGetSearchInfoByInfoID(long InfoID)
        {
            Tz888.Model.Search.SearchInfo sI = new Tz888.Model.Search.SearchInfo();
            sI = dal.objGetSearchInfoByInfoID(InfoID);
            return sI;
        }
        #endregion

        #region ǰ̨��Ϣ��ѯ(��Ա������ʹ��)
        /// <summary>
        /// ǰ̨��Ϣ��ѯ-Ϊǰ̨��ʾ�б�(��Ա������ʹ��)
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

        #region-- ��վ������ѯ�б� ---------------
        /// <summary>
        /// ��վ������ѯ�б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>ͷ����ѯ�б�</returns>
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








        #region-- ������Ϣ�б� ---------------
        /// <summary>
        /// ������Ϣ�б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>��ѯ�б�</returns>
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


        #region ���۴���

        public string getCommentNum(long InfoId)
        {
            string num = dal.getCommentNum(InfoId);
            return num;
        }
        #endregion


        #region-- �ж���Ϣ�Ƿ���Ч ---------------
        public bool IsValidInfo(
            string loginName,//��¼��
            string infoID  //��ϢID
            )
        {
            bool bl = false;
            int returnVal;
            returnVal = dal.IsValidInfo(loginName, infoID);
            switch (returnVal)
            {
                case 0:
                    throw new Exception("����Ϣ��Ҫ��Ա��¼����ܲ鿴!");

                case 1:
                    bl = true;//���Բ鿴
                    break;
                case 2:
                    throw new Exception("����Ϣ�Ǻ�����Ϣ,��Ҫ��ȡ����Ϣ��ϸ���ϣ������뾫׼ƥ�����!");

                case 3:
                    throw new Exception("����Ϣ����ϵ��ʽ��Ҫ���Ѳ��ܲ鿴!");

                default:
                    bl = true;
                    break;
            }
            return bl;
        }
        #endregion



        #region����ȡ��Ϣ�鿴�ĵ���
        public DataView GetPointCount(
            long InfoID)
        {

            return (dal.GetPointCount(InfoID));
        }
        #endregion



        #region ��Ϣ��ѯ
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

        #region ��Ϣ��ѯ
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

        #region ��Ϣ��ѯ
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


        #region ��Ϣ��ѯ
        /// <summary>
        /// ��ȡ��Ͷ�ʵĲ�ѯ����б�
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




        #region ��Ϣ��ѯ

        /// <summary>
        /// ��ȡ��DataSet���͵�Ͷ�ʲ�ѯ����б�
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
        /// ��ȡ��DataSet���͵�Ͷ�ʲ�ѯ����б�
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
        /// ��ȡ��DataSet���͵�Ͷ�ʲ�ѯ����б�
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
        /// ��ȡ��DataSet���͵���Ѷ��ѯ����б�
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
        ///  ��ȡ����ԭʼ��Ϣ,��InfoIDΪ�����ֶ� kevin 2007-07-17
        /// </summary>
        /// <param name="fields">Ҫ��ȡ����(��isJustCount=1ʱ�˲�����Ч)</param>
        /// <param name="where">����</param>bbb
        /// <param name="orderType">trueΪ����,falseΪ����(��isJustCount=1ʱ�˲�����Ч)</param>
        /// <param name="pageSize">ÿҳ��С(��isJustCount=1ʱ�˲�����Ч)</param>
        /// <param name="pageCur">��ǰҳ(��isJustCount=1ʱ�˲�����Ч)</param>
        /// <param name="isJustCount">trueΪ��������,���򲻼���</param>
        /// <returns></returns>
        public DataTable GetMainInfoTabList(string fields, string where, bool orderType, int pageSize, int pageCur, bool isJustCount)
        {

            return dal.GetMainInfoTabList(fields, where, orderType, pageSize, pageCur, isJustCount);
        }





        #region-- ����ƥ���б� [ͨ��FUNCTION��ʽ] ---------------
        /// <summary>
        /// ����ƥ���б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>��ѯ�б�</returns>
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

        #region-- ��Ӳ�ѯ�Ĺؼ��� -------------------
        /// <summary>
        /// ���
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        public bool InsertKeyword(string mstrKeyword, string mstrInfoTypeID)
        {
            bool blRet = false;

            //�����жϣ��������Ĺؼ��ʵĳ��ȹ��ڳ������������û�����ؼ����Ѽ�
            int KeywordLengthRequest = 20;

            if (KeywordLengthRequest < mstrKeyword.Length
                || mstrKeyword.Length == 0)
            {
                //��������ʱ���Ͳ���ӽ����û��ؼ��ʱ�
                return (blRet);
            }

            //string[] KeyWords = mstrKeyword.Trim().Split(' ');
            //for (int i = 0; i < KeyWords.Length; i++)
            //{
            //    blRet = dal.InsertKeyWord(KeyWords[i].Trim(), mstrInfoTypeID);
            //}
            //���ؼ��ʵĲ���Ƶ��洢�����н���,��:mstrInfoTypeIDΪ0��ʾ��������
            blRet = dal.InsertKeyWord(mstrKeyword, mstrInfoTypeID);
            return (blRet);
        }
        #endregion

        #region-- ��� -------------------
        /// <summary>
        /// ���
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        public bool InsertKeywordForMember(string Keyword, string InfoTypeID, string LoginName)
        {
            bool blRet = false;


            //�����жϣ��������Ĺؼ��ʵĳ��ȹ��ڳ������������û�����ؼ����Ѽ�
            int KeywordLengthRequest = 20;

            if (KeywordLengthRequest < Keyword.Length
                || Keyword.Length == 0)
            {
                //��������ʱ���Ͳ���ӽ����û��ؼ��ʱ�
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


        #region-- ��ѯ�б� ---------------
        /// <summary>
        /// ��ѯ�б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>��ѯ�б�</returns>
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


        #region  ��ѯ��عؼ����б�

        public DataView GetRelateKeyword(string InfoTypeID, string Keyword)
        {
            bool blRet = false;
            return dal.GetRelateKeyword(Keyword, InfoTypeID);
        }

        #endregion

        /// <summary>
        /// ��ȡDataSet���͵�Ͷ�ʲ�ѯ����б�
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
