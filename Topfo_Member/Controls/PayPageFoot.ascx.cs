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

public partial class Controls_PayPageFoot : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.IsInRole("GT1002"))
        {
            Literal1.Text = " &gt;&gt; <a href='http://member.topfo.com/Register/VIPMemberRegister_In.aspx'>申请拓富通</a>";
        }
    }
}
