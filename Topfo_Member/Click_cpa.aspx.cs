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

public partial class Click_cpa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (Request.QueryString["advsiteID"] != null && Request.QueryString["advsiteID"].Trim() != "")
        {
            HttpCookie loginedUser = new HttpCookie("adv_cpa");
            loginedUser.Expires = DateTime.Now.AddDays(1);
            loginedUser.Value = Request.QueryString["advsiteID"].Trim() + "," + Request.QueryString["listID"].Trim();
            Response.Cookies.Add(loginedUser);
        }
        Response.Redirect("http://member.topfo.com/Register/Register.aspx");
    }
}
