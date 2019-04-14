using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
 
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL.Info
{
    /// <summary>
    /// ��Ϣƥ��
    /// </summary>
    public class MatchInfoDAL : IDAL.Info.IMatchInfo
    {

        #region-- ����ƥ���б� [ͨ��FUNCTION��ʽ] ---------------
        /// <summary>
        /// ����ƥ���б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>��ѯ�б�</returns>
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
                //�ʱ���Դ ���ʱ���Դ
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
                    //�ʱ���Դ������
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
                    //�ʱ�������
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
                    //���ʶ�����
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
                    //���ʶ��ʱ���Դ
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
                    //���ʶ�����
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
                    //���̶�����
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
                    //���̶�����
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
                    //���̶��ʱ���Դ
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

        #region  ͳ����Ϣƥ����Ŀ
        /// <summary>
        /// ͳ����Ϣƥ����Ŀ
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

        #region ĳһ�û���������Ϣ
        /// <summary>
        /// ��ȡĳһ�û�������������Ϣ
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

        #region ĳһ����Ϣ�ж������ղأ�ͬʱ����hit����
        /// <summary>
        /// ĳһ����Ϣ�ж����˹�ע,ͬʱ�����û��ĵ������
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
