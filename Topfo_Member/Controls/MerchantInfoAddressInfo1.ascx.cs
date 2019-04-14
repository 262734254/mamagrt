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
using System.ComponentModel;


namespace Tz888.Member.Controls
{
    public partial class MerchantInfoAddressInfo1: System.Web.UI.UserControl
    {
        // private int inputCount = 0; //已添加的联系人数
        // private int maxContacts = 5; //可以添加的最大联系人数

        // private string _linkHtmlModel = "<div id={0}>姓名：<input id={1} name={2} onchange='CAcheckNavigate(3);' width=122px value={3} />&nbsp;&nbsp;" +
        //    "手机：<input id={4} name={5} onchange='CAcheckNavigate(3);' width=122px value={6} />&nbsp;&nbsp;" +
        //  "<A href=\"javascript:{7}_AddContact.remove('{8}');\">移除</A>" +
        //  "&nbsp;&nbsp;<span id={9}></span>" +
        //  "<input type=hidden id={10} name={11} value={12} /></div>";

        // private string _linkOutputHTML;

        private Tz888.Model.Info.InfoContactModel _infoContact = new Tz888.Model.Info.InfoContactModel();
        private List<Tz888.Model.Info.InfoContactManModel> _infoContactMans = new List<Tz888.Model.Info.InfoContactManModel>();


        //protected int InputCount
        //{
        //    get { return inputCount; }
        //}

        //protected int MaxContacts
        //{
        //    get { return maxContacts; }
        //    set { maxContacts = value; }
        //}

        private string _undertaker;

        /// <summary>
        /// 项目承办单位（特殊处理，放入招商信息表中）
        /// </summary>
        [Description("项目承办单位")]
        public string Undertaker
        {
            get
            {
                if (!string.IsNullOrEmpty(this.txtUndertaker.Text.Trim()))
                    this._undertaker = this.txtUndertaker.Text.Trim();
                return _undertaker;
            }
            set
            {
                _undertaker = value;
                this.txtUndertaker.Text = _undertaker;
            }
        }

        //protected string LinkOutputHTML
        //{
        //    get
        //    {
        //        if (this._infoContactMans != null && this._infoContactMans.Count > 0)
        //        {
        //            int i = 0;
        //            StringBuilder outHtmlCode = new StringBuilder();
        //            foreach (Tz888.Model.Info.InfoContactManModel model in this._infoContactMans)
        //            {
        //                string divPanelID = this.ClientID + "DC" + i.ToString();
        //                string nameControlID = this.ClientID + "TN" + i.ToString();
        //                string mobileControlID = this.ClientID + "TM" + i.ToString();
        //                string hiddenControlID = this.ClientID + "HV" + i.ToString();
        //                string spMsgID = this.ClientID + "SP" + i.ToString();
        //                outHtmlCode.Append(string.Format(this._linkHtmlModel,
        //                                                divPanelID, nameControlID, nameControlID, model.Name,
        //                                                mobileControlID, mobileControlID, model.Mobile,
        //                                                this.ClientID, divPanelID, spMsgID, hiddenControlID, hiddenControlID,
        //                                                model.ContactManID));
        //                i++;
        //            }
        //            this.inputCount = i;
        //            this.hdinputCount.Value = i.ToString();
        //            this._linkOutputHTML = outHtmlCode.ToString();
        //        }
        //        return _linkOutputHTML;
        //    }
        //    set { _linkOutputHTML = value; }
        //}

        /// <summary>
        /// 信息联系实体
        /// </summary>
        public Tz888.Model.Info.InfoContactModel InfoContact
        {
            get
            {
                string companyName = this.txtCompanyName.Text.Trim();
                string email = this.txtEmail.Text.Trim();
                string telCountry = this.txtTelCountry.Text.Trim();
                string telZoneCode = this.txtTelZoneCode.Text.Trim();
                string telNumber = this.txtTelNumber.Text.Trim();
                //string faxCountry = this.txtFaxCountry.Text.Trim();
                //string faxZoneCode = this.txtFaxZoneCode.Text.Trim();
                //string faxNumber = this.txtFaxNumber.Text.Trim();
                // string webSite = this.txtWebSite.Text.Trim();
                string name = this.txtName.Text.Trim();
                string mobile = this.txtMobile.Text.Trim();
                string address = this.txtAddress.Text.Trim();
                //string postCode = this.txtPostCode.Text.Trim();
                //新添加的职位
                string position = this.txtPosition.Text.Trim();
                this._infoContact.Position = position;
                //结束处


                this._infoContact.OrganizationName = companyName;
                this._infoContact.Email = email;
                //this._infoContact.WebSite = webSite;
                this._infoContact.TelCountryCode = telCountry;
                this._infoContact.TelStateCode = telZoneCode;
                this._infoContact.TelNum = telNumber;
                // this._infoContact.FaxCountryCode = faxCountry;
                //this._infoContact.FaxStateCode = faxZoneCode;
                //this._infoContact.FaxNum = faxNumber;
                this._infoContact.Name = name;
                this._infoContact.Mobile = mobile;
                this._infoContact.Address = address;
                // this._infoContact.PostCode = postCode;
               return _infoContact;
            }
            set
            {
                if (value != null)
                {
                    // 设置职位
                    if (!string.IsNullOrEmpty(value.Position))
                    {
                        this.txtPosition.Text = value.Position;
                        this._infoContact.Position = value.Position;
                    }
                    //结束处


                    if (!string.IsNullOrEmpty(value.OrganizationName))
                    {
                        this.txtCompanyName.Text = value.OrganizationName;
                        this._infoContact.OrganizationName = value.OrganizationName;
                    }
                    if (!string.IsNullOrEmpty(value.Email))
                    {
                        this.txtEmail.Text = value.Email;
                        this._infoContact.Email = value.Email;
                    }
                    if (!string.IsNullOrEmpty(value.TelCountryCode))
                    {
                        this.txtTelCountry.Text = value.TelCountryCode;
                        this._infoContact.TelCountryCode = value.TelCountryCode;
                    }
                    if (!string.IsNullOrEmpty(value.TelStateCode))
                    {
                        this.txtTelZoneCode.Text = value.TelStateCode;
                        this._infoContact.TelStateCode = value.TelStateCode;
                    }
                    if (!string.IsNullOrEmpty(value.TelNum))
                    {
                        this.txtTelNumber.Text = value.TelNum;
                        this._infoContact.TelNum = value.TelNum;
                    }
                    //if (!string.IsNullOrEmpty(value.FaxCountryCode))
                    //{
                    //    this.txtFaxCountry.Text = value.FaxCountryCode;
                    //    this._infoContact.FaxCountryCode = value.FaxCountryCode;
                    //}
                    //if (!string.IsNullOrEmpty(value.FaxStateCode))
                    //{
                    //    this.txtFaxZoneCode.Text = value.FaxStateCode;
                    //    this._infoContact.FaxStateCode = value.FaxStateCode;
                    //}
                    //if (!string.IsNullOrEmpty(value.FaxNum))
                    //{
                    //    this.txtFaxNumber.Text = value.FaxNum;
                    //    this._infoContact.FaxNum = value.FaxNum;
                    //}

                    //if (!string.IsNullOrEmpty(value.WebSite))
                    //{
                    //    this.txtWebSite.Text = value.WebSite;
                    //    this._infoContact.WebSite = value.WebSite;
                    //}

                    if (!string.IsNullOrEmpty(value.Address))
                    {
                        this.txtAddress.Text = value.Address;
                        this._infoContact.PostCode = value.PostCode;
                    }
                    //if (!string.IsNullOrEmpty(value.PostCode))
                    //{
                    //    this.txtPostCode.Text = value.PostCode;
                    //    this._infoContact.PostCode = value.PostCode;
                    //}
                    if (!string.IsNullOrEmpty(value.Name))
                    {
                        this.txtName.Text = value.Name;
                        this._infoContact.Name = value.Name;
                    }
                    if (!string.IsNullOrEmpty(value.Mobile))
                    {
                        this.txtMobile.Text = value.Mobile;
                        this._infoContact.Mobile = value.Mobile;
                    }
                }
            }
        }

        /// <summary>
        /// 联系人信息集合
        /// </summary>
        //public List<Tz888.Model.Info.InfoContactManModel> InfoContactMans
        //{
        //    get
        //    {
        //        this.inputCount = Convert.ToInt32(this.hdinputCount.Value);
        //        for (int i = 0; i < this.inputCount; i++)
        //        {
        //            string nameControlID = this.ClientID + "TN" + i.ToString();
        //            string mobileControlID = this.ClientID + "TM" + i.ToString();
        //            string hiddenControlID = this.ClientID + "HV" + i.ToString();
        //            Tz888.Model.Info.InfoContactManModel model = new Tz888.Model.Info.InfoContactManModel();
        //            if (!string.IsNullOrEmpty(this.Page.Request.Form[nameControlID].ToString()))
        //                model.Name = Convert.ToString(this.Page.Request.Form[nameControlID]);
        //            else
        //                model.Name = "";
        //            if (!string.IsNullOrEmpty(this.Page.Request.Form[mobileControlID].ToString()))
        //                model.Mobile = Convert.ToString(this.Page.Request.Form[mobileControlID]);
        //            else
        //                model.Mobile = "";
        //            if (!string.IsNullOrEmpty(this.Page.Request.Form[hiddenControlID].ToString()))
        //                model.ContactManID = Convert.ToInt64(this.Page.Request.Form[hiddenControlID].ToString());
        //            else
        //                model.ContactManID = 0;
        //            this._infoContactMans.Add(model);
        //        }
        //        return _infoContactMans;
        //    }
        //    set { _infoContactMans = value; }
        //}
    }
}
