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

[AjaxPro.AjaxNamespace("PublishProject")]
public partial class Publish_Publishproject3 : System.Web.UI.Page
{
    protected long _infoID;
    protected string title = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }

        if (!Page.IsPostBack)
        {
            if (this.Page.Request.QueryString["code"] != null)
            {
                string code = this.Page.Request.QueryString["code"].ToString();
                try
                {
                    code = Tz888.Common.DEncrypt.DESEncrypt.Decrypt(code);
                    string[] arr = code.Split('|');
                    if (arr.Length == 3)
                    {
                    
                        this._infoID = Convert.ToInt64(arr[0]);
                        string InfoType = arr[1].ToString();
                        this.title = arr[2].ToString();
                        if (InfoType.ToLower() != "project")
                            throw new Exception();
                        ViewState["InfoID"] = this._infoID;
                    }
                }catch
                { }
            }
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Publish_Publishproject3));
        this.SetPageDisplay();
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
    [AjaxPro.AjaxMethod]
    public int GetMatchCount(long InfoID)
    {
        Tz888.BLL.Info.MatchInfoBLL bll = new Tz888.BLL.Info.MatchInfoBLL();
        int count = bll.GetCount(InfoID, "PC", "") + bll.GetCount(InfoID, "PM", "");
        return count;
    }

    protected void SetPageDisplay()
    {
        if (Page.User.IsInRole("GT1002") || Page.User.IsInRole("GT1003"))
        {
            this.plTopfoMsg.Visible = true;
            this.plTopfoTitle.Visible = true;
            this.plnoneMsg.Visible = false;
            this.plnoneTitle.Visible = false;
        }
        else
        {
            this.plTopfoMsg.Visible = false;
            this.plTopfoTitle.Visible = false;
            this.plnoneMsg.Visible = true;
            this.plnoneTitle.Visible = true;
        }
    }
 
}
