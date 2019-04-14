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

public partial class Register_InviteFriend : System.Web.UI.Page
{
    protected string nickName;
    protected void Page_Load(object sender, EventArgs e)
    {
         string loginName = "";
       
         try { loginName = Request.Cookies["topfo.com_CKData"].Value; }
         catch (NullReferenceException exp)
         {
             loginName = "";
         }
         if (loginName.Trim() != "" || loginName != string.Empty)
         {
             Tz888.BLL.Register.MemberInfoBLL logBLL = new Tz888.BLL.Register.MemberInfoBLL();
             
             nickName = logBLL.getNickName(loginName);
             string email = logBLL.GetEmailByLoginName(loginName);

             txtemail.Text = email;
             name.Text = nickName;
             content.InnerText = "  我发现了一个很好的网站，已经成为它的会员了。我觉得它也很适合你，你可以到下面的地址去注册： http://member.topfo.com/Register/Register.aspx ，感受一下它的功能和良好服务。\r" +
                "  另外，如果你注册的时候在“邀请人”一栏填上我的昵称，还能给我带来500积分哦。我的昵称是“" + nickName + "”，呵呵，快去注册吧！ ";
             pnick2.Text = nickName;
         }
         
    }

    protected void button1_ServerClick(object sender, EventArgs e)
    {
        string firstSub = "";
        try { firstSub = Request.Cookies[txtFemail.Text].Value; }
        catch (NullReferenceException exp)
        { firstSub = ""; }
        if (firstSub == "" || firstSub == string.Empty)
        {

            Tz888.BLL.AutoSendMsg sendMail = new Tz888.BLL.AutoSendMsg();
            sendMail.SendMail2MenLst(name.Text, txtemail.Text.Trim(), txtFemail.Text.Trim(), content.Value);
            HttpCookie hasSend = new HttpCookie(txtFemail.Text);
            hasSend.Value = "true";
            hasSend.Expires = DateTime.Now.AddDays(365);
            Response.Cookies.Add(hasSend);
            Response.Write("<script language='javascript'>alert('推荐邮件已成功发送至您的好友！');</script>");

        }
        else
        {
            Response.Write("<script language='javascript'>alert('您已向该好友发送过推荐邮件.');</script>");
        }
    }
}
