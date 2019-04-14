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
using Tz888.Common.DEncrypt;


public partial class Register_ValidEMailEnterprise : System.Web.UI.Page
{
    protected string name;      //登陆名      
    protected string domain;    //用于替换模板中图片路径的域名
    protected string validurl;  //验证URL

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            name = Request.QueryString["logname"];
            string email = Request.QueryString["email"];
            string dname = "";
            string demail = "";
            Tz888.BLL.Register.RegisterMail mail = new Tz888.BLL.Register.RegisterMail();
            try
            {

                try
                {
                    if ((name != null && email != null) ||
                    (!name.Equals(String.Empty) && !email.Equals(String.Empty)))
                    {
                        demail = DEncrypt.Decrypt(email);
                        dname = DEncrypt.Decrypt(name);

                    }
                }
                catch (NullReferenceException ep)
                {
                    Tz888.Common.MessageBox.ShowBack("非法访问，"+ep.Message);
                    return;
                }
            }
            catch (FormatException exp)
            {
                Tz888.Common.MessageBox.ShowBack("邮箱验证出错！"+exp.Message);
                return;
            }
            
            lblMail.Text = demail;
            //邮件模板URL
            string url = Server.MapPath(mail.GetMailTemplateUrl());
            domain = "http://" + Request.ServerVariables["SERVER_NAME"].ToString();
            validurl = domain + Request.RawUrl.Replace("ValidEMailEnterprise.aspx", "ValidSuccessEnter.aspx");

            string isSend = mail.GetCookies(dname);
            if (isSend == "" || isSend == string.Empty)
            {
                mail.SendMail(url, dname, demail, validurl, domain);
                mail.CreateCookies(dname, email, "");
            }
           
        }
    }
}
