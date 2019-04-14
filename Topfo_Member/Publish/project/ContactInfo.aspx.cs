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

public partial class Publish_project_ContactInfo : System.Web.UI.Page
{

    protected long _infoID;
    protected string title;
    protected string cooperationDemandType;
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
        ImageButton1.Attributes.Add("onclick", "return chkpost();");
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
                    if (InfoType.ToLower() != "project")
                        throw new Exception();
                    this.cooperationDemandType = arr[3].ToString();
                }
                else
                {
                    Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "请通过正常途径访问!", "http://member.topfo.com");
                }
            }
            catch
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "请通过正常途径访问!", "http://member.topfo.com");
            }
        }
        else
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "请通过正常途径访问!", "http://member.topfo.com");
        if (!Page.IsPostBack)
        {
            InitInfoContact();
        }
    }
    private void InitInfoContact()
    {
        string loginName = Page.User.Identity.Name;
        Tz888.BLL.Register.common bll = new Tz888.BLL.Register.common();
        Tz888.Model.Register.OrgContactModel model = new Tz888.Model.Register.OrgContactModel();
        model = bll.getContactModel(loginName);
        if (model == null)
            return;
        txtCompanyName.Value = model.OrganizationName.Trim();
        txtLinkMan.Value = model.Name.Trim();
        txtMobile.Value = model.Mobile.Trim();
        txtTelStateCode.Value = model.TelStateCode.Trim();
        txtTel.Value = model.TelNum.Trim();

        txtWebSite.Value = model.Website.Trim();

        txtEmail.Value = model.Email.Trim();
        txtAddress.Value = model.address.Trim();
        txtCareer.Value = model.Career.Trim();

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Tz888.BLL.Info.InfoContact dal = new Tz888.BLL.Info.InfoContact();
        Tz888.Model.Info.InfoContactModel model = new Tz888.Model.Info.InfoContactModel();
       
        model.InfoID = _infoID;
        model.OrganizationName = txtCompanyName.Value.Trim();
        model.Name = txtLinkMan.Value.Trim();
        model.Career = txtCareer.Value.Trim();
        model.TelStateCode = txtTelStateCode.Value.Trim();
        model.TelNum = txtTel.Value.Trim();
        model.Mobile = txtMobile.Value.Trim();
        model.Address = txtAddress.Value.Trim();
        model.WebSite = txtWebSite.Value.Trim();
        model.Email = txtEmail.Value.Trim();
        bool b = dal.Add(model);
        if (b)
        {
            Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();
            Tz888.BLL.Info.MainInfoBLL mainDAL = new Tz888.BLL.Info.MainInfoBLL();
            mainInfoModel = mainDAL.GetModel(_infoID);
            string HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("Project", mainInfoModel.InfoCode, _infoID);
            Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
            mainBll.HasHtmlFile(_infoID, HtmlFile);
            string actionMsg = "";
            Tz888.BLL.PageStatic.ProjectPageStatic dalPage = new Tz888.BLL.PageStatic.ProjectPageStatic();
            dalPage.CreateStaticPageProject_New(_infoID.ToString(), ref actionMsg);
            Response.Redirect("/Publish/Publishproject3.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(_infoID.ToString() + "|Project|" + title));
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "联系信息添加失败..");
        }
    }
}
