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

public partial class Publish_LoansManage : System.Web.UI.Page
{
    Tz888.BLL.loansInfoTab loansinfotabbll = new Tz888.BLL.loansInfoTab();
    Tz888.BLL.LoansInfo loansinfobll = new Tz888.BLL.LoansInfo();
    Tz888.BLL.loanscontactsTab loanscontactstab = new Tz888.BLL.loanscontactsTab();
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Page.User.Identity.Name;
        username.Value = name.Trim();
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        if (!IsPostBack)
        {
            
        }
    }

}
