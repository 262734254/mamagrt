using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
namespace Tz888.BLL.Info
{
    public class InfoAuditMailBLL
    {
      
        //审核通过邮件模板
        public string GetEmailPassTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailPassTmp"];
            return url;
        }
        //审核未通过邮件模板
        public string GetEmailNoPassTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailNoPassTmp"];
            return url;
        }

        public void CreateCookies(string cookieName, string value, string domain)
        {
            System.Web.HttpCookie cookie = new System.Web.HttpCookie(cookieName);
            cookie.Domain = domain;
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddMinutes(5);

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

        public void SendPassMail(string LoginName,string Title,string HtmlFile,string TmpPath)
        {
            string EmailTmp = "";//邮件内容模版
            string NickName = "";//会员昵称
            string Email = "";

            int AuditCount = 0;
            int PassCount = 0;
            int NoPassCount = 0;
            int OverdueCount = 0;

            string AuditUrl = "http://member.topfo.com" + @"/Manage/ResourceManage_Audit.aspx";
            string PassUrl = "http://member.topfo.com" + @"/Manage/ResourceManage_Pass.aspx";
            string NoPassUrl = "http://member.topfo.com" + @"/Manage/ResourceManage_NoPass.aspx";
            string OverdueUrl = "http://member.topfo.com" + @"/Manage/ResourceManage_Overdue.aspx";

            string InfoUrl = "http://www.topfo.com" + @"/" + HtmlFile;

            Tz888.BLL.Register.MemberInfoBLL member = new Tz888.BLL.Register.MemberInfoBLL();
            Tz888.BLL.AutoSendMsg msg = new Tz888.BLL.AutoSendMsg();
            Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();

            AuditCount = bll.GetCount(Tz888.BLL.Common.AuditStatus.Auditing, LoginName, "0");
            PassCount = bll.GetCount(Tz888.BLL.Common.AuditStatus.Pass, LoginName, "0");
            NoPassCount = bll.GetCount(Tz888.BLL.Common.AuditStatus.NoPass, LoginName, "0");
            OverdueCount = bll.GetCount(Tz888.BLL.Common.AuditStatus.Overdue,LoginName,"0");

            NickName = member.getNickName(LoginName);
            Email = member.GetEmail(LoginName);
            EmailTmp = msg.DownUrl(TmpPath, "GB2312");

            EmailTmp = EmailTmp.Replace("#@Tmp_UserName#", NickName);
            EmailTmp = EmailTmp.Replace("#@Tmp_Title#", Title);
            EmailTmp = EmailTmp.Replace("#@Tmp_HtmlFileUrl#", InfoUrl);

            EmailTmp = EmailTmp.Replace("#@Tmp_AuditUrl#", AuditUrl);
            EmailTmp = EmailTmp.Replace("#@Tmp_PassUrl#", PassUrl);
            EmailTmp = EmailTmp.Replace("#@Tmp_NoPassUrl#", NoPassUrl);
            EmailTmp = EmailTmp.Replace("#@Tmp_OverdueUrl#", OverdueUrl);

            EmailTmp = EmailTmp.Replace("#@Tmp_AuditCount#", AuditCount.ToString());
            EmailTmp = EmailTmp.Replace("#@Tmp_PassCount#", PassCount.ToString());
            EmailTmp = EmailTmp.Replace("#@Tmp_NoPassCount#", NoPassCount.ToString());
            EmailTmp = EmailTmp.Replace("#@Tmp_OverdueCount#", OverdueCount.ToString());

            msg.SendEmail(Email, "您发布的资源已通过审核!", EmailTmp);
        }


        public void SendNoPassEmail(long InfoID, string LoginName, string Title, int FeedbackStatus, string FeedBackNote, string InfoType, string TmpPath)
        {
            string UpdateModel = "<div class=\"dcxg\"><a class=\"ablue03\" href=\"{0}\" target=\"_blank\">点此进行修改&gt;&gt;</a></div>";

            string EmailTmp = "";//邮件内容模版
            string NickName = "";//会员昵称
            string Email = "";
            string Update = "";
            string Status = "";

            string InfoUrl = "";

            int AuditCount = 0;
            int PassCount = 0;
            int NoPassCount = 0;
            int OverdueCount = 0;

            string AuditUrl = "http://member.topfo.com" + @"/Manage/ResourceManage_Audit.aspx";
            string PassUrl = "http://member.topfo.com" + @"/Manage/ResourceManage_Pass.aspx";
            string NoPassUrl = "http://member.topfo.com" + @"/Manage/ResourceManage_NoPass.aspx";
            string OverdueUrl = "http://member.topfo.com" + @"/Manage/ResourceManage_Overdue.aspx";

            Tz888.BLL.Register.MemberInfoBLL member = new Tz888.BLL.Register.MemberInfoBLL();
            Tz888.BLL.AutoSendMsg msg = new Tz888.BLL.AutoSendMsg();
            Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();

            AuditCount = bll.GetCount(Tz888.BLL.Common.AuditStatus.Auditing, LoginName, "0");
            PassCount = bll.GetCount(Tz888.BLL.Common.AuditStatus.Pass, LoginName, "0");
            NoPassCount = bll.GetCount(Tz888.BLL.Common.AuditStatus.NoPass, LoginName, "0");
            OverdueCount = bll.GetCount(Tz888.BLL.Common.AuditStatus.Overdue, LoginName, "0");

            NickName = member.getNickName(LoginName);
            Email = member.GetEmail(LoginName);
            EmailTmp = msg.DownUrl(TmpPath, "GB2312");


            if (FeedbackStatus == 0)
            {
                switch (InfoType.ToLower())
                {
                    case "capital":
                        InfoUrl = "http://member.topfo.com/Manage/ModifyCapital.aspx?id=" + InfoID.ToString() + "&type=" + InfoType;
                        Update = string.Format(UpdateModel, InfoUrl);
                        break;
                    case "merchant":
                        InfoUrl = "http://member.topfo.com/Manage/ModifyMerchant.aspx?id=" + InfoID.ToString() + "&type=" + InfoType;
                        Update = string.Format(UpdateModel, InfoUrl);
                        break;
                    case "project":
                        InfoUrl = "http://member.topfo.com/Manage/ModifyProject.aspx?id=" + InfoID.ToString() + "&type=" + InfoType;
                        Update = string.Format(UpdateModel, InfoUrl);
                        break;
                    default:
                        Update = "";
                        break;
                }
                Status = "可修改";
            }
            else
            {
                Update = "";
                Status = "即将删除";
            }

            EmailTmp = EmailTmp.Replace("#@Tmp_UserName#", NickName);
            EmailTmp = EmailTmp.Replace("#@Tmp_Title#", Title);

            EmailTmp = EmailTmp.Replace("#@Tmp_Status#", Status);
            EmailTmp = EmailTmp.Replace("#@Tmp_Remark#", FeedBackNote);
            EmailTmp = EmailTmp.Replace("#@Tmp_IsUpdate#", Update);

            EmailTmp = EmailTmp.Replace("#@Tmp_AuditUrl#", AuditUrl);
            EmailTmp = EmailTmp.Replace("#@Tmp_PassUrl#", PassUrl);
            EmailTmp = EmailTmp.Replace("#@Tmp_NoPassUrl#", NoPassUrl);
            EmailTmp = EmailTmp.Replace("#@Tmp_OverdueUrl#", OverdueUrl);

            EmailTmp = EmailTmp.Replace("#@Tmp_AuditCount#", AuditCount.ToString());
            EmailTmp = EmailTmp.Replace("#@Tmp_PassCount#", PassCount.ToString());
            EmailTmp = EmailTmp.Replace("#@Tmp_NoPassCount#", NoPassCount.ToString());
            EmailTmp = EmailTmp.Replace("#@Tmp_OverdueCount#", OverdueCount.ToString());

            msg.SendEmail(Email, "您发布的资源未通过审核!", EmailTmp);
        }
    }
}
