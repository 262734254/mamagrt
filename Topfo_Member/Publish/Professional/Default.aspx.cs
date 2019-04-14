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

public partial class Publish_Professional_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Publish_Professional_Default));
    }
    [AjaxPro.AjaxMethod]
    public void DeleteMethod(int ID)
    {
        Response.Write("<script>alert('aaaa')</script>");
        Tz888.Common.MessageBox.Go("aaa", true);

    }
}
