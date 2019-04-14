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

public partial class helper_FriendManager_addError : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.QueryString["name"] != null) && (Request.QueryString["name"] != ""))
        {
            this.hplName.Text = Request.QueryString["name"];
            //this.hplName.NavigateUrl = "";
        }
    }
}
