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

public partial class helper_try_vip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            bind();
           
        }
    }
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
    public void bind()
    {
        string LoginName = Page.User.Identity.Name;
        lblLoginName.Text = LoginName;
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("VipMsgTrialLog", "ID","ID", 1, 1, 1, 1, "LoginName='" + LoginName + "'");
       
        if (Convert.ToInt32(dt.Rows[0].ItemArray[0])==0)
        {
            lblMsg.Text = "发送短信，<span class='hong font14'>拓富通会员服务 </span>就能轻松试用！每次可试用一天，最多可以试用三次！";
            return;
        }
        if (Convert.ToInt32(dt.Rows[0].ItemArray[0])<3)
        {
            lblMsg.Text = "您已经试用过" + dt.Rows[0].ItemArray[0].ToString()+ "次，您可以再次通过短信申请试用！";
            //您已经试用过X次，请您填写我们的调查问卷，填写后您可以再次通过短信申请试用！
            return;
        }
        if (Convert.ToInt32(dt.Rows[0].ItemArray[0])>=3)
        {
            lblMsg.Text = "您已经试用过三次拓富通会员，可见你非常认同我们的拓富通会员服务，请立即申请使用吧！如果还有疑问，请与我们的<a href=\"javascript:jiayingOpenMyWin()\"><font color='red'>客服专员</font></a>联系!";
            return;
        }
    }
}
