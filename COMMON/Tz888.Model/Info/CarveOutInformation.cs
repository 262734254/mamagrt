using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    public class CarveOutInformation
    {
        private string mstrCarveOutInfoType;							//创业信息类型
        private string mstrAdTitle;										//广告标题
        private string mstrCountryName;									//国家缩写
        private string mstrCountryCode;									//国家缩写
        private string mstrProvinceID;									//省份
        private string mstrProvinceName;								//省份
        private string mstrCapitalCityID;								//区域-地级市县
        private string mstrCapitalCityName;								//区域-地级市县		
        private string mstrCountyID;									//区域-市县	
        private string mstrCountyName;									//区域-市县		
        private string mstrIndustryCarveOutID;							//创业行业ID
        private string mstrIndustryCarveOut;							//创业行业名称
        private string mstrCapitalID;									//投资金额ID
        private string mstrCapitalName;									//投资金额名称
        private string mstrInvestObject;								//投资对象
        private string mstrValidateID;									//发布时效ID
        private string mstrValidateNum;								//发布时效(以月为单位)
        private string mstrValidateName;							//发布时效名称
        private string mstrContent;										//投资要求
        private string mstrInvestReturn;								//回报形式
        private string mstrPic1;

        private string mstrRemark;										//备注
        private string mstrComName;										//公司名称
        private string mstrLinkMan;										//联系人
        private string mstrTel;											//电话
        private string mstrFax;											//传真
        private string mstrMobile;										//手机
        private string mstrAddress;										//地址
        private string mstrPostCode;									//邮编
        private string mstrEmail;										//电子邮件
        private string mstrWebSite;										//网址	

        private string mstrNickName;
        private string mstrRoleName;
        #region 设置参数

        public string CarveOutInfoType//创业信息类型
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
        public string AdTitle//广告标题
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

        public string CountryCode//国家缩写
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
        public string CountryName//国家缩写
        {
            get
            {
                return mstrCountryName;
            }
        }

        public string ProvinceID//区域-省份
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

        public string ProvinceName//区域-省份
        {
            get
            {
                return mstrProvinceName;
            }
        }

        public string CapitalCityID//区域-地级市
        {
            get
            {
                return mstrCapitalCityID;
            }
        }


        public string CapitalCityName//区域-地级市
        {
            get
            {
                return mstrCapitalCityName;
            }
        }
        public string CountyID//区域-市县
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

        public string CountyName//区域-市县
        {
            get
            {
                return mstrCountyName;
            }
        }

        public string IndustryCarveOutID//创业行业ID
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

        public string IndustryCarveOut//创业行业ID
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

        public string CapitalID//投资金额ID
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

        public string CapitalName//投资金额ID
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

        public string InvestObject//投资对象
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

        public string ValidateID//发布时效 ID
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

        public string ValidateNum//发布时效
        {
            get
            {
                return mstrValidateNum;
            }
        }

        public string ValidateName//发布时效名称
        {
            get
            {
                return mstrValidateName;
            }
        }


        public string Content//内容
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

        public string InvestReturn//回报形式
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
        public string Remark//备注
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

        public string ComName//公司名称
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

        public string LinkMan//联系人
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

        public string Tel//电话
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

        public string Fax//传真
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

        public string Mobile//手机
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

        public string Address//地址
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

        public string PostCode//邮编
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

        public string Email//电子邮件
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

        public string WebSite//网址
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
