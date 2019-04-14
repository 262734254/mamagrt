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
using Tz888.BLL.Register;

public partial class Register_ValidSuccessEnter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string actionType = Request.QueryString["act"].Trim();
        string name = Request.QueryString["logname"];
        string mail = Request.QueryString["email"];

        if (string.IsNullOrEmpty(actionType) ||
            string.IsNullOrEmpty(name) ||
            string.IsNullOrEmpty(mail))
        {
            return;
        }
        else
        {
            actionType = Tz888.Common.DEncrypt.DEncrypt.Decrypt(actionType);
            name = Tz888.Common.DEncrypt.DEncrypt.Decrypt(Request.QueryString["logname"]);
            mail = Tz888.Common.DEncrypt.DEncrypt.Decrypt(Request.QueryString["email"]);
            
        }
      
        if (actionType == "register")
        {
            divreg.Attributes.Add("style","");
            divvalid.Attributes.Add("style","display:none");
            divafter.Attributes.Add("style", "display:none");
            divahead.Attributes.Add("style", "");

            RegisterMail mailV = new RegisterMail();
            //邮件模板URL

            string validurl = Request.RawUrl.Replace("ValidSuccessEnter.aspx", "ValidEMailEnterprise.aspx");
            validurl = validurl.Substring(0,validurl.IndexOf("&act=")+"&act=".Length);
            validurl += Server.UrlEncode(Tz888.Common.DEncrypt.DEncrypt.Encrypt("valid"));

            hpvalidurl.HRef = validurl;
        }

        if(actionType == "valid")
        {
            try
            {
                divreg.Attributes.Add("style", "display:none");
                divvalid.Attributes.Add("style", "");
                divafter.Attributes.Add("style", "");
                divahead.Attributes.Add("style", "display:none");

                LoginInfoBLL login = new LoginInfoBLL();
                RegisterMail mailB = new RegisterMail();
                
                //防止刷新而导致邮件重发
                string CheckUp = mailB.GetCookies("SUCCESS" + name);
                
                if (CheckUp == "" || CheckUp == string.Empty)
                {
                    login.ValidUser(name);      //激活会员

                    string url = mailB.GetMailSucessTemplateUrl();
                    string domain = "http://" + Request.ServerVariables["SERVER_NAME"].ToString();

                    mailB.SendSuccessMail(Server.MapPath(url), name, mail, domain);
                    mailB.CreateCookies("SUCCESS" + name, mail, "");
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
