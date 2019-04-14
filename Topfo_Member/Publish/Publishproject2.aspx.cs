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

public partial class Publish_Publishproject2 : System.Web.UI.Page
{
    protected long _infoID;
    protected string title;
    protected string cooperationDemandType;

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
                    if (arr.Length == 4)
                    {
                        this._infoID = Convert.ToInt64(arr[0]);
                        string InfoType = arr[1].ToString();
                        this.title = arr[2].ToString();
                        if (InfoType.ToLower() != "project")
                            throw new Exception();
                        this.cooperationDemandType = arr[3].ToString();


                        ViewState["InfoID"] = this._infoID;
                        ViewState["Title"] = this.title;

                        this.TFZSEvaluateGQ1.InfoID = this._infoID;
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
        }

        this.IbtnShow.Attributes.Add("onclick", "show();return false;");

        this.btnSubmit.Attributes.Add("onclick", "return checkMyTFZSform()");
        
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        decimal Evaluate = this.TFZSEvaluateGQ1.SaveEvaluate();
        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        long InfoID = Convert.ToInt64(ViewState["InfoID"]);
        bll.HasMainEvaluation(InfoID, Evaluate);
        string Title = ViewState["Title"].ToString();
        Response.Redirect("./Publishproject3.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(InfoID.ToString() + "|Project|" + Title));
    }
    protected void IbtnPG_Click(object sender, ImageClickEventArgs e)
    {
        if (this.TFZSEvaluateGQ1.Visible)
            this.TFZSEvaluateGQ1.Visible = false;
        else
        {
            this.TFZSEvaluateGQ1.InfoID = Convert.ToInt64(ViewState["InfoID"]);
            this.TFZSEvaluateGQ1.Visible = true;
        }
    }
    protected void btnJump_Click(object sender, EventArgs e)
    {
        long InfoID = Convert.ToInt64(ViewState["InfoID"]);
        string Title = ViewState["Title"].ToString();
        Response.Redirect("./Publishproject3.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(InfoID.ToString() + "|Project|" + Title));
    }
}
