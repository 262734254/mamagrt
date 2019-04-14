using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Tz888.Member.Controls
{
    public partial class ZoneSelectControl : System.Web.UI.UserControl
    {
        private string _countryID;
        private string _provinceID;
        private string _cityID;
        private string _countyID;

        ///// <summary>
        ///// 国家代码
        ///// </summary>
        //public string CountryID
        //{
        //    get
        //    {
        //        this._countryID = this.hideCountryCode.Value;
        //        return _countryID;
        //    }
        //    set { _countryID = value; }
        //}
        ///// <summary>
        ///// 省代码
        ///// </summary>
        //public string ProvinceID
        //{
        //    get
        //    {
        //        this._provinceID = this.hideProvince.Value;
        //        return _provinceID;
        //    }
        //    set { _provinceID = value; }
        //}
        ///// <summary>
        ///// 城市代码
        ///// </summary>
        //public string CityID
        //{
        //    get
        //    {
        //        this._cityID = this.hideCapitalCity.Value;
        //        return _cityID;
        //    }
        //    set { _cityID = value; }
        //}
        ///// <summary>
        ///// 县代码
        ///// </summary>
        //public string CountyID
        //{
        //    get
        //    {
        //        this._countyID = this.hideCounty.Value;
        //        return _countyID;
        //    }
        //    set { _countyID = value; }
        //}
        /// <summary>
        /// 国家代码
        /// </summary>
        public string CountryID
        {
            get
            {
                this._countryID = this.hideCountryCode.Value;
                return _countryID;
            }
            set { this.hideCountryCode.Value = value; }
        }
        /// <summary>
        /// 省代码
        /// </summary>
        public string ProvinceID
        {
            get
            {
                this._provinceID = this.hideProvince.Value;
                return _provinceID;
            }
            set { this.hideProvince.Value = value; }
        }
        /// <summary>
        /// 城市代码
        /// </summary>
        public string CityID
        {
            get
            {
                this._cityID = this.hideCapitalCity.Value;
                return _cityID;
            }
            set { this.hideCapitalCity.Value = value; }
        }
        /// <summary>
        /// 县代码
        /// </summary>
        public string CountyID
        {
            get
            {
                this._countyID = this.hideCounty.Value;
                return _countyID;
            }
            set { this.hideCounty.Value = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Tz888.Common.Ajax.AjaxMethod));
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(this._countryID))
                    this.hideCountryCode.Value = this._countryID;
                if (!string.IsNullOrEmpty(this._provinceID))
                    this.hideProvince.Value = this._provinceID;
                if (!string.IsNullOrEmpty(this._cityID))
                    this.hideCapitalCity.Value = this._cityID;
                if (!string.IsNullOrEmpty(this._countyID))
                    this.hideCounty.Value = this._countyID;
            }
        }
    }
}
