using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Register
{
    /// <summary>
    /// 实体类MemberInfoTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MemberInfoModel
    {
        public MemberInfoModel()
        { }
        #region Model
        private int _memberid;
        private string _loginname;
        private string _membername;
        private bool _sex;
        private string _nickname;
        private DateTime _birthday;
        private string _certificateid;
        private string _certificatenumber;
        private string _countrycode;
        private string _provinceid;
        private string _countyid;
        private string _cityid;
        private string _address;
        private string _postcode;
        private string _tel;
        private string _mobile;
        private string _companyname;
        private int _investorproject;
        private string _fax;
        private string _email;
        private bool _issecurity;
        private string _managetypeid;
        private string _requirinfo;
        private string _requirinfodesc;
        private string _headportrait;

        private string _contactTitle;   //职位
        private string _contactName;    //联系人姓名
        /// <summary>
        /// 
        /// </summary>
        public int MemberID
        {
            set { _memberid = value; }
            get { return _memberid; }
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
        public string MemberName
        {
            set { _membername = value; }
            get { return _membername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CertificateID
        {
            set { _certificateid = value; }
            get { return _certificateid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CertificateNumber
        {
            set { _certificatenumber = value; }
            get { return _certificatenumber; }
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
        public string CountyID
        {
            set { _countyid = value; }
            get { return _countyid; }
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
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }

        public string Companyname
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        public int Investorproject
        {
            set { _investorproject = value; }
            get { return _investorproject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FAX
        {
            set { _fax = value; }
            get { return _fax; }
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
        public bool IsSecurity
        {
            set { _issecurity = value; }
            get { return _issecurity; }
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
        public string RequirInfo
        {
            set { _requirinfo = value; }
            get { return _requirinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RequirInfoDesc
        {
            set { _requirinfodesc = value; }
            get { return _requirinfodesc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HeadPortrait
        {
            set { _headportrait = value; }
            get { return _headportrait; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string ContactTitle
        {
            set { _contactTitle = value; }
            get { return _contactTitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContactName
        {
            set { _contactName = value; }
            get { return _contactName; }
        }
        #endregion Model

    }
}

