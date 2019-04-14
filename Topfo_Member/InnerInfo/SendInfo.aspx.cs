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
using Tz888.BLL;
using Tz888.Model;

public partial class InnerInfo_SendInfo : System.Web.UI.Page
{
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
    protected void Page_Load(object sender, EventArgs e)
    {
        Tz888.BLL.InnerInfo obj = new Tz888.BLL.InnerInfo();
        DataTable dt = obj.getFriends(Page.User.Identity.Name);
        this.lstFriend.DataSource = dt;
        lstFriend.DataValueField = dt.Columns["ContactId"].ToString();
        lstFriend.DataTextField = dt.Columns["ContactName"].ToString();
        this.lstFriend.DataBind();
    }
    protected void butSend_Click(object sender, EventArgs e)
    {
        string strReceivedMan = txtReceivedMan.Text.Trim();
        string[] ReceivedMan = strReceivedMan.Split(',');
        for (int i = 0; i < strReceivedMan.Split(',').Length; i++)
        {
            InnerInfoSend info = new InnerInfoSend();
            info.SendID = 0;
            info.LoginName = "liyanlili";//tzWeb.LoginInfo.GetLoginUserName(0);
            info.ReceivedMan = ReceivedMan[i].Trim();
            //info.Topic = Invest.WebRule.common.TxtToHtml(txtTopic.Text.Trim());
            //info.Context = Invest.WebRule.common.TxtToHtml(txtContext.Text.TrimEnd());
            info.Size = txtContext.Text.TrimEnd().Length + txtTopic.Text.Trim().Length;
            info.ChangeBy = "liyanlili";//tzWeb.LoginInfo.GetLoginUserName(0);

            bool IsSave = cbIsSave.Checked;//是否保存到放件箱
            Tz888.BLL.InnerInfo obj = new Tz888.BLL.InnerInfo();
            bool b = obj.SendInfo(info);
        }
        Response.Write("<script>alert('短消息发送成功！')</script>");
        Response.Redirect("Sent.aspx");
    }
}
