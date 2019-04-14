using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    public class CapitalInfoAreaModel
    {
        /// <summary>
        /// 投资区域实体类
        /// </summary>
        public CapitalInfoAreaModel()
		{}
		#region Model
		private int _infoareaid;
		private long _infoid;
		private string _countrycode;
        private string _countryName;
		private string _provinceid;
        private string _provinceName;
		private string _cityid;
        private string _cityName;
		private string _countyid;
        private string _countyname;
		/// <summary>
		/// ID
		/// </summary>
		public int InfoAreaID
		{
			set{ _infoareaid=value;}
			get{return _infoareaid;}
		}
		/// <summary>
		/// InfoID
		/// </summary>
		public long InfoID
		{
			set{ _infoid=value;}
			get{return _infoid;}
		}
		/// <summary>
		/// CountryCode
		/// </summary>
		public string CountryCode
		{
			set{ _countrycode=value;}
			get{return _countrycode;}
		}

        /// <summary>
        /// CountryName
        /// </summary>
        public string CountryName
        {
            set { _countryName = value; }
            get { return _countryName; }
        }
		/// <summary>
		/// ProvinceID
		/// </summary>
		public string ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
        /// <summary>
        /// ProvinceName
        /// </summary>
        public string ProvinceName
        {
            set { _provinceName = value; }
            get { return _provinceName; }
        }
		/// <summary>
		/// CityID
		/// </summary>
		public string CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}

        /// <summary>
        /// CityName
        /// </summary>
        public string CityName
        {
            set { _cityName = value; }
            get { return _cityName; }
        }

		/// <summary>
		/// CountyID
		/// </summary>
		public string CountyID
		{
			set{ _countyid=value;}
			get{return _countyid;}
		}

        /// <summary>
        /// CountyName
        /// </summary>
        public string CountyName
        {
            set { _countyname = value; }
            get { return _countyname; }
        }
		#endregion Model
    }
}
