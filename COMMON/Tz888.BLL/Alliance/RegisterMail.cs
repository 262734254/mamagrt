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
        //δͨ�����ģ��
        public string GetEmailNoPassTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailUserNoPassTmp"];
            return url;
        }
        //ͨ�����ģ��
        public string GetEmailPassTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailUserPassTmp"];
            return url;
        }
        

        //������ʾ�ʼ�
        public void SendNoPassMail(string url, string username,string realname,string strContent, string mail)
        {
            Tz888.BLL.AutoSendMsg msg = new Tz888.BLL.AutoSendMsg();
            
            string content;
            content = msg.DownUrl(url, "GB2312");
            content = content.Replace("$NICKNAME$", realname);
            content = content.Replace("$LOGINNAME$", username); 
            content = content.Replace("$Content$", strContent);
            msg.SendEmail(mail, "��Դ�����ʺ����δͨ��", content);
        }

        //���ͳɹ��ż�
        public void SendPassMail(string url, string username,string realname,string mail)
        {
            Tz888.BLL.AutoSendMsg msg = new Tz888.BLL.AutoSendMsg();
            string content;
            content = msg.DownUrl(url, "GB2312");
            content = content.Replace("$LOGINNAME$", username);
            content = content.Replace("$NICKNAME$", realname); 
            msg.SendEmail(mail, "��֤�ɹ�����ӭ������Դ����", content);

        } 

    
    }
}
