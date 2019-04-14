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

public partial class Register_RegisterSuccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ///------------------------------
        ///--design by AdSystem_20090620
        ///------------------------------
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        else
        {
            AdSystem.Logic loc = new AdSystem.Logic();
            loc.AdLogin_Add(Page.User.Identity.Name.Trim());
        }
    }
}
