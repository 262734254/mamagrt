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

public partial class Manage_ModifyProject : System.Web.UI.Page
{
    private long _infoID;
    protected void Page_Load(object sender, EventArgs e)
    {
     
        if (!this.Page.IsPostBack)
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

            this.ViewState["InfoID"] = this._infoID;
            if (this._infoID == 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "参数错误！");
                return;
            }

            this.BindSetCapital();
            this.BindCooperationDemandType();
            this.BindCurrency();

            this.LoadInfo(this._infoID);

        }
    }


    /// <summary>
    /// 绑定融资金额
    /// </summary>
    private void BindSetCapital()
    {
        Tz888.BLL.Common.SetCapitalBLL bll = new Tz888.BLL.Common.SetCapitalBLL();
        ddlCapital.DataSource = bll.GetList();
        ddlCapital.DataTextField = "CapitalName";
        ddlCapital.DataValueField = "CapitalID";
        ddlCapital.DataBind();
    }

    /// <summary>
    /// 绑定项目合作类型
    /// </summary>
    private void BindCooperationDemandType()
    {
        this.chkLstCooperationDemand.DataSource = Tz888.BLL.Info.Common.GetCooperationDemandList("Capital");
        this.chkLstCooperationDemand.DataTextField = "CooperationDemandName";
        this.chkLstCooperationDemand.DataValueField = "CooperationDemandTypeID";
        this.chkLstCooperationDemand.DataBind();
    }

    /// <summary>
    /// 绑定货币种类
    /// </summary>
    private void BindCurrency()
    {
        Tz888.BLL.Common.SetCurrencyBLL bll = new Tz888.BLL.Common.SetCurrencyBLL();
        DataView dv = bll.GetList();
        this.ddlCurrencyTotal.DataSource = dv;
        this.ddlCurrencyTotal.DataTextField = "CurrencyName";
        this.ddlCurrencyTotal.DataValueField = "CurrencyID";
        this.ddlCurrencyTotal.DataBind();

        this.ddlCurrency.DataSource = dv;
        this.ddlCurrency.DataTextField = "CurrencyName";
        this.ddlCurrency.DataValueField = "CurrencyID";
        this.ddlCurrency.DataBind();
    }


    private void LoadInfo(long InfoID)
    {
        Tz888.BLL.Info.ProjectInfoBLL bll = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.ProjectSetModel model = bll.GetIntegrityModel(InfoID);
        
        this.txtProjectName.Text = model.MainInfoModel.Title.Trim();
        if (!string.IsNullOrEmpty(model.ProjectInfoModel.CountryCode.Trim()))
            this.ZoneSelectControl1.CountryID = model.ProjectInfoModel.CountryCode.Trim();
        if (!string.IsNullOrEmpty(model.ProjectInfoModel.ProvinceID.Trim()))
            this.ZoneSelectControl1.ProvinceID = model.ProjectInfoModel.ProvinceID.Trim();
        if (!string.IsNullOrEmpty(model.ProjectInfoModel.CityID.Trim()))
            this.ZoneSelectControl1.CityID = model.ProjectInfoModel.CityID.Trim();
        if (!string.IsNullOrEmpty(model.ProjectInfoModel.CountyID.Trim()))
            this.ZoneSelectControl1.CountyID = model.ProjectInfoModel.CountyID.Trim();

        this.SelectIndustryControl1.IndustryString = model.ProjectInfoModel.IndustryBID;

        string CooperationDemandType = model.ProjectInfoModel.CooperationDemandType.Trim();
        string CooperationDemandTypeItems;
        for (int i = 0; i < chkLstCooperationDemand.Items.Count; i++)
        {
            CooperationDemandTypeItems = chkLstCooperationDemand.Items[i].Value;
            //CooperationDemandTypeItems += ",";
            if (CooperationDemandType.IndexOf(CooperationDemandTypeItems) != -1)
                chkLstCooperationDemand.Items[i].Selected = true;
        }

        this.ddlCurrencyTotal.SelectedValue = model.ProjectInfoModel.ProjectCurrency;
        this.txtCapitalTotal.Text = Convert.ToString(model.ProjectInfoModel.CapitalTotal);
        this.ddlCurrency.SelectedValue = model.ProjectInfoModel.CapitalCurrency;
        this.ddlCapital.SelectedValue = model.ProjectInfoModel.CapitalID;

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

        this.txtProIntro.Value = model.ProjectInfoModel.ComAbout;

        this.ddlValiditeTerm.SelectedValue = model.MainInfoModel.ValidateTerm.ToString();

        this.ImageUploadControl1.InfoList = model.InfoResourceModels;
        this.ImageUploadControl1.InfoType = "Project";
        this.ImageUploadControl1.NoneCount = 3;
        this.ImageUploadControl1.Count = 5;

        this.ProjectAddressInfo1.InfoContact = model.InfoContactModel;
        this.ProjectAddressInfo1.InfoContactMans = model.InfoContactManModels;

        if (Request.UrlReferrer != null)
            ViewState["strPrePage"] = Request.UrlReferrer.ToString();
        else
            ViewState["strPrePage"] = "";
        ViewState["InfoID"] = model.MainInfoModel.InfoID;
        ViewState["PublishT"] = model.MainInfoModel.publishT;
        ViewState["ComBrief"] = model.ProjectInfoModel.ComBrief;
        ViewState["AuditingStatus"] = model.MainInfoModel.AuditingStatus;
        ViewState["HtmlFile"] = model.MainInfoModel.HtmlFile;
        ViewState["ProjectNameBrief"] = model.ProjectInfoModel.ProjectNameBrief;

        ViewState["ShortTitle"] = model.ShortInfoModel.ShortTitle;
        ViewState["ShortContent"] = model.ShortInfoModel.ShortContent;
        ViewState["ShortInfoControlID"] = model.ShortInfoModel.ShortInfoControlID;

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Tz888.Model.Info.ProjectSetModel model = new Tz888.Model.Info.ProjectSetModel();

        model.InfoContactModel = this.ProjectAddressInfo1.InfoContact;
        model.InfoContactManModels = this.ProjectAddressInfo1.InfoContactMans;

        model.ProjectInfoModel.CountryCode = this.ZoneSelectControl1.CountryID;
        model.ProjectInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.ProjectInfoModel.CityID = this.ZoneSelectControl1.CityID;
        model.ProjectInfoModel.CountyID = this.ZoneSelectControl1.CountyID;
        model.ProjectInfoModel.ProjectName = this.txtProjectName.Text.Trim();

        for (int i = 0; chkLstCooperationDemand.Items.Count > i; i++)
        {
            if (chkLstCooperationDemand.Items[i].Selected)
            {
                model.ProjectInfoModel.CooperationDemandType += chkLstCooperationDemand.Items[i].Value + ",";
            }
        }
        model.ProjectInfoModel.CapitalCurrency = Convert.ToString(this.ddlCurrencyTotal.SelectedValue);

        if (!string.IsNullOrEmpty(this.txtCapitalTotal.Text.Trim()))
            model.ProjectInfoModel.CapitalTotal = Convert.ToDecimal(this.txtCapitalTotal.Text.Trim());

        model.ProjectInfoModel.ProjectCurrency = Convert.ToString(this.ddlCurrency.SelectedValue);

        model.ProjectInfoModel.CapitalID = this.ddlCapital.SelectedValue.Trim();

        model.ProjectInfoModel.ComAbout = this.txtProIntro.Value.Trim();
        model.ProjectInfoModel.IndustryBID = this.SelectIndustryControl1.IndustryString;

        model.ProjectInfoModel.ProjectNameBrief = ViewState["ProjectNameBrief"].ToString();

        model.MainInfoModel.InfoID = Convert.ToInt64(this.ViewState["InfoID"]);
        if (!string.IsNullOrEmpty(this.txtProjectName.Text.Trim()))
            model.MainInfoModel.Title = this.txtProjectName.Text.Trim();
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
        model.MainInfoModel.DisplayTitle = this.txtProjectName.Text.Trim();
        model.MainInfoModel.FrontDisplayTime = System.DateTime.Now;
        model.MainInfoModel.ValidateStartTime = System.DateTime.Now.AddDays(1);
        model.MainInfoModel.ValidateTerm = Convert.ToInt32(this.ddlValiditeTerm.SelectedValue.Trim());
        model.MainInfoModel.TemplateID = "001";
        model.MainInfoModel.HtmlFile = ViewState["HtmlFile"].ToString();

        model.ShortInfoModel.ShortInfoControlID = Convert.ToString(ViewState["ShortInfoControlID"]);
        model.ShortInfoModel.ShortTitle = ViewState["ShortTitle"].ToString();
        model.ShortInfoModel.ShortContent = ViewState["ShortContent"].ToString();
        model.ShortInfoModel.Remark = "";

        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = Tz888.Common.InfoResourceManage.ImageTransfer("Image", "Project", Tz888.Common.ResourceType.Image, Tz888.Common.ResourceProperty.InfoImage, ImageUploadControl1.InfoList);
        if (infoResourceModels != null)
            model.InfoResourceModels.AddRange(infoResourceModels);

        Tz888.BLL.Info.ProjectInfoBLL bll = new Tz888.BLL.Info.ProjectInfoBLL();

        if (bll.Update(model))
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改信息成功！", Request.Url.ToString());
        else
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改信息失败！", Request.Url.ToString());
    }
}
