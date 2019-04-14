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
            PageCount = 0;
            DataView dv = new DataView(); ;
            
            return (dv);

        }
        #endregion


        #region ��ȡ����Ϣ���ա����������͵���Ϣ
        /// <summary>
        /// ��ȡ����Ϣ���ա����������͵���Ϣ������Ҫ�̳�
        /// </summary>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>���ء���Ϣ���ա����������͵���Ϣ����ѯ��¼����ҳ��</returns>
        public virtual DataView GetInfoListByRecycle(
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
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


        #region ��ȡĳ������ĸ��˷�������Ϣ���ҵ���Ϣ��
        /// <summary>
        /// ��ȡĳ������ĸ��˷�������Ϣ���ҵ���Ϣ��
        /// </summary>
        /// <param name="loginName">�û��ĵ�½��</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>����ĸ��˷�������Ϣ�б���ѯ��¼����ҳ��</returns>
        public virtual DataView GetInfoListBySelf(
            string Criteria,
            string loginName,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
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
        ///  ��ȡ����ԭʼ��Ϣ,��InfoIDΪ�����ֶ� kevin 2007-07-17
        /// </summary>
        /// <param name="fields">Ҫ��ȡ����(��isJustCount=1ʱ�˲�����Ч)</param>
        /// <param name="where">����</param>
        /// <param name="orderType">trueΪ����,falseΪ����(��isJustCount=1ʱ�˲�����Ч)</param>
        /// <param name="pageSize">ÿҳ��С(��isJustCount=1ʱ�˲�����Ч)</param>
        /// <param name="pageCur">��ǰҳ(��isJustCount=1ʱ�˲�����Ч)</param>
        /// <param name="isJustCount">trueΪ��������,���򲻼���</param>
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



        #region ��ȡȫ������Ϣ�б�
        /// <summary>
        /// ��ȡȫ������Ϣ�б�
        /// </summary>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>����ȫ������Ϣ�б���ѯ��¼����ҳ��</returns>
        public virtual DataView GetInfoList(
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
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
              ref long PageCount // ���ظò�ѯ�ж�������¼
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
        /// ���ֵ����Ż���ѯ
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
            ref long PageCount // ���ظò�ѯ�ж�������¼
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
        /// ��ȡͶ�ʵĲ�ѯ����б�
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
            ref long PageCount // ���ظò�ѯ�ж�������¼
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
        /// ��ȡDataSet���͵�Ͷ�ʲ�ѯ����б�
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
            ref long PageCount // ���ظò�ѯ�ж�������¼
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
        /// ��ȡDataSet���͵����ʲ�ѯ����б�
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
            ref long PageCount // ���ظò�ѯ�ж�������¼
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
        /// ��ȡDataSet���͵����̲�ѯ����б�
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
            ref long PageCount // ���ظò�ѯ�ж�������¼
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
        /// ��ȡDataSet���͵���Ѷ��ѯ����б�
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
            ref long PageCount // ���ظò�ѯ�ж�������¼
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



        #region-- ��ȡ��Ϣ�鿴�ĵ���

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


        #region-- �ж���Ϣ�Ƿ���Ч ---------------
        public int IsValidInfo(
            string loginName,
            string infoID
            )
        {
            int bl = 0;

            SqlParameter[] parameters = { 	
											new SqlParameter("@LoginName",SqlDbType.Char,16),			//--��¼��
											new SqlParameter("@InfoID",SqlDbType.BigInt,8),				//--��ϢID
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

        #region  ���۴���

        public string getCommentNum(long InfoID)
        {                       
            string strsql = "select * from InfoCommentTab where InfoID=" + InfoID;
            int iRet = 0;
            iRet= DbHelperSQL.ExecuteSql(strsql);
            return iRet.ToString().Trim();
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


        #region-- ������վ�����̡�Ͷ�ʡ����ʲ�ѯ�б� ---------------
        /// <summary>
        /// ������վ�����̡�Ͷ�ʡ����ʲ�ѯ�б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>ͷ����ѯ�б�</returns>
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


        #region ���ĳ������Ϣ,ͨ�����Է�������
        /// <summary>
        /// ���ĳ������Ϣ,ͨ�����Է�������
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
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

                //���������
                sI.IsIntegralInfo = Convert.ToInt16(dv[0]["IsIntegralInfo"]);
                sI.MainPointCoun = Convert.ToSingle(dv[0]["MainPointCount"]);
                sI.MainEvaluation = Convert.ToInt32(dv[0]["MainEvaluation"]);
            }
            return sI;
        }
        #endregion


        #region ��ȡȫ������Ϣ�б���ʾ����վǰ̨��
        /// <summary>
        /// ��ȡȫ������Ϣ�б���ʾ����վǰ̨��
        /// </summary>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>����ȫ������Ϣ�б���ѯ��¼����ҳ��</returns>
        public virtual DataView GetInfoListForFrontView(
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
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
        /// ��ȡȫ������Ϣ�б�
        /// </summary>
        /// <param name="mySql">�������ݿ���</param>
        /// <param name="FNStrName">�����ַ���</param>
        /// <param name="Key">�ؼ���</param>
        /// <param name="SelectStr">ѡ�����ַ���</param>
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="Sort">�����ַ���</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">ͨ���ò�ѯ���������صĲ�ѯ��¼����ҳ��</param>
        /// <returns>���ص�ǰҳ����Ϣ�б�</returns>
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


        #region-- ��ӹؼ��� -------------------
        /// <summary>
        /// ���
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
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


        #region-- ��� -------------------
        /// <summary>
        /// ���
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
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


        #region  ��ѯ��عؼ����б�

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
