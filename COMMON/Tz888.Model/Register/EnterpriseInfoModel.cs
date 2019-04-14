using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Register
{
    public class EnterpriseInfoModel
    {
        public EnterpriseInfoModel()
        { }
        #region Model
        private int _enterpriseid;
        private string _loginname;
        private string _enterprisename;
        private string _comabout;
        private string _comaboutbrief;
        private int _setcomtypeid;
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
        private string _exhibitionhall;
        private int _hits;
        private DateTime _enrolDate;
        private string _remark;
        /// <summary>
        /// 企业ID
        /// </summary>
        public int EnterpriseID
        {
            set { _enterpriseid = value; }
            get { return _enterpriseid; }
        }
        /// <summary>
        /// LoginName
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string EnterpriseName
        {
            set { _enterprisename = value; }
            get { return _enterprisename; }
        }
        /// <summary>
        /// 公司介绍
        /// </summary>
        public string ComAbout
        {
            set { _comabout = value; }
            get { return _comabout; }
        }
        /// <summary>
        /// 公司介绍提炼
        /// </summary>
        public string ComAboutBrief
        {
            set { _comaboutbrief = value; }
            get { return _comaboutbrief; }
        }
        /// <summary>
        /// ManageTypeID
        /// </summary>
        public int SetComTypeID
        {
            set { _setcomtypeid = value; }
            get { return _setcomtypeid; }
        }
        /// <summary>
        /// 行业类型
        /// </summary>
        public string Industrylist
        {
            set { _industrylist = value; }
            get { return _industrylist; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisterDate
        {
            set { _registerdate = value; }
            get { return _registerdate; }
        }
        /// <summary>
        /// 国家代码
        /// </summary>
        public string CountryCode
        {
            set { _countrycode = value; }
            get { return _countrycode; }
        }
        /// <summary>
        /// 省代码
        /// </summary>
        public string ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 市
        /// </summary>
        public string CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 县
        /// </summary>
        public string CountyID
        {
            set { _countyid = value; }
            get { return _countyid; }
        }
        /// <summary>
        /// 币种
        /// </summary>
        public string currency
        {
            set { _currency = value; }
            get { return _currency; }
        }
        /// <summary>
        /// 注册资本
        /// </summary>
        public decimal RegCapital
        {
            set { _regcapital = value; }
            get { return _regcapital; }
        }
        /// <summary>
        /// 主营产品
        /// </summary>
        public string MainProduct
        {
            set { _mainproduct = value; }
            get { return _mainproduct; }
        }
        /// <summary>
        /// 登记意向
        /// </summary>
        public string RequirInfo
        {
            set { _requirinfo = value; }
            get { return _requirinfo; }
        }
        /// <summary>
        /// 审核状态(待审核0 已发布上网1 未通过审核2 己删除3 )
        /// </summary>
        public int AuditingStatus
        {
            set { _auditingstatus = value; }
            get { return _auditingstatus; }
        }
        /// <summary>
        /// 展厅地址
        /// </summary>
        public string ExhibitionHall
        {
            set { _exhibitionhall = value; }
            get { return _exhibitionhall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// 在我网登记时间
        /// </summary>
        public DateTime EnrolDate
        {
            set { _enrolDate = value; }
            get { return _enrolDate; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

