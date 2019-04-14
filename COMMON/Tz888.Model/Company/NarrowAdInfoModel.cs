using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Company
{
    public class NarrowAdInfoModel
    {
        #region Model
        private int _adid;
        private string _username;
        private DateTime? _createdate;
        private string _title;
        private string _descript;
        private string _url;
        private string _infotypename;
        private string _countrycode;
        private string _provinceid;
        private string _cityid;
        private string _countyid;
        private string _industrybid;
        /// <summary>
        /// 编号
        /// </summary>
        public int AdID
        {
            set { _adid = value; }
            get { return _adid; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Descript
        {
            set { _descript = value; }
            get { return _descript; }
        }
        /// <summary>
        /// 链接路径
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 会员类型
        /// </summary>
        public string InfoTypeName
        {
            set { _infotypename = value; }
            get { return _infotypename; }
        }
        /// <summary>
        /// 国家
        /// </summary>
        public string CountryCode
        {
            set { _countrycode = value; }
            get { return _countrycode; }
        }
        /// <summary>
        /// 省份
        /// </summary>
        public string ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 城市
        /// </summary>
        public string CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 地区
        /// </summary>
        public string CountyId
        {
            set { _countyid = value; }
            get { return _countyid; }
        }
        /// <summary>
        /// 行业
        /// </summary>
        public string IndustryBID
        {
            set { _industrybid = value; }
            get { return _industrybid; }
        }
        #endregion Model
    }
}
