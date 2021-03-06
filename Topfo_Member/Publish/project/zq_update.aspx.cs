﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Publish_project_zq_update : System.Web.UI.Page
{
    protected long _infoid;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

        if (isTof)
        {
            Page.MasterPageFile = "/indexTof.master";
        }
        else
        {
            Page.MasterPageFile = "/MasterPage.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ImageButton1.Attributes.Add("onclick", "return chkpost();");
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        _infoid=Convert.ToInt64(Request.QueryString["InfoID"]);
        if (!Page.IsPostBack)
        {
            bindObj();
            BindSetCapital();
            GetInfoModel();
            this.UpFileControl1.InfoID = _infoid;
        }
    }
    /// 绑定融资金额
    private void BindSetCapital()
    {
        Tz888.BLL.Common.SetCapitalBLL bll = new Tz888.BLL.Common.SetCapitalBLL();
        rbtnCapital.DataSource = bll.GetList();
        rbtnCapital.DataTextField = "CapitalName";
        rbtnCapital.DataValueField = "CapitalID";
        rbtnCapital.DataBind();
    }
    //融资对象
    public void bindObj()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("SETfinancingTargetTab", "*", "financingID", 10, 1, 0, 0, "");
        rbtnObj.DataTextField = "financingName";
        rbtnObj.DataValueField = "financingID";
        rbtnObj.DataSource = dt;
        rbtnObj.DataBind();
    }
    public void GetInfoModel()
    {
        Tz888.BLL.Info.ProjectInfoBLL bll = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.ProjectSetModel model = bll.GetIntegrityModel(_infoid);
        if (model == null)
            return;
        this.txtProjectName.Value = model.ProjectInfoModel.ProjectName;
        this.SelectIndustryControl1.IndustryString = model.ProjectInfoModel.IndustryBID;

        if (!string.IsNullOrEmpty(model.ProjectInfoModel.CountryCode.Trim()))
            this.ZoneSelectControl1.CountryID = model.ProjectInfoModel.CountryCode.Trim();
        if (!string.IsNullOrEmpty(model.ProjectInfoModel.ProvinceID.Trim()))
            this.ZoneSelectControl1.ProvinceID = model.ProjectInfoModel.ProvinceID.Trim();
        if (!string.IsNullOrEmpty(model.ProjectInfoModel.CityID.Trim()))
            this.ZoneSelectControl1.CityID = model.ProjectInfoModel.CityID.Trim();
        if (!string.IsNullOrEmpty(model.ProjectInfoModel.CountyID.Trim()))
            this.ZoneSelectControl1.CountyID = model.ProjectInfoModel.CountyID.Trim();

        this.txtProIntro.Value = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(Tz888.Common.Utility.PageValidate.HtmlToTxt(model.ProjectInfoModel.ComAbout));

        if (model.ProjectInfoModel.financingID.ToString() != "")
            rbtnObj.SelectedValue = model.ProjectInfoModel.financingID.ToString();
        this.txtCapitalTotal.Text = model.ProjectInfoModel.CapitalTotal.ToString();

        if (model.ProjectInfoModel.CapitalID != "")
            rbtnCapital.SelectedValue = model.ProjectInfoModel.CapitalID;
        this.txtWarrant.Value = model.ProjectInfoModel.warrant;
        this.txtMarketAbout.Value = model.ProjectInfoModel.marketAbout;
        this.txtCompanyYearIncome.Value = model.ProjectInfoModel.CompanyYearIncome.ToString();
        this.txtCompanyNG.Value = model.ProjectInfoModel.CompanyNG.ToString();
        this.txtCompanyTotalCapital.Value = model.ProjectInfoModel.CompanyTotalCapital.ToString();
        this.txtCompanyTotalDebet.Value = model.ProjectInfoModel.CompanyTotalDebet.ToString();

        if (model.InfoContactModel != null)
        {
            this.txtCompanyName.Value = model.InfoContactModel.OrganizationName;
            this.txtLinkMan.Value = model.InfoContactModel.Name;
            this.txtCareer.Value = model.InfoContactModel.Career;
            this.txtTelStateCode.Value = model.InfoContactModel.TelStateCode.Trim();
            this.txtTel.Value = model.InfoContactModel.TelNum;
            this.txtMobile.Value = model.InfoContactModel.Mobile;
            this.txtEmail.Value = model.InfoContactModel.Email;
            this.txtAddress.Value = model.InfoContactModel.Address;
            this.txtWebSite.Value = model.InfoContactModel.WebSite;
        }
        this.rbtnValiDate.SelectedValue = model.MainInfoModel.ValidateTerm.ToString();

        ViewState["PublishT"] = model.MainInfoModel.publishT;
        ViewState["InfoID"] = model.MainInfoModel.InfoID;
        ViewState["HtmlFile"] = model.MainInfoModel.HtmlFile;
        ViewState["ProjectNameBrief"] = model.ProjectInfoModel.ProjectNameBrief;
        ViewState["ShortTitle"] = model.ShortInfoModel.ShortTitle;
        ViewState["ShortContent"] = model.ShortInfoModel.ShortContent;
        ViewState["ShortInfoControlID"] = model.ShortInfoModel.ShortInfoControlID;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Tz888.Model.Info.ProjectSetModel model = new Tz888.Model.Info.ProjectSetModel();

        model.ProjectInfoModel.CountryCode = this.ZoneSelectControl1.CountryID;
        model.ProjectInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.ProjectInfoModel.CityID = this.ZoneSelectControl1.CityID;
        model.ProjectInfoModel.CountyID = this.ZoneSelectControl1.CountyID;
        model.ProjectInfoModel.ProjectName =this.txtProjectName.Value.Trim();
        model.ProjectInfoModel.RecTime = DateTime.Now;
        model.ProjectInfoModel.CooperationDemandType = "9";
        model.ProjectInfoModel.CapitalCurrency = "CNY";
        model.ProjectInfoModel.ProjectCurrency = "CNY";

        //新属性

        model.ProjectInfoModel.financingID = rbtnObj.SelectedValue;
        model.ProjectInfoModel.warrant =  Tz888.Common.Utility.PageValidate.TxtToHtml(Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtWarrant.Value.Trim()));
        model.ProjectInfoModel.marketAbout=Tz888.Common.Utility.PageValidate.TxtToHtml(Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtMarketAbout.Value));
        model.ProjectInfoModel.CompanyYearIncome = Convert.ToDecimal(this.txtCompanyYearIncome.Value);
        model.ProjectInfoModel.CompanyNG = Convert.ToDecimal(this.txtCompanyNG.Value); ;
        model.ProjectInfoModel.CompanyTotalCapital = Convert.ToDecimal(this.txtCompanyTotalCapital.Value.Trim());
        model.ProjectInfoModel.CompanyTotalDebet = Convert.ToDecimal(this.txtCompanyTotalDebet.Value.Trim());

        if (!string.IsNullOrEmpty(this.txtCapitalTotal.Text.Trim()))
            model.ProjectInfoModel.CapitalTotal = Convert.ToDecimal(this.txtCapitalTotal.Text.Trim());

        model.ProjectInfoModel.CapitalID = this.rbtnCapital.SelectedValue;

        model.ProjectInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProIntro.Value.Trim()));
        model.ProjectInfoModel.IndustryBID = this.SelectIndustryControl1.IndustryString;



        model.ProjectInfoModel.ProjectNameBrief = ViewState["ProjectNameBrief"].ToString();

        model.MainInfoModel.InfoID = Convert.ToInt64(this.ViewState["InfoID"]);
        if (!string.IsNullOrEmpty(this.txtProjectName.Value.Trim()))
            model.MainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        model.MainInfoModel.publishT = Convert.ToDateTime(this.ViewState["PublishT"]);
        model.MainInfoModel.LoginName = Page.User.Identity.Name;
        //model.MainInfoModel.KeyWord = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(keyword);
        model.MainInfoModel.Descript = "";
        model.MainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        model.MainInfoModel.FrontDisplayTime = System.DateTime.Now;
        model.MainInfoModel.ValidateStartTime = System.DateTime.Now;
        model.MainInfoModel.ValidateTerm = Convert.ToInt32(this.rbtnValiDate.SelectedValue.Trim());
        model.MainInfoModel.TemplateID = "001";
        model.MainInfoModel.HtmlFile = ViewState["HtmlFile"].ToString();

        model.ShortInfoModel.ShortInfoControlID = Convert.ToString(ViewState["ShortInfoControlID"]);
        model.ShortInfoModel.ShortTitle = ViewState["ShortTitle"].ToString();
        model.ShortInfoModel.ShortContent = ViewState["ShortContent"].ToString();
        model.ShortInfoModel.Remark = "";

        //联系信息
        if (model.InfoContactModel != null)
        {
            model.InfoContactModel.OrganizationName = txtCompanyName.Value.Trim();
            model.InfoContactModel.Name = txtLinkMan.Value.Trim();
            model.InfoContactModel.Career = txtCareer.Value.Trim();
            model.InfoContactModel.TelStateCode = txtTelStateCode.Value.Trim();
            model.InfoContactModel.TelNum = txtTel.Value.Trim();
            model.InfoContactModel.Mobile = txtMobile.Value.Trim();
            model.InfoContactModel.Email = txtEmail.Value.Trim();
            model.InfoContactModel.Address = txtAddress.Value.Trim();
            model.InfoContactModel.WebSite = txtWebSite.Value.Trim();
        }
     
        Tz888.BLL.Info.ProjectInfoBLL bll = new Tz888.BLL.Info.ProjectInfoBLL();
        //if (bll.ProjectInfoZQ_Update(model))
        //{
        //    bool isTof = Page.User.IsInRole("GT1002");
        //    if (isTof)
        //    {
        //        if (string.IsNullOrEmpty(model.MainInfoModel.HtmlFile.Trim()))
        //            model.MainInfoModel.HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("Project", model.MainInfoModel.InfoCode, model.MainInfoModel.InfoID);
        //        Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
        //        mainBll.HasHtmlFile(model.MainInfoModel.InfoID, model.MainInfoModel.HtmlFile);
        //        string actionMsg = "";
        //        Tz888.BLL.PageStatic.ProjectPageStatic staticobj = new Tz888.BLL.PageStatic.ProjectPageStatic();
        //        staticobj.CreateStaticPageProject(model.MainInfoModel.InfoID.ToString(), ref actionMsg);
        //    }
        //    Tz888.Common.MessageBox.ShowAndHref("修改信息成功！", Request.Url.ToString());
        //}
        //else
        //    Tz888.Common.MessageBox.ShowAndHref("修改信息失败！", Request.Url.ToString());
    }
}
