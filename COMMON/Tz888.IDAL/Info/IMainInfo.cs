using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    /// <summary>
    /// ������Ϣ���ݿ���ʽӿڶ���
    /// </summary>
    public interface IMainInfo
    {
        /// <summary>
        /// ��ȡһ������ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.MainInfoModel GetModel(long InfoID);
 
        /// <summary>
        /// ��ȡ���ݼ�
        /// </summary>
        /// <param name="strGetFields">ѡ�����</param>
        /// <param name="fldName">�����ֶ�</param>
        /// <param name="PageSize">��ҳ��¼����</param>
        /// <param name="PageIndex">ҳ��</param>
        /// <param name="OrderType">��������</param>
        /// <param name="strWhere">��ѯ����</param>
        /// <returns></returns>
        DataSet GetList(string strGetFields, string fldName, int PageSize, int PageIndex, int OrderType, string strWhere);

        /// <summary>
        /// ͳ�Ƽ�¼����
        /// </summary>
        /// <param name="strWhere">ͳ������</param>
        /// <returns>��¼����</returns>
        int GetCount(string InfoType,string strWhere);

        /// <summary>
        /// �û�ɾ����Ϣ
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="LoginName"></param>
        /// <param name="ErrorID"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        bool UserDelete(long InfoID, string LoginName, ref int ErrorID, ref string ErrorMsg);

        /// <summary>
        /// ��ȫɾ����Ϣ
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
        bool HasCompleteDelete(long InfoID, string LoginName);

        /// <summary>
        /// ɾ����Ϣ
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
        bool HasDelete(long InfoID, string LoginName, bool IsMendaciousInfo, ref int ErrorID, ref string ErrorMsg);
        bool UpdatePromotionStatu(long InfoId, int PromotionStatu);
       /// <summary>
        /// ��Դˢ��
        /// </summary>
        /// <returns></returns>
        bool UpdateRefresh(long InfoID);

        /// <summary>
        /// ����Դ������ͼ��ȡ����
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="OrderBy"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        DataTable GetMainInfoViewList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);


        /// <summary>
        /// ������Ϣ��Ч��
        /// </summary>
        /// <returns></returns>
        bool SetValidateTerm(long InfoID, int ValidateTerm);
        /// <summary>
        /// ���¹���ȯ״̬
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="flg">0Ϊȡ������ȯ 1Ϊ���ù���ȯ</param>
        /// <returns></returns>
        int HasCost(long InfoID, int flg);
        /// <summary>
        /// ������Ч��
        /// </summary>
        /// <param name="infoId">��ϢID</param>
        /// <param name="startDay">��ʼ��Чʱ��</param>
        /// <param name="terms">��Ч����</param>
        /// <returns>�Ƿ���³ɹ�</returns>
        bool ChangeValidTerm(long infoId, DateTime startDay, int terms);
        

        /// <summary>
        /// �����Ϣ 
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <param name="AuditingStatus">���״̬:0δ��ˣ� 1���ͨ����2���δͨ��</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
        bool HasAuditing(long InfoID, byte AuditingStatus, bool IsCore, long Hit, string LoginName,
            string AuditingRemark, string HtmlFile, string HtmlFile1, short IsIntegral, float MainPointCount);


        /// <summary>
        /// ��Ϣ���״̬��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool InfoAuditNote(Tz888.Model.Info.InfoAuditModel model);

        /// <summary>
        /// ��ȡ��Դ��˼�¼
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.InfoAuditModel GetInfoAuditNote(long InfoID);


        #region ��Ϣ���� HasFixPrice
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <param name="FixPriceID">���۵ȼ�ID</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
        bool HasFixPrice(long InfoID, string FixPriceID, string LoginName);
        #endregion

        bool HasMainEvaluation(long InfoID, decimal MainEvaluation);

        //������Ϣ�ľ�̬��ҳ���ַ
        bool HasHtmlFile(long InfoID, string HtmlFile);

                /// <summary>
        /// ��Ա�鿴�����Ϣ����
        /// </summary>
        /// <param name="loginName">�û���</param>
        /// <param name="ip">�û���ʹ�õ�IP</param>
        /// <param name="infoId">��ϢID</param>
        /// <param name="viewOptions">--0δ��֤��ͨ��,1 �Ѿ���֤ͨ��,2δ��֤��ͨ��</param>
        /// <param name="validateOptions">--0δ�������� ,1 ��Ա�涨ȡ������������,2 IPȡ������������</param>
        /// <returns>�Ƿ�ִ�гɹ�</returns>
        bool FreeInfoView(string loginName, string ip, long infoId, ref int viewOptions, ref int validateOptions);

        /// <summary>
        /// ��ȡ��Ϣ����Դ����
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        string GetInfoTypeID(long InfoID);

        /// <summary>
        /// ͳ����Դ��������
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        int GetInfoBuyersCount(long InfoID);

        /// <summary>
        /// ����������Ϣ�ö�
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="IsTop"></param>
        /// <returns></returns>
        bool SetProjectInfoTop(long InfoID, int IsTop);


        bool AddHit(long InfoID);


        /// <summary>
        /// ��Դ�ٱ�
        /// </summary>
        /// <param name="InfoID">�ٱ���Ϣ</param>
        /// <param name="reportMan">�ٱ���</param>
        /// <param name="Remark">˵��</param>
        /// <returns></returns>
        bool InfoReport(long InfoID, string reportMan, string Remark);


         /// <summary>
        /// �ٱ�����
        /// </summary>
        /// <param name="ID">�ٱ���ID</param>
        /// <param name="chkMan">������</param>
        /// <param name="Remark">������</param>
        /// <returns></returns>
         bool InfoReportCheck(int ID, string chkMan, string Remark);

         /// <summary>
         /// ��ȡ������Ϣ�û� Ȼ����֪ͨ
         /// </summary>
         /// <param name="infoid">������ԴID</param>
         /// <returns></returns>
        string GetMaininfo(string InfoID);

        /// <summary>
        /// ��ȡ��Դ����
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        int GetInfoMainEvaluation(long InfoID, int MainEvaluation);
        
    }
}
