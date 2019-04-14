using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Configuration;


namespace Tz888.BLL.Register
{
    public class RegisterMail
    {
        //确认信件模板
        public string GetMailTemplateUrl()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailConfirm"];
            return url;
        }
        //成功信件模板
        public string GetMailSucessTemplateUrl()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailSuccess"];
            return url;
        }
        

        //发送确认邮件
        public void SendMail(string url, string name, string mail, string validurl, string absimgurl)
        {
            Tz888.BLL.AutoSendMsg msg = new Tz888.BLL.AutoSendMsg();
            Tz888.BLL.Register.MemberInfoBLL member = new MemberInfoBLL();

            string nickName = member.getNickName(name);
            string content;
            content = msg.DownUrl(url, "GB2312");
            content = content.Replace("$NICKNAME$", nickName);
            content = content.Replace("$LOGNAME$", name);
            content = content.Replace("$EMAIL$", mail);
            content = content.Replace("$CONFIRMURL$", validurl);
            content = content.Replace("../..", absimgurl);

            msg.SendEmail(mail, "完成验证即可享受TopFo的特色服务", content);
        }

        //发送成功信件
        public void SendSuccessMail(string url, string name, string mail, string absimgurl)
        {
            Tz888.BLL.Register.MemberInfoBLL member = new MemberInfoBLL();
            Tz888.BLL.Register.LoginInfoBLL log = new LoginInfoBLL();
            Tz888.BLL.AutoSendMsg msg = new Tz888.BLL.AutoSendMsg();

            string nickName = member.getNickName(name);
            string managerType = log.GetManagerType(name);
            string content;
            content = msg.DownUrl(url, "GB2312");
            content = content.Replace("$LOGINNAME$", name);
            content = content.Replace("$NICKNAME$", nickName);
            content = content.Replace("$MANAGERTYPE$", managerType);
            content = content.Replace("c" + managerType.Trim(), "");
            content = content.Replace("../..", absimgurl);
            content = content.Replace("$LOGINURL$", absimgurl);
            msg.SendEmail(mail, "验证成功，欢迎加入拓富大家庭", content);

        }

        public void CreateCookies(string cookieName, string value, string domain)
        {
            System.Web.HttpCookie cookie = new System.Web.HttpCookie(cookieName);
            cookie.Domain = domain;
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddDays(7);

            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public string GetCookies(string cookieName)
        {
            try
            {
                System.Web.HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[cookieName];

                return cookie.Value;
            }
            catch (NullReferenceException exp)
            {
                return "";
            }
        }

        //找回密码模板
        public string GetMailResetTemplateUrl()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailReset"];
            return url;
        }
        //找回用户名模板
        public string GetEmailSucceedTemplateUrl()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailSucceed"];
            return url;
        }


        //发送重设密码邮件
        public void SendResetMail(string url, string name,string pwd, string mail,string validurl, string absimgurl)
        {
            Tz888.BLL.AutoSendMsg msg = new Tz888.BLL.AutoSendMsg();
            Tz888.BLL.Register.MemberInfoBLL member = new MemberInfoBLL();
 
            string content;
            content = msg.DownUrl(url, "GB2312");
            content = content.Replace("$LOGINNAME$", name);
            content = content.Replace("$PassWord$", pwd);
            content = content.Replace("../..", absimgurl);
            content = content.Replace("$CONFIRMURL$", validurl);
            msg.SendEmail(mail, "重设密码以确保您TopFo账号安全", content);
        }

        //发送找回用户名信件
        public void SendSucceedMail(string url, string name, string mail, string absimgurl)
        {
            Tz888.BLL.Register.MemberInfoBLL member = new MemberInfoBLL();
            Tz888.BLL.Register.LoginInfoBLL log = new LoginInfoBLL();
            Tz888.BLL.AutoSendMsg msg = new Tz888.BLL.AutoSendMsg();
  
            string content;
            content = msg.DownUrl(url, "GB2312");
            content = content.Replace("$LOGINNAME$", name); 
            content = content.Replace("../..", absimgurl);
            content = content.Replace("$LOGINURL$", absimgurl);
            msg.SendEmail(mail, "成功找回用户名，欢迎登陆TopFo", content);

        }
    }
}
