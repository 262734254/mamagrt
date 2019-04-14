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

public partial class Manage_ModifyMerchant : System.Web.UI.Page
{
    private long _infoID;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            if (this.Page.Request.QueryString["InfoID"] != null)
            {
                try
                {
                    this._infoID = Convert.ToInt64(this.Page.Request.QueryString["InfoID"]);
                }
                catch
                {
                    this._infoID = 0;
                }
            }
            this._infoID = 118;
            this.ViewState["InfoID"] = this._infoID;
            if (this._infoID == 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "参数错误！");
                return;
            }
            this.BindMerchantType();
            this.BindCooperationDemandType();
            this.BindSetCapital();
            this.BindCurrency();
            this.LoadInfo(this._infoID);
        }
    }



    /// <summary>
    /// 招商类别
    /// </summary>
    private void BindMerchantType()
    {
        this.rblMerchantType.DataSource = Tz888.BLL.Info.Common.GetMerchantAttributeList();
        this.rblMerchantType.DataTextField = "MerchantAttributeName";
        this.rblMerchantType.DataValueField = "MerchantAttributeID";
        this.rblMerchantType.DataBind();
    }

    /// <summary>
    /// 合作方式
    /// </summary>
    private void BindCooperationDemandType()
    {
        this.cblCooperationDemandType.DataSource = Tz888.BLL.Info.Common.GetCooperationDemandList("Merchant");
        this.cblCooperationDemandType.DataTextField = "CooperationDemandName";
        this.cblCooperationDemandType.DataValueField = "CooperationDemandTypeID";
        this.cblCooperationDemandType.DataBind();
    }

    /// <summary>
    /// 绑定融资金额
    /// </summary>
    private void BindSetCapital()
    {
        Tz888.BLL.Common.SetCapitalBLL bll = new Tz888.BLL.Common.SetCapitalBLL();
        this.ddlMerchantTotal.DataSource = bll.GetList();
        this.ddlMerchantTotal.DataTextField = "CapitalName";
        this.ddlMerchantTotal.DataValueField = "CapitalID";
        this.ddlMerchantTotal.DataBind();
    }

    /// <summary>
    /// 绑定货币种类
    /// </summary>
    private void BindCurrency()
    {
        Tz888.BLL.Common.SetCurrencyBLL bll = new Tz888.BLL.Common.SetCurrencyBLL();
        DataView dv = bll.GetList();
        this.ddlCapitalCurrency.DataSource = dv;
        this.ddlCapitalCurrency.DataTextField = "CurrencyName";
        this.ddlCapitalCurrency.DataValueField = "CurrencyID";
        this.ddlCapitalCurrency.DataBind();

        this.ddlMerchantCurrency.DataSource = dv;
        this.ddlMerchantCurrency.DataTextField = "CurrencyName";
        this.ddlMerchantCurrency.DataValueField = "CurrencyID";
        this.ddlMerchantCurrency.DataBind();
    }

    private void LoadInfo(long InfoID)
    {
        Tz888.BLL.Info.MarchantInfoBLL bll = new Tz888.BLL.Info.MarchantInfoBLL();
        Tz888.Model.Info.MerchantSetModel model = bll.GetIntegrityModel(InfoID);

        this.rblMerchantType.SelectedValue = model.MerchantInfoModel.MerchantTypeID.Trim();
        this.txtMerchantTopic.Text = model.MainInfoModel.Title;
        if(!string.IsNullOrEmpty(model.MerchantInfoModel.CountryCode.Trim()))
            this.ZoneSelectControl1.CountryID = model.MerchantInfoModel.CountryCode.Trim();
        if(!string.IsNullOrEmpty(model.MerchantInfoModel.ProvinceID.Trim()))
            this.ZoneSelectControl1.ProvinceID = model.MerchantInfoModel.ProvinceID.Trim();
        if(!string.IsNullOrEmpty(model.MerchantInfoModel.CityID.Trim()))
            this.ZoneSelectControl1.CityID = model.MerchantInfoModel.CityID.Trim();
        if(!string.IsNullOrEmpty(model.MerchantInfoModel.CountyID.Trim()))
            this.ZoneSelectControl1.CountyID = model.MerchantInfoModel.CountyID.Trim();
        this.SelectIndustryControl1.IndustryString = model.MerchantInfoModel.IndustryClassList.Trim();

        string CooperationDemandType = model.MerchantInfoModel.CooperationDemandType.Trim();
        string CooperationDemandTypeItems;
        for (int i = 0; i < cblCooperationDemandType.Items.Count; i++)
        {
            CooperationDemandTypeItems = cblCooperationDemandType.Items[i].Value;
            //CooperationDemandTypeItems += ",";
            if (CooperationDemandType.IndexOf(CooperationDemandTypeItems) != -1)
                cblCooperationDemandType.Items[i].Selected = true;
        }

        this.ddlCapitalCurrency.SelectedValue = model.MerchantInfoModel.CapitalCurrency;
        this.txtCapitalTotal.Text = Convert.ToString(model.MerchantInfoModel.CapitalTotal);
        this.ddlMerchantCurrency.SelectedValue = model.MerchantInfoModel.MerchantCurrency;
        this.ddlMerchantTotal.SelectedValue = model.MerchantInfoModel.MerchantTotal;

        this.txtZoneAbout.Value = model.MerchantInfoModel.ZoneAbout.Trim();

        if (!string.IsNullOrEmpty(model.MainInfoModel.KeyWord.Trim()))
        {
            string[] keys = model.MainInfoModel.KeyWord.Trim().Split(',');
            for (int i = 0; i < keys.Length; i++)
            {
                string key = keys[i].ToString().Trim();
                switch (i)
                {
                    case 0:
                        this.txtKeyword1.Text = key;
                        break;
                    case 1:
                        this.txtKeyword2.Text = key;
                        break;
                    case 2:
                        this.txtKeyword3.Text = key;
                        break;
                    default:
                        break;
                }
            }
        }

        this.ddlValiditeTerm.SelectedValue = model.MainInfoModel.ValidateTerm.ToString();

        this.ImageUploadControl1.InfoList = model.InfoResourceModels;
        this.ImageUploadControl1.InfoType = "Merchant";
        this.ImageUploadControl1.NoneCount = 3;
        this.ImageUploadControl1.Count = 5;

        this.MerchantInfoAddressInfo1.InfoContact = model.InfoContactModel;
        //this.MerchantInfoAddressInfo1.InfoContactMans = model.InfoContactManModels;
        this.MerchantInfoAddressInfo1.Undertaker = model.MerchantInfoModel.ReceiveOrganization.Trim();


        if (Request.UrlReferrer != null)
            ViewState["strPrePage"] = Request.UrlReferrer.ToString();
        else
            ViewState["strPrePage"] = "";
        ViewState["InfoID"] = model.MainInfoModel.InfoID;
        ViewState["PublishT"] = model.MainInfoModel.publishT;
        ViewState["ZoneAboutBrief"] = model.MerchantInfoModel.ZoneAboutBrief;
        ViewState["AuditingStatus"] = model.MainInfoModel.AuditingStatus;
        ViewState["HtmlFile"] = model.MainInfoModel.HtmlFile;

        ViewState["ShortTitle"] = model.ShortInfoModel.ShortTitle;
        ViewState["ShortContent"] = model.ShortInfoModel.ShortContent;
        ViewState["ShortInfoControlID"] = model.ShortInfoModel.ShortInfoControlID;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Tz888.Model.Info.MerchantSetModel model = new Tz888.Model.Info.MerchantSetModel();

        model.InfoContactModel = this.MerchantInfoAddressInfo1.InfoContact;
      //  model.InfoContactManModels = this.MerchantInfoAddressInfo1.InfoContactMans;

        #region 招商信息实体
        model.MerchantInfoModel.MerchantTypeID = this.rblMerchantType.SelectedValue;
        model.MerchantInfoModel.CountryCode = this.ZoneSelectControl1.CountryID;
        model.MerchantInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.MerchantInfoModel.CityID = this.ZoneSelectControl1.CityID;
        model.MerchantInfoModel.CountyID = this.ZoneSelectControl1.CountyID;

        model.MerchantInfoModel.IndustryClassList = this.SelectIndustryControl1.IndustryString;
        model.MerchantInfoModel.CapitalCurrency = this.ddlCapitalCurrency.SelectedValue;
        model.MerchantInfoModel.CapitalTotal = Convert.ToDecimal(this.txtCapitalTotal.Text.Trim());
        model.MerchantInfoModel.MerchantCurrency = this.ddlMerchantCurrency.SelectedValue;
        model.MerchantInfoModel.MerchantTotal = this.ddlMerchantTotal.SelectedValue;
        model.MerchantInfoModel.ZoneAbout = this.txtZoneAbout.Value.ToString();
        model.MerchantInfoModel.ZoneAboutBrief = ViewState["ZoneAboutBrief"].ToString();
        if (MerchantInfoAddressInfo1.Undertaker != null)
        {
            model.MerchantInfoModel.ReceiveOrganization = this.MerchantInfoAddressInfo1.Undertaker.Trim();
        }

        model.MerchantInfoModel.CooperationDemandType = "";

        for (int i = 0; cblCooperationDemandType.Items.Count > i; i++)
        {
            if (cblCooperationDemandType.Items[i].Selected)
            {
                model.MerchantInfoModel.CooperationDemandType += cblCooperationDemandType.Items[i].Value + ",";
            }
        }
        
        #endregion

        model.MainInfoModel.InfoID = Convert.ToInt64(this.ViewState["InfoID"]);
        if (!string.IsNullOrEmpty(this.txtMerchantTopic.Text.Trim()))
            model.MainInfoModel.Title = this.txtMerchantTopic.Text.Trim();
        model.MainInfoModel.publishT = Convert.ToDateTime(this.ViewState["PublishT"]);

        model.MainInfoModel.LoginName = ""; //用户名称

        string keyword = "";
        if (!string.IsNullOrEmpty(this.txtKeyword1.Text.Trim()))
            keyword += this.txtKeyword1.Text.Trim() + ",";
        if (!string.IsNullOrEmpty(this.txtKeyword2.Text.Trim()))
            keyword += this.txtKeyword2.Text.Trim() + ",";
        if (!string.IsNullOrEmpty(this.txtKeyword3.Text.Trim()))
            keyword += this.txtKeyword3.Text.Trim() + ",";

        model.MainInfoModel.KeyWord = keyword;
        model.MainInfoModel.Descript = "";
        model.MainInfoModel.DisplayTitle = this.txtMerchantTopic.Text.Trim();
        model.MainInfoModel.FrontDisplayTime = System.DateTime.Now;
        model.MainInfoModel.ValidateStartTime = System.DateTime.Now.AddDays(1);
        model.MainInfoModel.ValidateTerm = Convert.ToInt32(this.ddlValiditeTerm.SelectedValue.Trim());
        model.MainInfoModel.TemplateID = "001";
        model.MainInfoModel.HtmlFile = ViewState["HtmlFile"].ToString();

        model.ShortInfoModel.ShortInfoControlID = Convert.ToString(ViewState["ShortInfoControlID"]);
        model.ShortInfoModel.ShortTitle = ViewState["ShortTitle"].ToString();
        model.ShortInfoModel.ShortContent = ViewState["ShortContent"].ToString();
        model.ShortInfoModel.Remark = "";

        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = Tz888.Common.InfoResourceManage.ImageTransfer("Image", "Merchant", Tz888.Common.ResourceType.Image, Tz888.Common.ResourceProperty.InfoImage, ImageUploadControl1.InfoList);
        if (infoResourceModels != null)
            model.InfoResourceModels.AddRange(infoResourceModels);

        Tz888.BLL.Info.MarchantInfoBLL bll = new Tz888.BLL.Info.MarchantInfoBLL();

        if (bll.Update(model))
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改信息成功！", Request.Url.ToString());
        else
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改信息失败！", Request.Url.ToString());
    }
}
