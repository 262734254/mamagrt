using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// 招商资源信息实体类
    /// </summary>
    public class MerchantInfoModel
    {
        public MerchantInfoModel()
		{}
		#region Model
		private long _infoid;
		private string _merchanttypeid;
        private string _merchanttypename;
		private string _industryclasslist;

        private List<string> _industryBName = new List<string>();

		private string _capitalcurrency;
		private decimal _capitaltotal;
		private string _merchantcurrency;
		private string _merchanttotal;
        private string _merchanttotalname;
		
        private string _cooperationdemandtype;
        private List<string> _cooperationdemandtypename = new List<string>();

		private string _countrycode;
        private string _countryName;
		private string _provinceid;
        private string _provincename;
		private string _cityid;
        private string _cityname;
		private string _countyid;
        private string _countyname;
		private string _zoneabout;
		private string _zoneaboutbrief;
		private string _receiveorganization;
		private int _merchantorganization;
		private string _remark;
        private string _vipabout;
        //以下是对招商信息的添加部分 
        private string _economicindicators;
        private string _investmentenvironment;
        private string _projectstatus;
        private string _market;
        private string _benefit;
        private int merchanreturns;//百分率
        /// <summary>
        /// //百分率
        /// </summary>
        public int Merchanreturns //百分率
        {
            get { return merchanreturns; }
            set { merchanreturns = value; }
        }
        //以下是2010-06-08 
          //信息完整度
        private int _informationintegrity;
         /// <summary>
         /// 信息完整度
         /// </summary>
        public int InformationIntegrity
        {
            set { _informationintegrity = value; }
            get { return _informationintegrity; }
        }
         //拓富认证
        private int _topcertification;
        public int TopCertification
        {
            set { _topcertification = value; }
            get { return _topcertification; }
        }
        //评价人气
        private int _evaluationpop;
        public int EvaluationPop
        {
            set { _evaluationpop = value; }
            get { return _evaluationpop; }

        }

         //

        /// <summary>
        /// 
        /// </summary>
        public string EconomicIndicators
        {
            set { _economicindicators = value; }
            get { return _economicindicators; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InvestmentEnvironment
        {
            set { _investmentenvironment = value; }
            get { return _investmentenvironment; }

        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectStatus
        {
            set { _projectstatus = value; }
            get { return _projectstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Market
        {
            set { _market = value; }
            get { return _market; }
        }
        public string Benefit
        {
            set { _benefit = value; }
            get { return _benefit; }
        }

        //新增的结束部分

        public string VipAbout
        {
            get { return _vipabout; }
            set { _vipabout = value; }
        }

        /// <summary>
        /// 所属行业
        /// </summary>
        public List<string> IndustryBName
        {
            set { _industryBName = value; }
            get { return _industryBName; }
        }

        /// <summary>
        /// 合作方式
        /// </summary>
        public List<string> CooperationDemandTypeName
        {
            set { _cooperationdemandtypename = value; }
            get { return _cooperationdemandtypename; }
        }


		/// <summary>
		/// InfoID
		/// </summary>
        public long InfoID
		{
			set{ _infoid=value;}
			get{return _infoid;}
		}
		/// <summary>
		/// MerchantTypeID
		/// </summary>
		public string MerchantTypeID
		{
			set{ _merchanttypeid=value;}
			get{return _merchanttypeid;}
		}

        public string MerchantTypeName
        {
            set { _merchanttypename = value; }
            get { return _merchanttypename; }
        }
		/// <summary>
		/// IndustryClassList
		/// </summary>
		public string IndustryClassList
		{
			set{ _industryclasslist=value;}
			get{return _industryclasslist;}
		}
		/// <summary>
		/// CapitalCurrency
		/// </summary>
		public string CapitalCurrency
		{
			set{ _capitalcurrency=value;}
			get{return _capitalcurrency;}
		}
		/// <summary>
		/// CapitalTotal
		/// </summary>
		public decimal CapitalTotal
		{
			set{ _capitaltotal=value;}
			get{return _capitaltotal;}
		}
		/// <summary>
		/// MerchantCurrency
		/// </summary>
		public string MerchantCurrency
		{
			set{ _merchantcurrency=value;}
			get{return _merchantcurrency;}
		}
		/// <summary>
		/// MerchantTotal
		/// </summary>
		public string MerchantTotal
		{
			set{ _merchanttotal=value;}
			get{return _merchanttotal;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string Merchanttotalname
        {
            get { return _merchanttotalname; }
            set { _merchanttotalname = value; }
        }
		/// <summary>
		/// CooperationDemandType
		/// </summary>
		public string CooperationDemandType
		{
			set{ _cooperationdemandtype=value;}
			get{return _cooperationdemandtype;}
		}
		/// <summary>
		/// CountryCode
		/// </summary>
		public string CountryCode
		{
			set{ _countrycode=value;}
			get{return _countrycode;}
		}
        /// <summary>
        /// CountryName
        /// </summary>
        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }
		/// <summary>
		/// ProvinceID
		/// </summary>
		public string ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
        public string ProvinceName
        {
            set { _provincename = value; }
            get { return _provincename; }
        }
		/// <summary>
		/// CityID
		/// </summary>
		public string CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
        public string CityName
        {
            set { _cityname = value; }
            get { return _cityname; }
        }
		/// <summary>
		/// CountyID
		/// </summary>
		public string CountyID
		{
			set{ _countyid=value;}
			get{return _countyid;}
		}
        public string CountyName
        {
            set { _countyname = value; }
            get { return _countyname; }
        }
		/// <summary>
		/// ZoneAbout
		/// </summary>
		public string ZoneAbout
		{
			set{ _zoneabout=value;}
			get{return _zoneabout;}
		}
		/// <summary>
		/// 区域介绍提炼
		/// </summary>
		public string ZoneAboutBrief
		{
			set{ _zoneaboutbrief=value;}
			get{return _zoneaboutbrief;}
		}
		/// <summary>
		/// ReceiveOrganization
		/// </summary>
		public string ReceiveOrganization
		{
			set{ _receiveorganization=value;}
			get{return _receiveorganization;}
		}
		/// <summary>
		/// MerchantOrganization
		/// </summary>
		public int MerchantOrganization
		{
			set{ _merchantorganization=value;}
			get{return _merchantorganization;}
		}
		/// <summary>
		/// Remrk
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}



        //修改属性08.6.2
        private int _sellstockshare;
        private string _returnmodeid;
        private string _projectabout;
        private string _marketabout;
        private string _competitioabout;
        private string _bussinessmodeabout;
        private string _manageteamabout;
        private string _warrant;
        private decimal _companyyearincome;
        private decimal _companyng;
        private decimal _companytotalcapital;
        private decimal _companytotaldebet;
        private string _financingid;
       
      
        /// <summary>
        /// 
        /// </summary>
        public int SellStockShare
        {
            set { _sellstockshare = value; }
            get { return _sellstockshare; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReturnModeID
        {
            set { _returnmodeid = value; }
            get { return _returnmodeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectAbout
        {
            set { _projectabout = value; }
            get { return _projectabout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string marketAbout
        {
            set { _marketabout = value; }
            get { return _marketabout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string competitioAbout
        {
            set { _competitioabout = value; }
            get { return _competitioabout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BussinessModeAbout
        {
            set { _bussinessmodeabout = value; }
            get { return _bussinessmodeabout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ManageTeamAbout
        {
            set { _manageteamabout = value; }
            get { return _manageteamabout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string warrant
        {
            set { _warrant = value; }
            get { return _warrant; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CompanyYearIncome
        {
            set { _companyyearincome = value; }
            get { return _companyyearincome; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CompanyNG
        {
            set { _companyng = value; }
            get { return _companyng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CompanyTotalCapital
        {
            set { _companytotalcapital = value; }
            get { return _companytotalcapital; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CompanyTotalDebet
        {
            set { _companytotaldebet = value; }
            get { return _companytotaldebet; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string financingID
        {
            set { _financingid = value; }
            get { return _financingid; }
        }

		#endregion Model
    }
    public class ExcavateMerchantInfoMode
    {
        public ExcavateMerchantInfoMode()
        {
        }
        #region --excavateMode--
        private long _id;
        private string _title;
        private string _prjCompany;
        private string _companyInfo;
        private string _prjContactMan;
        private string _prjTel;
        private string _prjInfo;
        private string _industry;
        private string _prjCountryName;
        private string _prjProvinceName;
        private string _requireMoney;
        private string _cooperateMode;
        private string _contactMan;
        private string _manTel;
        private string _manMobile;
        private string _manAddress;
        private string _manCode;
        private string _manTax;
        private string _manEmail;
        private string _webUrl;
        private string _publishTime;
        
        public string PublishTime
        {
            get { return _publishTime; }
            set { _publishTime = value; }
        }
        public string WebUrl
        {
            get { return _webUrl; }
            set { _webUrl = value; }
        }
        public string ManEmail 
        {
            get { return _manEmail; }
            set { _manEmail = value; }
        }
        public string ManTax
        {
            get { return _manTax; }
            set { _manTax = value; }
        }
        public string ManCode
        {
            get { return _manCode; }
            set { _manCode = value; }
        }
        public string ManAddress
        {
            get { return _manAddress; }
            set { _manAddress = value; }
        }
        public string ManMobile
        {
            get { return _manMobile; }
            set { _manMobile = value; }
        }
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string PrjCompany
        {
            get { return _prjCompany; }
            set { _prjCompany = value; }
        }
        public string CompanyInfo
        {
            get { return _companyInfo; }
            set { _companyInfo = value; }
        }
        public string PrjContactMan
        {
            get { return _prjContactMan; }
            set { _prjContactMan = value; }
        }
        public string PrjTel
        {
            get { return _prjTel; }
            set { _prjTel = value; }
        }
        public string PrjInfo
        {
            get { return _prjInfo; }
            set { _prjInfo = value; }
        }
        public string Industry
        {
            get { return _industry; }
            set { _industry = value; }
        }
        public string PrjCountryName
        {
            get { return _prjCountryName; }
            set { _prjCountryName = value; }
        }
        public string PrjProvinceName
        {
            get { return _prjProvinceName; }
            set { _prjProvinceName = value; }
        }
        public string RequireMoney
        {
            get { return _requireMoney; }
            set { _requireMoney = value; }
        }
        public string CooperateMode
        {
            get { return _cooperateMode; }
            set { _cooperateMode = value; }
        }
        public string ContactMan
        {
            get { return _contactMan; }
            set { _contactMan = value; }
        }
        public string ManTel
        {
            get { return _manTel; }
            set { _manTel = value; }
        }
        #endregion
    }
}
