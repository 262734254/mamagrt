using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class PageIniControl
    {
        private readonly IPageIniControl dal = DataAccess.CreateIPageIniControl();
        public PageIniControl()
        {

        }
        #region ����ҵ	���ݰ�
        /// <summary>
        /// ����ҵ	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataTable IndustryBDataBind()
        {
            return dal.IndustryBDataBind();
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
        public static DataView BulletinDataBind()
        {
            return new DataView();
        }

        #endregion

        #region ���λ��	���ݰ�
        /// <summary>
        /// �������	���ݰ�
        /// </summary>
        /// <returns></returns>
        public static DataView ADLocationDataBind()
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
            return dal.CaptitalDataBind();
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
            return dal.MerchantTypeDataBind();
        }
        #endregion

        #region �ʱ�����	���ݰ�
        /// <summary>
        /// �ʱ�����	���ݰ�
        /// </summary>
        /// <returns></returns>
        public DataTable CaptitalTypeDataBind()
        {
            return dal.CaptitalTypeDataBind();
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
            return dal.ProvinceDataBind(CountryCode);
        }
        #endregion

        #region-- ��Ѷ���� ---------------
        /// <summary>
        /// ��ѯ�б�
        /// </summary>		
        /// <returns>�б�</returns>
        public DataTable GetList()
        {
            return dal.GetList();
        }
        #endregion

        #region-- ��ҵ��ҵ ---------------
        /// <summary>
        /// ��ѯ�б�
        /// </summary>		
        /// <returns>�б�</returns>
        public DataTable GetListIndustryCarveout()
        {
            return dal.GetListIndustryCarveout();
        }
        #endregion

        #region-- �̻� ---------------
        /// <summary>
        /// ��ѯ�б�
        /// </summary>		
        /// <returns>�б�</returns>
        public DataTable GetListIndustryOppor()
        {
            return dal.GetListIndustryOppor();
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
            return dal.IndustryMDataBind(IndustryBID);
        }
        #endregion


        #region ��DATAVIEW����������ո�
        public DataTable CleanSpace(DataTable DealDV, string DealCol)
        {
            return dal.CleanSpace(DealDV, DealCol);
        }
        #endregion

        #region ��ʼ������������
        public static DataView ADTypeDataBind()//�������
        {
            return new DataView();
        }
        /// <summary>
        /// ���λ��
        /// </summary>
        /// <param name="SiteType">���λ����.0:��վ 1����վ ���ַ�����ȫ��</param>
        /// <returns>����DV</returns>
        public static DataView ADLocationDataBind(string SiteType)//���λ
        {
            return new DataView();

        }

        /// <summary>
        /// վ ���
        /// </summary>
        /// <param name="roleType">��ɫ���� 0:������ 2:�ڲ�Ա��</param>
        /// <param name="loginName">��¼��,�����ڲ�Ա�����˲�������ʹ��</param>
        /// <returns></returns>

        public static DataView ADSiteDataBind(string roleType, string loginName)//վ��
        {
            return new DataView();
        }


        #endregion

        #region �ؼ��ֵȲ�����
        public DataView DefaultViewDataBind(Tz888.Model.Info.MainInfoModel model)
        {
            Tz888.BLL.Info.SetDefaultValue bll = new Tz888.BLL.Info.SetDefaultValue();
            DataView dv = bll.GetValue(model);
            if (dv != null && dv.Count > 0)
            {
                for (int i = 0; i < dv.Count; i++)
                {
                    if (dv[i]["FromColumn"].ToString().Trim() != "")
                    {
                        dv[i]["FromColumnName"] = dv[i]["FromColumnName"].ToString().Trim() + "[�ֶ�]";
                    }
                }
            }
            return dv;
        }
        #endregion

        #region �������� ���ݰ�
        public DataTable SETfinancingTargetTabBind()
        {
            Tz888.SQLServerDAL.PageIniControlDAL Dal = new Tz888.SQLServerDAL.PageIniControlDAL();
            return Dal.SETfinancingTargetTabBind();
        }
        #endregion
    }

}


