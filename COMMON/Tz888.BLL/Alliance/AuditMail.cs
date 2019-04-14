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
        //���ͨ���ʼ�ģ��
        public string GetEmailPassTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailPassTmp"];
            return url;
        }
        //���δͨ���ʼ�ģ��
        public string GetEmailNoPassTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["EmailNoPassTmp"];
            return url;
        }    //���淢�����ͨ��������ϵ��ʼ�ģ��
        public string GetReleaseOKTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["ReleaseOKTmp"];
            return url;
        }
        //���淢�����ͨ�������ŵ��ʼ�ģ��
        public string GetReleasePassTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["ReleasePassTmp"];
            return url;
        }
        //���淢�����δͨ�����ʼ�ģ��
        public string GetReleaseNoPassTmpPath()
        {
            string url = (string)ConfigurationManager.AppSettings["ReleaseNoPassTmp"];
            return url;
        }
 
        /// <summary>
        /// ͳ��ָ���û���ĳһ���͵��������Ŀ
        /// </summary>
        /// <param name="Type">ͳ������</param>
        /// <param name="loginName">�û���</param>
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

        #region ��ȡ��ҳ����
        /// <summary>
        /// ��ȡ��ҳ����
        /// </summary>
        /// <param name="url">��ַ</param>
        /// <param name="Encod">ҳ�����</param>
        /// <returns></returns>
        public string DownUrl(string url, string Encod)
        {
            WebClient wc = new WebClient();

            byte[] by = wc.DownloadData(url);

            return Encoding.GetEncoding(Encod).GetString(by);

        }
        #endregion

        #region �����ʼ�
        /// <summary>
        /// �����ʼ��ķ���
        /// </summary>
        /// <param name="Email">�ռ����ʼ���ַ</param>
        /// <param name="Title">�ʼ�����</param>
        /// <param name="body">�ʼ�����</param>
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
                wt(Email + "�����ͳɹ�" + DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                wt(Email + "������ʧ��.ԭ��" + ex.Message.ToString() + "," + DateTime.Now.ToString());
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

        //���淢�����ͨ�����ѷ���
        public void SendTypeMail(string AuditType, string LoginName, string TmpPath, string Earnings, string Title, string Email, string Reasons)
        {
            string EmailTmp = "";   //�ʼ�����ģ��  
            EmailTmp = DownUrl(TmpPath, "GB2312");
            string emailTitle = "";
            switch (AuditType)
            {
                case "3": emailTitle = "������ȡ���δͨ��"; break;
                case "1": emailTitle = "������ȡ���ͨ��,�ѷ���"; break;
                case "2": emailTitle = "������ȡ���ͨ��,������"; break;
            }
            EmailTmp = EmailTmp.Replace("#@NICKNAME#", LoginName);
            EmailTmp = EmailTmp.Replace("#@EARNINGS#", Earnings);
            EmailTmp = EmailTmp.Replace("#@NOPASSREASON#", Reasons);

            SendEmail(Email, emailTitle, EmailTmp);
        }

        public void SendPassMail(string LoginName, string Title, string TmpPath, string Email, string Type)
        {
            string EmailTmp = "";//�ʼ�����ģ��  

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

            SendEmail(Email, "����������Դ��ͨ�����!", EmailTmp);
        }

        public void SendNoPassEmail(string LoginName, string Title, string FeedBackNote, string TmpPath, string Email, string Type)
        { 

            string EmailTmp = "";//�ʼ�����ģ��  
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

            SendEmail(Email, "����������Դδͨ�����!", EmailTmp);
            
        }
    }
}