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

public partial class InnerInfo_wasterView : System.Web.UI.Page
{
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
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        Tz888.Model.InnerInfo model = new Tz888.Model.InnerInfo();
        Tz888.BLL.InnerInfo infoBLL = new Tz888.BLL.InnerInfo();
        if (Request.QueryString["wasterId"] != null && Request.QueryString["wasterId"] != "")
        {
            //int waster = 29;
            model = infoBLL.GetInfoContext(Convert.ToInt32(Request.QueryString["wasterId"]), 2); 
            //model = infoBLL.GetInfoContext(waster, 2); 
            this.HlpTopic.Text = model.Topic;
            this.HplSendman.Text = model.SendName;
            this.HplReceiveman.Text = model.ReceiveName;
            this.TBoxInfoText.Text = model.Context;
        }
    }
}
