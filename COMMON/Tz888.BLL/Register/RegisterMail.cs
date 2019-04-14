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
        //ȷ���ż�ģ��
        public string GetMailTemplateUrl()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailConfirm"];
            return url;
        }
        //�ɹ��ż�ģ��
        public string GetMailSucessTemplateUrl()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailSuccess"];
            return url;
        }
        

        //����ȷ���ʼ�
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

            msg.SendEmail(mail, "�����֤��������TopFo����ɫ����", content);
        }

        //���ͳɹ��ż�
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
            msg.SendEmail(mail, "��֤�ɹ�����ӭ�����ظ����ͥ", content);

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

        //�һ�����ģ��
        public string GetMailResetTemplateUrl()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailReset"];
            return url;
        }
        //�һ��û���ģ��
        public string GetEmailSucceedTemplateUrl()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailSucceed"];
            return url;
        }


        //�������������ʼ�
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
            msg.SendEmail(mail, "����������ȷ����TopFo�˺Ű�ȫ", content);
        }

        //�����һ��û����ż�
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
            msg.SendEmail(mail, "�ɹ��һ��û�������ӭ��½TopFo", content);

        }
    }
}
