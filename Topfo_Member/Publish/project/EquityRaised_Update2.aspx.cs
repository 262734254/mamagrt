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

public partial class Publish_project_EquityRaised_Update2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btOK.Attributes.Add("onclick", "return chkpost()");
    }
    protected void btOK_Click(object sender, EventArgs e)
    {
        
    }
}
