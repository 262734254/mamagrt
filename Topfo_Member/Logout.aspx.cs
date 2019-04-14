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

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tz888.BLL.Login.LoginInfoBLL.Logout();
        string comeUrl = "http://member.topfo.com/Login.aspx";
        if (Request.QueryString["url"] != null && Request.QueryString["url"].Trim() != "")
            comeUrl = Request.QueryString["url"].Trim();

        //SelfCreateWeb.BLL.BLoginUser.Logout();
        //SelfCreateWeb.BLL.BLoginUser.ClientLogout();
        Session["MemberCompetence"] = null;
        Session.Abandon();
        Response.Redirect(comeUrl);
    }
}
 