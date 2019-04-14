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
using Tz888.Common.DEncrypt;

public partial class Register_Control_ResponseAjax : System.Web.UI.Page
{
    /// <summary>
    /// 检查用户名是否可用
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private void ValidateName(string name)
    {
        MemberInfoBLL memberBll = new MemberInfoBLL();
        int result = memberBll.ValideNameUseable(name);
        if (result > 0)
        {   //不可用

            Response.Write("1");
        }
        else
        {   //可用
            Response.Write("0");
        }

    }
    //------------
    private void ValidNickName(string name,string isreverse)
    {
        MemberInfoBLL memberBll = new MemberInfoBLL();
        int result = memberBll.ValidNikeName(name);
       
        //检查昵称是否可注册
       
        if (isreverse.Length <= 0)
        {
            if (result > 0)
            {   //不可用

                Response.Write("1");
            }
            else
            {   //可用
                Response.Write("0");
            }
        }//检查昵称是否存在

        else
        {

            if (result > 0)
            {   //存在
               
                Response.Write("0");
            }
            else
            {   //不存在

               
                Response.Write("1");
            }
        }
    }

    private void ValidNickName(string name)
    {
        MemberInfoBLL memberBll = new MemberInfoBLL();
        int result = memberBll.ValidNikeName(name);

        //检查昵称是否可注册

     

            if (result > 0)
            {   //不可用

                Response.Write("1");
            }
            else
            {   //可用
                Response.Write("0");
            }
      


   
    }
    //////////////////////////////////////////////////////////////////////////
   // 检查EMAIL是否可注册

    private void ValidEmail(string email)
    {
        MemberInfoBLL memberBll = new MemberInfoBLL();
        int result = memberBll.ValidEmail(email);
        if (result > 0)
        {   //不可用

             Response.Write("1");
        }
        else
        {   //可用
            Response.Write("0");
        }  
    }

    //------------
    private void ValidVerCode(string code)
    {
        if (Session["valationNo"] == null)
        {
            Response.Write("-1");   //超时
        }
        else
        {
            if (code.Trim() != "" && ((string)Session["valationNo"]).ToLower() == code.ToLower())
            { Response.Write(0); }
            else
            { Response.Write(1); }
        }
    }

    private void ChangeEmail(string name,string newEmail,string validUrl,string domain)
    {
        LoginInfoBLL loginBll = new LoginInfoBLL();

        #region  使用更新后的邮箱，替换注册账号邮箱激活地址
  
        string HEAD_URL = validUrl.Substring(0,validUrl.IndexOf("email="));
        string END_URL = validUrl.Substring(validUrl.IndexOf("logname="));
        string NEW_EMAIL = Tz888.Common.DEncrypt.DEncrypt.Encrypt(newEmail);
               NEW_EMAIL = Server.UrlEncode(NEW_EMAIL);
       
        validUrl = HEAD_URL + "email=" + NEW_EMAIL + "&" + END_URL; 

        #endregion

        loginBll.ChangeEmail(Tz888.Common.DEncrypt.DEncrypt.Decrypt(name), newEmail);
        ReSendValidMail( name, newEmail, validUrl, domain);

    }
    /// <summary>
    /// 发送邮件

    /// </summary>
    /// <param name="loginName"></param>
    /// <param name="email"></param>
    /// <param name="validUrl"></param>
    /// <param name="domain"></param>
    /// <param name="isResend">是否为重发</param>

    private void ReSendValidMail(string loginName,string email,string validUrl,string domain)
    {
        RegisterMail mail = new RegisterMail();
        
        loginName = Tz888.Common.DEncrypt.DEncrypt.Decrypt(loginName);
        string url = Server.MapPath("../"+mail.GetMailTemplateUrl()); //模板地址

       string isSend = mail.GetCookies(loginName);
       string isSuccess = mail.GetCookies("SUCCESS" + loginName);   //是否已经通过验证

       if ((isSend == "" || isSend == string.Empty) || (isSuccess == "" || isSuccess == string.Empty))
       {
           try
           {

               mail.SendMail(url, loginName, email, validUrl, domain);
           }
           catch (Exception exp)
           {
               return;
           }
           mail.CreateCookies(loginName, email, "");
       }
    }

    /// <summary>
    /// 检查首页　登记公司机构／创建网上展厅　的用户权限

    /// </summary>
    /// <param name="loginName">登陆名，取自Cookies</param>
    /// <returns>1 有权限　0　无权限　-1　未登陆</returns>
    private void CheckLoginUsr()
    {
        string result = "";
        try
        {

            string logName = Request.Cookies["topfo.com_CKData"].Value;
            if (logName != "" || logName != string.Empty)
            {

                LoginInfoBLL loginBll = new LoginInfoBLL();
                string memberType = loginBll.GetManagerType(logName);
             
                if (memberType.Trim() == "个人")
                { result = "var result = '0'"; }
                else
                { result = "var result = '1'"; }
            }
        }
        catch (NullReferenceException exp)
        {
            result = "var result = '-1'";
        }

        Response.Write(result);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Request.QueryString["name"];
        string type = Request.QueryString["type"];
        string newEmail = Request.QueryString["email"];
        string validUrl = Request.QueryString["validurl"];
        string domain = Request.QueryString["domain"];
        string isreverse = Request.QueryString["isre"];
        string NickName = Request.QueryString["NickName"];

        if (!string.IsNullOrEmpty(name))
        {

            switch (type)
            { 
                case "name":
                    ValidateName(name);
                    break;
                case "nick":
                    name = Server.UrlDecode(name);
                    ValidNickName(name,isreverse);
                    break;
                case "vercode":
                    ValidVerCode(name); 
                    break;
                case "chEmail":
                    ChangeEmail(name, newEmail, validUrl, domain);
                    break;
                case "resend":
                    ReSendValidMail(name, newEmail, validUrl, domain);
                    break;
                case "home":
                    CheckLoginUsr();
                    break;
                case "email":
                    ValidEmail(newEmail);
                    break;
                case "nickN":
                    ValidNickName(NickName);
                    break;
                default :
                    break;
            }
        }

    }
}
