using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Info
{
    public class MainInfoBLL
    {
        private readonly IMainInfo dal = DataAccess.CreateInfo_MainInfo();
        Tz888.BLL.SendNotice Notice = new SendNotice();

        #region ��ȡ��Ϣ�������ݼ�¼��
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
        public DataSet GetList(string strGetFields, string fldName, int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            return dal.GetList(strGetFields, fldName, PageSize, PageIndex, OrderType, strWhere);
        }
        #endregion
        public Tz888.Model.Info.MainInfoModel GetModel(long InfoID)
        {
            return dal.GetModel(InfoID);
        }
        #region ͳ�Ƽ�¼����
        /// <summary>
        /// ͳ�Ƽ�¼����
        /// </summary>
        /// <param name="strWhere">ͳ������</param>
        /// <returns></returns>
        public int GetCount(string InfoType,string strWhere)
        {
            return dal.GetCount(InfoType,strWhere);
        }
        #endregion

        #region �ظ������������ʹ��
        /// <summary>
        /// ��������������ͻ�ȡ�б��ظ������������ʹ�ã�
        /// </summary>
        /// <param name="strGetFields"></param>
        /// <param name="fldName"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="OrderType"></param>
        /// <param name="loginName"></param>
        /// <param name="RoleName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataSet GetList(string strGetFields, string fldName, int PageSize, int PageIndex, int OrderType,string loginName ,string RoleName,Tz888.BLL.Common.AuditStatus type)
        {
            string strWhere = "";
            switch ((int)type)
            {
                case 0:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    break;
                case 1:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 2:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    break;
                case 3:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE()";
                    break;
                default:
                    break;
            }

            return dal.GetList(strGetFields, fldName, PageSize, PageIndex, OrderType, strWhere);
        }

        /// <summary>
        /// ͳ��ָ���û���ĳһ���͵��������Ŀ
        /// </summary>
        /// <param name="Type">ͳ������</param>
        /// <param name="loginName">�û���</param>
        /// <returns></returns>
        public int GetCount(Tz888.BLL.Common.AuditStatus Type, string loginName,string RoleName)
        {
            string strWhere = "";
            switch ((int)Type)
            {
                case 0:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    break;
                case 1:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 2:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    break;
                case 3:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE()";
                    break;
                default:
                    break;
            }
            return this.GetCount("",strWhere);
        }

        /// <summary>
        /// ��ȡ����Ŀ���������͵���ʾ��Ϣ
        /// </summary>
        /// <param name="loginName">�û�����</param>
        /// <param name="model">��Ϣģ��[***{0}**{1}***],��һ������Ϊ������Ŀ���ڶ�������Ϊ����������</param>
        /// <param name="Type">��������</param>
        /// <returns></returns>
        public string GetRemind(string loginName, string RoleName ,string model, Tz888.BLL.Common.AuditStatus type)
        {
            string remindInfo = "";
            switch ((int)type)
            {
                case 0:
                    remindInfo = "�����";
                    break;
                case 1:
                    remindInfo = "ͨ�����";
                    break;
                case 2:
                    remindInfo = "δͨ�����";
                    break;
                case 3:
                    remindInfo = "�ѹ���";
                    break;
                default:
                    break;
            }
            int count = this.GetCount(type, loginName,RoleName);
            string request = string.Format(model, count.ToString(), remindInfo);
            return request;
        }

        /// <summary>
        /// �û�ɾ����Ϣ
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="LoginName"></param>
        /// <param name="ErrorID"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        public bool UserDelete(long InfoID, string LoginName, ref int ErrorID, ref string ErrorMsg)
        {
            return dal.UserDelete(InfoID, LoginName, ref ErrorID, ref ErrorMsg);
        }

        #endregion

        #region ��վ��̨�������ʹ��
        /// <summary>
        /// ��������������ͻ�ȡ�б���վ��̨�������ʹ�ã�
        /// </summary>
        /// <param name="strGetFields"></param>
        /// <param name="fldName"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="OrderType"></param>
        /// <param name="loginName"></param>
        /// <param name="RoleName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataSet GetList(string strGetFields, string fldName, int PageSize, int PageIndex, int OrderType, Tz888.BLL.Common.AuditStatus type,string InfoType)
        {
            string strWhere = "";
            switch ((int)type)
            {
                case 0:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    break;
                case 1:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    break;
                case 3:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 5:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1";
                    else
                        strWhere = "DelStatus <> 1";
                    break;
                default:
                    break;
            }

            return dal.GetList(strGetFields, fldName, PageSize, PageIndex, OrderType, strWhere);
        }

        /// <summary>
        /// ͳ���������Ŀ
        /// </summary>
        /// <param name="Type">ͳ������</param>
        /// <param name="InfoType">��Ϣ����</param>
        /// <returns></returns>
        public int GetCount(Tz888.BLL.Common.AuditStatus Type,string InfoType)
        {
            string strWhere = "";
            switch ((int)Type)
            {
                case 0:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    break;
                case 1:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    break;
                case 3:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 5:
                    if(!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1";
                    else
                        strWhere = "DelStatus <> 1";
                    break;
                default:
                    break;
            }
            return this.GetCount(InfoType,strWhere);
        }

        /// <summary>
        /// ͳ����Ϣ����Ŀ
        /// </summary>
        /// <param name="Type">��Ϣ״̬</param>
        /// <param name="InfoType">��Ϣ����</param>
        /// <param name="strWhere">��ѯ����</param>
        /// <returns></returns>
        public int GetInfoCount(Tz888.BLL.Common.AuditStatus Type,Tz888.BLL.Common.InfoType InfoType, string Criteria)
        {
            string strInfoType = "";

            switch ((int)InfoType)
            {
                case 0:
                    strInfoType = "Merchant";
                    break;
                case 1:
                    strInfoType = "Project";
                    break;
                case 2:
                    strInfoType = "Capital";
                    break;
                default:
                    break;
            }

            string strWhere = "";
            switch ((int)Type)
            {
                case 0:
                    if (!string.IsNullOrEmpty(strInfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    break;
                case 1:
                    if (!string.IsNullOrEmpty(strInfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(strInfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    break;
                case 3:
                    if (!string.IsNullOrEmpty(strInfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 5:
                    if (!string.IsNullOrEmpty(strInfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1";
                    else
                        strWhere = "DelStatus <> 1";
                    break;
                default:
                    break;
            }
            if (string.IsNullOrEmpty(strWhere))
                strWhere = Criteria;
            else
                strWhere += " AND " + Criteria;
            return this.GetCount(strInfoType, strWhere);
        }

        /// <summary>
        /// ��ȡ��ѯ����
        /// </summary>
        public static string GetCriteria(Tz888.BLL.Common.AuditStatus Type, string InfoType)
        {
            string strWhere = "";
            switch ((int)Type)
            {
                case 0:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    break;
                case 1:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    break;
                case 3:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 5:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1";
                    else
                        strWhere = "DelStatus <> 1";
                    break;
                default:
                    break;
            }
            return strWhere;
        }
        /// <summary>
        /// ��ȡ������Դ��Ӧ�Ĳ�ѯ��������
        /// </summary>
        ///2010-06-13
        /// <returns></returns>
        public static string GetCriteria()
        {
            string strWhere = "(InfoTypeID='Project' or InfoTypeID='Capital' or InfoTypeID='Merchant')";

            return strWhere;
        
        
        }

        /// <summary>
        /// ��ȡ����Ŀ���������͵���ʾ��Ϣ
        /// </summary>
        /// <param name="loginName">�û�����</param>
        /// <param name="model">��Ϣģ��[***{0}**{1}***],��һ������Ϊ������Ŀ���ڶ�������Ϊ����������</param>
        /// <param name="Type">��������</param>
        /// <returns></returns>
        public string GetRemind(string model, Tz888.BLL.Common.AuditStatus type,string InfoType)
        {
            string remindInfo = "";
            switch ((int)type)
            {
                case 0:
                    remindInfo = "�����";
                    break;
                case 1:
                    remindInfo = "ͨ�����";
                    break;
                case 2:
                    remindInfo = "δͨ�����";
                    break;
                case 3:
                    remindInfo = "�ѹ���";
                    break;
                default:
                    break;
            }
            int count = this.GetCount(type, InfoType);
            string request = string.Format(model, count.ToString(), remindInfo);
            return request;
        }

        #endregion

        #region ����Դ������ͼ��ȡ����
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
        public DataTable GetMainInfoViewList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            return dal.GetMainInfoViewList(SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref PageCount);
        }
        #endregion

        #region ��Դˢ��
        /// <summary>
        /// ��Դˢ��
        /// </summary>
        /// <returns></returns>
        public bool UpdateRefresh(long InfoID)
        {
            return dal.UpdateRefresh(InfoID);
        }
        #endregion

        #region ������Ϣ��Ч��
        /// <summary>
        /// ������Ϣ��Ч��
        /// </summary>
        /// <returns></returns>
        public bool SetValidateTerm(long InfoID, int ValidateTerm)
        {
            return dal.SetValidateTerm(InfoID, ValidateTerm);
        }

        #endregion

        #region ������Ч��
        /// <summary>
        /// ������Ч��
        /// </summary>
        /// <param name="infoId">��ϢID</param>
        /// <param name="startDay">��ʼ��Чʱ��</param>
        /// <param name="terms">��Ч����</param>
        /// <returns>�Ƿ���³ɹ�</returns>
        public bool ChangeValidTerm(long infoId, DateTime startDay, int terms)
        {
            return dal.ChangeValidTerm(infoId, startDay, terms);
        }
        #endregion
        #region  �����ƹ�״̬
        /// <summary>
        /// �����ƹ�״̬
        /// </summary>
        /// <param name="InfoId">������ԴID</param>
        /// <param name="PromotionStatu">�޸ĵ���</param>
        /// <returns></returns>
        public bool UpdatePromotionStatu(long InfoId, int PromotionStatu)
        {
            return dal.UpdatePromotionStatu(InfoId, PromotionStatu);
        }
        #endregion
        #region �����Ϣ
        /// <summary>
        /// �����Ϣ 
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <param name="AuditingStatus">���״̬:0δ��ˣ� 1���ͨ����2���δͨ��</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
        public bool HasAuditing(long InfoID, byte AuditingStatus, bool IsCore, long Hit, string LoginName,
            string AuditingRemark, string HtmlFile, string HtmlFile1, short IsIntegral, float MainPointCount)
        {
            bool check = false;
            check=dal.HasAuditing(InfoID,AuditingStatus,IsCore,Hit,LoginName,
            AuditingRemark, HtmlFile, HtmlFile1, IsIntegral, MainPointCount);
            if (check)//�����˳ɹ���֪ͨ�û�
            {
                GetMaininfo(InfoID.ToString()); 
            }
            return check;
        }
        #endregion

        #region ��Ϣ���״̬��Ϣ��¼
        /// <summary>
        /// ��Ϣ���״̬��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InfoAuditNote(Tz888.Model.Info.InfoAuditModel model)
        {
            return dal.InfoAuditNote(model);
        }
        #endregion

        #region ��ȡ��Ϣ���״̬��Ϣ
        /// <summary>
        /// ��ȡ��Ϣ���״̬��Ϣ
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.InfoAuditModel GetInfoAuditNote(long InfoID)
        {
            return dal.GetInfoAuditNote(InfoID);
        }
        #endregion

        #region ��Ϣ���� HasFixPrice
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <param name="FixPriceID">���۵ȼ�ID</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
        public bool HasFixPrice(long InfoID, string FixPriceID, string LoginName)
        {
            return dal.HasFixPrice(InfoID, FixPriceID, LoginName);
        }
        #endregion

        #region ���ù���ȯ
        /// <summary>
        /// ���ù���ȯ
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="flg"></param>
        /// <returns>���ع���ȯ״̬</returns>
        public int HasCost(long InfoID, int flg)
        {
            return dal.HasCost(InfoID, flg);
        }
        #endregion

        #region ��ȫɾ����Ϣ HasCompleteDelete
        /// <summary>
        /// ��ȫɾ����Ϣ
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
        public virtual bool HasCompleteDelete(long InfoID, string LoginName)
        {
            return dal.HasCompleteDelete(InfoID, LoginName);
        }
        #endregion

        #region ɾ����Ϣ HasDelete
        /// <summary>
        /// ɾ����Ϣ
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
        public bool HasDelete(long InfoID, string LoginName, bool IsMendaciousInfo, ref int ErrorID, ref string ErrorMsg)
        {
            //??
            return dal.HasDelete(InfoID, LoginName, IsMendaciousInfo,ref ErrorID, ref ErrorMsg);
        }
        #endregion.

        #region ������Ϣ����ָ��
        public bool HasMainEvaluation(long InfoID, decimal MainEvaluation)
        {
            return dal.HasMainEvaluation(InfoID, MainEvaluation);
        }
        #endregion ������Ϣ����ָ��

        #region ������Ϣ��̬����ַ
        public bool HasHtmlFile(long InfoID, string HtmlFile)
        {
            return dal.HasHtmlFile(InfoID, HtmlFile);
        }
        #endregion
		 
        #region ��Ա�鿴�����Ϣ����
		
        /// <summary>
        /// ��Ա�鿴�����Ϣ����
        /// </summary>
        /// <param name="loginName">�û���</param>
        /// <param name="ip">�û���ʹ�õ�IP</param>
        /// <param name="infoId">��ϢID</param>
        /// <param name="viewOptions">--0δ��֤��ͨ��,1 �Ѿ���֤ͨ��,2δ��֤��ͨ��</param>
        /// <param name="validateOptions">--0δ�������� ,1 ��Ա�涨ȡ������������,2 IPȡ������������</param>
        /// <returns>�Ƿ�ִ�гɹ�</returns>
        public bool FreeInfoView(string loginName, string ip, long infoId, ref int viewOptions, ref int validateOptions)
        {
            return dal.FreeInfoView(loginName, ip,infoId, ref viewOptions, ref validateOptions);
        }

	    #endregion

        #region ��ȡָ����Ϣ����Ϣ����
        public string GetInfoTypeID(long InfoID)
        {
            return dal.GetInfoTypeID(InfoID);
        }
        #endregion

        #region ͳ����Դ��������
        public int GetInfoBuyersCount(long InfoID)
        {
            return dal.GetInfoBuyersCount(InfoID);
        }
        #endregion

        #region ����������Ϣ�ö�
        public bool SetProjectInfoTop(long InfoID, int IsTop)
        {
            return dal.SetProjectInfoTop(InfoID, IsTop);
        }
        #endregion

        #region ���ӵ��
        public bool AddHit(long InfoID)
        {
            return dal.AddHit(InfoID);
        }
        #endregion


        /// <summary>
        /// ��Դ�ٱ�
        /// </summary>
        /// <param name="InfoID">�ٱ���Ϣ</param>
        /// <param name="reportMan">�ٱ���</param>
        /// <param name="Remark">˵��</param>
        /// <returns></returns>
        public bool InfoReport(long InfoID, string reportMan, string Remark)
        {
            return dal.InfoReport(InfoID, reportMan, Remark);
        }
        /// <summary>
        /// �ٱ�����
        /// </summary>
        /// <param name="ID">�ٱ���ID</param>
        /// <param name="chkMan">������</param>
        /// <param name="Remark">������</param>
        /// <returns></returns>
        public bool InfoReportCheck(int ID, string chkMan, string Remark)
        {
            return dal.InfoReport(ID, chkMan, Remark);

        }

        /// <summary>
        /// ��ȡ������Ϣ�û� Ȼ����֪ͨ
        /// </summary>
        /// <param name="infoid">������ԴID</param>
        /// <returns></returns>
        public int  GetMaininfo(string infoid)
        {
            string loginname = dal.GetMaininfo(infoid);
            string Contents = "����������Ϣ����˳ɹ�,���¼�����ظ�ͨ�鿴��";
            return Notice.InfoCheck(loginname, Contents, "��Դ��˳ɹ�", Contents, Contents);
          
        }

        #region ��ȡ��Դ����
        public int GetInfoMainEvaluation(long InfoID, int MainEvaluation)
        {
            return dal.GetInfoMainEvaluation(InfoID, MainEvaluation);
        }
        #endregion

    }
}
