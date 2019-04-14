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


public partial class Register_Control_OrgContactControl : System.Web.UI.UserControl
{
        private int inputCount = 1; //已添加的联系人数
        private int maxContacts = 5; //可以添加的最大联系人数
       
        private string _linkHtmlModel = "<div id={0}>姓名：<input id={1} name={2} width=122px value={3} />&nbsp;&nbsp;" +
                              "手机：<input id={4} name={5} width=122px value={6} />&nbsp;&nbsp;" +
                              "<A href=\"javascript:{7}_AddContact.remove('{8}');\">移除</A>" +
                              "<input type=hidden id={9} name={10} value={11} /></div>";

        private string _linkOutputHTML;

        private Tz888.Model.Register.OrgContactModel _OrgContact = new Tz888.Model.Register.OrgContactModel();
        private List<Tz888.Model.Register.OrgContactMan> _ContactMans = new List<Tz888.Model.Register.OrgContactMan>();


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
            if (this._ContactMans != null && this._ContactMans.Count > 0)
            {
                int i = 0;
                StringBuilder outHtmlCode = new StringBuilder();
                foreach (Tz888.Model.Register.OrgContactMan model in this._ContactMans)
                {
                    string divPanelID = this.ClientID + "DC" + i.ToString();
                    string nameControlID = this.ClientID + "TN" + i.ToString();
                    string mobileControlID = this.ClientID + "TM" + i.ToString();
                    string hiddenControlID = this.ClientID + "HV" + i.ToString();
                    outHtmlCode.Append(string.Format(this._linkHtmlModel,
                                                    divPanelID, nameControlID, nameControlID, model.Name,
                                                    mobileControlID, mobileControlID, model.Mobile,
                                                    this.ClientID, divPanelID, hiddenControlID, hiddenControlID,
                                                    model.LoginName));
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
        ///公司、机构登记表结构显示不同
        ///</summary>
        /// 
        /// <summary>
        /// 信息联系实体
        /// </summary>
        public Tz888.Model.Register.OrgContactModel OrgContact
        { 
            get {
                //string OrganizationName = this.txtOrganizationName.Text.Trim();
                string Career = "";//职务
                string email = this.txtEmail.Text.Trim();
                string telCountry = this.txtTelCountry.Text.Trim();
                string telZoneCode = this.txtTelZoneCode.Text.Trim();
                string telNumber = this.txtTelNumber.Text.Trim();
                string faxCountry = this.txtFaxCountry.Text.Trim();
                string faxZoneCode = this.txtFaxZoneCode.Text.Trim();
                string faxNumber = this.txtFaxNumber.Text.Trim();
                string mobile = this.txtMobile.Text.Trim();
                string name = this.txtName.Text.Trim();
                string address = this.txtAddress.Text;
                string postCode = this.txtPostCode.Text.Trim();
                string webSite = this.txtWebSite.Text.Trim();
                bool isDel = false;
                string remark1 = "";

                //this._OrgContact.OrganizationName = OrganizationName;
                this._OrgContact.Email = email;
                this._OrgContact.Mobile = mobile;
                this._OrgContact.Name = name;
                this._OrgContact.TelCountryCode = telCountry;
                this._OrgContact.TelStateCode = telZoneCode;
                this._OrgContact.TelNum = telNumber;
                this._OrgContact.FaxCountryCode = faxCountry;
                this._OrgContact.FaxStateCode = faxZoneCode;
                this._OrgContact.FaxNum = faxNumber;
                this._OrgContact.Website = webSite;
                this._OrgContact.address = address;
                this._OrgContact.PostCode = postCode;
                this._OrgContact.IsDel = isDel;
                this._OrgContact.remark = remark1;
              
                return _OrgContact; 
            }
            set { 
                if(value != null)
                {
                    if (!string.IsNullOrEmpty(value.OrganizationName))
                    {
                        //this.txtOrganizationName.Text = value.OrganizationName;
                        this._OrgContact.OrganizationName = value.OrganizationName;
                    }
                    if (!string.IsNullOrEmpty(value.Email))
                    {
                        this.txtEmail.Text = value.Email;
                        this._OrgContact.Email = value.Email;
                    }
                    if (!string.IsNullOrEmpty(value.TelCountryCode))
                    {
                        this.txtTelCountry.Text = value.TelCountryCode;
                        this._OrgContact.TelCountryCode = value.TelCountryCode;
                    }
                    if (!string.IsNullOrEmpty(value.TelStateCode))
                    {
                        this.txtTelZoneCode.Text = value.TelStateCode;
                        this._OrgContact.TelStateCode = value.TelStateCode;
                    }
                    if (!string.IsNullOrEmpty(value.TelNum))
                    {
                        this.txtTelNumber.Text = value.TelNum;
                        this._OrgContact.TelNum = value.TelNum;
                    }
                    if (!string.IsNullOrEmpty(value.FaxCountryCode))
                    {
                        this.txtFaxCountry.Text = value.FaxCountryCode;
                        this._OrgContact.FaxCountryCode = value.FaxCountryCode;
                    }
                    if (!string.IsNullOrEmpty(value.FaxStateCode))
                    {
                        this.txtFaxZoneCode.Text = value.FaxStateCode;
                        this._OrgContact.FaxStateCode = value.FaxStateCode;
                    }
                    if (!string.IsNullOrEmpty(value.FaxNum))
                    {
                        this.txtFaxNumber.Text = value.FaxNum;
                        this._OrgContact.FaxNum = value.FaxNum;
                    }
                    if (!string.IsNullOrEmpty(value.Website))
                    {
                        this.txtWebSite.Text = value.Website;
                        this._OrgContact.Website = value.Website;
                    }
                    if (!string.IsNullOrEmpty(value.address))
                    {
                        this.txtAddress.Text = value.address;
                        this._OrgContact.address = value.address;
                    }
                    if (!string.IsNullOrEmpty(value.PostCode))
                    {
                        this.txtPostCode.Text = value.PostCode;
                        this._OrgContact.PostCode = value.PostCode;
                    }
                    if (!string.IsNullOrEmpty(value.Name) && value.Name.ToString()!="/")
                    {
                        this.txtName.Text = value.Name;
                        this._OrgContact.Name = value.Name;
                    }
                    if (!string.IsNullOrEmpty(value.Mobile) && value.Mobile.ToString() != "/")
                    {
                        this.txtMobile.Text = value.Mobile;
                        this._OrgContact.Mobile = value.Mobile;
                    }
                    //if (!string.IsNullOrEmpty(value.IsDel))
                    //{
                    //    this.txtFaxNumber.Text = value.FaxNum;
                    //    this._OrgContact.FaxNum = value.FaxNum;
                    //}
                    //if (!string.IsNullOrEmpty(value.remark))
                    //{
                    //    this.txtFaxNumber.Text = value.FaxNum;
                    //    this._OrgContact.FaxNum = value.FaxNum;
                    //}

                }
            }
        }

        /// <summary>
        /// 联系人信息集合
        /// </summary>
    public List<Tz888.Model.Register.OrgContactMan> ContactMans
        {
            get {
                this.inputCount = Convert.ToInt32(this.hdinputCount.Value);
                for (int i = 0; i < this.inputCount; i++)
                {
                    string nameControlID = this.ClientID + "TN" + i.ToString();
                    string mobileControlID = this.ClientID + "TM" + i.ToString();
                    string hiddenControlID = this.ClientID + "HV" + i.ToString();
                    Tz888.Model.Register.OrgContactMan model = new Tz888.Model.Register.OrgContactMan();
                    try
                    {
                        if (model != null)
                        {
                            model.LoginName = Page.User.Identity.Name; // this.Page.Request.Form[hiddenControlID].ToString();
                            model.Name = Convert.ToString(this.Page.Request.Form[nameControlID]);
                            model.Mobile = Convert.ToString(this.Page.Request.Form[mobileControlID]);
                            if (model.Name != "" && model.Mobile != "")
                            {
                                this._ContactMans.Add(model);
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch
                    { return null; }
                }
                return _ContactMans; 
            }
            set {   _ContactMans = value; }
        }
    }
