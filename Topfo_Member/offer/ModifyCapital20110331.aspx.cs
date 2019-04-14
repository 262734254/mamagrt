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

public partial class Manage_ModifyCapital : System.Web.UI.Page
{
    private long _infoID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        if (!this.Page.IsPostBack)
        {
            if (this.Page.Request.QueryString["id"] != null)
            {
                try
                {
                    this._infoID = Convert.ToInt64(this.Page.Request.QueryString["id"]);
                }
                catch
                {
                    this._infoID = 0;
                }
            }
          //this._infoID = 1535843;
            this.ViewState["InfoID"] = this._infoID;
            if (this._infoID == 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "参数错误！");
                return;
            }
            this.BindSetCapital();
           // this.BindCapitalType();
            this.BindCooperationDemandType();
          //  this.BindJoinManage();
          //  this.BindStage();
            //2010-06-12新增
          //  this.BindRegDollar();
          //  this.BindTeam();
          //  this.BindPin();
          //  this.BindCheng();
            BindDateEnd();
            //end
            this.LoadInfo(this._infoID);

            this.FilesUploadControl1.InfoType = "Capital";
            this.FilesUploadControl1.NoneCount = 5;
            this.FilesUploadControl1.Count = 5;
            //this.UpFileControl1.InfoID = _infoID;
            //this.UpFileControl1.InfoType = "Capital";

            #region 以下是做判断的的方法
            ////资本类型
            //for (int i = 0; i < this.rblfinancingTarget.Items.Count; i++)
            //{
            //    this.rblfinancingTarget.Items[i].Attributes.Add("onclick", "checkCapitalType();");
            //}
            //单项目可投资金额
            //for (int i = 0; i < this.rblCurreny.Items.Count; i++)
            //{
            //    this.rblCurreny.Items[i].Attributes.Add("onclick", "checkCurrency();");
            //}
            //投资项目阶段
            //for (int i = 0; i < this.rdlStage.Items.Count; i++)
            //{
            //    this.rdlStage.Items[i].Attributes.Add("onclick", "checkStage();");
            //}
            //投资方式
            for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
            {
                this.chkLstCooperationDemand.Items[i].Attributes.Add("onclick", "checkCooperationDemand();");
            }
            //是否参与项目方管理
            //for (int i = 0; i < this.rdlJoinManage.Items.Count; i++)
            //{
            //    this.rdlJoinManage.Items[i].Attributes.Add("onclick", "checkJoinManage();");
            //}
            //意向有效期限
            for (int i = 0; i < this.rdlValiditeTerm.Items.Count; i++)
            {
                this.rdlValiditeTerm.Items[i].Attributes.Add("onclick", "checkValiditeTerm();");
            }
            //机构注册资金
            //for (int i = 0; i < this.rblRegisterdollar.Items.Count; i++)
            //{

            //    this.rblRegisterdollar.Items[i].Attributes.Add("onclick", "checkCurreny();");

            //}
            //机构团队规模
            //for (int i = 0; i < this.rblTeam.Items.Count; i++)
            //{

            //    this.rblTeam.Items[i].Attributes.Add("onclick", "checkTeam();");

            //}
            //机构年平均投资事件数
            //for (int i = 0; i < this.rblPinJ.Items.Count; i++)
            //{

            //    this.rblPinJ.Items[i].Attributes.Add("onclick", "checkPinjun();");

            //}
            //机构成功投资事件总数
            //for (int i = 0; i < this.rblSucess.Items.Count; i++)
            //{

            //    this.rblSucess.Items[i].Attributes.Add("onclick", "checkSucess();");

            //}
            #endregion
        }
    }
    #region 信息绑定
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
    #region 设置融资金额
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
    #endregion

    #region 设置投资类型
    /// <summary>
    /// 设置投资类型
    /// </summary>
    //private void BindCapitalType()
    //{
    //    Tz888.BLL.Common.ParameterBLL bll = new Tz888.BLL.Common.ParameterBLL();
    //    rblfinancingTarget.DataSource = bll.GetALLfinancingTarget();
    //    rblfinancingTarget.DataValueField = "financingID";
    //    rblfinancingTarget.DataTextField = "FinancingName";
    //    rblfinancingTarget.DataBind();
    //}
    #endregion
    #region  设置项目发展阶段
    /// <summary>
    /// 设置项目发展阶段
    /// </summary>
    //private void BindStage()
    //{
    //    Tz888.BLL.Common.ParameterBLL bll = new Tz888.BLL.Common.ParameterBLL();
    //    this.rdlStage.DataSource = bll.GetALLStage();
    //    this.rdlStage.DataValueField = "StageID";
    //    this.rdlStage.DataTextField = "StageName";
    //    this.rdlStage.DataBind();
    //}
    #endregion
    #region  机构注册资金
    /// <summary>
    /// 机构注册资金
    /// </summary>
    //private void BindRegDollar()
    //{
    //    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    //    DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='jgzczj' ");
    //    this.rblRegisterdollar.DataTextField = "cdictname";
    //    this.rblRegisterdollar.DataValueField = "idictvalue";
    //    this.rblRegisterdollar.DataSource = dt;
    //    this.rblRegisterdollar.DataBind();
    //}
    #endregion
    #region  机构团队规模
    /// <summary>
    /// 机构团队规模
    /// </summary>
    //private void BindTeam()
    //{
    //    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    //    DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='jgtdgm' ");
    //    this.rblTeam.DataTextField = "cdictname";
    //    this.rblTeam.DataValueField = "idictvalue";
    //    this.rblTeam.DataSource = dt;
    //    this.rblTeam.DataBind();

    //}
    #endregion
    #region 机构年平均投资事件数
    /// <summary>
    /// 机构年平均投资事件数
    /// </summary>
    //private void BindPin()
    //{
    //    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    //    DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='jgpjtzsjs' ");
    //    this.rblPinJ.DataTextField = "cdictname";
    //    this.rblPinJ.DataValueField = "idictvalue";
    //    this.rblPinJ.DataSource = dt;
    //    this.rblPinJ.DataBind();
    //}
    #endregion
    #region 机构成功投资事件总数
    ///// <summary>
    ///// 机构成功投资事件总数
    ///// </summary>
    //private void BindCheng()
    //{

    //    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    //    DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='jgcgtzsjs' ");
    //    this.rblSucess.DataTextField = "cdictname";
    //    this.rblSucess.DataValueField = "idictvalue";
    //    this.rblSucess.DataSource = dt;
    //    this.rblSucess.DataBind();
    //}
    #endregion
    #region 设置参与管理
    /// <summary>
    /// 设置参与管理
    /// </summary>
    //private void BindJoinManage()
    //{
    //    Tz888.BLL.Common.ParameterBLL bll = new Tz888.BLL.Common.ParameterBLL();
    //    this.rdlJoinManage.DataSource = bll.GetALLJoinManageTab();
    //    this.rdlJoinManage.DataValueField = "JoinManageID";
    //    this.rdlJoinManage.DataTextField = "JoinManageName";
    //    this.rdlJoinManage.DataBind();
    //}
    #endregion
    #region 绑定项目合作类型
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
    #endregion
    #region  项目有效期限
    /// <summary>
    /// 项目有效期限
    /// </summary>
    private void BindDateEnd()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdlValiditeTerm.DataTextField = "cdictname";
        this.rdlValiditeTerm.DataValueField = "idictvalue";
        this.rdlValiditeTerm.DataSource = dt;
        this.rdlValiditeTerm.DataBind();
    }
    #endregion
    private void LoadInfo(long InfoID)
    {
        Tz888.BLL.Info.V124.CapitalInfoBLL bll = new Tz888.BLL.Info.V124.CapitalInfoBLL();
        Tz888.Model.Info.V124.CapitalSetModel model = new Tz888.Model.Info.V124.CapitalSetModel();
        model = bll.GetIntegrityModel(InfoID);

        //this.txtGovName.Text = model.InfoContactModel.OrganizationName;
        //this.txtGovIntro.Value = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(Tz888.Common.Utility.PageValidate.HtmlToTxt(model.CapitalInfoModel.ComBreif));
      
        this.txtCapitalName.Text = model.MainInfoModel.Title;
        if (model.CapitalInfoModel != null)
        {
            if (!string.IsNullOrEmpty(model.CapitalInfoModel.CapitalTypeID.ToString()))
            {
                //this.rblfinancingTarget.SelectedValue = model.CapitalInfoModel.CapitalTypeID;
            }
            string CooperationDemandType = model.CapitalInfoModel.CooperationDemandType;
            string CooperationDemandTypeItems;
            for (int i = 0; i < chkLstCooperationDemand.Items.Count; i++)
            {
                CooperationDemandTypeItems = chkLstCooperationDemand.Items[i].Value;
                //CooperationDemandTypeItems += ",";
                if (CooperationDemandType.IndexOf(CooperationDemandTypeItems) != -1)
                    chkLstCooperationDemand.Items[i].Selected = true;
            }
            //添加所属区域
            //this.ZoneSelectControl1.CountryID = model.CapitalInfoModel.SCountryID.Trim();
            //this.ZoneSelectControl1.ProvinceID = model.CapitalInfoModel.SProvinceID.Trim();
            //this.ZoneSelectControl1.CityID = model.CapitalInfoModel.SCityID.Trim();
            //this.ZoneSelectControl1.CountyID = model.CapitalInfoModel.SCountyID.Trim();



            this.ZoneMoreSelectControl1.CapitalInfoAreaModels = model.CapitalInfoAreaModels;
            if (!string.IsNullOrEmpty(model.CapitalInfoModel.IndustryBID.ToString()))
            {
                this.SelectIndustryControl1.IndustryString = model.CapitalInfoModel.IndustryBID;
            }

            this.rblCurreny.SelectedValue = model.CapitalInfoModel.CapitalID;

            //this.rdlJoinManage.SelectedValue = model.CapitalInfoModel.joinManageID.ToString();

            //this.rdlStage.SelectedValue = model.CapitalInfoModel.stageID.ToString();
            this.txtCapitalIntent.Value = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(Tz888.Common.Utility.PageValidate.HtmlToTxt(model.CapitalInfoModel.ComAbout));
            //以下是需要添加的参数
            //注册资金
            //this.rblRegisterdollar.SelectedValue = model.CapitalInfoModel.RegisteredCapital.ToString().Trim();
            ////团队规模
            //this.rblTeam.SelectedValue = model.CapitalInfoModel.TeamScale.ToString().Trim();
            ////机构年平均投资事件数
            //this.rblPinJ.SelectedValue = model.CapitalInfoModel.AverageInvestment.ToString().Trim();
            ////机构成功投资事件总数
            //this.rblSucess.SelectedValue = model.CapitalInfoModel.SuccessfulInvestment.ToString().Trim();
            ////投资需求摘要
            //this.txtDemand.Value = model.CapitalInfoModel.InvestmentDemand;
            ViewState["ComBreif"] = model.CapitalInfoModel.ComBreif;
        }
        //if (!string.IsNullOrEmpty(model.MainInfoModel.KeyWord.Trim()))
        //{
        //    string[] keys = model.MainInfoModel.KeyWord.Trim().Split(',');
        //    for (int i = 0; i < keys.Length; i++)
        //    {
        //        string key = keys[i].ToString().Trim();
        //        switch (i)
        //        {
        //            case 0:
        //                this.txtKeyword1.Text = key;
        //                break;
        //            case 1:
        //                this.txtKeyword2.Text = key;
        //                break;
        //            case 2:
        //                this.txtKeyword3.Text = key;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}
        this.rdlValiditeTerm.SelectedValue = model.MainInfoModel.ValidateTerm.ToString();

        //this.CapitalAddressInfo1.InfoContact = model.InfoContactModel;

        //这里是换为投资机构名称
        txtGovName.Text = model.InfoContactModel.OrganizationName;
       //txtGovIntro.Value = model.InfoContactModel.OrgIntro;
        txtLinkMan.Text = model.InfoContactModel.Name;
        txtTelCountry.Text = model.InfoContactModel.TelCountryCode;
        txtTelZoneCode.Text = model.InfoContactModel.TelStateCode;
        txtTelNumber.Text = model.InfoContactModel.TelNum;

        //txtFaxCountry.Text = model.InfoContactModel.FaxCountryCode;
        //txtFaxZoneCode.Text = model.InfoContactModel.FaxStateCode;
        //txtFaxNumber.Text = model.InfoContactModel.FaxNum;

        txtMobile.Text = model.InfoContactModel.Mobile;
        txtAddress.Text = model.InfoContactModel.Address;
        //txtPostCode.Text = model.InfoContactModel.PostCode;
        txtEmail.Text = model.InfoContactModel.Email;

        txtWebSite.Text = model.InfoContactModel.WebSite;
        //以下是职位
        //txtPosition.Text = model.InfoContactModel.Position;



        if (Request.UrlReferrer != null)
            ViewState["strPrePage"] = Request.UrlReferrer.ToString();
        else
            ViewState["strPrePage"] = "";
        ViewState["InfoID"] = model.MainInfoModel.InfoID;
        ViewState["PublishT"] = model.MainInfoModel.publishT;

        ViewState["AuditingStatus"] = model.MainInfoModel.AuditingStatus;
        ViewState["HtmlFile"] = model.MainInfoModel.HtmlFile;

        ViewState["ShortTitle"] = model.ShortInfoModel.ShortTitle;
        ViewState["ShortContent"] = model.ShortInfoModel.ShortContent;
        ViewState["ShortInfoControlID"] = model.ShortInfoModel.ShortInfoControlID;


        this.FilesUploadControl1.InfoList = model.InfoResourceModels;
    }

    #endregion
    #region 更新信息
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //20090811 判断权限
        Tz888.BLL.Login.LoginInfoBLL loginbll = new Tz888.BLL.Login.LoginInfoBLL();
        bool yanzheng = loginbll.yanzheng(Page.User.Identity.Name);
        if (!yanzheng)
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败,你没有发布信息的权限！\\n可能是你发布违规信息帐户被锁定了。\\n详情请联系客服。");
            return;
        }
        //-----end-
        Tz888.Model.Info.V124.CapitalSetModel model = new Tz888.Model.Info.V124.CapitalSetModel();

        //model.InfoContactModel = this.CapitalAddressInfo1.InfoContact;
        model.CapitalInfoAreaModels = ZoneMoreSelectControl1.CapitalInfoAreaModels;
       
        //model.InfoContactModel.OrganizationName = this.txtGovName.Text;


        #region 投资信息实体赋值
        model.CapitalInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtCapitalIntent.Value.Trim());
        //if (!string.IsNullOrEmpty(this.rblfinancingTarget.SelectedValue.ToString()))
        //{
        //    model.CapitalInfoModel.CapitalTypeID = this.rblfinancingTarget.SelectedValue;
        //}
        if (!string.IsNullOrEmpty(this.rblCurreny.SelectedValue.ToString()))
        {
            model.CapitalInfoModel.CapitalID = this.rblCurreny.SelectedValue;
        }
        model.CapitalInfoModel.CooperationDemandType = "";
        model.CapitalInfoModel.IndustryBID = this.SelectIndustryControl1.IndustryString;
        //if (!string.IsNullOrEmpty(rdlStage.SelectedValue.ToString()))
        //{
        //    model.CapitalInfoModel.stageID = Convert.ToInt32(this.rdlStage.SelectedValue.Trim());
        //}
        //if (!string.IsNullOrEmpty(this.rdlJoinManage.SelectedValue.ToString()))
        //{
        //    model.CapitalInfoModel.joinManageID = Convert.ToInt32(this.rdlJoinManage.SelectedValue.Trim());
        //}
        for (int i = 0; chkLstCooperationDemand.Items.Count > i; i++)
        {
            if (chkLstCooperationDemand.Items[i].Selected)
            {
                model.CapitalInfoModel.CooperationDemandType += chkLstCooperationDemand.Items[i].Value + ",";
            }
        }
        //以下是需要添加的参数
        //注册资金
        model.CapitalInfoModel.RegisteredCapital = "";// this.rblRegisterdollar.SelectedValue;
        model.CapitalInfoModel.ComBreif =Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(Tz888.Common.Utility.PageValidate.HtmlToTxt(""));
        //团队规模  
        model.CapitalInfoModel.TeamScale = "";//;this.rblTeam.SelectedValue;
        //机构年平均投资事件数
        model.CapitalInfoModel.AverageInvestment = ""; //this.rblPinJ.SelectedValue;
        //机构成功投资事件总数
        model.CapitalInfoModel.SuccessfulInvestment = ""; //this.rblSucess.SelectedValue;
        //投资需求摘要
        model.CapitalInfoModel.InvestmentDemand = "";// this.txtDemand.Value;
        //添加所属区域

        //model.CapitalInfoModel.SCountryID = this.ZoneSelectControl1.CountryID;
        //model.CapitalInfoModel.SProvinceID = this.ZoneSelectControl1.ProvinceID;
        //model.CapitalInfoModel.SCityID = this.ZoneSelectControl1.CityID;
        //model.CapitalInfoModel.SCountyID = this.ZoneSelectControl1.CountyID;
        #endregion
        //2010-08-04

        model.MainInfoModel.InfoID = Convert.ToInt64(this.ViewState["InfoID"]);
        if (!string.IsNullOrEmpty(this.txtCapitalName.Text.Trim()))
            model.MainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());
        model.MainInfoModel.publishT = Convert.ToDateTime(this.ViewState["PublishT"]);

        model.MainInfoModel.LoginName = ""; //用户名称

        //这里是换为投资机构名称
        model.InfoContactModel.OrganizationName = this.txtGovName.Text;
        model.InfoContactModel.OrgIntro =Tz888.Common.Utility.PageValidate.TxtToHtml("");
        model.InfoContactModel.Name = this.txtLinkMan.Text;
        model.InfoContactModel.TelCountryCode = this.txtTelCountry.Text;
        model.InfoContactModel.TelStateCode = this.txtTelZoneCode.Text;
        model.InfoContactModel.TelNum = this.txtTelNumber.Text;

        //model.InfoContactModel.FaxCountryCode =this.txtFaxCountry.Text;
        //model.InfoContactModel.FaxStateCode = txtFaxZoneCode.Text;
        //model.InfoContactModel.FaxNum = this.txtFaxNumber.Text;

        model.InfoContactModel.Mobile = this.txtMobile.Text;
        model.InfoContactModel.Address = this.txtAddress.Text;
        //model.InfoContactModel.PostCode = this.txtPostCode.Text;
        model.InfoContactModel.Email = this.txtEmail.Text;

        model.InfoContactModel.WebSite = this.txtWebSite.Text;



        //以下是职位
        //model.InfoContactModel.Position = this.txtPosition.Text;


        string keyword = "";
        //if (!string.IsNullOrEmpty(this.txtKeyword1.Text.Trim()))
        //    keyword += this.txtKeyword1.Text.Trim() + ",";
        //if (!string.IsNullOrEmpty(this.txtKeyword2.Text.Trim()))
        //    keyword += this.txtKeyword2.Text.Trim() + ",";
        //if (!string.IsNullOrEmpty(this.txtKeyword3.Text.Trim()))
        //    keyword += this.txtKeyword3.Text.Trim() + ",";

        model.MainInfoModel.KeyWord = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(keyword);
        model.MainInfoModel.Descript = "";
        model.MainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());
        model.MainInfoModel.FrontDisplayTime = System.DateTime.Now;
        model.MainInfoModel.ValidateStartTime = System.DateTime.Now;
        //意向有效期限
        model.MainInfoModel.ValidateTerm = int.Parse(this.rdlValiditeTerm.SelectedValue.Trim());
        model.MainInfoModel.TemplateID = "001";
        model.MainInfoModel.HtmlFile = ViewState["HtmlFile"].ToString();
        model.MainInfoModel.AuditingStatus = Convert.ToInt32(ViewState["AuditingStatus"].ToString());
        model.ShortInfoModel.ShortInfoControlID = Convert.ToString(ViewState["ShortInfoControlID"]);
        model.ShortInfoModel.ShortTitle = ViewState["ShortTitle"].ToString();
        model.ShortInfoModel.ShortContent = ViewState["ShortContent"].ToString();
        model.ShortInfoModel.Remark = "";
       

        Tz888.BLL.Info.V124.CapitalInfoBLL bll = new Tz888.BLL.Info.V124.CapitalInfoBLL();

        string navUrl = "";
        bool isTof = Page.User.IsInRole("GT1002");
        if (isTof)
        {
            navUrl = "http://member.topfo.com/indexTof.aspx";
        }
        else
        {
            navUrl = "http://member.topfo.com/index.aspx";
        }

        bool b = bll.Update(model);

        //修改附件
        Tz888.BLL.Info.InfoResourceBLL obj2 = new Tz888.BLL.Info.InfoResourceBLL();
        obj2.DeleteByInfoID(long.Parse(this.ViewState["InfoID"].ToString()));
        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>();
        infoResourceModels = this.FilesUploadControl1.InfoList;
        if (infoResourceModels != null)
            model.InfoResourceModels.AddRange(infoResourceModels);
        if (infoResourceModels != null)
        {
            foreach (Tz888.Model.Info.InfoResourceModel ResModel in infoResourceModels)
            {
                ResModel.InfoID = long.Parse(this.ViewState["InfoID"].ToString());
                obj2.Insert(ResModel);
            }
        }
        if (b)
        {
            if (isTof)
            {
                if (string.IsNullOrEmpty(model.MainInfoModel.HtmlFile.Trim()))
                    model.MainInfoModel.HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("Capital", model.MainInfoModel.InfoCode, model.MainInfoModel.InfoID);
                Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
                mainBll.HasHtmlFile(model.MainInfoModel.InfoID, model.MainInfoModel.HtmlFile);
                string actionMsg = "";
                Tz888.BLL.PageStatic.V124.CapitalPageStatic staticobj = new Tz888.BLL.PageStatic.V124.CapitalPageStatic();
                staticobj.CreateStaticPageCapital(model.MainInfoModel.InfoID.ToString(), ref actionMsg);
            }
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改投资资源成功！", navUrl);
        }
        else

            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改投资资源失败！", navUrl);

    }
    #endregion
}
