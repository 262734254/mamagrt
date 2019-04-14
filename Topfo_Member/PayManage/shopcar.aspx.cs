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

public partial class PayManage_shopcar : System.Web.UI.Page
{
    public long infoID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["InfoID"] != null)
        {
            infoID = Convert.ToInt64(Request.QueryString["InfoID"]);
        }
        string loginname = Page.User.Identity.Name;
        if (loginname == "")
        {
            Response.Redirect("http://member.topfo.com/login.aspx?ReturnURL=" + Request.Url.ToString());
            return;
        }
        Tz888.BLL.Pay dal = new Tz888.BLL.Pay();
        try
        {
            bool b = dal.ShopCar_Add(infoID, loginname);
            Response.Redirect("trade_info_wait.aspx");
        }
        catch
        {
            Response.Redirect("trade_info_wait.aspx");
        }
    }
}
