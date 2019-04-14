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

public partial class Register_Tegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tz888.Common.Ajax.AjaxMethod ajax = new Tz888.Common.Ajax.AjaxMethod();
        if (!IsPostBack)
        {
            if (Request.QueryString["jid"] != null && Request.QueryString["jid"].ToString().Trim() != "")
            {
                string introducer = Request.QueryString["jid"].ToString().Trim();
                bool flag = false;
                flag = ajax.ValiLoginName(introducer);
                if (flag)
                {
                    HttpCookie Cook = new HttpCookie("JID");
                    Cook.Value = introducer.Trim();
                    Cook.Domain = ".topfo.com";
                    Response.SetCookie(Cook);
                }
            }
        }
    }
}