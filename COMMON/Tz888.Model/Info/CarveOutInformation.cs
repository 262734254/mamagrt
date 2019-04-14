using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    public class CarveOutInformation
    {
        private string mstrCarveOutInfoType;							//��ҵ��Ϣ����
        private string mstrAdTitle;										//������
        private string mstrCountryName;									//������д
        private string mstrCountryCode;									//������д
        private string mstrProvinceID;									//ʡ��
        private string mstrProvinceName;								//ʡ��
        private string mstrCapitalCityID;								//����-�ؼ�����
        private string mstrCapitalCityName;								//����-�ؼ�����		
        private string mstrCountyID;									//����-����	
        private string mstrCountyName;									//����-����		
        private string mstrIndustryCarveOutID;							//��ҵ��ҵID
        private string mstrIndustryCarveOut;							//��ҵ��ҵ����
        private string mstrCapitalID;									//Ͷ�ʽ��ID
        private string mstrCapitalName;									//Ͷ�ʽ������
        private string mstrInvestObject;								//Ͷ�ʶ���
        private string mstrValidateID;									//����ʱЧID
        private string mstrValidateNum;								//����ʱЧ(����Ϊ��λ)
        private string mstrValidateName;							//����ʱЧ����
        private string mstrContent;										//Ͷ��Ҫ��
        private string mstrInvestReturn;								//�ر���ʽ
        private string mstrPic1;

        private string mstrRemark;										//��ע
        private string mstrComName;										//��˾����
        private string mstrLinkMan;										//��ϵ��
        private string mstrTel;											//�绰
        private string mstrFax;											//����
        private string mstrMobile;										//�ֻ�
        private string mstrAddress;										//��ַ
        private string mstrPostCode;									//�ʱ�
        private string mstrEmail;										//�����ʼ�
        private string mstrWebSite;										//��ַ	

        private string mstrNickName;
        private string mstrRoleName;
        #region ���ò���

        public string CarveOutInfoType//��ҵ��Ϣ����
        {
            get
            {
                return mstrCarveOutInfoType;
            }

            set
            {
                mstrCarveOutInfoType = value;
            }
        }
        public string AdTitle//������
        {
            get
            {
                return mstrAdTitle;
            }

            set
            {
                mstrAdTitle = value;
            }
        }

        public string CountryCode//������д
        {
            get
            {
                return mstrCountryCode;
            }

            set
            {
                mstrCountryCode = value;
            }
        }
        public string CountryName//������д
        {
            get
            {
                return mstrCountryName;
            }
        }

        public string ProvinceID//����-ʡ��
        {
            get
            {
                return mstrProvinceID;
            }

            set
            {
                mstrProvinceID = value;
            }
        }

        public string ProvinceName//����-ʡ��
        {
            get
            {
                return mstrProvinceName;
            }
        }

        public string CapitalCityID//����-�ؼ���
        {
            get
            {
                return mstrCapitalCityID;
            }
        }


        public string CapitalCityName//����-�ؼ���
        {
            get
            {
                return mstrCapitalCityName;
            }
        }
        public string CountyID//����-����
        {
            get
            {
                return mstrCountyID;
            }

            set
            {
                mstrCountyID = value;
            }
        }

        public string CountyName//����-����
        {
            get
            {
                return mstrCountyName;
            }
        }

        public string IndustryCarveOutID//��ҵ��ҵID
        {
            get
            {
                return mstrIndustryCarveOutID;
            }

            set
            {
                mstrIndustryCarveOutID = value;
            }
        }

        public string IndustryCarveOut//��ҵ��ҵID
        {
            get
            {
                return mstrIndustryCarveOut;
            }

            set
            {
                mstrIndustryCarveOut = value;
            }
        }

        public string CapitalID//Ͷ�ʽ��ID
        {
            get
            {
                return mstrCapitalID;
            }

            set
            {
                mstrCapitalID = value;
            }
        }

        public string CapitalName//Ͷ�ʽ��ID
        {
            get
            {
                return mstrCapitalName;
            }

            set
            {
                mstrCapitalName = value;
            }
        }

        public string InvestObject//Ͷ�ʶ���
        {
            get
            {
                return mstrInvestObject;
            }

            set
            {
                mstrInvestObject = value;
            }
        }

        public string ValidateID//����ʱЧ ID
        {
            get
            {
                return mstrValidateID;
            }

            set
            {
                mstrValidateID = value;
            }
        }

        public string ValidateNum//����ʱЧ
        {
            get
            {
                return mstrValidateNum;
            }
        }

        public string ValidateName//����ʱЧ����
        {
            get
            {
                return mstrValidateName;
            }
        }


        public string Content//����
        {
            get
            {
                return mstrContent;
            }

            set
            {
                mstrContent = value;
            }
        }

        public string InvestReturn//�ر���ʽ
        {
            get
            {
                return mstrInvestReturn;
            }

            set
            {
                mstrInvestReturn = value;
            }
        }

        public string Pic1
        {
            get
            {
                return mstrPic1;
            }

            set
            {
                mstrPic1 = value;
            }
        }
        public string Remark//��ע
        {
            get
            {
                return mstrRemark;
            }

            set
            {
                mstrRemark = value;
            }
        }

        public string ComName//��˾����
        {
            get
            {
                return mstrComName;
            }

            set
            {
                mstrComName = value;
            }
        }

        public string LinkMan//��ϵ��
        {
            get
            {
                return mstrLinkMan;
            }

            set
            {
                mstrLinkMan = value;
            }
        }

        public string Tel//�绰
        {
            get
            {
                return mstrTel;
            }

            set
            {
                mstrTel = value;
            }
        }

        public string Fax//����
        {
            get
            {
                return mstrFax;
            }

            set
            {
                mstrFax = value;
            }
        }

        public string Mobile//�ֻ�
        {
            get
            {
                return mstrMobile;
            }

            set
            {
                mstrMobile = value;
            }
        }

        public string Address//��ַ
        {
            get
            {
                return mstrAddress;
            }

            set
            {
                mstrAddress = value;
            }
        }

        public string PostCode//�ʱ�
        {
            get
            {
                return mstrPostCode;
            }

            set
            {
                mstrPostCode = value;
            }
        }

        public string Email//�����ʼ�
        {
            get
            {
                return mstrEmail;
            }

            set
            {
                mstrEmail = value;
            }
        }

        public string WebSite//��ַ
        {
            get
            {
                return mstrWebSite;
            }

            set
            {
                mstrWebSite = value;
            }
        }

        public string NickName
        {
            get
            {
                return mstrNickName;
            }

            set
            {
                mstrNickName = value;
            }
        }

        public string RoleName
        {
            get
            {
                return mstrRoleName;
            }

            set
            {
                mstrRoleName = value;
            }
        }
        #endregion
    }
}
