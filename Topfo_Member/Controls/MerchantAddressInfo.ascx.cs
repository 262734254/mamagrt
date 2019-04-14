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
using System.Collections.Generic;
using System.Text;

namespace Tz888.Member.Controls
{
    public partial class MerchantAddressInfo : System.Web.UI.UserControl
    {
        private int inputCount = 0; //已添加的联系人数
        private int maxContacts = 5; //可以添加的最大联系人数

        private string _linkHtmlModel = "<div id={0}>姓名：<input id={1} name={2} onchange='CAcheckNavigate(3);' width=122px value={3} />&nbsp;&nbsp;" +
                            "手机：<input id={4} name={5} onchange='CAcheckNavigate(3);' width=122px value={6} />&nbsp;&nbsp;" +
                            "<A href=\"javascript:{7}_AddContact.remove('{8}');\">移除</A>" +
                            "&nbsp;&nbsp;<span id={9}></span>" +
                            "<input type=hidden id={10} name={11} value={12} /></div>";

        private string _linkOutputHTML;

        private Tz888.Model.Register.OrgContactModel _OrgContactModel = new Tz888.Model.Register.OrgContactModel();

        private List<Tz888.Model.Register.OrgContactMan> _OrgContactManModels = new List<Tz888.Model.Register.OrgContactMan>();


        protected int InputCount
        {
            get { return inputCount; }
        }

        protected int MaxContacts
        {
            get { return maxContacts; }
            set { maxContacts = value; }
        }

        protected string LinkOutputHTML
        {
            get
            {
                if (this._OrgContactManModels != null && this._OrgContactManModels.Count > 0)
                {
                    int i = 0;
                    StringBuilder outHtmlCode = new StringBuilder();
                    foreach (Tz888.Model.Register.OrgContactMan model in this._OrgContactManModels)
                    {
                        string divPanelID = this.ClientID + "DC" + i.ToString();
                        string nameControlID = this.ClientID + "TN" + i.ToString();
                        string mobileControlID = this.ClientID + "TM" + i.ToString();
                        string hiddenControlID = this.ClientID + "HV" + i.ToString();
                        string spMsgID = this.ClientID + "SP" + i.ToString();
                        outHtmlCode.Append(string.Format(this._linkHtmlModel,
                                                        divPanelID, nameControlID, nameControlID, model.Name,
                                                        mobileControlID, mobileControlID, model.Mobile,
                                                        this.ClientID, divPanelID, spMsgID, hiddenControlID, hiddenControlID,
                                                        model.ContactManID));
                        i++;
                    }
                    this.inputCount = i;
                    this.hdinputCount.Value = i.ToString();
                    this._linkOutputHTML = outHtmlCode.ToString();
                }
                return _linkOutputHTML;
            }
            set { _linkOutputHTML = value; }
        }

        /// <summary>
        /// 信息联系实体
        /// </summary>
        public Tz888.Model.Register.OrgContactModel OrgContactModel
        {
            get {
                string email = this.txtEmail.Text.Trim();
                string telCountry = this.txtTelCountry.Text.Trim();
                string telZoneCode = this.txtTelZoneCode.Text.Trim();
                string telNumber = this.txtTelNumber.Text.Trim();
                string faxCountry = this.txtFaxCountry.Text.Trim();
                string faxZoneCode = this.txtFaxZoneCode.Text.Trim();
                string faxNumber = this.txtFaxNumber.Text.Trim();
                string name = this.txtName.Text.Trim();
                string mobile = this.txtMobile.Text.Trim();
                string address = this.txtAddress.Text.Trim();
                string postCode = this.txtPostCode.Text.Trim();

                this._OrgContactModel.Email = email;
                this._OrgContactModel.TelCountryCode = telCountry;
                this._OrgContactModel.TelStateCode = telZoneCode;
                this._OrgContactModel.TelNum = telNumber;
                this._OrgContactModel.FaxCountryCode = faxCountry;
                this._OrgContactModel.FaxStateCode = faxZoneCode;
                this._OrgContactModel.FaxNum = faxNumber;
                this._OrgContactModel.Name = name;
                this._OrgContactModel.Mobile = mobile;
                this._OrgContactModel.address = address;
                this._OrgContactModel.PostCode = postCode;
                return _OrgContactModel; }
            set {
                if (value != null)
                {
                    if (!string.IsNullOrEmpty(value.Email))
                    {
                        this.txtEmail.Text = value.Email;
                        this._OrgContactModel.Email = value.Email;
                    }
                    if (!string.IsNullOrEmpty(value.TelCountryCode))
                    {
                        this.txtTelCountry.Text = value.TelCountryCode;
                        this._OrgContactModel.TelCountryCode = value.TelCountryCode;
                    }
                    if (!string.IsNullOrEmpty(value.TelStateCode))
                    {
                        this.txtTelZoneCode.Text = value.TelStateCode;
                        this._OrgContactModel.TelStateCode = value.TelStateCode;
                    }
                    if (!string.IsNullOrEmpty(value.TelNum))
                    {
                        this.txtTelNumber.Text = value.TelNum;
                        this._OrgContactModel.TelNum = value.TelNum;
                    }
                    if (!string.IsNullOrEmpty(value.FaxCountryCode))
                    {
                        this.txtFaxCountry.Text = value.FaxCountryCode;
                        this._OrgContactModel.FaxCountryCode = value.FaxCountryCode;
                    }
                    if (!string.IsNullOrEmpty(value.FaxStateCode))
                    {
                        this.txtFaxZoneCode.Text = value.FaxStateCode;
                        this._OrgContactModel.FaxStateCode = value.FaxStateCode;
                    }
                    if (!string.IsNullOrEmpty(value.FaxNum))
                    {
                        this.txtFaxNumber.Text = value.FaxNum;
                        this._OrgContactModel.FaxNum = value.FaxNum;
                    }

                    if (!string.IsNullOrEmpty(value.address))
                    {
                        this.txtAddress.Text = value.address;
                        this._OrgContactModel.address = value.address;
                    }
                    if (!string.IsNullOrEmpty(value.PostCode))
                    {
                        this.txtPostCode.Text = value.PostCode;
                        this._OrgContactModel.PostCode = value.PostCode;
                    }

                    if (!string.IsNullOrEmpty(value.Name))
                    {
                        this.txtName.Text = value.Name;
                        this._OrgContactModel.Name = value.Name;
                    }
                    if (!string.IsNullOrEmpty(value.Mobile))
                    {
                        this.txtMobile.Text = value.Mobile;
                        this._OrgContactModel.Mobile = value.Mobile;
                    }
                }
                _OrgContactModel = value; }
        }


        /// <summary>
        /// 联系人信息集合
        /// </summary>
        public List<Tz888.Model.Register.OrgContactMan> OrgContactManModels
        {
            get
            {
                this.inputCount = Convert.ToInt32(this.hdinputCount.Value);
                for (int i = 0; i < this.inputCount; i++)
                {
                    string nameControlID = this.ClientID + "TN" + i.ToString();
                    string mobileControlID = this.ClientID + "TM" + i.ToString();
                    string hiddenControlID = this.ClientID + "HV" + i.ToString();
                    Tz888.Model.Register.OrgContactMan model = new Tz888.Model.Register.OrgContactMan();
                    if (!string.IsNullOrEmpty(this.Page.Request.Form[nameControlID].ToString()))
                        model.Name = Convert.ToString(this.Page.Request.Form[nameControlID]);
                    else
                        model.Name = "";
                    if (!string.IsNullOrEmpty(this.Page.Request.Form[mobileControlID].ToString()))
                        model.Mobile = Convert.ToString(this.Page.Request.Form[mobileControlID]);
                    else
                        model.Mobile = "";
                    if (!string.IsNullOrEmpty(this.Page.Request.Form[hiddenControlID].ToString()))
                        model.ContactManID = Convert.ToInt32(this.Page.Request.Form[hiddenControlID].ToString());
                    else
                        model.ContactManID = 0;
                    this._OrgContactManModels.Add(model);
                }
                return _OrgContactManModels;
            }
            set { _OrgContactManModels = value; }
        }
    }
}
