using System;
namespace Tz888.Model
{
    /// <summary>
    /// 实体类BusinesProcess 。(业务申请与处理)
    /// </summary>
    public class BusinesProcess
    {
        public BusinesProcess()
        { }
        #region Model
        private int _infoid;
        private string _username;
        private string _title;
        private string _companyname;
        private string _submitman;
        private string _descript;
        private string _countrycode;
        private string _provinceid;
        private string _cityid;
        private string _countyid;
        private string _address;
        private string _tel;
        private string _fax;
        private string _email;
        private int _auditstatus;
        private int _serviesbid;
        private int _serviesmid;
        private DateTime _createdate;
        private decimal _price;
        /// <summary>
        /// 
        /// </summary>
        public int InfoID
        {
            set { _infoid = value; }
            get { return _infoid; }
        }
        public int ServiesBID
        {
            set { _serviesbid = value; }
            get { return _serviesbid; }
        }
         public int ServiesMID
        {
            set { _serviesmid = value; }
            get { return _serviesmid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
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
        public string CompanyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubmitMan
        {
            set { _submitman = value; }
            get { return _submitman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Descript
        {
            set { _descript = value; }
            get { return _descript; }
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
        public string Address
        {
            set { _address = value; }
            get { return _address; }
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
        public string Fax
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
        public int AuditStatus
        {
            set { _auditstatus = value; }
            get { return _auditstatus; }
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
        /// 需求定价
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        #endregion Model

    }
}


 