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
using System.Text;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Net.Sockets;

public partial class Message_TEST2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SendEmail();
    }
    public void SendEmail()
    {
        string from = txtEmail.Text.ToString() ;   //发送方邮箱
        string subject = TextBox1.Text.ToString();  //标题
        string fasong = txtShoujianren.Text.ToString();
        string Content = txtContent.Text.ToString();
        string Number = txtNumber.Text.ToString();
        string PWD = txtPwd.Text.ToString();
        string ZUJI = TextBox2.Text.ToString();
        MailMessage newEmail = new MailMessage();

        #region 发送方邮件
        newEmail.From = new MailAddress(from, from);
        #endregion

        #region 发送对象，可群发
        string[] receiveLST = fasong.Split(';');
        for (int i = 0; i < receiveLST.Length; i++)
        {
            newEmail.To.Add(new MailAddress(receiveLST[i].ToString()));
        }

        #endregion


        #region Subject
        newEmail.Subject = subject;  //标题
        #endregion

        #region Body
        string strBody = "<p><b>"+Content+"</b></p>"; //html格式，也可以是普通文本格式 
        newEmail.Body = strBody;  //内容
        #endregion

        #region 附件
        //Attachment MsgAttach = new Attachment(this.FileUpload1.PostedFile.FileName);//可通过一个FileUpload地址获取附件地址
        //newEmail.Attachments.Add(MsgAttach);
        #endregion

        #region Deployment
        newEmail.IsBodyHtml = true;                //是否支持html
        newEmail.Priority = MailPriority.Normal;  //优先级
        #endregion

        //发送方服务器信息
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.UseDefaultCredentials = true;
        smtpClient.Credentials = new System.Net.NetworkCredential(Number, PWD);
        smtpClient.Host = ZUJI; //主机

        //smtpClient.Send(newEmail);   //同步发送,程序将被阻塞

        #region 异步发送, 会进入回调函数SendCompletedCallback，来判断发送是 否成功
        smtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);//回调函数
        string userState = "测试";
        smtpClient.SendAsync(newEmail, userState);
        #endregion

    }

    private static void SendCompletedCallback(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        if (e.Cancelled)  //邮件发送被取消
        {

        }
        if (e.Error != null)   //邮件发送失败
        {

        }
        else   //发送成功
        {

        }

    }

    protected void txtShoujianren_TextChanged(object sender, EventArgs e)
    {

    }
}
