using System;
using System.Collections.Generic;
using System.Text;
namespace Tz888.Model
{
    /// <summary>
    ///推广接收设置
    /// </summary>
    public class SubscribeGetSet
    {
        public SubscribeGetSet()
        { }
        #region Model
        private int _id;
        private string _loginname;
        private int _isget;
        private string _objectgradeid;
        private string _objectneed;
        private string _area;
        private string _countrycode;
        private string _provinceid;
        private string _cityid;
        private string _countyid;
        private string _industry;
        private string _othercriter;
        private string _reveivetype;
        private List<Tz888.Model.Info.CapitalInfoAreaModel> _capitalInfoAreaModels = new List<Tz888.Model.Info.CapitalInfoAreaModel>();
        
        /// <summary>
        /// 投资区域信息
        /// </summary>
        public List<Tz888.Model.Info.CapitalInfoAreaModel> CapitalInfoAreaModels
        {
            get { return _capitalInfoAreaModels; }
            set { _capitalInfoAreaModels = value; }
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
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsGet
        {
            set { _isget = value; }
            get { return _isget; }
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
            set { _cityid = value; }
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
        public string ReveiveType
        {
            set { _reveivetype = value; }
            get { return _reveivetype; }
        }
        #endregion Model
    }
}

