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
using Tz888.Model.Register;
using Tz888.BLL.Register;
using System.Collections.Generic;

public partial class Publish_PublishMerchant1 : System.Web.UI.Page
{
    //private const string CON_LoginName = "";
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
        }

        if (this.CheckGovernmentRegisterStatus())
        {
            Session["IsShowTitle"] = false;
            Response.Redirect("./PublishMerchant2.aspx");
        }
        
        if (!IsPostBack)
        {
            this.BindMerchantMain();
            this.InitUserContact(); 
        }
        //this.ImageUploadControl1.InfoType = "GovernmentRegister";
        //this.ImageUploadControl1.IsTopfoUser = (Page.User.IsInRole("GT1002"));
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Tz888.Common.Ajax.AjaxMethod));

        this.txtExhibitionHall.Attributes.Add("onblur", "CheckDomain(this.value,'" + Page.User.Identity.Name.ToString() + "');");
    }

    /// <summary>
    /// 绑定招商机构主体类型
    /// </summary>
    private void BindMerchantMain()
    {
        Tz888.BLL.Register.GovernmentRegisterBLL bll = new GovernmentRegisterBLL();
        ddlSubjectType.DataSource = bll.getMerchantTypeTab();
        ddlSubjectType.DataTextField = "MerchantTypeName";
        ddlSubjectType.DataValueField = "MerchantTypeID";
        ddlSubjectType.DataBind();
    }

    /// <summary>
    /// 加载用户联系信息
    /// </summary>
    private void InitUserContact()
    {
        //string loginName = CON_LoginName;
        string loginName = Page.User.Identity.Name;
        Tz888.BLL.Register.common bll = new Tz888.BLL.Register.common();
        Tz888.Model.Register.OrgContactModel model = new Tz888.Model.Register.OrgContactModel();

        model = bll.getContactModel(loginName);

        if (model == null)
            return;
        Tz888.Model.Register.OrgContactModel model1 = new Tz888.Model.Register.OrgContactModel();
        model1.OrganizationName = model.OrganizationName.Trim();
        model1.Name = model.Name.Trim();
        model1.Mobile = model.Mobile.Trim();
        model1.PostCode = model.PostCode.Trim();
        model1.TelCountryCode = model.TelCountryCode.Trim();
        model1.TelNum = model.TelNum.Trim();
        model1.TelStateCode = model.TelStateCode.Trim();
        model1.Website = model.Website.Trim();
        model1.FaxCountryCode = model.FaxCountryCode.Trim();
        model1.FaxNum = model.FaxNum.Trim();
        model1.FaxStateCode = model.FaxStateCode.Trim();
        model1.Email = model.Email.Trim();
        model1.address = model.address.Trim();
        model1.Career = model.Career.Trim();

        this.MerchantAddressInfo1.OrgContactModel = model1;
        
    }

    /// <summary>
    /// 检查用户是否已经登记招商机构 
    /// </summary>
    /// <returns></returns>
    public bool CheckGovernmentRegisterStatus()
    {
        Tz888.BLL.Register.GovernmentRegisterBLL obj2 = new GovernmentRegisterBLL();
        DataTable dt = obj2.getGovernmentModel(Page.User.Identity.Name);
        if (dt == null || dt.Rows.Count == 0)
              return false;
        return true;
    }
    protected void IbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        bool IsVip = false;
        if (Page.User.IsInRole("GT1002")) IsVip = true;

        //SelfCreateWeb.Model.DatabaseOperationStatus dos = new SelfCreateWeb.BLL.BSelfCreateWebInfo().AddSelfCreateWebInfo(new SelfCreateWeb.Model.MSelfCreateWebInfo(0, Page.User.Identity.Name, "", 0, this.txtExhibitionHall.Text.Trim(), DateTime.Now, DateTime.Now), new SelfCreateWeb.ParameterMap.PSelfCreateWebInfo(false, true, false, false, true,false,false));
         //2010-06-22注释掉以上的
       SelfCreateWeb.Model.DatabaseOperationStatus dos = new SelfCreateWeb.BLL.BSelfCreateWebInfo().AddSelfCreateWebInfo(new SelfCreateWeb.Model.MSelfCreateWebInfo(0, Page.User.Identity.Name, "", 0, this.txtExhibitionHall.Text.Trim(), DateTime.Now, DateTime.Now, 0, ""), new SelfCreateWeb.ParameterMap.PSelfCreateWebInfo(false, true, false, false, true, false, false, false, false));//之前的版本

        if (dos == SelfCreateWeb.Model.DatabaseOperationStatus.Success)
        {
            new SelfCreateWeb.BLL.BSelfCreateWebInfo().InitPageParameter(Page.User.Identity.Name, IsVip, true);
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "此域名不可用，请重新输入！");
            return;
        }

        Tz888.Model.Register.GovernmentInfoModel model = new GovernmentInfoModel();
        Tz888.BLL.Register.GovernmentRegisterBLL bll = new GovernmentRegisterBLL();

        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //行业实体列表
        List<Tz888.Model.Register.OrgContactMan> ContactManModels = new List<Tz888.Model.Register.OrgContactMan>();//联系人实体列表 
        Tz888.Model.Register.OrgContactModel ContactModel = new Tz888.Model.Register.OrgContactModel(); //创建信息联系方式主体
        List<Tz888.Model.MemberResourceModel> infoResourceModels = new List<Tz888.Model.MemberResourceModel>();//图片资料

        //基本信息
        //model.LoginName = "heyi";
        model.LoginName = Page.User.Identity.Name;
        if (!string.IsNullOrEmpty(this.txtMerchantName.Text.Trim()))
            model.GovernmentName = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtMerchantName.Text.Trim());
        model.GovAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtMerchantIntro.Value.Trim());
        model.GovAboutBrief = "";
        model.SubjectType = ddlSubjectType.SelectedValue;
        model.CountryCode = this.ZoneSelectControl1.CountryID;
        model.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.CityID = this.ZoneSelectControl1.CityID;
        model.CountyID = this.ZoneSelectControl1.CountyID;
        model.AuditingStatus = 0;//审核状态

        model.GovernmentID = 0;
        model.ExhibitionHall = this.txtExhibitionHall.Text.Trim();//展厅
        model.Hits = 0;//点击数

        model.remark = "";

        //联系信息
        ContactModel = this.MerchantAddressInfo1.OrgContactModel;//联系信息
        ContactManModels = this.MerchantAddressInfo1.OrgContactManModels;//联系人

        //将已上传的图片从临时目录迁移到正式目录      
        //infoResourceModels = Tz888.Common.InfoResourceManage.MemberImageTransfer("Image", "EnterpriseImage", Tz888.Common.ResourceType.Image, Tz888.Common.MemberResourceProperty.RP0, ImageUploadControl1.InfoList);
        //infoResourceModels = ImageUploadControl1.InfoList;

        int rv = bll.GovernmentAdd(model, ContactModel, ContactManModels, infoResourceModels);
        if (rv > 0)
        {
            Session["IsShowTitle"] = true;
            Response.Redirect("./PublishMerchant2.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "招商机构登记失败！");
        }
    }
}
