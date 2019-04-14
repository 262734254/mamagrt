using System;
namespace Tz888.Model
{
    /// <summary>
    /// 实体类UserTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class WebUnion_UserInfo
    {
        public WebUnion_UserInfo()
        { }
        #region Model
        private int _userid;
        private string _username;
        private string _password;
        private string _companyname;
        private string _countrycode;
        private string _provinceid;
        private string _cityid;
        private string _countyid;
        private string _industryid;
        private string _serviesbid;
        private string _serviesmid;
        private int _employeecount;
        private decimal _registmoeny;
        private decimal _registyear;
        private decimal _turnover;
        private string _businesdetails;
        private string _website;
        private string _linkman;
        private string _linktel;
        private string _linkfax;
        private string _email;
        private bool _isopen;
        private DateTime _submitdate;
        private int _auditstatus;
        private DateTime _auditdate;
        private string _auditman;
        private string _qqmsn;

        //网站联盟注册会员的网站信息 
        private int _netid; 
        private string _netname;
        private string _netdomain;
        private string _netdescript;
        private string _netcallnum;
        private string _nettype;
        private string _netremark;
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PassWord
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountryCode
        {
            set { _countrycode = value; }
            get { return _countrycode; }
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
        public string IndustryID
        {
            set { _industryid = value; }
            get { return _industryid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ServiesBID
        {
            set { _serviesbid = value; }
            get { return _serviesbid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ServiesMID
        {
            set { _serviesmid = value; }
            get { return _serviesmid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeCount
        {
            set { _employeecount = value; }
            get { return _employeecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RegistMoeny
        {
            set { _registmoeny = value; }
            get { return _registmoeny; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RegistYear
        {
            set { _registyear = value; }
            get { return _registyear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Turnover
        {
            set { _turnover = value; }
            get { return _turnover; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BusinesDetails
        {
            set { _businesdetails = value; }
            get { return _businesdetails; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WebSite
        {
            set { _website = value; }
            get { return _website; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkTel
        {
            set { _linktel = value; }
            get { return _linktel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkFax
        {
            set { _linkfax = value; }
            get { return _linkfax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isOpen
        {
            set { _isopen = value; }
            get { return _isopen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime SubmitDate
        {
            set { _submitdate = value; }
            get { return _submitdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AuditStatus
        {
            set { _auditstatus = value; }
            get { return _auditstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AuditDate
        {
            set { _auditdate = value; }
            get { return _auditdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditMan
        {
            set { _auditman = value; }
            get { return _auditman; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string QQMSN
        {
            set { _qqmsn = value; }
            get { return _qqmsn; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int NetID
        {
            set { _netid = value; }
            get { return _netid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NetName
        {
            set { _netname = value; }
            get { return _netname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NetDomain
        {
            set { _netdomain = value; }
            get { return _netdomain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NetDescript
        {
            set { _netdescript = value; }
            get { return _netdescript; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NetCallnum
        {
            set { _netcallnum = value; }
            get { return _netcallnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NetType
        {
            set { _nettype = value; }
            get { return _nettype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NetRemark
        {
            set { _netremark = value; }
            get { return _netremark; }
        }
        #endregion Model


    }
}

