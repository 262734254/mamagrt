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

[AjaxPro.AjaxNamespace("PublishMerchant")]
public partial class Publish_PublishMerchant3 : System.Web.UI.Page
{
    protected long _infoID;
    protected string title;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }

        //this.ShowNavigateTitle();
        //this.SetPageDisplay();

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
                        if (InfoType.ToLower() != "merchant")
                            throw new Exception();
                        ViewState["InfoID"] = this._infoID;
                    }
                }
                catch { }
            }
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Publish_PublishMerchant3));
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
        //this._infoID = Convert.ToInt64(ViewState["InfoID"]);
        Tz888.BLL.Info.MatchInfoBLL bll = new Tz888.BLL.Info.MatchInfoBLL();
        return bll.GetCount(InfoID, "MC", "") + bll.GetCount(InfoID, "MP", "");
    }

    //protected void SetPageDisplay()
    //{
    //    if (Page.User.IsInRole("GT1002") || Page.User.IsInRole("GT1003"))
    //    {
    //        this.plTopfoMsg.Visible = true;
    //        this.plTopfoTitle.Visible = true;
    //        this.plnoneMsg.Visible = false;
    //        this.plnoneTitle.Visible = false;
    //    }
    //    else
    //    {
    //        this.plTopfoMsg.Visible = false;
    //        this.plTopfoTitle.Visible = false;
    //        this.plnoneMsg.Visible = true;
    //        this.plnoneTitle.Visible = true;
    //    }
    //}

    //protected void ShowNavigateTitle()
    //{
    //    if (Session["IsShowTitle"] != null && Convert.ToBoolean(Session["IsShowTitle"]))
    //        this.plTitle.Visible = true;
    //    else
    //        this.plTitle.Visible = false;
    //}
}
