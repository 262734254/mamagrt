using System;
namespace Tz888.Model
{
    /// <summary>
    ///Õ∆π„…Ë÷√
    /// </summary>
    public class SubscribeSet
    {
        public SubscribeSet()
        { }
        #region Model
        private int _id;
        private int _infoid;
        private string _title;
        private string _loginname;
        private string _objectgradeid;
        private string _objectneed;
        private string _area;
        private string _countrycode;
        private string _provinceid;
        private string _cityid;
        private string _countyid;
        private string _industry;
        private string _othercriter;
        private string _subscribetype;
        private int _subscribecount;
        private int _subscribeover;
        private string _promotioncount;
        private string _manageTypeId;

        public string ManageTypeId
        {
            get { return _manageTypeId; }
            set { _manageTypeId = value; }
        }
        public string Promotioncount
        {
            get { return _promotioncount; }
            set { _promotioncount = value; }
        }

       
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
        public int InfoID
        {
            set { _infoid = value; }
            get { return _infoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
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
        public string objectGradeID
        {
            set { _objectgradeid = value; }
            get { return _objectgradeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string objectNeed
        {
            set { _objectneed = value; }
            get { return _objectneed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        public string CountryCode
        {
            set { _countrycode = value; }
            get { return _countrycode; }
        }
        public string ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        public string CityID
        {
            set {_cityid = value; }
            get { return _cityid; }
        }
        public string CountyID
        {
            set { _countyid = value; }
            get { return _countyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Industry
        {
            set { _industry = value; }
            get { return _industry; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OtherCriter
        {
            set { _othercriter = value; }
            get { return _othercriter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubscribeType
        {
            set { _subscribetype = value; }
            get { return _subscribetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SubscribeCount
        {
            set { _subscribecount = value; }
            get { return _subscribecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SubscribeOver
        {
            set { _subscribeover = value; }
            get { return _subscribeover; }
        }
        #endregion Model
    }
}

