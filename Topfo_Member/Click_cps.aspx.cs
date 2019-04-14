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
using AdSystem;

public partial class Click_cps : System.Web.UI.Page
{
    public string cookieName = "AdSystem";  //互告网站的cookie的存储名称
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["advsiteID"] != null && Request.QueryString["advsiteID"].Trim() != "")
        {
            string sitekey = Request.QueryString["advsiteID"].Trim();
            string listid = Request.QueryString["listID"];
            AdSystem.Logic loc = new Logic();
            string infoid = loc.getInfoIdByList(listid).ToString().Trim();
            if (sitekey != "" && infoid != "" && infoid != "0")
            {
                HttpCookie testcook = new HttpCookie(cookieName);
                testcook.Values.Add("sitekey", sitekey);
                testcook.Values.Add("infoid", infoid);
                testcook.Values.Add("clickT", "cps");
                testcook.Domain = "topfo.com";

                Response.Cookies.Add(testcook);
            }
            string htmlfile = Request.QueryString["htmlfile"];
            Response.Redirect("http://www.topfo.com/" + htmlfile);
        }
    }

}
