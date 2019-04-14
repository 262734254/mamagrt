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

        /// <summary>
        /// 国家代码
        /// </summary>
        public string CountryID
        {
            get
            {
                this._countryID = this.hideCountryCode2.Value;
                return _countryID;
            }
            set { _countryID = value; }
        }
        /// <summary>
        /// 省代码
        /// </summary>
        public string ProvinceID
        {
            get
            {
                this._provinceID = this.hideProvince2.Value;
                return _provinceID;
            }
            set { _provinceID = value; }
        }
        /// <summary>
        /// 城市代码
        /// </summary>
        public string CityID
        {
            get
            {
                this._cityID = this.hideCapitalCity2.Value;
                return _cityID;
            }
            set { _cityID = value; }
        }
        /// <summary>
        /// 县代码
        /// </summary>
        public string CountyID
        {
            get
            {
                this._countyID = this.hideCounty2.Value;
                return _countyID;
            }
            set { _countyID = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Tz888.Common.Ajax.AjaxMethod));
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(this._countryID))
                    this.hideCountryCode2.Value = this._countryID;
                if (!string.IsNullOrEmpty(this._provinceID))
                    this.hideProvince2.Value = this._provinceID;
                if (!string.IsNullOrEmpty(this._cityID))
                    this.hideCapitalCity2.Value = this._cityID;
                if (!string.IsNullOrEmpty(this._countyID))
                    this.hideCounty2.Value = this._countyID;
            }
        }
    }
}
