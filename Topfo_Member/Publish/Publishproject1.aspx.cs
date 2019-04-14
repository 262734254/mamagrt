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

public partial class Publish_Publishproject1 : System.Web.UI.Page
{
    //private const string CON_LoginName = "heyi";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }

        if (!this.Page.IsPostBack)
        {
            this.BindSetCapital();
            this.BindCooperationDemandType();
            this.BindCurrency();
            this.InitInfoContact();
        }
        this.ImageUploadControl1.IsTopfoUser = (Page.User.IsInRole("GT1002"));

        for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
        {
            this.chkLstCooperationDemand.Items[i].Attributes.Add("onclick", "checkCooperationDemand();");
        } 
    }

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
        this.chkLstCooperationDemand.DataSource = Tz888.BLL.Info.Common.GetCooperationDemandList("Project");
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


    private void InitInfoContact()
    {
        //string loginName = CON_LoginName;
        string loginName = Page.User.Identity.Name;
        Tz888.BLL.Register.common bll = new Tz888.BLL.Register.common();
        Tz888.Model.Register.OrgContactModel model = new Tz888.Model.Register.OrgContactModel();

        model = bll.getContactModel(loginName);

        if (model == null)
            return;
        Tz888.Model.Info.InfoContactModel model1 = new Tz888.Model.Info.InfoContactModel();

        model1.OrganizationName = model.OrganizationName.Trim();
        model1.Name = model.Name.Trim();
        model1.Mobile = model.Mobile.Trim();
        model1.PostCode = model.PostCode.Trim();
        model1.TelCountryCode = model.TelCountryCode.Trim();
        model1.TelNum = model.TelNum.Trim();
        model1.TelStateCode = model.TelStateCode.Trim();
        model1.WebSite = model.Website.Trim();
        model1.FaxCountryCode = model.FaxCountryCode.Trim();
        model1.FaxNum = model.FaxNum.Trim();
        model1.FaxStateCode = model.FaxStateCode.Trim();
        model1.Email = model.Email.Trim();
        model1.Address = model.address.Trim();
        model1.Career = model.Career.Trim();

        this.ProjectAddressInfo1.InfoContact = model1;

    }

    protected void imgbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        Tz888.BLL.Info.ProjectInfoBLL projectObj = new Tz888.BLL.Info.ProjectInfoBLL();
        

        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ProjectInfoModel projectInfoModel = new Tz888.Model.Info.ProjectInfoModel(); //创建融资信息实体
        Tz888.Model.Info.InfoContactModel infoContactModel = new Tz888.Model.Info.InfoContactModel(); //创建信息联系方式主体
        Tz888.Model.Info.ShortInfoModel sortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        List<Tz888.Model.Info.InfoContactManModel> infoContactManModels = new List<Tz888.Model.Info.InfoContactManModel>(); //联系人实体列表
        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>();

        DateTime time_Now = DateTime.Now;

        infoContactModel = this.ProjectAddressInfo1.InfoContact;
        industryModels = this.SelectIndustryControl1.IndustryModels;
        infoContactManModels = this.ProjectAddressInfo1.InfoContactMans;

        projectInfoModel.CountryCode = this.ZoneSelectControl1.CountryID;
        projectInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        projectInfoModel.CityID = this.ZoneSelectControl1.CityID;
        projectInfoModel.CountyID = this.ZoneSelectControl1.CountyID;
        projectInfoModel.ProjectName = this.txtProjectName.Text.Trim();

        for (int i = 0; chkLstCooperationDemand.Items.Count > i; i++)
        {
            if (chkLstCooperationDemand.Items[i].Selected)
            {
                projectInfoModel.CooperationDemandType += chkLstCooperationDemand.Items[i].Value + ",";
            }
        }
        projectInfoModel.CapitalCurrency = Convert.ToString(this.ddlCurrencyTotal.SelectedValue);

        if (!string.IsNullOrEmpty(this.txtCapitalTotal.Text.Trim()))
            projectInfoModel.CapitalTotal = Convert.ToDecimal(this.txtCapitalTotal.Text.Trim());

        projectInfoModel.ProjectCurrency = Convert.ToString(this.ddlCurrency.SelectedValue);

        projectInfoModel.CapitalID = this.ddlCapital.SelectedValue.Trim();

        projectInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtProIntro.Value.Trim());
        foreach (Tz888.Model.Common.IndustryModel model in industryModels)
        {
            projectInfoModel.IndustryBID += model.IndustryBID + ",";
        }
        projectInfoModel.ProjectNameBrief = "";

        if (!string.IsNullOrEmpty(this.txtProjectName.Text))
            mainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Text);

        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Project", industryModels[0].IndustryBID, this.ZoneSelectControl1.CountryID, time_Now);
        mainInfoModel.publishT = time_Now;
        mainInfoModel.Hit = 0;

        mainInfoModel.IsCore = true;
        //mainInfoModel.LoginName = ""; //用户名称
        mainInfoModel.LoginName = Page.User.Identity.Name;
        mainInfoModel.InfoOriginRoleName = "0"; //用户角色
        mainInfoModel.GradeID = "0";
        mainInfoModel.FixPriceID = "1";
        mainInfoModel.FeeStatus = 0;

        string keyword = "";
        if (!string.IsNullOrEmpty(this.txtKeyword1.Text.Trim()))
            keyword += this.txtKeyword1.Text.Trim() + ",";
        if (!string.IsNullOrEmpty(this.txtKeyword2.Text.Trim()))
            keyword += this.txtKeyword2.Text.Trim() + ",";
        if (!string.IsNullOrEmpty(this.txtKeyword3.Text.Trim()))
            keyword += this.txtKeyword3.Text.Trim() + ",";
        if (!string.IsNullOrEmpty(keyword))
            mainInfoModel.KeyWord = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(keyword);
        mainInfoModel.Descript = "";
        if (!string.IsNullOrEmpty(this.txtProjectName.Text.Trim()))
            mainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Text.Trim());
        mainInfoModel.FrontDisplayTime = time_Now;
        mainInfoModel.ValidateStartTime = time_Now;
        mainInfoModel.ValidateTerm = Convert.ToInt32(this.ddlValiditeTerm.SelectedValue.Trim());
        mainInfoModel.TemplateID = "001";
        mainInfoModel.HtmlFile = "";

        sortInfoModel.ShortInfoControlID = "ProjectIndex1";
        sortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Text.Trim());
        sortInfoModel.ShortContent = "";
        sortInfoModel.Remark = "";

        //将已上传的图片从临时目录迁移到正式目录
        //infoResourceModels = Tz888.Common.InfoResourceManage.ImageTransfer("Image", "Project", Tz888.Common.ResourceType.Image, Tz888.Common.ResourceProperty.InfoImage, ImageUploadControl1.InfoList);
        infoResourceModels = ImageUploadControl1.InfoList;

        //将融资信息写入数据库，返回InfoID
        long infoID = projectObj.Insert(mainInfoModel, projectInfoModel, infoContactModel, sortInfoModel, infoContactManModels, infoResourceModels);

        if (infoID > 0)
        {
            bool isTof = Page.User.IsInRole("GT1002");
            if (isTof)
            {
                string HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("Project", mainInfoModel.InfoCode, infoID);
                Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
                mainBll.HasHtmlFile(infoID, HtmlFile);
                string actionMsg = "";
                Tz888.BLL.PageStatic.ProjectPageStatic staticobj = new Tz888.BLL.PageStatic.ProjectPageStatic();
                staticobj.CreateStaticPageProject(infoID.ToString(), ref actionMsg);
            }
            Response.Redirect("Publishproject2.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(infoID.ToString() + "|Project|" + this.txtProjectName.Text.Trim() + "|" +projectInfoModel.CooperationDemandType));
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
        }
    }
}
