using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Register
{
  public   class SS_Agency_Services
    {
        public SS_Agency_Services() { }
        private int _OrganID;
        private string _LoginName;
        private string _OrganName;
        private string _CountryCode;
        private int _ProvinceID;
        private int _CityID;
        private int _Area;
        private int _OrganType;
        private int _ServiceBigtype;
        private string _ServiceSmalltype;
        private int _BusinessCount;
        private int _Bankroll;
        private string _FoundDate;
        private string _Turnover;
        private string _BusinessView;
        private string _www;
        private string _LinkName;
        private string _Tel;
        private string _FAX;
        private string _Email;
        private string _OrganDoc;
        private DateTime _Regdate;
      private int _IsChekUp;
        /// <summary>
        /// 注册服务机构表ID
        /// </summary>
        public int OrganID
        {
            set { _OrganID = value; }
            get { return _OrganID; }
        }
        /// <summary>
        /// 登录帐号
        /// </summary>
        public string LoginName
        {
            set { _LoginName = value; }
            get { return _LoginName; }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string OrganName
        {
            set { _OrganName = value; }
            get { return _OrganName; }
        }
        /// <summary>
        /// 国家区号
        /// </summary>
        public string CountryCode
        {
            set { _CountryCode = value; }
            get { return _CountryCode; }
        }
        /// <summary>
        /// 省ID
        /// </summary>
        public int ProvinceID
        {
            set { _ProvinceID = value; }
            get { return _ProvinceID; }
        }
        /// <summary>
        /// 市ID
        /// </summary>
        public int CityID
        {
            set { _CityID = value; }
            get { return _CityID; }
        }
        /// <summary>
        /// 县ID
        /// </summary>
        public int Area
        {
            set { _Area = value; }
            get { return _Area; }
        }
        /// <summary>
        /// 机构类型
        /// </summary>
        public int OrganType
        {
            set { _OrganType = value; }
            get { return _OrganType; }
        }
        /// <summary>
        /// 服务大类
        /// </summary>
        public int ServiceBigtype
        {
            set { _ServiceBigtype = value; }
            get { return _ServiceBigtype; }
        }
        /// <summary>
        /// 服务小类
        /// </summary>
        public string ServiceSmalltype
        {
            set { _ServiceSmalltype = value; }
            get { return _ServiceSmalltype; }
        }
        /// <summary>
        /// 企业规模
        /// </summary>
        public int BusinessCount
        {
            set { _BusinessCount = value; }
            get { return _BusinessCount; }
        }
        /// <summary>
        /// 注册资金
        /// </summary>
        public int Bankroll
        {
            set { _Bankroll = value; }
            get { return _Bankroll; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string FoundDate
        {
            set { _FoundDate = value; }
            get { return _FoundDate; }
        }
        /// <summary>
        /// 营业额
        /// </summary>
        public string Turnover
        {
            set { _Turnover = value; }
            get { return _Turnover; }
        }
        /// <summary>
        /// 主营业说明
        /// </summary>
        public string BusinessView
        {
            set { _BusinessView = value; }
            get { return _BusinessView; }
        }
        /// <summary>
        ///网址
        /// </summary>
        public string www
        {
            set { _www = value; }
            get { return _www; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkName
        {
            set { _LinkName = value; }
            get { return _LinkName; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel
        {
            set { _Tel = value; }
            get { return _Tel; }
        }
        /// <summary>
        ///传真
        /// </summary>
        public string FAX
        {
            set { _FAX = value; }
            get { return _FAX; }
        }
        /// <summary>
        ///email
        /// </summary>
        public string Email
        {
            set { _Email = value; }
            get { return _Email; }
        }
        /// <summary>
        ///备注
        /// </summary>
        public string OrganDoc
        {
            set { _OrganDoc = value; }
            get { return _OrganDoc; }
        }
        /// <summary>
        ///会员注册时间
        /// </summary>
        public DateTime Regdate
        {
            set { _Regdate = value; }
            get { return _Regdate; }
        }
      /// <summary>
        ///审核与否 1 已审核 0 未审核 2 审核不通过
        /// </summary>
      public int IsChekUp
        {
            set { _IsChekUp = value; }
            get { return _IsChekUp; }
        }
    }
}
