using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// 信息联系方式表
    /// </summary>
    public class InfoContactModel
    {
        public InfoContactModel()
        { }
        #region Model
        private long _contactid;
        private long _infoid;
        private string _organizationname;
        private string _orgIntro;
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
        //招商联系人职位

        /// <summary>
        /////招商联系人职位
        /// </summary>
        private string _position;
        public string Position
        {
            set { _position = value; }
            get { return _position; }
        }
        //end
        /// <summary>
        /// 
        /// </summary>
        public long ContactID
        {
            set { _contactid = value; }
            get { return _contactid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long InfoID
        {
            set { _infoid = value; }
            get { return _infoid; }
        }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string OrganizationName
        {
            set { _organizationname = value; }
            get { return _organizationname; }
        }


        public string OrgIntro
        {
            get { return _orgIntro; }
            set { _orgIntro = value; }
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
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
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
