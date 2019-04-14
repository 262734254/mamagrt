using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Configuration;


namespace Tz888.BLL
{
    public class RegisterMail
    {
        //未通过审核模板
        public string GetEmailNoPassTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailUserNoPassTmp"];
            return url;
        }
        //通过审核模板
        public string GetEmailPassTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailUserPassTmp"];
            return url;
        }
        

        //发送提示邮件
        public void SendNoPassMail(string url, string username,string realname,string strContent, string mail)
        {
            Tz888.BLL.AutoSendMsg msg = new Tz888.BLL.AutoSendMsg();
            
            string content;
            content = msg.DownUrl(url, "GB2312");
            content = content.Replace("$NICKNAME$", realname);
            content = content.Replace("$LOGINNAME$", username); 
            content = content.Replace("$Content$", strContent);
            msg.SendEmail(mail, "资源联盟帐号审核未通过", content);
        }

        //发送成功信件
        public void SendPassMail(string url, string username,string realname,string mail)
        {
            Tz888.BLL.AutoSendMsg msg = new Tz888.BLL.AutoSendMsg();
            string content;
            content = msg.DownUrl(url, "GB2312");
            content = content.Replace("$LOGINNAME$", username);
            content = content.Replace("$NICKNAME$", realname); 
            msg.SendEmail(mail, "验证成功，欢迎加入资源联盟", content);

        } 

    
    }
}
