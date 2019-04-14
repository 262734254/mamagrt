using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    /// <summary>
    /// 公司登记实体类Enterprise 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Enterprise
    {
        public Enterprise()
        { }
      
        #region Model  公司登记信息
        private int _enterpriseid;
        private string _loginname;
        private string _enterprisename;
        private string _managetypeid;
        private string _industrylist;
        private DateTime _registerdate;
        private string _countrycode;
        private string _provinceid;
        private string _cityid;
        private string _countyid;
        private string _currency;
        private decimal _regcapital;
        private string _mainproduct;
        private string _requirinfo;
        private int _auditingstatus;
        private string _auditingremark;
        private string _auditingby;
        private DateTime _auditingdate;
        private string _descript;
        private string _website;
        private string _exhibitionhall;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int EnterpriseID
        {
            set { _enterpriseid = value; }
            get { return _enterpriseid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EnterpriseName
        {
            set { _enterprisename = value; }
            get { return _enterprisename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ManageTypeID
        {
            set { _managetypeid = value; }
            get { return _managetypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Industrylist
        {
            set { _industrylist = value; }
            get { return _industrylist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RegisterDate
        {
            set { _registerdate = value; }
            get { return _registerdate; }
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
        public string currency
        {
            set { _currency = value; }
            get { return _currency; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RegCapital
        {
            set { _regcapital = value; }
            get { return _regcapital; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainProduct
        {
            set { _mainproduct = value; }
            get { return _mainproduct; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RequirInfo
        {
            set { _requirinfo = value; }
            get { return _requirinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AuditingStatus
        {
            set { _auditingstatus = value; }
            get { return _auditingstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditingRemark
        {
            set { _auditingremark = value; }
            get { return _auditingremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditingBy
        {
            set { _auditingby = value; }
            get { return _auditingby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AuditingDate
        {
            set { _auditingdate = value; }
            get { return _auditingdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Descript
        {
            set { _descript = value; }
            get { return _descript; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Website
        {
            set { _website = value; }
            get { return _website; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExhibitionHall
        {
            set { _exhibitionhall = value; }
            get { return _exhibitionhall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

        #region 联系人信息（公司）      
        private int _contactmanid;
        private int _contactid;
       // private string _loginname;
        private string _name;
        private string _mobile;
      //  private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int ContactManID
        {
            set { _contactmanid = value; }
            get { return _contactmanid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ContactID
        {
            set { _contactid = value; }
            get { return _contactid; }
        }
        /// <summary>
        /// 
        /// </summary>
        //public string LoginName
        //{
        //    set { _loginname = value; }
        //    get { return _loginname; }
        //}
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        //public string Remark
        //{
        //    set { _remark = value; }
        //    get { return _remark; }
        //}    
        #endregion

    }
}