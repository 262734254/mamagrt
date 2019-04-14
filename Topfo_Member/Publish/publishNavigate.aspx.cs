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

public partial class Publish_publishNavigate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }

        if (Page.User.IsInRole("MT1004"))
        {
            Response.Redirect("/Publish/PublishMerchant1.aspx");
        }
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
    protected void IbtnPublishProject_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect("project/gq1.aspx");
        Response.Redirect("project/EquityRaised_Issue.aspx");
    }
    protected void IbtnPublishMerchant_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PublishMerchant1.aspx");
    }
    protected void IbtnPublishCapital_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PublishCapital1.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect("project/gq1.aspx");
        Response.Redirect("project/CreditorsRaised_Issue.aspx");
    }
}
 