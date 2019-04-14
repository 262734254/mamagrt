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

public partial class PayManage_Ad_buylist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Page.User.Identity.Name;
       // string name = "21263729";
        LgName.Value = name;
    }
}
