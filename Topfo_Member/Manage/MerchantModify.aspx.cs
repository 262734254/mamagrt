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

public partial class Info_Merchant_MerchantModify : System.Web.UI.Page
{
    private long _infoID;
    private string theInfoType = "Merchant";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session.Count == 0 || Session["LoginName"] == null)
        {
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "操作超时,请重新登录", "/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            return;
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

            this.ViewState["InfoID"] = this._infoID;
            if (this._infoID == 0)
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "参数错误！", Request.Url.ToString());
                this.Response.End();
                return;
            }

            this.ImageUploadControl1.InfoType = theInfoType;
            this.ImageUploadControl1.NoneCount = 5;
            this.ImageUploadControl1.Count = 5;

            this.BindMerchantType();
            this.BindCooperationDemandType();
            this.BindSetCapital();
            this.BindCurrency();
            this.LoadInfo(this._infoID);
        }

        for (int i = 0; i < this.rblMerchantType.Items.Count; i++)
        {
            this.rblMerchantType.Items[i].Attributes.Add("onclick", "checkMerchantType();");
        }


        for (int i = 0; i < this.cblCooperationDemandType.Items.Count; i++)
        {
            this.cblCooperationDemandType.Items[i].Attributes.Add("onclick", "checkCooperationDemand();");
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

        try
        {
            this.rblMerchantType.SelectedValue = model.MerchantInfoModel.MerchantTypeID.Trim();
        }
        catch { }
        this.txtMerchantTopic.Text = model.MainInfoModel.Title;
        if (!string.IsNullOrEmpty(model.MerchantInfoModel.CountryCode))
            this.ZoneSelectControl1.CountryID = model.MerchantInfoModel.CountryCode.Trim();
        if (!string.IsNullOrEmpty(model.MerchantInfoModel.ProvinceID))
            this.ZoneSelectControl1.ProvinceID = model.MerchantInfoModel.ProvinceID.Trim();
        if (!string.IsNullOrEmpty(model.MerchantInfoModel.CityID))
            this.ZoneSelectControl1.CityID = model.MerchantInfoModel.CityID.Trim();
        if (!string.IsNullOrEmpty(model.MerchantInfoModel.CountyID))
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
        decimal CapitalTotal = Convert.ToDecimal(model.MerchantInfoModel.CapitalTotal);
        if (CapitalTotal > 0)
            this.txtCapitalTotal.Text = CapitalTotal.ToString();
        this.ddlMerchantCurrency.SelectedValue = model.MerchantInfoModel.MerchantCurrency;
        this.ddlMerchantTotal.SelectedValue = model.MerchantInfoModel.MerchantTotal;

        this.txtZoneAbout.Value = Tz888.Common.Utility.PageValidate.HtmlToTxt(model.MerchantInfoModel.ZoneAbout.Trim());
        this.txtZoneAboutBrf.Value = Tz888.Common.Utility.PageValidate.HtmlToTxt(model.MerchantInfoModel.ZoneAboutBrief.Trim());

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

        this.MerchantInfoAddressInfo1.InfoContact = model.InfoContactModel;
        this.MerchantInfoAddressInfo1.InfoContactMans = model.InfoContactManModels;
        this.MerchantInfoAddressInfo1.Undertaker = model.MerchantInfoModel.ReceiveOrganization.Trim();

        this.txtDescript.Text = model.MainInfoModel.Descript;
        this.txtDisplayTitle.Text = model.MainInfoModel.DisplayTitle;

        this.txtShortTitle.Text = model.ShortInfoModel.ShortTitle;
        this.txtShortContent.Text = model.ShortInfoModel.ShortContent;
        ViewState["ShortInfoControlID"] = model.ShortInfoModel.ShortInfoControlID;

        this.tbHits.Text = model.MainInfoModel.Hit.ToString();

        if (model.MainInfoModel.AuditingStatus == 0)
            this.rdAudit.Checked = true;
        if (model.MainInfoModel.AuditingStatus == 1)
            this.rdPass.Checked = true;
        if (model.MainInfoModel.AuditingStatus == 2)
            this.rdNopass.Checked = true;

        if (Request.UrlReferrer != null)
            ViewState["strPrePage"] = Request.UrlReferrer.ToString();
        else
            ViewState["strPrePage"] = "";
        ViewState["UserName"] = model.MainInfoModel.LoginName;
        ViewState["InfoID"] = model.MainInfoModel.InfoID;
        ViewState["InfoCode"] = model.MainInfoModel.InfoCode;
        ViewState["PublishT"] = model.MainInfoModel.publishT;
        ViewState["FrontDisplayTime"] = model.MainInfoModel.FrontDisplayTime;
        ViewState["ValidateStartTime"] = model.MainInfoModel.ValidateStartTime;
        ViewState["AuditingStatus"] = model.MainInfoModel.AuditingStatus;
        ViewState["HtmlFile"] = model.MainInfoModel.HtmlFile;

        ViewState["ShortInfoControlID"] = model.ShortInfoModel.ShortInfoControlID;

        Tz888.Common.MessageBox.ResponseScript(this.Page, "ConAudit(" + model.MainInfoModel.AuditingStatus + ")");
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        Tz888.Model.Info.MerchantSetModel model = new Tz888.Model.Info.MerchantSetModel();

        model.InfoContactModel = this.MerchantInfoAddressInfo1.InfoContact;
        model.InfoContactManModels = this.MerchantInfoAddressInfo1.InfoContactMans;

        #region 招商信息实体
        model.MerchantInfoModel.MerchantTypeID = this.rblMerchantType.SelectedValue;
        model.MerchantInfoModel.CountryCode = this.ZoneSelectControl1.CountryID;
        model.MerchantInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.MerchantInfoModel.CityID = this.ZoneSelectControl1.CityID;
        model.MerchantInfoModel.CountyID = this.ZoneSelectControl1.CountyID;

        model.MerchantInfoModel.IndustryClassList = this.SelectIndustryControl1.IndustryString;
        model.MerchantInfoModel.CapitalCurrency = this.ddlCapitalCurrency.SelectedValue;
        try
        {
            model.MerchantInfoModel.CapitalTotal = Convert.ToDecimal(this.txtCapitalTotal.Text.Trim());
        }
        catch
        {
            model.MerchantInfoModel.CapitalTotal = 0;
        }
        model.MerchantInfoModel.MerchantCurrency = this.ddlMerchantCurrency.SelectedValue;
        model.MerchantInfoModel.MerchantTotal = this.ddlMerchantTotal.SelectedValue;
        model.MerchantInfoModel.ZoneAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtZoneAbout.Value.ToString());
        model.MerchantInfoModel.ZoneAboutBrief = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtZoneAboutBrf.Value.Trim());
        try
        {
            model.MerchantInfoModel.ReceiveOrganization = this.MerchantInfoAddressInfo1.Undertaker.Trim();
        }
        catch{}

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

        model.MainInfoModel.LoginName = ViewState["UserName"].ToString();

        model.MainInfoModel.ApproveTime = DateTime.Now;
        model.MainInfoModel.ApproveBy = Session["loginName"].ToString();

        string keyword = "";
        if (!string.IsNullOrEmpty(this.txtKeyword1.Text.Trim()))
            keyword += this.txtKeyword1.Text.Trim() + ",";
        if (!string.IsNullOrEmpty(this.txtKeyword2.Text.Trim()))
            keyword += this.txtKeyword2.Text.Trim() + ",";
        if (!string.IsNullOrEmpty(this.txtKeyword3.Text.Trim()))
            keyword += this.txtKeyword3.Text.Trim() + ",";

        model.MainInfoModel.KeyWord = keyword;
        model.MainInfoModel.Descript = this.txtDescript.Text.Trim();
        model.MainInfoModel.DisplayTitle = this.txtDisplayTitle.Text.Trim();
        model.MainInfoModel.FrontDisplayTime = Convert.ToDateTime(ViewState["FrontDisplayTime"]);
        model.MainInfoModel.ValidateStartTime = Convert.ToDateTime(ViewState["ValidateStartTime"]);
        model.MainInfoModel.ValidateTerm = Convert.ToInt32(this.ddlValiditeTerm.SelectedValue.Trim());
        model.MainInfoModel.TemplateID = "001";
        model.MainInfoModel.HtmlFile = ViewState["HtmlFile"].ToString();

        model.ShortInfoModel.ShortInfoControlID = Convert.ToString(ViewState["ShortInfoControlID"]);
        model.ShortInfoModel.ShortTitle = this.txtShortTitle.Text.Trim();

        model.ShortInfoModel.ShortContent = this.txtShortContent.Text.Trim();
        model.ShortInfoModel.Remark = "";

        byte AuditingOrigin = Convert.ToByte(ViewState["AuditingStatus"]);
        byte AuditingStatus = 0;

        if (this.rdAudit.Checked)
            AuditingStatus = 0;
        if (this.rdPass.Checked)
            AuditingStatus = 1;
        if (this.rdNopass.Checked)
            AuditingStatus = 2;

        model.MainInfoModel.AuditingStatus = AuditingStatus;

        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = Tz888.Common.InfoResourceManage.ImageTransfer("Image", "Merchant", Tz888.Common.ResourceType.Image, Tz888.Common.ResourceProperty.InfoImage, ImageUploadControl1.InfoList);
        if (infoResourceModels != null)
            model.InfoResourceModels.AddRange(infoResourceModels);

        string actionMsg = "";
        string InfoCode = ViewState["InfoCode"].ToString();
        string strHtmlFile = ViewState["HtmlFile"].ToString();
        bool IsSuccess;
        long InfoID = Convert.ToInt64(ViewState["InfoID"]);
        bool HasDone = false;
        bool AllHasDone;

        Tz888.BLL.Info.MarchantInfoBLL merchantBll = new Tz888.BLL.Info.MarchantInfoBLL();
        Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();

        AllHasDone = merchantBll.Update(model);

        #region 定价
        HasDone = mainBll.HasFixPrice(InfoID, "1", Session["loginName"].ToString());
        if (!HasDone)
            AllHasDone = false;//修改失败
        #endregion

        #region 审核

        string AuditingRemark = "";
        
        
        Tz888.Model.Info.InfoAuditModel auditModel = new Tz888.Model.Info.InfoAuditModel();

        switch (AuditingOrigin)
        {
            case 0:
                switch (AuditingStatus)
                {
                    case 0:
                        break;
                    case 1:
                        AuditingRemark = "未审核->审核通过";

                        #region 写入操作记录
                        //需要生成文件
                        strHtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName(theInfoType, InfoCode, InfoID);
                        //更改审核状态，同时记录操作
                        HasDone = mainBll.HasAuditing(InfoID, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, strHtmlFile, "", 0, 0);

                        if (!HasDone)
                            AllHasDone = false;
                        #endregion

                        #region 写入信息审核记录
                        auditModel = new Tz888.Model.Info.InfoAuditModel();
                        auditModel.InfoID = model.MainInfoModel.InfoID;
                        auditModel.InfoTypeID = theInfoType;
                        auditModel.LoginName = model.MainInfoModel.LoginName;
                        auditModel.PostDate = System.DateTime.Now;
                        auditModel.Title = model.MainInfoModel.Title;
                        auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                        auditModel.FeedBackNote = "";
                        auditModel.AuditStatus = AuditingStatus;
                        auditModel.AuditingDate = System.DateTime.Now;
                        auditModel.AuditingBy = Session["LoginName"].ToString();
                        auditModel.AuditingRemark = AuditingRemark;
                        auditModel.Memo = "";
                        HasDone = mainBll.InfoAuditNote(auditModel);
                        #endregion

                        #region 生成静态化文件
                        Tz888.BLL.PageStatic.MerchantPageStatic staticobj = new Tz888.BLL.PageStatic.MerchantPageStatic();
                        IsSuccess = staticobj.CreateStaticPageMerchant(model.MainInfoModel.InfoID.ToString(), ref actionMsg);
                        //if (!IsSuccess)
                        //    AllHasDone = false;
                        #endregion

                        break;
                    case 2:
                        AuditingRemark = "未审核->审核未通过";

                        #region 写入操作记录
                        HasDone = mainBll.HasAuditing(InfoID, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, "", "", 0,0);

                        if (!HasDone)
                            AllHasDone = false;

                        #endregion

                        #region 写入信息审核记录
                        auditModel = new Tz888.Model.Info.InfoAuditModel();
                        auditModel.InfoID = model.MainInfoModel.InfoID;
                        auditModel.InfoTypeID = theInfoType;
                        auditModel.LoginName = model.MainInfoModel.LoginName;
                        auditModel.PostDate = System.DateTime.Now;
                        auditModel.Title = model.MainInfoModel.Title;
                        auditModel.FeedbackStatus = Convert.ToInt32(this.rblFeedbackStatus.SelectedValue.Trim());
                        auditModel.FeedBackNote = this.tbAuditingRemark.Text.Trim();
                        auditModel.AuditStatus = AuditingStatus;
                        auditModel.AuditingDate = System.DateTime.Now;
                        auditModel.AuditingBy = Session["LoginName"].ToString();
                        auditModel.AuditingRemark = AuditingRemark;
                        auditModel.Memo = "";
                        HasDone = mainBll.InfoAuditNote(auditModel);

                        if (!HasDone)
                            AllHasDone = false;
                        #endregion

                        break;
                    default:
                        break;
                }
                break;
            case 1:
                switch (AuditingStatus)
                {
                    case 0:
                        AuditingRemark = "审核通过->未审核";

                        #region 写入操作记录
                        //更改审核状态，同时记录操作
                        HasDone = mainBll.HasAuditing(InfoID, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, "", "", 0, 0);
                        if (!HasDone)
                            AllHasDone = false;
                        #endregion

                        #region 写入信息审核记录
                        auditModel = new Tz888.Model.Info.InfoAuditModel();
                        auditModel.InfoID = model.MainInfoModel.InfoID;
                        auditModel.InfoTypeID = theInfoType;
                        auditModel.LoginName = model.MainInfoModel.LoginName;
                        auditModel.PostDate = System.DateTime.Now;
                        auditModel.Title = model.MainInfoModel.Title;
                        auditModel.FeedbackStatus = 0;
                        auditModel.FeedBackNote = "";
                        auditModel.AuditStatus = AuditingStatus;
                        auditModel.AuditingDate = System.DateTime.Now;
                        auditModel.AuditingBy = Session["LoginName"].ToString();
                        auditModel.AuditingRemark = AuditingRemark;
                        auditModel.Memo = "";
                        HasDone = mainBll.InfoAuditNote(auditModel);

                        if (!HasDone)
                            AllHasDone = false;
                        #endregion

                        #region 删除已生成的文件

                        //删除静态化文件

                        #endregion

                        break;
                    case 1:
                        #region 生成静态化文件
                        Tz888.BLL.PageStatic.MerchantPageStatic staticobj = new Tz888.BLL.PageStatic.MerchantPageStatic();
                        IsSuccess = staticobj.CreateStaticPageMerchant(model.MainInfoModel.InfoID.ToString(), ref actionMsg);
                        //if (!IsSuccess)
                        //    AllHasDone = false;
                        #endregion
                        break;
                    case 2:
                        AuditingRemark = "审核通过->审核未通过";

                        #region 写入操作记录
                        //更改审核状态，同时记录操作
                        HasDone = mainBll.HasAuditing(InfoID, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, "", "", 0, 0);
                        if (!HasDone)
                            AllHasDone = false;
                        #endregion

                        #region 写入信息审核记录
                        auditModel = new Tz888.Model.Info.InfoAuditModel();
                        auditModel.InfoID = model.MainInfoModel.InfoID;
                        auditModel.InfoTypeID = theInfoType;
                        auditModel.LoginName = model.MainInfoModel.LoginName;
                        auditModel.PostDate = System.DateTime.Now;
                        auditModel.Title = model.MainInfoModel.Title;
                        auditModel.FeedbackStatus = Convert.ToInt32(this.rblFeedbackStatus.SelectedValue.Trim());
                        auditModel.FeedBackNote = this.tbAuditingRemark.Text.Trim();
                        auditModel.AuditStatus = AuditingStatus;
                        auditModel.AuditingDate = System.DateTime.Now;
                        auditModel.AuditingBy = Session["LoginName"].ToString();
                        auditModel.AuditingRemark = AuditingRemark;
                        auditModel.Memo = "";
                        HasDone = mainBll.InfoAuditNote(auditModel);

                        if (!HasDone)
                            AllHasDone = false;
                        #endregion

                        #region 删除已生成的文件

                        //删除静态化文件

                        #endregion

                        break;
                    default:
                        break;
                }
                break;
            case 2:
                switch (AuditingOrigin)
                {
                    case 0:
                        AuditingRemark = "审核未通过->未审核";

                        #region 写入操作记录
                        HasDone = mainBll.HasAuditing(InfoID, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, "", "", 0, 0);

                        if (!HasDone)
                            AllHasDone = false;
                        #endregion

                        #region 写入信息审核记录
                        auditModel = new Tz888.Model.Info.InfoAuditModel();
                        auditModel.InfoID = model.MainInfoModel.InfoID;
                        auditModel.InfoTypeID = theInfoType;
                        auditModel.LoginName = model.MainInfoModel.LoginName;
                        auditModel.PostDate = System.DateTime.Now;
                        auditModel.Title = model.MainInfoModel.Title;
                        auditModel.FeedbackStatus = 0;
                        auditModel.FeedBackNote = "";
                        auditModel.AuditStatus = AuditingStatus;
                        auditModel.AuditingDate = System.DateTime.Now;
                        auditModel.AuditingBy = Session["LoginName"].ToString();
                        auditModel.AuditingRemark = AuditingRemark;
                        auditModel.Memo = "";
                        HasDone = mainBll.InfoAuditNote(auditModel);

                        if (!HasDone)
                            AllHasDone = false;
                        #endregion

                        break;
                    case 1:
                        AuditingRemark = "审核未通过->审核通过";

                        #region 写入操作记录
                        strHtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName(theInfoType, InfoCode, InfoID);

                        HasDone = mainBll.HasAuditing(InfoID, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, strHtmlFile, "", 0, 0);

                        if (!HasDone)
                            AllHasDone = false;
                        #endregion

                        #region 写入信息审核记录
                        auditModel = new Tz888.Model.Info.InfoAuditModel();
                        auditModel.InfoID = model.MainInfoModel.InfoID;
                        auditModel.InfoTypeID = theInfoType;
                        auditModel.LoginName = model.MainInfoModel.LoginName;
                        auditModel.PostDate = System.DateTime.Now;
                        auditModel.Title = model.MainInfoModel.Title;
                        auditModel.FeedbackStatus = 0;
                        auditModel.FeedBackNote = "";
                        auditModel.AuditStatus = AuditingStatus;
                        auditModel.AuditingDate = System.DateTime.Now;
                        auditModel.AuditingBy = Session["LoginName"].ToString();
                        auditModel.AuditingRemark = AuditingRemark;
                        auditModel.Memo = "";
                        HasDone = mainBll.InfoAuditNote(auditModel);

                        if (!HasDone)
                            AllHasDone = false;
                        #endregion

                        #region 生成静态化文件
                        Tz888.BLL.PageStatic.MerchantPageStatic staticobj = new Tz888.BLL.PageStatic.MerchantPageStatic();
                        IsSuccess = staticobj.CreateStaticPageMerchant(model.MainInfoModel.InfoID.ToString(), ref actionMsg);

                        //if (!IsSuccess)
                        //    AllHasDone = false;
                        #endregion

                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }

        #endregion

        #region 邮件通知

        #endregion

        if (AllHasDone)
        {
            string theUrlReferrer = ViewState["strPrePage"].ToString();
            Response.Redirect("ModifyStatus.aspx?InfoID=" + InfoID.ToString() + "&Type=" + theInfoType + "&PrePage=" + theUrlReferrer + "&msg=" + actionMsg);
        }
        else
        {
            Response.Write("<script>alert('变更失败！');history.back(-1);</script>");
        }

    }
}
