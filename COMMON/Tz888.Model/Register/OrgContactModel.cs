using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Register
{
    /// <summary>
    /// 实体类OrgContactModel 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class OrgContactModel
    {
        public OrgContactModel()
        { }
        #region Model
        private int _contactid;
        private string _loginname;
        private string _organizationname;
        private string _name;
        private string _career;
        private string _telcountrycode;
        private string _telstatecode;
        private string _telnum;
        private string _faxcountrycode;
        private string _faxstatecode;
        private string _faxnum;
        private string _email;
        private string _website;
        private string _mobile;
        private string _address;
        private string _postcode;
        private bool _isdel;
        private string _remark;
       //添加详细信息的参数
        private string _position;
        /// <summary>
        /// 职位的描述
        /// </summary>
        public string Position
        {
            set { _position = value; }
            get { return _position; }
        }

        //结束处
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
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrganizationName
        {
            set { _organizationname = value; }
            get { return _organizationname; }
        }
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
        public string Career
        {
            set { _career = value; }
            get { return _career; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TelCountryCode
        {
            set { _telcountrycode = value; }
            get { return _telcountrycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TelStateCode
        {
            set { _telstatecode = value; }
            get { return _telstatecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TelNum
        {
            set { _telnum = value; }
            get { return _telnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FaxCountryCode
        {
            set { _faxcountrycode = value; }
            get { return _faxcountrycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FaxStateCode
        {
            set { _faxstatecode = value; }
            get { return _faxstatecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FaxNum
        {
            set { _faxnum = value; }
            get { return _faxnum; }
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
        /// 网站地址
        /// </summary>
        public string Website
        {
            set { _website = value; }
            get { return _website; }
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
        public string address
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
        public bool IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
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

    }
}

