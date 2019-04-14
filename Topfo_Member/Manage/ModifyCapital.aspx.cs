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

            this.ViewState["InfoID"] = this._infoID;
            if (this._infoID == 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "参数错误！");
                return;
            }
            this.BindCurrency();
            this.BindSetCapital();
            this.BindCapitalType();
            this.BindCooperationDemandType();

            this.LoadInfo(this._infoID);

            this.ImageUploadControl1.IsTopfoUser = (Page.User.IsInRole("GT1002") || Page.User.IsInRole("GT1003"));

            for (int i = 0; i < this.rblCapitalType.Items.Count; i++)
            {
                this.rblCapitalType.Items[i].Attributes.Add("onclick", "checkCapitalType();");
            }


            for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
            {
                this.chkLstCooperationDemand.Items[i].Attributes.Add("onclick", "checkCooperationDemand();");
            }
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

    private void LoadInfo(long InfoID)
    {

        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdlValiditeTerm.DataTextField = "cdictname";
        this.rdlValiditeTerm.DataValueField = "idictvalue";
        this.rdlValiditeTerm.DataSource = dt;
        this.rdlValiditeTerm.DataBind();
        //2010-07-28 以上绑定项目有效期限

       


        Tz888.BLL.Info.CapitalInfoBLL bll = new Tz888.BLL.Info.CapitalInfoBLL();
        Tz888.Model.Info.CapitalSetModel model = new Tz888.Model.Info.CapitalSetModel();
        model = bll.GetIntegrityModel(InfoID);

        //07-28项目有效期限
        this.rdlValiditeTerm.SelectedValue = model.MainInfoModel.ValidateTerm.ToString();

        this.txtCapitalName.Text = model.MainInfoModel.Title;
        this.rblCapitalType.SelectedValue = model.CapitalInfoModel.CapitalTypeID.Trim(); ;

        string CooperationDemandType = model.CapitalInfoModel.CooperationDemandType;
        string CooperationDemandTypeItems;
        for (int i = 0; i < chkLstCooperationDemand.Items.Count; i++)
        {
            CooperationDemandTypeItems = chkLstCooperationDemand.Items[i].Value;
            //CooperationDemandTypeItems += ",";
            if (CooperationDemandType.IndexOf(CooperationDemandTypeItems) != -1)
                chkLstCooperationDemand.Items[i].Selected = true;
        }

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

        this.ZoneMoreSelectControl1.CapitalInfoAreaModels = model.CapitalInfoAreaModels;

        this.SelectIndustryControl1.IndustryString = model.CapitalInfoModel.IndustryBID;

        this.ImageUploadControl1.InfoList = model.InfoResourceModels;

        this.ddlCurrency.SelectedValue = model.CapitalInfoModel.Currency.Trim(); ;

        this.ddlCapital.SelectedValue = model.CapitalInfoModel.CapitalID;

        this.txtCapitalIntent.Value = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(Tz888.Common.Utility.PageValidate.HtmlToTxt(model.CapitalInfoModel.ComAbout));

       // this.ddlValiditeTerm.SelectedValue = model.MainInfoModel.ValidateTerm.ToString();

        this.CapitalAddressInfo1.InfoContact = model.InfoContactModel;

        this.CapitalAddressInfo1.InfoContactMans = model.InfoContactManModels;


        if (Request.UrlReferrer != null)
            ViewState["strPrePage"] = Request.UrlReferrer.ToString();
        else
            ViewState["strPrePage"] = "";
        ViewState["InfoID"] = model.MainInfoModel.InfoID;
        ViewState["PublishT"] = model.MainInfoModel.publishT;
        ViewState["ComBreif"] = model.CapitalInfoModel.ComBreif;
        ViewState["AuditingStatus"] = model.MainInfoModel.AuditingStatus;
        ViewState["HtmlFile"] = model.MainInfoModel.HtmlFile;

        ViewState["ShortTitle"] = model.ShortInfoModel.ShortTitle;
        ViewState["ShortContent"] = model.ShortInfoModel.ShortContent;
        ViewState["ShortInfoControlID"] = model.ShortInfoModel.ShortInfoControlID;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Tz888.Model.Info.CapitalSetModel model = new Tz888.Model.Info.CapitalSetModel();

        model.InfoContactModel = this.CapitalAddressInfo1.InfoContact;
        model.InfoContactManModels = this.CapitalAddressInfo1.InfoContactMans;
        model.CapitalInfoAreaModels = this.ZoneMoreSelectControl1.CapitalInfoAreaModels;

        #region 投资信息实体赋值

        model.CapitalInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalIntent.Value.Trim()));
        model.CapitalInfoModel.CapitalTypeID = this.rblCapitalType.SelectedValue;
        model.CapitalInfoModel.Currency = this.ddlCurrency.SelectedValue;

        model.CapitalInfoModel.CapitalID = this.ddlCapital.SelectedValue;

        model.CapitalInfoModel.ComBreif = this.ViewState["ComBreif"].ToString();

        model.CapitalInfoModel.IndustryBID = this.SelectIndustryControl1.IndustryString;

        model.CapitalInfoModel.CooperationDemandType = "";
        for (int i = 0; chkLstCooperationDemand.Items.Count > i; i++)
        {
            if (chkLstCooperationDemand.Items[i].Selected)
            {
                model.CapitalInfoModel.CooperationDemandType += chkLstCooperationDemand.Items[i].Value + ",";
            }
        }
        #endregion

        model.MainInfoModel.InfoID = Convert.ToInt64(this.ViewState["InfoID"]);
        if (!string.IsNullOrEmpty(this.txtCapitalName.Text.Trim()))
            model.MainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());
        model.MainInfoModel.publishT = Convert.ToDateTime(this.ViewState["PublishT"]);

        model.MainInfoModel.LoginName = ""; //用户名称

        string keyword = "";
        if (!string.IsNullOrEmpty(this.txtKeyword1.Text.Trim()))
            keyword += this.txtKeyword1.Text.Trim() + ",";
        if (!string.IsNullOrEmpty(this.txtKeyword2.Text.Trim()))
            keyword += this.txtKeyword2.Text.Trim() + ",";
        if (!string.IsNullOrEmpty(this.txtKeyword3.Text.Trim()))
            keyword += this.txtKeyword3.Text.Trim() + ",";

        model.MainInfoModel.KeyWord = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(keyword);
        model.MainInfoModel.Descript = "";
        model.MainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());
        model.MainInfoModel.FrontDisplayTime = System.DateTime.Now;
        model.MainInfoModel.ValidateStartTime = System.DateTime.Now;
       // model.MainInfoModel.ValidateTerm = Convert.ToInt32(this.ddlValiditeTerm.SelectedValue.Trim());
        //项目有效期限
        model.MainInfoModel.ValidateTerm = Convert.ToInt32(this.rdlValiditeTerm.SelectedValue.Trim());
        model.MainInfoModel.TemplateID = "001";
        model.MainInfoModel.HtmlFile = ViewState["HtmlFile"].ToString();

        model.ShortInfoModel.ShortInfoControlID = Convert.ToString(ViewState["ShortInfoControlID"]);
        model.ShortInfoModel.ShortTitle = ViewState["ShortTitle"].ToString();
        model.ShortInfoModel.ShortContent = ViewState["ShortContent"].ToString();
        model.ShortInfoModel.Remark = "";

        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels;
        infoResourceModels = ImageUploadControl1.InfoList;
        //List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = Tz888.Common.InfoResourceManage.ImageTransfer("Image", "Capital", Tz888.Common.ResourceType.Image, Tz888.Common.ResourceProperty.InfoImage, ImageUploadControl1.InfoList);
        if (infoResourceModels != null)
            model.InfoResourceModels.AddRange(infoResourceModels);

        Tz888.BLL.Info.CapitalInfoBLL bll = new Tz888.BLL.Info.CapitalInfoBLL();

        if (bll.Update(model))
        {

            bool isTof = Page.User.IsInRole("GT1002");
            if (isTof)
            {
                if (string.IsNullOrEmpty(model.MainInfoModel.HtmlFile.Trim()))
                    model.MainInfoModel.HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("Capital", model.MainInfoModel.InfoCode, model.MainInfoModel.InfoID);
                Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
                mainBll.HasHtmlFile(model.MainInfoModel.InfoID, model.MainInfoModel.HtmlFile);
                string actionMsg = "";
                Tz888.BLL.PageStatic.CapitalPageStatic staticobj = new Tz888.BLL.PageStatic.CapitalPageStatic();
                staticobj.CreateStaticPageCapital(model.MainInfoModel.InfoID.ToString(), ref actionMsg);
            }
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改信息成功！", Request.Url.ToString());
        }
        else
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改信息失败！", Request.Url.ToString());

    }
}
