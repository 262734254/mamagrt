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

public partial class helper_FriendManager_AddSuccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["name"].ToString() != null && Request.QueryString["name"].ToString() != "")
        {
            this.hplName.Text = Request.QueryString["name"].ToString();
            //this.hplName.NavigateUrl="";
            this.hplSendInfo.Text = "给" +Server.UrlDecode( Request.QueryString["name"].ToString()) + "发送站内短信";
            this.hplSendInfo.NavigateUrl = "../../innerinfo/SendView.aspx?Ac=0&name=" + Request.QueryString["name"].ToString();
        }
    }

}
