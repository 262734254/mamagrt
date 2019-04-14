using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info.V124
{
    public class CapitalInfoModel
    {
        #region Model
        private long _infoid;
        private string _industrybid;
        private List<string> _industrybName = new List<string>();
        private string _cooperationdemandtype;
        private List<string> _cooperationdemandtypename = new List<string>();
        private string _currency;
        private string _capitalid;
        private string _capitalname;
        private string _capitaltypeid;
        private string _capitaltypename;
        private string _comabout;
        private string _combreif;
        private string _remrk;
        private int _isvip;
        private string _areaid;
        private string _provinceid;
        private string _cityid;
        private string _countyid;
        private int _stageid;
        private string _stageName;
        private int _joinmanageid;
        private string _joinmanagename;
        private string _cooperationdemandtyperemark;
        //对资本资源的2010-06-05新增的字段

        private string _registeredcapital;
        private string _teamscale;
        private string _averageinvestment;
        private string _successfulinvestment;
        private string _investmentdemand;
        private string _prorganizers;
        private string _Scountryid;
        private string _Sprovinceid;
        private string _Scityid;
        private string _Scountyid;
      //资本资源的人气 认证 完整度
       private int _evaluationpop;
          /// <summary>
       /// 评价人气(1.2.3.4.5星)
          /// </summary>
        public int EvaluationPop
       {
          set{_evaluationpop=value;}
          get{return _evaluationpop;}
       }
      private int _topcertification;
      /// <summary>
      /// 拓福认证
      /// </summary>
        public int TopCertification
      {
          set{_topcertification=value;}
          get{return _topcertification;}
      }

     private int _informationintegrity;
        /// <summary>
        /// 信息完整度（%）
        /// </summary>
     public int InformationIntegrity
     {
         set { _informationintegrity = value; }
         get { return _informationintegrity; }
     }





       /// <summary>
       ///  国家
       /// </summary>
     public string  SCountryID
     {
         set{_Scountryid=value;}
         get{return _Scountryid;}
     }
        /// <summary>
        /// 省
        /// </summary>
        public string SProvinceID
        {
          set{_Sprovinceid=value;}
            get{return _Sprovinceid;}
        }
        /// <summary>
        /// 市
        /// </summary>
        public string SCityID
        {
          set{_Scityid=value;}
          get{return _Scityid;}
        }
        /// <summary>
        ///  区 县
        /// </summary>
         public string SCountyID
         {
         
          set{_Scountyid=value;}
          get{return _Scountyid;}
         }
        /// <summary>
        /// 诚办单位
        /// </summary>
        public string Prorganizers
        {
            set { _prorganizers = value; }
            get { return _prorganizers; }
        }
     
        /// <summary>
        /// 机构注册资金
        /// </summary>
        public string RegisteredCapital
        {
            set{ _registeredcapital=value;}
            get{return _registeredcapital;}
        }
        /// <summary>
        /// 机构团队规模
        /// </summary>
        public string TeamScale
        {
            set{_teamscale=value;}
            get{return _teamscale;}
        }
        /// <summary>
        /// 机构年平均投资事件数
        /// </summary>
        public string AverageInvestment
        {
            set { _averageinvestment = value; }
            get { return _averageinvestment; }
        }
        /// <summary>
        /// 机构成功投资事件总数
        /// </summary>
        public string SuccessfulInvestment
        {
            set { _successfulinvestment = value; }
            get { return _successfulinvestment; }
        }
        /// <summary>
        /// 需求摘要
        /// </summary>
        public string InvestmentDemand
        {
            set { _investmentdemand = value; }
            get { return _investmentdemand; }
        }
        /// <summary>
        /// 所在区域
        /// </summary>
       




        //结束处

        /// <summary>
        /// InfoID
        /// </summary>
        public long InfoID
        {
            set { _infoid = value; }
            get { return _infoid; }
        }
        /// <summary>
        /// IndustryBID
        /// </summary>
        public string IndustryBID
        {
            set { _industrybid = value; }
            get { return _industrybid; }
        }
        /// <summary>
        /// 行业名称
        /// </summary>
        public List<string> IndustryBName
        {
            set { _industrybName = value; }
            get { return _industrybName; }
        }

        /// <summary>
        /// CooperationDemandType
        /// </summary>
        public string CooperationDemandType
        {
            set { _cooperationdemandtype = value; }
            get { return _cooperationdemandtype; }
        }
        /// <summary>
        /// 合作类型名称
        /// </summary>
        public List<string> CooperationDemandTypeName
        {
            set { _cooperationdemandtypename = value; }
            get { return _cooperationdemandtypename; }
        }
        /// <summary>
        /// currency
        /// </summary>
        public string currency
        {
            set { _currency = value; }
            get { return _currency; }
        }
        /// <summary>
        /// CapitalID
        /// </summary>
        public string CapitalID
        {
            set { _capitalid = value; }
            get { return _capitalid; }
        }
        /// <summary>
        /// 资本金额名称
        /// </summary>
        public string CapitalName
        {
            set { _capitalname = value; }
            get { return _capitalname; }
        }

        /// <summary>
        /// 资本类型ID
        /// </summary>
        public string CapitalTypeID
        {
            set { _capitaltypeid = value; }
            get { return _capitaltypeid; }
        }

        /// <summary>
        /// 资本类型名称
        /// </summary>
        public string CapitalTypeName
        {
            set { _capitaltypename = value; }
            get { return _capitaltypename; }
        }
        /// <summary>
        /// ComAbout
        /// </summary>
        public string ComAbout
        {
            set { _comabout = value; }
            get { return _comabout; }
        }
        /// <summary>
        /// 项目介绍提炼
        /// </summary>
        public string ComBreif
        {
            set { _combreif = value; }
            get { return _combreif; }
        }
        /// <summary>
        /// Remrk
        /// </summary>
        public string Remrk
        {
            set { _remrk = value; }
            get { return _remrk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isVIP
        {
            set { _isvip = value; }
            get { return _isvip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountyID
        {
            set { _countyid = value; }
            get { return _countyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int stageID
        {
            set { _stageid = value; }
            get { return _stageid; }
        }

        public string StageName
        {
            get { return _stageName; }
            set { _stageName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int joinManageID
        {
            set { _joinmanageid = value; }
            get { return _joinmanageid; }
        }

        public string Joinmanagename
        {
            get { return _joinmanagename; }
            set { _joinmanagename = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CooperationDemandTypeRemark
        {
            set { _cooperationdemandtyperemark = value; }
            get { return _cooperationdemandtyperemark; }
        }
        #endregion Model
    }
}
