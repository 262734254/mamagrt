using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// 
    /// </summary>
    public class ProjectAddressInfoModel
    {
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
        private string _mobile;
        private string _address;
        private string _postcode;

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
    }
}
