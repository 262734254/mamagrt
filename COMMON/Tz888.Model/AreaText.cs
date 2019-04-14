using System;
namespace Tz888.Model
{
    /// <summary>
    /// 实体类AreaTextTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class AreaText
    {
        public AreaText()
        { }
        #region Model
        private int _areaid;
        private string _subtitle;
        private string _shortdescript;
        private string _htmlurl;
        private string _url;
        private string _countrycode;
        private string _provinceid;
        private string _cityid;
        private string _countyid;
        private int _orderby;
        private int _areakind;
        private string _createby;
        private DateTime _created;
        private int _areatype;
        private int _hit;
        private int _infotype;
        /// <summary>
        /// 
        /// </summary>
        public int AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Subtitle
        {
            set { _subtitle = value; }
            get { return _subtitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShortDescript
        {
            set { _shortdescript = value; }
            get { return _shortdescript; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HtmlURL
        {
            set { _htmlurl = value; }
            get { return _htmlurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string URL
        {
            set { _url = value; }
            get { return _url; }
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
        public int Orderby
        {
            set { _orderby = value; }
            get { return _orderby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AreaKind
        {
            set { _areakind = value; }
            get { return _areakind; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateBy
        {
            set { _createby = value; }
            get { return _createby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Created
        {
            set { _created = value; }
            get { return _created; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int areaType
        {
            set { _areatype = value; }
            get { return _areatype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int hit
        {
            set { _hit = value; }
            get { return _hit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InfoType
        {
            set { _infotype = value; }
            get { return _infotype; }
        }
        #endregion Model

    }
}

