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

public partial class Publish_PublishCapital : System.Web.UI.Page
{
    private const string CON_LoginName = "test";
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
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            return;
        }
        
        if (!this.Page.IsPostBack)
        {
            this.BindCurrency();
            this.BindSetCapital();
            this.BindCapitalType();
            this.BindCooperationDemandType();
            this.InitInfoContact();
            
        }
        this.ImageUploadControl1.IsTopfoUser = (Page.User.IsInRole("GT1002"));

        for (int i = 0; i < this.rblCapitalType.Items.Count; i++)
        {
            this.rblCapitalType.Items[i].Attributes.Add("onclick", "checkCapitalType();");
        }


        for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
        {
            this.chkLstCooperationDemand.Items[i].Attributes.Add("onclick", "checkCooperationDemand();");
        }
    }

    /// <summary>
    /// 设置货币种类
    /// </summary>
    private void BindCurrency()
    {
        Tz888.BLL.Common.SetCurrencyBLL bll = new Tz888.BLL.Common.SetCurrencyBLL();
        this.ddlCurrency.DataSource = bll.GetList();
        this.ddlCurrency.DataTextField = "CurrencyName";
        this.ddlCurrency.DataValueField = "CurrencyID";
        this.ddlCurrency.DataBind();
    }

    /// <summary>
    /// 设置融资金额
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
    /// 设置投资类型
    /// </summary>
    private void BindCapitalType()
    {
        Tz888.BLL.Common.ParameterBLL bll = new Tz888.BLL.Common.ParameterBLL();
        rblCapitalType.DataSource = bll.GetAllCapitalType();
        rblCapitalType.DataValueField = "CapitalTypeID";
        rblCapitalType.DataTextField = "CapitalTypeName";
        rblCapitalType.DataBind();
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

    private void InitInfoContact()
    {
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

        this.CapitalAddressInfo1.InfoContact = model1;

    }

    protected void IbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        Tz888.BLL.Info.CapitalInfoBLL capitalObj = new Tz888.BLL.Info.CapitalInfoBLL();

        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.CapitalInfoModel capitalInfoModel = new Tz888.Model.Info.CapitalInfoModel(); //创建投资信息实体
        Tz888.Model.Info.InfoContactModel infoContactModel = new Tz888.Model.Info.InfoContactModel(); //创建信息联系方式主体
        Tz888.Model.Info.ShortInfoModel shortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        List<Tz888.Model.Info.CapitalInfoAreaModel> capitalInfoAreaModels = new List<Tz888.Model.Info.CapitalInfoAreaModel>();//投资区域信息实体列表
        List<Tz888.Model.Info.InfoContactManModel> infoContactManModels = new List<Tz888.Model.Info.InfoContactManModel>(); //联系人实体列表
        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>();//投资信息资源信息实体

        DateTime time_now = DateTime.Now;

        infoContactModel = this.CapitalAddressInfo1.InfoContact;
        industryModels = this.SelectIndustryControl1.IndustryModels;
        capitalInfoAreaModels = this.ZoneMoreSelectControl1.CapitalInfoAreaModels;
        infoContactManModels = this.CapitalAddressInfo1.InfoContactMans;

        #region 投资信息实体赋值

        capitalInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtCapitalIntent.Value.Trim());
        capitalInfoModel.CapitalTypeID = this.rblCapitalType.SelectedValue;
        capitalInfoModel.Currency = this.ddlCurrency.SelectedValue;
        
        capitalInfoModel.CapitalID = this.ddlCapital.SelectedValue;
        capitalInfoModel.ComBreif = "";
        capitalInfoModel.CooperationDemandType = "";
        capitalInfoModel.IndustryBID = "";
        foreach (Tz888.Model.Common.IndustryModel model in industryModels)
        {
            capitalInfoModel.IndustryBID += model.IndustryBID + ",";
        }

        for (int i = 0; chkLstCooperationDemand.Items.Count > i; i++)
        {
            if (chkLstCooperationDemand.Items[i].Selected)
            {
                capitalInfoModel.CooperationDemandType += chkLstCooperationDemand.Items[i].Value + ",";
            }
        }

        #endregion

        if (!string.IsNullOrEmpty(this.txtCapitalName.Text.Trim()))
            mainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());

        string CountryCode;
        try
        {
            CountryCode = capitalInfoAreaModels[0].CountryCode;
        }
        catch
        {
            CountryCode = "ALL";
        }
        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Capital", industryModels[0].IndustryBID, CountryCode, time_now);
        mainInfoModel.publishT = time_now;
        mainInfoModel.Hit = 0;

        mainInfoModel.IsCore = true;
        mainInfoModel.LoginName = Page.User.Identity.Name;
        //mainInfoModel.LoginName = "Clandylee"; //用户名称
        mainInfoModel.InfoOriginRoleName = "0"; //用户角色
        mainInfoModel.GradeID = "0";
        mainInfoModel.FixPriceID = "1";
        mainInfoModel.FeeStatus = 0;

        string keyword = "";
        if (!string.IsNullOrEmpty(this.txtKeyword1.Text.Trim()))
            keyword += Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtKeyword1.Text.Trim()) + ",";
        if (!string.IsNullOrEmpty(this.txtKeyword2.Text.Trim()))
            keyword += Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtKeyword2.Text.Trim()) + ",";
        if (!string.IsNullOrEmpty(this.txtKeyword3.Text.Trim()))
            keyword += Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtKeyword3.Text.Trim()) + ",";

        mainInfoModel.KeyWord = keyword;
        mainInfoModel.Descript = "";
        if (!string.IsNullOrEmpty(this.txtCapitalName.Text.Trim()))
            mainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());
        mainInfoModel.FrontDisplayTime = time_now;
        mainInfoModel.ValidateStartTime = time_now;
        mainInfoModel.ValidateTerm = Convert.ToInt32(this.ddlValiditeTerm.SelectedValue.Trim());
        mainInfoModel.TemplateID = "001";
        mainInfoModel.HtmlFile = "";
        
        shortInfoModel.ShortInfoControlID = "CapitalIndex1";
        if (!string.IsNullOrEmpty(this.txtCapitalName.Text.Trim()))
            shortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());
        shortInfoModel.ShortContent = "";
        shortInfoModel.Remark = "";

        //将已上传的图片从临时目录迁移到正式目录
        //infoResourceModels = Tz888.Common.InfoResourceManage.ImageTransfer("Image", "Capital", Tz888.Common.ResourceType.Image, Tz888.Common.ResourceProperty.InfoImage, ImageUploadControl1.InfoList);
        infoResourceModels = ImageUploadControl1.InfoList;

        Tz888.BLL.Info.CapitalInfoBLL bll = new Tz888.BLL.Info.CapitalInfoBLL();
        //long infoID = bll.Insert(mainInfoModel, capitalInfoModel, infoContactModel, shortInfoModel, capitalInfoAreaModels, infoContactManModels, infoResourceModels);
        long infoID = bll.Insert(mainInfoModel, capitalInfoModel, infoContactModel, shortInfoModel, capitalInfoAreaModels, infoResourceModels);
        if (infoID > 0)
        {
            bool isTof = Page.User.IsInRole("GT1002");
            if (isTof)
            {
                string HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("Capital", mainInfoModel.InfoCode, infoID);
                Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
                mainBll.HasHtmlFile(infoID, HtmlFile);
                string actionMsg = "";
                Tz888.BLL.PageStatic.CapitalPageStatic staticobj = new Tz888.BLL.PageStatic.CapitalPageStatic();
                staticobj.CreateStaticPageCapital(infoID.ToString(), ref actionMsg);
            }
            Response.Redirect("PublishCapital2.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(infoID.ToString() + "|Capital|" + this.txtCapitalName.Text.Trim()));
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
        }
    }
}
