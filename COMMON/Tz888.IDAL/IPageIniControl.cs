using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.IDAL
{
    public interface IPageIniControl
    { 
        #region ����ҵ	���ݰ�
        /// <summary>
        /// ����ҵ	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataTable IndustryBDataBind();
        DataView IndustryBDataBind2();
        #endregion

        #region ��ҵ��ҵ����	���ݰ�
        /// <summary>
        /// ��ҵ��ҵ	���ݰ�
        /// </summary>
        /// 			/// <returns></returns>
        DataView IndustryCarveOutDataBind();
        #endregion

        #region �̻���ҵ����	���ݰ�
        /// <summary>
        /// ���̻���ҵ	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataView IndustryOpportunityDataBind();

        #endregion

        #region �ɹ���������	���ݰ�
        /// <summary>
        /// �ɹ���������	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataView CaseDataBind();

        #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// �ɹ���������	���ݰ�
        /// </summary>
        /// <returns></returns>
         DataView BulletinDataBind();

        #endregion

        #region ���λ��	���ݰ�
        /// <summary>
        /// �������	���ݰ�
        /// </summary>
        /// <returns></returns>
         DataView ADLocationDataBind();

        #endregion

        #region ��ҵ��Ӣ����	���ݰ�
        /// <summary>
        /// ��ҵ��Ӣ����	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataView EliteDataBind();
        #endregion

        #region չ����ҵ����	���ݰ�
        /// <summary>
        /// չ����ҵ����	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataView ExhibitionDataBind();

        #endregion

        #region Ͷ�ʽ��	���ݰ�
        /// <summary>
        /// Ͷ�ʽ��	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataTable CaptitalDataBind();
        #endregion

        #region Ͷ�ʽ��	���ݰ�
        /// <summary>
        /// Ͷ�ʽ��	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataView MemberQuantityDataBind();
        #endregion

        #region ��ҵ�ʽ�����	���ݰ�
        /// <summary>
        /// �ʱ�����	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataView CapitalCarveOutDataBind();
        #endregion

        #region ����ʱЧ	���ݰ�
        /// <summary>
        /// ����ʱЧ	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataView ValidateDateDataBind();
        #endregion

        #region ����ʱЧ	���ݰ�
        /// <summary>
        /// ����ʱЧ	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataView OpportunityTypeDataBind();
        #endregion

        #region ��Ϣ����	���ݰ�
        /// <summary>
        /// ��Ϣ����	���ݰ� 
        /// </summary>
        /// <returns></returns>
        DataView FixPriceDataBind();
        #endregion

        #region ��Ϣ����	���ݰ�
        /// <summary>
        /// ��Ϣ����	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataView GradeDataBind();
        #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// ��������	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataTable MerchantTypeDataBind();
        #endregion

        #region �ʱ�����	���ݰ�
        /// <summary>
        /// �ʱ�����	���ݰ�
        /// </summary>
        /// <returns></returns>
         DataTable CaptitalTypeDataBind();
        #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// ��������	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataView NewsTypeDataBind();
        #endregion

        #region ����������	���ݰ�
        /// <summary>
        /// ����������	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataView AreaDataBind();
        #endregion

        #region ������ҵ����	���ݰ�
        /// <summary>
        /// ��Ϣ����	���ݰ�
        /// </summary>
        /// <returns></returns>
        DataView NewsIndustyDataBind();
        #endregion

        #region ����  ���ݰ�
        /// <summary>
        /// ����  ���ݰ�
        /// </summary>
        /// <returns></returns>
        DataView CountryDataBind();
        #endregion

        #region ʡ�� ���ݰ�
        /// <summary>
        /// ʡ�� ���ݰ�
        /// </summary>
        /// <returns></returns>
        DataTable ProvinceDataBind(string CountryCode);
        
        #endregion

        #region-- ��ҵ��ҵ ---------------
        /// <summary>
        /// ��ѯ�б�
        /// </summary>		
        /// <returns>�б�</returns>
         DataTable GetListIndustryCarveout();
        #endregion
         #region-- �̻� ---------------
         /// <summary>
         /// ��ѯ�б�
         /// </summary>		
         /// <returns>�б�</returns>
         DataTable GetListIndustryOppor();
         #endregion

        #region-- ��Ѷ���� ---------------
        /// <summary>
        /// ��ѯ�б�
        /// </summary>		
        /// <returns>�б�</returns>
         DataTable GetList();
        #endregion
        #region �ؼ��� ���ݰ�
        /// <summary>
        /// �ؼ��� ���ݰ�
        /// </summary>
        /// <returns></returns>
         DataView CapitalCityDataBind(string ProvinceID);
        #endregion

        #region �ؼ���  ���ݰ�
        /// <summary>
        /// �ؼ���  ���ݰ�
        /// </summary>
        /// <returns></returns>
         DataView CountyDataBind(string CapitalCityID);
        #endregion

        #region �ؼ���  ���ݰ�
        /// <summary>
        /// �ؼ���  ���ݰ�
        /// </summary>
        /// <returns></returns>
         DataView AreaByCapitalCityDataBind(string CapitalCityID);
        #endregion

        #region ֤������	���ݰ�
        /// <summary>
        /// ֤������	���ݰ�
        /// </summary>
        /// <returns></returns>
         DataView CertificateDataBind();
        #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView DeptInfoDataBind();
        #endregion

        #region ְ������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView WorkTypeDataBind();
        #endregion

        #region ѧ������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView DegreeInfoDataBind();
        #endregion

        #region ��ɫ������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView RoleGroupDataBind();
        #endregion

        #region �˵�Ȩ�޲�������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView MenuTypeDataBind();
        #endregion

        #region ϵͳȨ�޲�������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView SystemTypeDataBind();
        #endregion

        #region ��ϢȨ�޲�������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView InfoOPPDataBind();
        #endregion

        #region ��Ϣ����	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView InfoTypeDataBind();
        #endregion

        #region ��ɫ����	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView WorkTypeActiveDataBind();
        #endregion

        #region ��Ϣ��ʾ��Ŀ�ؼ�	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView InfoControlDataBind(string InfoTypeID, string WebSiteLoginName);
        #endregion

        #region ��Ϣ��ʾ��Ŀ�ؼ�	���ݰ�
        /// <summary>
        ///	  ������Ϣ������ѡ����Ŀ�ؼ�
        /// </summary>
        /// <returns></returns>
         DataView InfoControlDataBindByInfoType(string InfoTypeID);
        #endregion

        #region ��Ϣ��ʾ��վ���пؼ�	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView InfoControlDataBind(string WebSiteLoginName);
        #endregion

        #region ר������	���ݰ�
        /// <summary>
        /// ר������	���ݰ�
        /// </summary>
        /// <returns></returns>
         DataView ExpertTypeDataBind();

        #endregion

        #region ר������	���ݰ�
        /// <summary>
        /// ר������	���ݰ�
        /// </summary>
        /// <returns></returns>
         DataView ExpertTypeDataBind(string strExpertTypeID);

        #endregion

        #region ��ȡ��Ƭ���ͱ�
         DataView GetCardTypeList();
        #endregion

        #region ר������	���ݰ�
        /// <summary>
        /// ר������	���ݰ�
        /// </summary>
        /// <returns></returns>
         DataView ExpertInfoDataBind(string strLoginName);

        #endregion

        #region ר������	���ݰ�
        /// <summary>
        /// ר������	���ݰ�
        /// </summary>
        /// <returns></returns>
         DataView ExpertNameDataBind(string loginid);

        #endregion

        #region ��Աְλ����	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        DataView PositionDataBind();

        #endregion

        #region ��ѯר�������Ϣ
        /// <summary>
        /// ר������	���ݰ�
        /// </summary>
        /// <returns></returns>
         DataView GetExpertMessage(string ExpertLoginName);
        #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        DataView AttractCapitalTypeDataBind();
        #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView FeedbackSDataBind();
        #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        DataView FeedbackBDataBind();
        #endregion
        

        #region ��������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        DataTable IndustryMDataBind(string IndustryBID);
        #endregion


        #region ��DATAVIEW����������ո�
        DataTable CleanSpace(DataTable DealDV, string DealCol);
        #endregion

        #region ��ʼ������������
        DataView ADTypeDataBind();//�������
        /// <summary>
        /// ���λ��
        /// </summary>
        /// <param name="SiteType">���λ����.0:��վ 1����վ ���ַ�����ȫ��</param>
        /// <returns>����DV</returns>
        DataView ADLocationDataBind(string SiteType);//���λ

        /// <summary>
        /// վ ���
        /// </summary>
        /// <param name="roleType">��ɫ���� 0:������ 2:�ڲ�Ա��</param>
        /// <param name="loginName">��¼��,�����ڲ�Ա�����˲�������ʹ��</param>
        /// <returns></returns>

         DataView ADSiteDataBind(string roleType, string loginName);//վ��
        

        #endregion

        #region �ؼ��ֵȲ�����
         DataView DefaultViewDataBind();
        #endregion


    }

}

