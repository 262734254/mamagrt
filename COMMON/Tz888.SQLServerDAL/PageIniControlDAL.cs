using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.IDAL;
namespace Tz888.SQLServerDAL
{
   public class PageIniControlDAL : IPageIniControl
    {
        public Tz888.SQLServerDAL.Conn obj;
        public PageIniControlDAL()
        {
            obj = new Tz888.SQLServerDAL.Conn();
        }
        #region ����ҵ	���ݰ�
        /// <summary>
        /// ����ҵ	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataTable  IndustryBDataBind()
        {

            return obj.GetList("SetIndustryBTab", "*", "IndustryBID", 100, 1, 0, 1, "");
        }

        public DataView IndustryBDataBind2()
        {

            return new DataView(); 
        }
        #endregion

        #region ��ҵ��ҵ����	���ݰ�
        /// <summary>
        /// ��ҵ��ҵ	���ݰ�
        /// </summary>
        /// 			/// <returns></returns>
        public DataView IndustryCarveOutDataBind()
        {
            return new DataView();
        }

        #endregion

        #region �̻���ҵ����	���ݰ�
        /// <summary>
        /// ���̻���ҵ	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView IndustryOpportunityDataBind()
        {
            return new DataView();
        }

        #endregion

        #region �ɹ���������	���ݰ�
        /// <summary>
        /// �ɹ���������	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView CaseDataBind()
        {
            return new DataView();
        }

        #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// �ɹ���������	���ݰ�
        /// </summary>
        /// <returns></returns>
        public  DataView BulletinDataBind()
        {
            return new DataView();
        }

        #endregion

        #region ���λ��	���ݰ�
        /// <summary>
        /// �������	���ݰ�
        /// </summary>
        /// <returns></returns>
        public  DataView ADLocationDataBind()
        {
            return new DataView();
        }

        #endregion

        #region ��ҵ��Ӣ����	���ݰ�
        /// <summary>
        /// ��ҵ��Ӣ����	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView EliteDataBind()
        {
            return new DataView();
        }

        #endregion

        #region չ����ҵ����	���ݰ�
        /// <summary>
        /// չ����ҵ����	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView ExhibitionDataBind()
        {
            return new DataView();
        }

        #endregion

        #region Ͷ�ʽ��	���ݰ�
        /// <summary>
        /// Ͷ�ʽ��	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataTable CaptitalDataBind()
        {
            return obj.GetList("SetCapitalTab", "*", "CapitalID", 100, 1, 0, 1, "");
        }
        #endregion

        #region Ͷ�ʽ��	���ݰ�
        /// <summary>
        /// Ͷ�ʽ��	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView MemberQuantityDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ��ҵ�ʽ�����	���ݰ�
        /// <summary>
        /// �ʱ�����	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView CapitalCarveOutDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ����ʱЧ	���ݰ�
        /// <summary>
        /// ����ʱЧ	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView ValidateDateDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ����ʱЧ	���ݰ�
        /// <summary>
        /// ����ʱЧ	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView OpportunityTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ��Ϣ����	���ݰ�
        /// <summary>
        /// ��Ϣ����	���ݰ� 
        /// </summary>
        /// <returns></returns>
        public DataView FixPriceDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ��Ϣ����	���ݰ�
        /// <summary>
        /// ��Ϣ����	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView GradeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// ��������	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataTable MerchantTypeDataBind()
        {
            return obj.GetList("SetMerchantTypeTab", "*", "MerchantTypeID", 100, 1, 0, 1, "");
        }
        #endregion

        #region �ʱ�����	���ݰ�
        /// <summary>
        /// �ʱ�����	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataTable CaptitalTypeDataBind()
        {
            return obj.GetList("SetCapitalTypeTab", "*", "CapitalTypeID", 100, 1, 0, 1, "");
        }
           #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// ��������	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView NewsTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ����������	���ݰ�
        /// <summary>
        /// ����������	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView AreaDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ������ҵ����	���ݰ�
        /// <summary>
        /// ��Ϣ����	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView NewsIndustyDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ����  ���ݰ�
        /// <summary>
        /// ����  ���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView CountryDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ʡ�� ���ݰ�
       
        /// <summary>
        /// ʡ�� ���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataTable ProvinceDataBind(string CountryCode)
        {
            string mstrCriteria = "";

            if (CountryCode != null)
            {
                mstrCriteria = "ProvinceID <> '0000' and CountryCode = '" + CountryCode + "'";
            }

            DataTable dt = obj.GetList("SetProvinceVIW", "*", "ProvinceID", 100, 1, 0, 1, "");
            dt = CleanSpace(dt, "ProvinceID");
            return dt;
        }
        #endregion

        #region-- ��Ѷ���� ---------------
        /// <summary>
        /// ��ѯ�б�
        /// </summary>		
        /// <returns>�б�</returns>
        public DataTable GetList()
        {
            return obj.GetList("SetNewsTypeTab", "*", "NewsTypeID", 100, 1, 0, 1, "newstypeName in( '���̶�̬',  'Ͷ�ʶ�̬',  '���ʶ�̬', '�̻���Ѷ',	'��ҵ��Ѷ',  '����Ҫ��',  'չ����Ѷ',  '�Ż�����',  '���߷���')");
        }
        #endregion

        #region-- ��ҵ��ҵ ---------------
        /// <summary>
        /// ��ѯ�б�
        /// </summary>		
        /// <returns>�б�</returns>
        public DataTable GetListIndustryCarveout()
        {
           return obj.GetList("SetIndustryCraveOutTab", "*", "IndustryCarveoutID", 100, 1, 0, 1, "");
        }
        #endregion

        #region-- �̻� ---------------
        /// <summary>
        /// ��ѯ�б�
        /// </summary>		
        /// <returns>�б�</returns>
        public DataTable GetListIndustryOppor()
        {
            return obj.GetList("SetIndustryOpportunityTab", "*", "IndustryOpportunityID", 100, 1, 0, 1, "");
        }
        #endregion

        #region �ؼ��� ���ݰ�
        /// <summary>
        /// �ؼ��� ���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView CapitalCityDataBind(string ProvinceID)
        {
            return new DataView();
        }
        #endregion

        #region �ؼ���  ���ݰ�
        /// <summary>
        /// �ؼ���  ���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView CountyDataBind(string CapitalCityID)
        {
            return new DataView();
        }
        #endregion

        #region �ؼ���  ���ݰ�
        /// <summary>
        /// �ؼ���  ���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView AreaByCapitalCityDataBind(string CapitalCityID)
        {
            return new DataView();
        }
        #endregion

        #region ֤������	���ݰ�
        /// <summary>
        /// ֤������	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView CertificateDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView DeptInfoDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ְ������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView WorkTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ѧ������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView DegreeInfoDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ��ɫ������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView RoleGroupDataBind()
        {
            return new DataView();
        }
        #endregion

        #region �˵�Ȩ�޲�������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView MenuTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ϵͳȨ�޲�������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView SystemTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ��ϢȨ�޲�������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView InfoOPPDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ��Ϣ����	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView InfoTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ��ɫ����	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView WorkTypeActiveDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ��Ϣ��ʾ��Ŀ�ؼ�	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView InfoControlDataBind(string InfoTypeID, string WebSiteLoginName)
        {
            return new DataView();
        }
        #endregion

        #region ��Ϣ��ʾ��Ŀ�ؼ�	���ݰ�
        /// <summary>
        ///	  ������Ϣ������ѡ����Ŀ�ؼ�
        /// </summary>
        /// <returns></returns>
        public DataView InfoControlDataBindByInfoType(string InfoTypeID)
        {
            return new DataView();
        }
        #endregion

        #region ��Ϣ��ʾ��վ���пؼ�	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView InfoControlDataBind(string WebSiteLoginName)
        {
            return new DataView();
        }
        #endregion

        #region ר������	���ݰ�
        /// <summary>
        /// ר������	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView ExpertTypeDataBind()
        {
            return new DataView();
        }

        #endregion

        #region ר������	���ݰ�
        /// <summary>
        /// ר������	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView ExpertTypeDataBind(string strExpertTypeID)
        {
            return new DataView();
        }

        #endregion

        #region ��ȡ��Ƭ���ͱ�
        public DataView GetCardTypeList()
        {
            return new DataView();
        }
        #endregion

        #region ר������	���ݰ�
        /// <summary>
        /// ר������	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView ExpertInfoDataBind(string strLoginName)
        {
            return new DataView();
        }

        #endregion

        #region ר������	���ݰ�
        /// <summary>
        /// ר������	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView ExpertNameDataBind(string loginid)
        {
            return new DataView();
        }

        #endregion

        #region ��Աְλ����	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView PositionDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ��ѯר�������Ϣ
        /// <summary>
        /// ר������	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataView GetExpertMessage(string ExpertLoginName)
        {
            return new DataView();
        }
        #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView AttractCapitalTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView FeedbackSDataBind()
        {
            return new DataView();
        }
        #endregion

        #region ��������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView FeedbackBDataBind()
        {
            return new DataView();
        }
        #endregion
        

        #region ��������	���ݰ�
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataTable IndustryMDataBind(string IndustryBID)
        {
            string Criteria = "";
            if (IndustryBID != null &&
                IndustryBID.Trim() != "")
            {
                Criteria = "IndustryBID='" + IndustryBID + "'";
            }
            return obj.GetList("SetIndustryMTab", "*", "IndustryMID", 100, 1, 0, 1, Criteria);
        }
        #endregion


        #region ��DATAVIEW����������ո�
        public  DataTable CleanSpace(DataTable DealDV, string DealCol)
        {
            int DVItemCount = DealDV.Rows.Count;
            for (int i = 0; i < DVItemCount; i++)
            {
                DealDV.Rows[i][DealCol] = DealDV.Rows[i][DealCol].ToString().Trim();
            }
            return DealDV;
        }
        #endregion

        #region ��ʼ������������
        public  DataView ADTypeDataBind()//�������
        {
            return new DataView();
        }
        /// <summary>
        /// ���λ��
        /// </summary>
        /// <param name="SiteType">���λ����.0:��վ 1����վ ���ַ�����ȫ��</param>
        /// <returns>����DV</returns>
        public  DataView ADLocationDataBind(string SiteType)//���λ
        {
            return new DataView();

        }

        /// <summary>
        /// վ ���
        /// </summary>
        /// <param name="roleType">��ɫ���� 0:������ 2:�ڲ�Ա��</param>
        /// <param name="loginName">��¼��,�����ڲ�Ա�����˲�������ʹ��</param>
        /// <returns></returns>

        public  DataView ADSiteDataBind(string roleType, string loginName)//վ��
        {
            return new DataView();
        }


        #endregion

        #region �ؼ��ֵȲ�����
        public DataView DefaultViewDataBind()
        {
            return new DataView();
        }
        #endregion

       #region �������� ���ݰ�
       public DataTable SETfinancingTargetTabBind()
       {
           return obj.GetList("SETfinancingTargetTab", "*", "financingID", 100, 1, 0, 1, "");
       }
       #endregion

    }

}


		
