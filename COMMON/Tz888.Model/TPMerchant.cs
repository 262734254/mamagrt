using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class TPMerchant
    {
        #region ��Ѷ
        private long _infoID;
        private string _Title;
        private DateTime _publishT;
        private long _Hit;
        private int _IsCore;
        private string _LoginName;
        private string _KeyWord;
        private string _Descript;
        private string _DisplayTitle;
        private DateTime _FrontDisplayTime;
        private DateTime _ValidateStartTime;
        private int _ValidateTerm;
        private string _TemplateID;
        private string _HtmlFile;
        private int _auditingstatus;
        private string _NewsTypeID;
        private string _NewsTypeName;
        private string _subTitle;
        private string _NewsLblStatus; 
        private string _NewsIndustryID;
        private string _Origin;
        private string _Author;
        private string _RedirectUrl;
        private int _IsRedirect;
        private string _Summary;
        private string _Content;
        private string _Pic1;
        private string _PicAbout;
        private int _PageStatus;
        private int _PageCharCount;
        private string _ShortInfoControlID;
        private string _ShortTitle;
        private string _ShortContent;
        private string _strRemark;
        private string _ResearchSpot;
        private string _ProvinceID;
        private string _CityID;
        private string _CountyID;
        private string _InfoCode;
        private string _activeAdress;
        private string _activeDateFrom;
        private string _activeDateTo;
        private string _mainUnit;
        private string _secondUnit;
        private string _OrganizationName;
        private string _Name;
        private string _TelCountryCode;
        private string _TelStateCode;
        private string _TelNum;
        private string _FaxCountryCode;
        private string _FaxStateCode;
        private string _FaxNum;
        private string _Mobile;
        private string _address;
        private string _WebSite;
        private string _PostCode;
        private string _Email;
        private string _AuditingRemark;
        private string _NickName;
        private string _RoleName;
        /// <summary>
        /// ��ϢID
        /// </summary>
        public long infoID
        {
            set { _infoID = value; }
            get { return _infoID; }
        }
        /// <summary>
        /// ��Ѷ����
        /// </summary>
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }
        /// <summary>
        /// ��¼����
        /// </summary>
        public string LoginName
        {
            set { _LoginName = value; }
            get { return _LoginName; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime publishT
        {
            set { _publishT = value; }
            get { return _publishT; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public long Hit
        {
            set { _Hit = value; }
            get { return _Hit; }
        }
        /// <summary>
        ///  �Ƿ��ص�
        /// </summary>
        public int IsCore
        {
            set { _IsCore = value; }
            get { return _IsCore; }
        }
        /// <summary>
        /// ��ǩ
        /// </summary>
        public string KeyWord
        {
            set { _KeyWord = value; }
            get { return _KeyWord; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Descript
        {
            set { _Descript = value; }
            get { return _Descript; }
        }
        /// <summary>
        /// �̱���
        /// </summary>
        public string DisplayTitle
        {
            set { _DisplayTitle = value; }
            get { return _DisplayTitle; }
        }
        /// <summary>
        /// չ��ʱ��
        /// </summary>
        public DateTime FrontDisplayTime
        {
            set { _FrontDisplayTime = value; }
            get { return _FrontDisplayTime; }
        }
        /// <summary>
        /// ��Чʱ��
        /// </summary>
        public DateTime ValidateStartTime
        {
            set { _ValidateStartTime = value; }
            get { return _ValidateStartTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ValidateTerm
        {
            set { _ValidateTerm = value; }
            get { return _ValidateTerm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TemplateID
        {
            set { _TemplateID = value; }
            get { return _TemplateID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HtmlFile
        {
            set { _HtmlFile = value; }
            get { return _HtmlFile; }
        } 

        /// <summary>
        ///״̬
        /// </summary>
        public int auditingstatus
        {
            set { _auditingstatus = value; }
            get { return _auditingstatus; }
        }
        /// <summary>
        /// ��Ѷ����
        /// </summary>
        public string NewsTypeID
        {
            set { _NewsTypeID = value; }
            get { return _NewsTypeID; }
        }
        /// <summary>
        /// ��Ѷ����
        /// </summary>
        public string NewsTypeName
        {
            set { _NewsTypeName = value; }
            get { return _NewsTypeName; }
        }

        /// <summary>
        /// �̱��� 
        /// </summary>
        public string subTitle
        {
            set { _subTitle = value; }
            get { return _subTitle; }
        }
        /// <summary>
        /// ��Ѷ��ǩ״̬
        /// </summary>
        public string NewsLblStatus
        {
            set { _NewsLblStatus = value; }
            get { return _NewsLblStatus; }
        }

        /// <summary>
        /// ��Ѷ��ҵ
        /// </summary>
        public string NewsIndustryID
        {
            set { _NewsIndustryID = value; }
            get { return _NewsIndustryID; }
        }
        /// <summary>
        /// ��Ѷ��Դ
        /// </summary>
        public string Origin
        {
            set { _Origin = value; }
            get { return _Origin; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Author
        {
            set { _Author = value; }
            get { return _Author; }
        }
        /// <summary>
        /// ת������
        /// </summary>
        public string RedirectUrl
        {
            set { _RedirectUrl = value; }
            get { return _RedirectUrl; }
        }
        /// <summary>
        /// �Ƿ�ʹ��ת������
        /// </summary>
        public int IsRedirect
        {
            set { _IsRedirect = value; }
            get { return _IsRedirect; }
        }
        /// <summary>
        /// ��ѶժҪ
        /// </summary>
        public string Summary
        {
            set { _Summary = value; }
            get { return _Summary; }
        }
        /// <summary>
        /// ��Ѷ���� 
        /// </summary>
        public string Content
        {
            set { _Content = value; }
            get { return _Content; }
        }
        /// <summary>
        /// ͼƬ·��
        /// </summary>
        public string Pic1
        {
            set { _Pic1 = value; }
            get { return _Pic1; }

        }
        /// <summary>
        /// ͼƬ���
        /// </summary>
        public string PicAbout
        {
            set { _PicAbout = value; }
            get { return _PicAbout; }

        }
        /// <summary>
        /// ���ݷ�ҳ
        /// </summary>
        public int PageStatus
        {
            set { _PageStatus = value; }
            get { return _PageStatus; }

        }
        /// <summary>
        /// �Զ���ҳÿҳ�ַ�����
        /// </summary>
        public int PageCharCount
        {
            set { _PageCharCount = value; }
            get { return _PageCharCount; }

        }
        /// <summary>
        /// ժҪid
        /// </summary>
        public string ShortInfoControlID
        {
            set { _ShortInfoControlID = value; }
            get { return _ShortInfoControlID; }

        }
        /// <summary>
        /// �̱���
        /// </summary>
        public string ShortTitle
        {
            set { _ShortTitle = value; }
            get { return _ShortTitle; }

        }
        /// <summary>
        /// ��Ҫ
        /// </summary>
        public string ShortContent
        {
            set { _ShortContent = value; }
            get { return _ShortContent; }

        }
        public string strRemark
        {
            set { _strRemark = value; }
            get { return _strRemark; }

        }
        /// <summary>
        /// ������ҵ�۽����о��ɹ�����������
        /// </summary>
        public string ResearchSpot
        {
            set { _ResearchSpot = value; }
            get { return _ResearchSpot; }

        }
        /// <summary>
        /// ����ʡ��
        /// </summary>
        public string ProvinceID
        {
            set { _ProvinceID = value; }
            get { return _ProvinceID; }

        }
        /// <summary>
        /// �����м�
        /// </summary>
        public string CityID
        {
            set { _CityID = value; }
            get { return _CityID; }

        }
        /// <summary>
        /// �����ؼ�
        /// </summary>
        public string CountyID
        {
            set { _CountyID = value; }
            get { return _CountyID; }

        }

        /// <summary>
        ///  ��Ϣ��ʶ
        /// </summary>
        public string InfoCode
        {
            set { _InfoCode = value; }
            get { return _InfoCode; }

        }
        #endregion��

        /// <summary>
        ///  ���ַ
        /// </summary>
        public string activeAdress
        {
            set { _activeAdress = value; }
            get { return _activeAdress; }

        } 

        /// <summary>
        ///  ���ʼʱ��
        /// </summary>
        public string activeDateFrom
        {
            set { _activeDateFrom = value; }
            get { return _activeDateFrom; }

        } 

        /// <summary>
        ///  �����ʱ��
        /// </summary>
        public string activeDateTo
        {
            set { _activeDateTo = value; }
            get { return _activeDateTo; }

        }��

        /// <summary>
        ///  ���쵥λ
        /// </summary>
        public string mainUnit
        {
            set { _mainUnit = value; }
            get { return _mainUnit; }

        }��
        /// <summary>
        ///  �а쵥λ
        /// </summary>
        public string secondUnit
        {
            set { _secondUnit = value; }
            get { return _secondUnit; }

        }����
        /// <summary>
        ///  ��ί������
        /// </summary>
        public string OrganizationName
        {
            set { _OrganizationName = value; }
            get { return _OrganizationName; }

        }
        /// <summary>
        ///  ��ϵ������
        /// </summary>
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }

        }
        /// <summary>
        ///  ��ϵ�˵绰
        /// </summary>
        public string TelCountryCode
        {
            set { _TelCountryCode = value; }
            get { return _TelCountryCode; }

        }
        /// <summary>
        ///  ��ϵ�˵绰
        /// </summary>
        public string TelStateCode
        {
            set { _TelStateCode = value; }
            get { return _TelStateCode; }

        }
        /// <summary>
        ///  ��ϵ�˵绰
        /// </summary>
        public string TelNum
        {
            set { _TelNum = value; }
            get { return _TelNum; }

        }
        /// <summary>
        ///  ��ϵ�˴���
        /// </summary>
        public string FaxCountryCode
        {
            set { _FaxCountryCode = value; }
            get { return _FaxCountryCode; }

        }
        /// <summary>
        ///  ��ϵ�˴���
        /// </summary>
        public string FaxStateCode
        {
            set { _FaxStateCode = value; }
            get { return _FaxStateCode; }

        }
        /// <summary>
        ///  ��ϵ�˴���
        /// </summary>
        public string FaxNum
        {
            set { _FaxNum = value; }
            get { return _FaxNum; }

        }
        /// <summary>
        ///  ��ϵ���ֻ�
        /// </summary>
        public string Mobile
        {
            set { _Mobile = value; }
            get { return _Mobile; }

        }
        /// <summary>
        ///  ��ϵ�˵�ַ
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }

        }
        /// <summary>
        ///  ��ַ
        /// </summary>
        public string WebSite
        {
            set { _WebSite = value; }
            get { return _WebSite; }

        }
        /// <summary>
        ///  �ʱ�
        /// </summary>
        public string PostCode
        {
            set { _PostCode = value; }
            get { return _PostCode; }

        }
        /// <summary>
        ///  E-mail
        /// </summary>
        public string Email
        {
            set { _Email = value; }
            get { return _Email; }

        }

        /// <summary>
        /// ������� 
        /// </summary>
        public string AuditingRemark
        {
            set { _AuditingRemark = value; }
            get { return _AuditingRemark; }
        }

        /// <summary>
        ///  
        /// </summary>
        public string NickName
        {
            set { _NickName = value; }
            get { return _NickName; }
        }

        /// <summary>
        ///   
        /// </summary>
        public string RoleName
        {
            set { _RoleName = value; }
            get { return _RoleName; }
        }
        
    } 
  
}
