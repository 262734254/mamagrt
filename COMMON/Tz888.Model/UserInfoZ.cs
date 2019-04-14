using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class UserInfoZ
    {
        #region Model
        private int _infoid;
        private string _username;
        private string _companyname;
        private string _countrycode;
        private string _provinceid;
        private string _cityid;
        private string _countyid;
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
        private string _companyabout;
        private string _structid;

        public string Structid
        {
            get { return _structid; }
            set { _structid = value; }
        }
        public string CompanyAbout
        {
            set { _companyabout = value; }
            get { return _companyabout; }
        }
        private bool _contactdefault;
        public bool ContactDefault
        {
            set { _contactdefault = value; }
            get { return _contactdefault; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InfoID
        {
            set { _infoid = value; }
            get { return _infoid; }
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
        #endregion Model
    }
}
