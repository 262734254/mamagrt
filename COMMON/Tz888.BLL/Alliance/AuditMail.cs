using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class AuditMail
    {
        private readonly IAuditMail dal = DataAccess.CreateIAuditMail(); 
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
        }    //收益发放审核通过发送完毕的邮件模板
        public string GetReleaseOKTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["ReleaseOKTmp"];
            return url;
        }
        //收益发放审核通过待发放的邮件模板
        public string GetReleasePassTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["ReleasePassTmp"];
            return url;
        }
        //收益发放审核未通过的邮件模板
        public string GetReleaseNoPassTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["ReleaseNoPassTmp"];
            return url;
        }
 
        /// <summary>
        /// 统计指定用户的某一类型的需求的数目
        /// </summary>
        /// <param name="Type">统计类型</param>
        /// <param name="loginName">用户名</param>
        /// <returns></returns> 
        public int GetCount(Tz888.BLL.Common.AuditStatus Type, string loginName, string infoType)
        {
            string strWhere = "";
            switch ((int)Type)
            {
                case 0:
                    strWhere = "UserName = '" + loginName + "' And AuditStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    break;
                case 1:
                    strWhere = "UserName = '" + loginName + "' And AuditStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 2:
                    strWhere = "UserName = '" + loginName + "'  And AuditStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    break;
                case 3:
                    strWhere = "UserName = '" + loginName + "' ";
                    break;
                default:
                    break;
            }
            return this.GetCount(infoType, strWhere);
        }

        public int GetCount(string InfoType, string strWhere)
        { 
            return dal.GetCount(InfoType, strWhere);
        }

        #region 获取网页内容
        /// <summary>
        /// 获取网页内容
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="Encod">页面编码</param>
        /// <returns></returns>
        public string DownUrl(string url, string Encod)
        {
            WebClient wc = new WebClient();

            byte[] by = wc.DownloadData(url);

            return Encoding.GetEncoding(Encod).GetString(by);

        }
        #endregion

        #region 发送邮件
        /// <summary>
        /// 发送邮件的方法
        /// </summary>
        /// <param name="Email">收件人邮件地址</param>
        /// <param name="Title">邮件标题</param>
        /// <param name="body">邮件内容</param>
        public void SendEmail(string Email, string Title, string body)
        {
            string smtpServer = System.Configuration.ConfigurationManager.AppSettings["SmtpServer2"];
            string senderName = System.Configuration.ConfigurationManager.AppSettings["SenderEmailName2"];
            string senderMail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail2"];
            string senderPWD = System.Configuration.ConfigurationManager.AppSettings["EmailPassword2"];
            if (Email == "")
                return;
            ////////////////////////////////////////////////////////////////////////
            try
            {
                MailMessage mailMSG = new MailMessage();
                mailMSG.From = new MailAddress(senderMail, senderName, System.Text.Encoding.Default);
                mailMSG.To.Add(Email);

                mailMSG.SubjectEncoding = System.Text.Encoding.Default;
                mailMSG.Subject = Title;
                mailMSG.BodyEncoding = System.Text.Encoding.Default;
                mailMSG.Body = body;
                mailMSG.IsBodyHtml = true;
                mailMSG.Priority = MailPriority.High;

                SmtpClient smtp = new SmtpClient(smtpServer);
                string mailname2 = senderMail.Substring(0, senderMail.IndexOf("@")).Trim();
                smtp.Credentials = new NetworkCredential(mailname2, senderPWD);
                smtp.Send(mailMSG);
                wt(Email + "：发送成功" + DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                wt(Email + "：发送失败.原因：" + ex.Message.ToString() + "," + DateTime.Now.ToString());
            }

        }
        #endregion

        public void wt(string str)
        {
            if (System.IO.File.Exists(@"E:\log.txt"))
            {
                try
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(@"E:\log.txt", true, System.Text.Encoding.GetEncoding("gb2312"));
                    sw.WriteLine(str);
                    sw.Flush();
                    sw.Close();
                }
                catch //(Exception ex)
                {

                }
            }
        }

        //收益发放审核通过并已发放
        public void SendTypeMail(string AuditType, string LoginName, string TmpPath, string Earnings, string Title, string Email, string Reasons)
        {
            string EmailTmp = "";   //邮件内容模版  
            EmailTmp = DownUrl(TmpPath, "GB2312");
            string emailTitle = "";
            switch (AuditType)
            {
                case "3": emailTitle = "收益提取审核未通过"; break;
                case "1": emailTitle = "收益提取审核通过,已发放"; break;
                case "2": emailTitle = "收益提取审核通过,待发放"; break;
            }
            EmailTmp = EmailTmp.Replace("#@NICKNAME#", LoginName);
            EmailTmp = EmailTmp.Replace("#@EARNINGS#", Earnings);
            EmailTmp = EmailTmp.Replace("#@NOPASSREASON#", Reasons);

            SendEmail(Email, emailTitle, EmailTmp);
        }

        public void SendPassMail(string LoginName, string Title, string TmpPath, string Email, string Type)
        {
            string EmailTmp = "";//邮件内容模版  

            int AuditCount = 0;
            int PassCount = 0;
            int NoPassCount = 0;
            int OverdueCount = 0;

            string AuditUrl = "http://zy.topfo.com" + @"/admin/zyManage_Audit.aspx";
            string PassUrl = "http://zy.topfo.com" + @"/admin/zyManage_Pass.aspx";
            string NoPassUrl = "http://zy.topfo.com" + @"/admin/zyManage_NoPass.aspx";
            string OverdueUrl = "http://zy.topfo.com" + @"/admin/zyManage_Overdue.aspx";

            string InfoUrl = "http://www.topfo.com" + @"/";// +HtmlFile;


            AuditCount = GetCount(Tz888.BLL.Common.AuditStatus.Auditing, LoginName, Type);
            PassCount = GetCount(Tz888.BLL.Common.AuditStatus.Pass, LoginName, Type);
            NoPassCount = GetCount(Tz888.BLL.Common.AuditStatus.NoPass, LoginName, Type);
            OverdueCount = GetCount(Tz888.BLL.Common.AuditStatus.Overdue, LoginName, Type);

            EmailTmp = DownUrl(TmpPath, "GB2312");

            EmailTmp = EmailTmp.Replace("#@Tmp_UserName#", LoginName);
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

            SendEmail(Email, "您发布的资源已通过审核!", EmailTmp);
        }

        public void SendNoPassEmail(string LoginName, string Title, string FeedBackNote, string TmpPath, string Email, string Type)
        { 

            string EmailTmp = "";//邮件内容模版  
            string Update = "";
            string Status = "";
 

            int AuditCount = 0;
            int PassCount = 0;
            int NoPassCount = 0;
            int OverdueCount = 0;

            string AuditUrl = "http://zy.topfo.com" + @"/admin/zyManage_Audit.aspx";
            string PassUrl = "http://zy.topfo.com" + @"/admin/zyManage_Pass.aspx";
            string NoPassUrl = "http://zy.topfo.com" + @"/admin/zyManage_NoPass.aspx";
            string OverdueUrl = "http://zy.topfo.com" + @"/admin/zyManage_Overdue.aspx";

            AuditCount = GetCount(Tz888.BLL.Common.AuditStatus.Auditing, LoginName, Type);
            PassCount = GetCount(Tz888.BLL.Common.AuditStatus.Pass, LoginName, Type);
            NoPassCount = GetCount(Tz888.BLL.Common.AuditStatus.NoPass, LoginName, Type);
            OverdueCount = GetCount(Tz888.BLL.Common.AuditStatus.Overdue, LoginName, Type);

            EmailTmp = DownUrl(TmpPath, "GB2312");

            EmailTmp = EmailTmp.Replace("#@Tmp_UserName#", LoginName);
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

            SendEmail(Email, "您发布的资源未通过审核!", EmailTmp);
            
        }
    }
}