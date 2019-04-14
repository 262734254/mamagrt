using System;
namespace Tz888.Model
{
    /// <summary>
    /// 实体类MerchantSiteTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MerchantSite
    {
        public MerchantSite()
        { }
        #region Model
        private int _id;
        private string _sitetitle;
        private string _siteurl;
        private string _provinceid;
        private string _cityid;
        private string _countyid;
        private string _email;
        private string _postloginname;
        private int _auditstatus;
        private DateTime _postdate;
        private DateTime _auditdate;
        private string _auditloginname;
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
        public string SiteTitle
        {
            set { _sitetitle = value; }
            get { return _sitetitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteUrl
        {
            set { _siteurl = value; }
            get { return _siteurl; }
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
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PostLoginName
        {
            set { _postloginname = value; }
            get { return _postloginname; }
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
        public DateTime PostDate
        {
            set { _postdate = value; }
            get { return _postdate; }
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
        public string AuditLoginName
        {
            set { _auditloginname = value; }
            get { return _auditloginname; }
        }
        #endregion Model

    }
}

