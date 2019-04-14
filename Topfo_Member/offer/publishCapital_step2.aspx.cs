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

public partial class publishCapital_step2 : System.Web.UI.Page
{
    protected long _infoID;
    protected string title = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (string.IsNullOrEmpty(Page.User.Identity.Name))
        //{
        //    Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        //    return;
        //}
        if (!Page.IsPostBack)
        {
            this.LoadInfoContact();
            if (!Page.IsPostBack)
            {
               
                if (this.Page.Request.QueryString["code"] != null)
                {
                    string code = this.Page.Request.QueryString["code"].ToString();
                    try
                    {
                        code = Tz888.Common.DEncrypt.DESEncrypt.Decrypt(code);
                        string[] arr = code.Split('|');
                        if (arr.Length == 4)
                        {
                            this._infoID = Convert.ToInt64(arr[0]);
                            string InfoType = arr[1].ToString();
                            this.title = arr[2].ToString();
                            if (InfoType.ToLower() != "capital")
                                throw new Exception();
                            ViewState["InfoID"] = this._infoID;
                            ViewState["Title"] = this.title;
                           // ViewState["OrganizationName"] = arr[3].ToString();
                        }
                        else
                            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "请通过正常途径访问!", "http://member.topfo.com");
                    }
                    catch
                    {
                        Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "请通过正常途径访问!", "http://member.topfo.com");
                    }
                }
                else
                    Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "请通过正常途径访问!", "http://member.topfo.com");
            }
        }
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        //bool isTof = Page.User.IsInRole("GT1002");

        //if (isTof)
        //{
        //    Page.MasterPageFile = "/indexTof.master";
        //}
        //else
        //{
        //    Page.MasterPageFile = "/MasterPage.master";
        //}
    }

    private void LoadInfoContact()
    {
        string loginName = Page.User.Identity.Name;
        Tz888.BLL.Register.common bll = new Tz888.BLL.Register.common();
        Tz888.Model.Register.OrgContactModel model = new Tz888.Model.Register.OrgContactModel();
        model = bll.getContactModel(loginName);
        if (model == null)
            return;

        this.txtLinkMan.Text = model.Name;
        this.txtMobile.Text = model.Mobile;
        this.txtTelCountry.Text = model.TelCountryCode;
        this.txtTelZoneCode.Text = model.TelStateCode;
        this.txtTelNumber.Text = model.TelNum;

       //this.txtFaxCountry.Text = model.FaxCountryCode;
       //this.txtFaxZoneCode.Text = model.FaxStateCode;
       //this.txtFaxNumber.Text = model.FaxNum;

        this.txtEmail.Text = model.Email;
        this.txtAddress.Text = model.address;
        //this.txtPostCode.Text = model.PostCode;
        this.txtWebSite.Text = model.Website;
        //以下是职位
        this.txtPosition.Text = model.Position;

        //ViewState["OrganizationName"] = model.OrganizationName;
        //这里是换为投资机构名称
        this.txtGovName.Text = model.OrganizationName;
    }

    protected void btn_ServerClick(object sender, EventArgs e)
    {
       

        ////这里是判断验证码
        //try
        //    //验证验证码
        //{
        //    if (Session["valationNo"] == null || ImageCode.Text.ToUpper().Trim() != Session["valationNo"].ToString().ToUpper().Trim() || Session["valationNo"].ToString().Trim() == "")
        //    {
        //        Tz888.Common.MessageBox.Show(this.Page, "验证码错误!");
        //        return;
        //    }
        //}
        //catch
        //{
        //    Tz888.Common.MessageBox.Show(this.Page, "未知错误!");
        //}

        this._infoID = Convert.ToInt64(this.ViewState["InfoID"]);
        this.title = Convert.ToString(this.ViewState["Title"]);
        Tz888.Model.Info.InfoContactModel infoContactModel = new Tz888.Model.Info.InfoContactModel(); //创建信息联系方式主体

        string email = this.txtEmail.Text.Trim();
        string telCountry = this.txtTelCountry.Text.Trim();
        string telZoneCode = this.txtTelZoneCode.Text.Trim();
        string telNumber = this.txtTelNumber.Text.Trim();
        //注释掉传真
        string faxCountry ="0";
        string faxZoneCode ="0";
        string faxNumber = "0";
        string webSite = this.txtWebSite.Text.Trim();
        string name = this.txtLinkMan.Text.Trim();
        string mobile = this.txtMobile.Text.Trim();
        string address = this.txtAddress.Text.Trim();
        //注释右邮编
        string postCode ="0";

        //以下是职位
        string position = this.txtPosition.Text.Trim();
         //投资机构名称
        string organizationName = this.txtGovName.Text.Trim();

       // if (ViewState["OrganizationName"] != null)
       // {
           // infoContactModel.OrganizationName = ViewState["OrganizationName"].ToString();
       // }
        infoContactModel.OrganizationName = organizationName;
        infoContactModel.InfoID = this._infoID;
        infoContactModel.Email = email;
        infoContactModel.WebSite = webSite;
        infoContactModel.TelCountryCode = telCountry;
        infoContactModel.TelStateCode = telZoneCode;
        infoContactModel.TelNum = telNumber;
        infoContactModel.FaxCountryCode = faxCountry;
        infoContactModel.FaxStateCode = faxZoneCode;
        infoContactModel.FaxNum = faxNumber;
        infoContactModel.Name = name;
        infoContactModel.Mobile = mobile;
        infoContactModel.Address = address;
        infoContactModel.PostCode = postCode;
        //以下是职位
        infoContactModel.Position = position;

        Tz888.BLL.Info.InfoContact obj = new Tz888.BLL.Info.InfoContact();

        //这里是更新联系信息
        if (obj.Update(infoContactModel))
        {
            Response.Redirect("publishCapital_step3.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(this._infoID.ToString() + "|Capital|" + this.title));
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "更新联系方式失败！");
        }
        //以下是单独将信息完整度分数插入到Captialinfo中

        Tz888.BLL.Info.V124.CapitalInfoBLL InformationIntegrityUpdate = new Tz888.BLL.Info.V124.CapitalInfoBLL();
        InformationIntegrityUpdate.InsertInformationIntegrity(infoContactModel);


    }
}
