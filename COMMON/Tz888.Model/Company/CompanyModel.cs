using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Company
{
    [Serializable]
    public class CompanyModel
    {
        private int _companyid;
		private string _loginname;
		private string _companyname;
		private int? _industryid;
		private string _industryname;
		private int? _rangeid;
		private string _rangename;
		private int? _natureid;
		private string _naturename;
		private DateTime? _createdate;
		private int? _hit;
		private int? _integrity;
		private string _establishment;
		private long _employees;
		private long _capital;
		private string _linkname;
		private string _email;
		private string _url;
		private string _address;
		private string _logo;
		private string _introduction;
		private string _serviceproce;
		private string _title;
		private string _keywords;
		private string _description;
        private string _telphone;
        private string _mobile;
        private int? _auditingstatus;
        private string _htmlfile;
        private int _ismake;
        private int _isDelete;
        private int _Provice;
        private int _City;
        private int _FromId;

        /// <summary>
        /// 省份
        /// </summary>
        public int Provice 
        {
            get { return _Provice; }
            set { _Provice = value; }
        }

        /// <summary>
        /// 城市
        /// </summary>
        public int City
        {
            get { return _City; }
            set { _City = value; }
        }

        /// <summary>
        /// 来源
        /// </summary>
        public int FromId
        {
            get { return _FromId; }
            set { _FromId = value; }
        }
      
		/// <summary>
		/// 企业ID
		/// </summary>
		public int CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 企业名称
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 行业ID
		/// </summary>
		public int? IndustryID
		{
			set{ _industryid=value;}
			get{return _industryid;}
		}
		/// <summary>
		/// 行业名称
		/// </summary>
		public string IndustryName
		{
			set{ _industryname=value;}
			get{return _industryname;}
		}
		/// <summary>
		/// 区域ID
		/// </summary>
		public int? RangeID
		{
			set{ _rangeid=value;}
			get{return _rangeid;}
		}
		/// <summary>
		/// 区域名称
		/// </summary>
		public string RangeName
		{
			set{ _rangename=value;}
			get{return _rangename;}
		}
		/// <summary>
		/// 企业性质ID
		/// </summary>
		public int? NatureID
		{
			set{ _natureid=value;}
			get{return _natureid;}
		}
		/// <summary>
		/// 企业性质名称
		/// </summary>
		public string NatureName
		{
			set{ _naturename=value;}
			get{return _naturename;}
		}
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 点击率
		/// </summary>
		public int? Hit
		{
			set{ _hit=value;}
			get{return _hit;}
		}
		/// <summary>
		/// 诚信指度
		/// </summary>
		public int? Integrity
		{
			set{ _integrity=value;}
			get{return _integrity;}
		}
		/// <summary>
        /// 成立日期
		/// </summary>
		public string EstablishMent
		{
			set{ _establishment=value;}
			get{return _establishment;}
		}
		/// <summary>
		/// 员工人数
		/// </summary>
		public long Employees
		{
			set{ _employees=value;}
			get{return _employees;}
		}
		/// <summary>
		/// 注册资金
		/// </summary>
		public long Capital
		{
			set{ _capital=value;}
			get{return _capital;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string LinkName
		{
			set{ _linkname=value;}
			get{return _linkname;}
		}
		/// <summary>
		/// 电子邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
        /// 企业网址
		/// </summary>
		public string URL
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 联系地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// Logo
		/// </summary>
		public string Logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// 企业简介
		/// </summary>
		public string Introduction
		{
			set{ _introduction=value;}
			get{return _introduction;}
		}
		/// <summary>
		/// 主营产品/服务
		/// </summary>
		public string ServiceProce
		{
			set{ _serviceproce=value;}
			get{return _serviceproce;}
		}
		/// <summary>
		/// 网页标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 关键字
		/// </summary>
		public string Keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 网页短标题
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Telphone
        {
            get { return _telphone; }
            set { _telphone = value; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? Auditingstatus
        {
            get { return _auditingstatus; }
            set { _auditingstatus = value; }
        }
        /// <summary>
        /// 静态路径
        /// </summary>
        public string Htmlfile
        {
            get { return _htmlfile; }
            set { _htmlfile = value; }
        }
        /// <summary>
        /// 是否推广
        /// </summary>
        public int Ismake
        {
            get { return _ismake; }
            set { _ismake = value; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }
    }
}
