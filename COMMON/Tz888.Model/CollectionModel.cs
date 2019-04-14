using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class CollectionModel
    {
        #region Model 公司机构收藏
        private int _id;
        private string _loginname;
        private DateTime _createdate;
        private string _industrybid;
        private string _contactloginname;
        private int _collectorgtype;
        private string _collectorgname;
        private string _countrycode;
        private string _provinceid;
        private string _cityid;
        private string _countyid;
        private string _remrk;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IndustryBID
        {
            set { _industrybid = value; }
            get { return _industrybid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContactLoginName
        {
            set { _contactloginname = value; }
            get { return _contactloginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CollectOrgType
        {
            set { _collectorgtype = value; }
            get { return _collectorgtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CollectOrgName
        {
            set { _collectorgname = value; }
            get { return _collectorgname; }
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
        public string Remrk
        {
            set { _remrk = value; }
            get { return _remrk; }
        }
        #endregion Model

    }
}