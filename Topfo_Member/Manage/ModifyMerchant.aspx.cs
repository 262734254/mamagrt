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
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }

        if (Page.User.IsInRole("GT1001"))
        {
            FilesUploadControl1.Count = 5;
            FilesUploadControl1.NoneCount = 3;
        }
        else
        {
            FilesUploadControl1.Count = 5;
            FilesUploadControl1.NoneCount = 5;
        }
        if (!Page.IsPostBack)
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
            //this._infoID = 2617;
            this.ViewState["InfoID"] = this._infoID;
            if (this._infoID == 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "参数错误！");
                return;
            }
            //this.BindMerchantType();
            //this.BindCooperationDemandType();
            //this.BindSetCapital();
            this.BindCurrency();
            this.LoadInfo(this._infoID);

            //this.FilesUploadControl1.IsTopfoUser = (Page.User.IsInRole("GT1002") || Page.User.IsInRole("GT1003"));

            //for (int i = 0; i < this.rblMerchantType.Items.Count; i++)
            //{
            //    switch (i)
            //    {
            //        case 0:
            //            this.rblMerchantType.Items[i].Attributes.Add("onclick", "checkMerchantType();ShowInfoMsg('&nbsp;&nbsp;&nbsp;&nbsp;包括产业转移、主题招商等','hui');");
            //            break;
            //        case 1:
            //            this.rblMerchantType.Items[i].Attributes.Add("onclick", "checkMerchantType();ShowInfoMsg('','');");
            //            break;
            //        case 2:
            //            this.rblMerchantType.Items[i].Attributes.Add("onclick", "checkMerchantType();ShowInfoMsg('&nbsp;&nbsp;&nbsp;&nbsp;包括产权转让、股权转让、资产出让等','hui');");
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //for (int i = 0; i < this.cblCooperationDemandType.Items.Count; i++)
            //{
            //    this.cblCooperationDemandType.Items[i].Attributes.Add("onclick", "checkCooperationDemand();");
            //}
        }
    }
    #region 初始化
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
    #endregion
    #region 招商类别
    /// <summary>
    /// 招商类别
    /// </summary>
    //private void BindMerchantType()
    //{
    //    this.rblMerchantType.DataSource = Tz888.BLL.Info.Common.GetMerchantAttributeList();
    //    this.rblMerchantType.DataTextField = "MerchantAttributeName";
    //    this.rblMerchantType.DataValueField = "MerchantAttributeID";
    //    this.rblMerchantType.DataBind();
    //}
    #endregion
    #region 合作方式
    /// <summary>
    /// 合作方式
    /// </summary>
    //private void BindCooperationDemandType()
    //{
    //    this.cblCooperationDemandType.DataSource = Tz888.BLL.Info.Common.GetCooperationDemandList("Merchant");
    //    this.cblCooperationDemandType.DataTextField = "CooperationDemandName";
    //    this.cblCooperationDemandType.DataValueField = "CooperationDemandTypeID";
    //    this.cblCooperationDemandType.DataBind();

    //}
    #endregion
    #region 绑定融资金额
    /// <summary>
    /// 绑定融资金额
    /// </summary>
    //private void BindSetCapital()
    //{
    //    Tz888.BLL.Common.SetCapitalBLL bll = new Tz888.BLL.Common.SetCapitalBLL();
    //    this.ddlMerchantTotal.DataSource = bll.GetList();
    //    this.ddlMerchantTotal.DataTextField = "CapitalName";
    //    this.ddlMerchantTotal.DataValueField = "CapitalID";
    //    this.ddlMerchantTotal.DataBind();
    //}
    #endregion
    #region 绑定货币种类
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

        //this.ddlMerchantCurrency.DataSource = dv;
        //this.ddlMerchantCurrency.DataTextField = "CurrencyName";
        //this.ddlMerchantCurrency.DataValueField = "CurrencyID";
        //this.ddlMerchantCurrency.DataBind();
    }
    #endregion
    #region 初始化方法
    private void LoadInfo(long InfoID)
    {

        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdlValiditeTerm.DataTextField = "cdictname";
        this.rdlValiditeTerm.DataValueField = "idictvalue";
        this.rdlValiditeTerm.DataSource = dt;
        this.rdlValiditeTerm.DataBind();
        //2010-07-28 以上绑定项目有效期限
       

        Tz888.BLL.Info.MarchantInfoBLL bll = new Tz888.BLL.Info.MarchantInfoBLL();
        Tz888.Model.Info.MerchantSetModel model = bll.GetIntegrityModel(InfoID);

       

        //this.rblMerchantType.SelectedValue = "2"; //model.MerchantInfoModel.MerchantTypeID.Trim();
        this.txtMerchantTopic.Text = model.MainInfoModel.Title;
        
        if (model.MerchantInfoModel != null)
        {
            if (!string.IsNullOrEmpty(model.MerchantInfoModel.CountryCode.Trim()))
                this.ZoneSelectControl1.CountryID = model.MerchantInfoModel.CountryCode.Trim();
            if (!string.IsNullOrEmpty(model.MerchantInfoModel.ProvinceID.Trim()))
                this.ZoneSelectControl1.ProvinceID = model.MerchantInfoModel.ProvinceID.Trim();
            if (!string.IsNullOrEmpty(model.MerchantInfoModel.CityID.Trim()))
                this.ZoneSelectControl1.CityID = model.MerchantInfoModel.CityID.Trim();
            if (!string.IsNullOrEmpty(model.MerchantInfoModel.CountyID.Trim()))
                this.ZoneSelectControl1.CountyID = model.MerchantInfoModel.CountyID.Trim();
            this.SelectIndustryControl1.IndustryString = model.MerchantInfoModel.IndustryClassList.Trim();
            string CooperationDemandType = model.MerchantInfoModel.CooperationDemandType.Trim();
            #region 2010-06-11 新增字段的读取

            ////项目现状及规划
            //txtProjectStatus.Text = model.MerchantInfoModel.ProjectStatus;
            ////项目优势及市场分析
            //txtMarket.Text = model.MerchantInfoModel.Market;
            ////地方经济指标描述
            //txtEconomicIndicators.Text = model.MerchantInfoModel.EconomicIndicators;
            //////投资环境描述
            //txtInvestmentEnvironment.Text = model.MerchantInfoModel.InvestmentEnvironment;
            ////经济效益分析
            //txtBenefit.Text = model.MerchantInfoModel.Benefit;
            this.ddlCapitalCurrency.SelectedValue = model.MerchantInfoModel.CapitalCurrency;
            this.txtCapitalTotal.Text = Convert.ToString(model.MerchantInfoModel.CapitalTotal);
            //this.ddlMerchantCurrency.SelectedValue = model.MerchantInfoModel.MerchantCurrency;
            //this.ddlMerchantTotal.SelectedValue = model.MerchantInfoModel.MerchantTotal;
            this.txtHuiBao.Text = Convert.ToString( model.MerchantInfoModel.Merchanreturns);
            this.txtZoneAbout.Value = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(Tz888.Common.Utility.PageValidate.HtmlToTxt(model.MerchantInfoModel.ZoneAbout.Trim()));
            //if (!string.IsNullOrEmpty(model.MerchantInfoModel.ReceiveOrganization))
            //    this.MerchantInfoAddressInfo1.Undertaker = model.MerchantInfoModel.ReceiveOrganization.Trim();
            //else
            //    this.MerchantInfoAddressInfo1.Undertaker = "";
            txtAddress.Text = model.InfoContactModel.Address;
            txtEmail.Text = model.InfoContactModel.Email;
            txtMobile.Text = model.InfoContactModel.Mobile;
            txtCompanyName.Text = model.InfoContactModel.OrganizationName;
            txtName.Text = model.InfoContactModel.Name;
            txtTelCountry.Text = model.InfoContactModel.TelCountryCode;
            txtTelZoneCode.Text = model.InfoContactModel.TelStateCode;
            txtTelNumber.Text = model.InfoContactModel.TelNum;
            ViewState["ZoneAboutBrief"] = model.MerchantInfoModel.ZoneAboutBrief;
        }

        string[] cooType = model.MerchantInfoModel.CooperationDemandType.ToString().Split(new char[] { ',' });
        //for (int i = 0; i < cooType.Length; i++)//3,4,5,6,7,8,
        //{
        //    switch (cooType[i])
        //    {
        //        case"3":
        //            cblCooperationDemandType.Items[0].Selected = true;
        //            break;
        //        case"4":
        //            cblCooperationDemandType.Items[1].Selected = true;
        //            break;
        //        case"5":
        //            cblCooperationDemandType.Items[2].Selected = true;
        //            break;
        //        case"6":
        //            cblCooperationDemandType.Items[3].Selected = true;
        //            break;
        //        case "7":
        //            cblCooperationDemandType.Items[4].Selected = true;
        //            break;
        //        case "8":
        //            cblCooperationDemandType.Items[5].Selected = true;
        //            break;
        //        default:
        //            break;
        //    }
        //}
        //string CooperationDemandTypeItems;
        //for (int i = 0; i < cblCooperationDemandType.Items.Count; i++)
        //{
        //    CooperationDemandTypeItems = cblCooperationDemandType.Items[i].Value; 
        //    //CooperationDemandTypeItems += ",";
        //    if (CooperationDemandTypeItems.IndexOf(CooperationDemandTypeItems) != -1)
        //        cblCooperationDemandType.Items[i].Selected = true;
        //}
       
            #endregion

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
       // this.ddlValiditeTerm.SelectedValue = model.MainInfoModel.ValidateTerm.ToString();
        //07-28项目有效期限
        this.rdlValiditeTerm.SelectedValue = model.MainInfoModel.ValidateTerm.ToString();
       
        this.FilesUploadControl1.InfoList = model.InfoResourceModels;
        this.FilesUploadControl1.InfoType = "Merchant";

        //this.MerchantInfoAddressInfo1.InfoContact = model.InfoContactModel; //控件
        //this.MerchantInfoAddressInfo1.infoContact = model.InfoContactManModels;
        if (Request.UrlReferrer != null)
            ViewState["strPrePage"] = Request.UrlReferrer.ToString();
        else
            ViewState["strPrePage"] = "";
        ViewState["InfoID"] = model.MainInfoModel.InfoID;
        ViewState["PublishT"] = model.MainInfoModel.publishT;

        ViewState["AuditingStatus"] = model.MainInfoModel.AuditingStatus;
        ViewState["HtmlFile"] = model.MainInfoModel.HtmlFile;
        if (model.ShortInfoModel != null)
        {
            ViewState["ShortTitle"] = model.ShortInfoModel.ShortTitle;
            ViewState["ShortContent"] = model.ShortInfoModel.ShortContent;
            ViewState["ShortInfoControlID"] = model.ShortInfoModel.ShortInfoControlID;
        }

    }
    #endregion
    /// <summary>
    /// 修改事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Tz888.Model.Info.MerchantSetModel model = new Tz888.Model.Info.MerchantSetModel();

        //model.InfoContactModel = this.MerchantInfoAddressInfo1.InfoContact; //用户控件
        //model.InfoContactManModels = this.MerchantInfoAddressInfo1.InfoContactMans;

        #region 招商信息实体
        // model.InfoContactModel.Position=this
        model.MerchantInfoModel.MerchantTypeID = "";// this.rblMerchantType.SelectedValue;
        model.MerchantInfoModel.CountryCode = this.ZoneSelectControl1.CountryID;
        model.MerchantInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.MerchantInfoModel.CityID = this.ZoneSelectControl1.CityID;
        model.MerchantInfoModel.CountyID = this.ZoneSelectControl1.CountyID;
        model.MerchantInfoModel.IndustryClassList = this.SelectIndustryControl1.IndustryString;
        model.MerchantInfoModel.CapitalCurrency = this.ddlCapitalCurrency.SelectedValue;
        model.MerchantInfoModel.CapitalTotal = Convert.ToDecimal(this.txtCapitalTotal.Text.Trim());
        model.MerchantInfoModel.MerchantCurrency = "";//this.ddlMerchantCurrency.SelectedValue;
        model.MerchantInfoModel.MerchantTotal = ""; //this.ddlMerchantTotal.SelectedValue;
        model.MerchantInfoModel.Merchanreturns = Convert.ToInt32(this.txtHuiBao.Text.Trim());

        //项目现状及规划
        model.MerchantInfoModel.ProjectStatus = "";// txtProjectStatus.Text;
        //项目优势及市场分析
        model.MerchantInfoModel.Market = Tz888.Common.Utility.PageValidate.TxtToHtml("");
        //地方经济指标描述
        model.MerchantInfoModel.EconomicIndicators = Tz888.Common.Utility.PageValidate.TxtToHtml("");
        //投资环境描述
        model.MerchantInfoModel.InvestmentEnvironment = Tz888.Common.Utility.PageValidate.TxtToHtml("");
        //经济效益分析
        model.MerchantInfoModel.Benefit = Tz888.Common.Utility.PageValidate.TxtToHtml("");

        model.MerchantInfoModel.ZoneAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtZoneAbout.Value.ToString()));
        if (ViewState["ZoneAboutBrief"] != null)
        {
            model.MerchantInfoModel.ZoneAboutBrief = ViewState["ZoneAboutBrief"].ToString();
        }
        //if (!string.IsNullOrEmpty(model.MerchantInfoModel.ReceiveOrganization))
        //    this.MerchantInfoAddressInfo1.Undertaker = model.MerchantInfoModel.ReceiveOrganization.Trim();
        //else
            //this.MerchantInfoAddressInfo1.Undertaker = "";
        ViewState["ZoneAboutBrief"] = model.MerchantInfoModel.ZoneAboutBrief;

        model.MerchantInfoModel.CooperationDemandType = "";

        //for (int i = 0; cblCooperationDemandType.Items.Count > i; i++)
        //{
        //    if (cblCooperationDemandType.Items[i].Selected)
        //    {
        //        model.MerchantInfoModel.CooperationDemandType += cblCooperationDemandType.Items[i].Value + ",";
        //    }
        //}
        #endregion
        model.MainInfoModel.InfoID = Convert.ToInt64(this.ViewState["InfoID"]);
        if (!string.IsNullOrEmpty(this.txtMerchantTopic.Text.Trim()))
            model.MainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtMerchantTopic.Text.Trim());
        model.MainInfoModel.publishT = Convert.ToDateTime(this.ViewState["PublishT"]);

        model.MainInfoModel.LoginName = ""; //用户名称

        string keyword = "";
        //if (!string.IsNullOrEmpty(this.txtKeyword1.Text.Trim()))
        //    keyword += this.txtKeyword1.Text.Trim() + ",";
        //if (!string.IsNullOrEmpty(this.txtKeyword2.Text.Trim()))
        //    keyword += this.txtKeyword2.Text.Trim() + ",";
        //if (!string.IsNullOrEmpty(this.txtKeyword3.Text.Trim()))
        //    keyword += this.txtKeyword3.Text.Trim() + ",";

        model.MainInfoModel.KeyWord = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(keyword);
        model.MainInfoModel.Descript = "";
        model.MainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtMerchantTopic.Text.Trim());
        model.MainInfoModel.FrontDisplayTime = System.DateTime.Now;
        model.MainInfoModel.ValidateStartTime = System.DateTime.Now;
       //model.MainInfoModel.ValidateTerm = Convert.ToInt32(this.ddlValiditeTerm.SelectedValue.Trim());
        //项目有效期限
        model.MainInfoModel.ValidateTerm = Convert.ToInt32(this.rdlValiditeTerm.SelectedValue.Trim());

        model.MainInfoModel.TemplateID = "001";
        model.MainInfoModel.HtmlFile = ViewState["HtmlFile"].ToString();

        model.ShortInfoModel.ShortInfoControlID = Convert.ToString(ViewState["ShortInfoControlID"]);
        if (ViewState["ShortTitle"] != null)
        {
            model.ShortInfoModel.ShortTitle = ViewState["ShortTitle"].ToString();
        }
        if (ViewState["ShortContent"] != null)
        {
            model.ShortInfoModel.ShortContent = ViewState["ShortContent"].ToString();
        }

        model.ShortInfoModel.Remark = "";

        model.InfoContactModel.Address = txtAddress.Text.ToString().Trim();
        model.InfoContactModel.Email = txtEmail.Text.ToString().Trim();
        model.InfoContactModel.Mobile = txtMobile.Text.ToString().Trim();
        model.InfoContactModel.OrganizationName = txtCompanyName.Text.ToString().Trim();
        model.InfoContactModel.Name = txtName.Text.ToString().Trim();
        model.InfoContactModel.TelCountryCode = txtTelCountry.Text.ToString().Trim();
        model.InfoContactModel.TelStateCode = txtTelZoneCode.Text.ToString().Trim();
        model.InfoContactModel.TelNum = txtTelNumber.Text.ToString().Trim();


        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels;
        infoResourceModels = FilesUploadControl1.InfoList;
        //List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = Tz888.Common.InfoResourceManage.ImageTransfer("Image", "Merchant", Tz888.Common.ResourceType.Image, Tz888.Common.ResourceProperty.InfoImage, FilesUploadControl1.InfoList);
        if (infoResourceModels != null)
            model.InfoResourceModels.AddRange(infoResourceModels);

        Tz888.BLL.Info.MarchantInfoBLL bll = new Tz888.BLL.Info.MarchantInfoBLL();
        if (bll.Update(model))
        {
            //bool isTof = Page.User.IsInRole("GT1002");
            //if (isTof)
            //{

            //    if (string.IsNullOrEmpty(model.MainInfoModel.HtmlFile.Trim()))
            //        model.MainInfoModel.HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("Merchant", model.MainInfoModel.InfoCode, model.MainInfoModel.InfoID);
            //    Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
            //    mainBll.HasHtmlFile(model.MainInfoModel.InfoID, model.MainInfoModel.HtmlFile);
            //    string actionMsg = "";
            //    Tz888.BLL.PageStatic.MerchantPageStatic staticobj = new Tz888.BLL.PageStatic.MerchantPageStatic();
            //    staticobj.CreateStaticPageMerchant(model.MainInfoModel.InfoID.ToString(), ref actionMsg);
            //}
            Response.Redirect("./ResourceManage_Pass.aspx");

        }
        else
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改信息失败！", "./ResourceManage_Pass.aspx");
    }

}
