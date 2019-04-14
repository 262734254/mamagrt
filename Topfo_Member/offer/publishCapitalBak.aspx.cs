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
using Tz888.Common;

public partial class publishCapital : System.Web.UI.Page
{
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
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Tz888.Common.Ajax.AjaxMethod));
        if (!this.Page.IsPostBack)
        {
            this.BindCapitalType();
            this.BindSetCapital();
            this.BindCooperationDemandType();
            this.BindJoinManage();
            this.BindStage();
        }

        for (int i = 0; i < this.rblfinancingTarget.Items.Count; i++)
        {
            this.rblfinancingTarget.Items[i].Attributes.Add("onclick", "checkCapitalType();");
        }

        for (int i = 0; i < this.rblCurreny.Items.Count; i++)
        {
            this.rblCurreny.Items[i].Attributes.Add("onclick", "checkCurrency();");
        }

        for (int i = 0; i < this.rblStage.Items.Count; i++)
        {
            this.rblStage.Items[i].Attributes.Add("onclick", "checkStage();");
        }

        for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
        {
            this.chkLstCooperationDemand.Items[i].Attributes.Add("onclick", "checkCooperationDemand();");
        }

        for (int i = 0; i < this.rdlJoinManage.Items.Count; i++)
        {
            this.rdlJoinManage.Items[i].Attributes.Add("onclick", "checkJoinManage();");
        }

        for (int i = 0; i < this.rdlValiditeTerm.Items.Count; i++)
        {
            this.rdlValiditeTerm.Items[i].Attributes.Add("onclick", "checkValiditeTerm();");
        }
    }

    #region 信息绑定
    /// <summary>
    /// 设置融资金额
    /// </summary>
    private void BindSetCapital()
    {
        Tz888.BLL.Common.SetCapitalBLL bll = new Tz888.BLL.Common.SetCapitalBLL();
        rblCurreny.DataSource = bll.GetList();
        rblCurreny.DataTextField = "CapitalName";
        rblCurreny.DataValueField = "CapitalID";
        rblCurreny.DataBind();
    }

    /// <summary>
    /// 设置投资类型
    /// </summary>
    private void BindCapitalType()
    {
        Tz888.BLL.Common.ParameterBLL bll = new Tz888.BLL.Common.ParameterBLL();
        rblfinancingTarget.DataSource = bll.GetALLfinancingTarget();
        rblfinancingTarget.DataValueField = "financingID";
        rblfinancingTarget.DataTextField = "FinancingName";
        rblfinancingTarget.DataBind();
    }

    /// <summary>
    /// 设置项目发展阶段
    /// </summary>
    private void BindStage()
    {
        Tz888.BLL.Common.ParameterBLL bll = new Tz888.BLL.Common.ParameterBLL();
        this.rblStage.DataSource = bll.GetALLStage();
        this.rblStage.DataValueField = "StageID";
        this.rblStage.DataTextField = "StageName";
        this.rblStage.DataBind();
    }

    /// <summary>
    /// 设置参与管理
    /// </summary>
    private void BindJoinManage()
    {
        Tz888.BLL.Common.ParameterBLL bll = new Tz888.BLL.Common.ParameterBLL();
        this.rdlJoinManage.DataSource = bll.GetALLJoinManageTab();
        this.rdlJoinManage.DataValueField = "JoinManageID";
        this.rdlJoinManage.DataTextField = "JoinManageName";
        this.rdlJoinManage.DataBind();
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

    private Tz888.Model.Info.InfoContactModel GetInfoContact()
    {
        //string loginName = Page.User.Identity.Name;
        string loginName = Page.User.Identity.Name;
        Tz888.BLL.Register.common bll = new Tz888.BLL.Register.common();
        Tz888.Model.Register.OrgContactModel model = new Tz888.Model.Register.OrgContactModel();

        model = bll.getContactModel(loginName);
        Tz888.Model.Info.InfoContactModel model1 = new Tz888.Model.Info.InfoContactModel();

        if (model == null)
            return model1;
        model1.OrganizationName = this.txtGovName.Text;
        model1.OrgIntro = this.txtGovIntro.Value;
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
        return model1;
    }
    #endregion



    protected void btnSubmit_ServerClick(object sender, EventArgs e)
    {
        try//验证验证码
        {
            if (Session["valationNo"] == null || ImageCode.Text.ToUpper().Trim() != Session["valationNo"].ToString().ToUpper().Trim() || Session["valationNo"].ToString().Trim() == "")
            {
                Tz888.Common.MessageBox.Show(this.Page, "验证码错误!");
                return;
            }
        }
        catch
        {
            Tz888.Common.MessageBox.Show(this.Page, "未知错误!");
        }
        //20090811 判断权限
        Tz888.BLL.Login.LoginInfoBLL loginbll = new Tz888.BLL.Login.LoginInfoBLL();
        bool yanzheng = loginbll.yanzheng(Page.User.Identity.Name);
        if (!yanzheng)
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败,你没有发布信息的权限！\\n可能是你发布违规信息帐户被锁定了。\\n详情请联系客服。");
            return;
        }
        //-----end-

        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.V124.CapitalInfoModel capitalInfoModel = new Tz888.Model.Info.V124.CapitalInfoModel(); //创建投资信息实体
        List<Tz888.Model.Info.CapitalInfoAreaModel> capitalInfoAreaModels = new List<Tz888.Model.Info.CapitalInfoAreaModel>();//投资区域信息实体列表
        Tz888.Model.Info.ShortInfoModel shortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体

        DateTime time_now = DateTime.Now;
        capitalInfoAreaModels = this.ZoneSelect1.CapitalInfoAreaModels;

        #region 投资信息实体赋值
        capitalInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtCapitalIntent.Value.Trim());
        capitalInfoModel.CapitalTypeID = this.rblfinancingTarget.SelectedValue;
        capitalInfoModel.CapitalID = this.rblCurreny.SelectedValue;
        capitalInfoModel.ComBreif = "";
        capitalInfoModel.CooperationDemandType = "";
        capitalInfoModel.IndustryBID = this.SelectIndustryControl1.IndustryString;
        capitalInfoModel.stageID = Convert.ToInt32(this.rblStage.SelectedValue);
        capitalInfoModel.joinManageID = Convert.ToInt32(this.rdlJoinManage.SelectedValue);
        

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
        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Capital", capitalInfoModel.IndustryBID.Split(',')[0], CountryCode, time_now);
        mainInfoModel.publishT = time_now;
        mainInfoModel.Hit = 0;

        mainInfoModel.IsCore = true;
        mainInfoModel.LoginName = Page.User.Identity.Name; //用户名称
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
        mainInfoModel.ValidateTerm = Convert.ToInt32(this.rdlValiditeTerm.SelectedValue.Trim());
        mainInfoModel.TemplateID = "001";
        mainInfoModel.HtmlFile = "";

        shortInfoModel.ShortInfoControlID = "CapitalIndex1";
        if (!string.IsNullOrEmpty(this.txtCapitalName.Text.Trim()))
            shortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());
        shortInfoModel.ShortContent = "";
        shortInfoModel.Remark = "";

        Tz888.BLL.Info.V124.CapitalInfoBLL bll = new Tz888.BLL.Info.V124.CapitalInfoBLL();

        //这里是插入资源投资信息
        long infoID = bll.Insert(mainInfoModel, capitalInfoModel,this.GetInfoContact(), shortInfoModel, capitalInfoAreaModels,null);


        if (infoID > 0)
        {
            bool isTof = Page.User.IsInRole("GT1002");
            if (isTof)
            {
                string HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("Capital", mainInfoModel.InfoCode, infoID);
                Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
                Page.Response.Write(infoID.ToString() + HtmlFile.ToString());
                mainBll.HasHtmlFile(infoID, HtmlFile);
                string actionMsg = "";
                Tz888.BLL.PageStatic.CapitalPageStatic staticobj = new Tz888.BLL.PageStatic.CapitalPageStatic();
                staticobj.CreateStaticPageCapital(infoID.ToString(), ref actionMsg);
            }
            Response.Redirect("publishCapital_step2.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(infoID.ToString() + "|Capital|" + this.txtCapitalName.Text.Trim() + "|" + txtGovName.Text.Trim()));
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
        }
    }
}
