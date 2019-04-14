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

public partial class Register_RetrieveStep1 : System.Web.UI.Page
{
    HttpCookie myCookie = new HttpCookie("RePwdName");
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    //通过邮箱找回密码
    protected void LbEmail_Click(object sender, EventArgs e)
    {
        if (this.TxtUserName.Text.Trim().Length > 0)
        { 
            myCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(myCookie);
            myCookie.Value = this.TxtUserName.Text.Trim().ToString();
            Response.Redirect("RetrieveStep2.aspx");
        } 
    }
    //通过密码保护找回密码
    protected void LbQuestion_Click(object sender, EventArgs e)
    {
        if (this.TxtUserName.Text.Trim().Length > 0)
        { 
            myCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(myCookie);
            myCookie.Value = this.TxtUserName.Text.Trim().ToString();
            Response.Redirect("RetrieveStep5.aspx");
        }
    }
    //通过手机找回密码
    protected void LbPhone_Click(object sender, EventArgs e)
    {
        if (this.TxtUserName.Text.Trim().Length > 0)
        { 
            myCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(myCookie);
            myCookie.Value = this.TxtUserName.Text.Trim().ToString();
            Response.Redirect("RetrieveStep7.aspx");
        }
    }
}
