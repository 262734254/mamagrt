using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Tz888.BLL
{
    public class AutoSendMsg
    {
        private readonly IAutoSendMsg dal = DataAccess.CreateAutoSendMsg();
        private readonly IConn obj = DataAccess.CreateIConn();
        Tz888.BLL.SubscribeSet dalSend = new Tz888.BLL.SubscribeSet();

        #region ��Դ����֪ͨ---------------------------
        public void MacthingInfo()
        {
            Tz888.BLL.SendNotice notice = new SendNotice();
            DataTable dt1 = dalSend.GetMachInfoList("");//���ж������б�
            for(int i=0;i<dt1.Rows.Count;i++)
            {
                string loginname =dt1.Rows[i]["LoginName"].ToString().Trim();
                DataTable dtGetTool = obj.GetList("UserParametersTab", "NoticeEmail,NoticeMobile", "parID", 1, 1, 0, 1, "loginname='" + loginname + "'");
                string email = dtGetTool.Rows[0]["NoticeEmail"].ToString().Trim();
                string mobile = dtGetTool.Rows[0]["NoticeMobile"].ToString().Trim();
                DataTable dt2 = dalSend.GetMachInfoList(loginname);//����ID
                string TempStr = DownUrl("http://member.topfo.com/helper/sendMachinfo.aspx?ID=" + dt2.Rows[0]["ID"].ToString(), "GB2312");
                string title = GetCustomType("0");
                string siteContent = "�����µĶ�����Ϣ,������ظ�����-�ҵĶ��ġ��в鿴!";
                notice.InfoMatching(loginname, siteContent, title + "��Ϣ����" + DateTime.Now.ToShortDateString(), siteContent, TempStr);
            }
 
        }
        #endregion

        #region ��Դ��Ч�ڼ�������֪ͨ---------------
        public void InfoVali()
        {

        }
        #endregion

        #region �ظ�ͨ��Ա��������֪ͨ---------------
        public void VipVali()
        {
            SubscribeSet dalSend = new SubscribeSet();
            DataTable dt=dalSend.GetMemberExpiredList();
            Tz888.BLL.SendNotice objSend = new SendNotice();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string loginname = dt.Rows[i]["LoginName"].ToString();
                    string expireddate = Convert.ToDateTime(dt.Rows[i]["VipInvalidDate"].ToString()).ToShortDateString();
                    string email = dt.Rows[i]["NoticeEmail"].ToString().Trim();
                    string mobile = dt.Rows[i]["NoticeMobile"].ToString().Trim();
                    string mobileContet = "�����ظ�ͨ��Ա�ʸ񼴽���" + expireddate + "����,Ϊ�˱�֤������Ȩ,�뼰ʱ����!www.topfo.com[������Ϣ���]";
                    objSend.Send(loginname, mobileContet,"�����ظ�ͨ��������",mobileContet,mobileContet,"VipExpiredNotice");
                }
            }
        }
        #endregion

        #region �ƹ㷢��---------------------
        public void SendSubscribe()
        {
            
            //�ƹ�������б�
            DataTable dt1 = dalSend.GetReceivedList("");
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string loginname = dt1.Rows[i]["ReceiveLoginName"].ToString().Trim();
                    //���շ�ʽ
                    DataTable dtGetType = obj.GetList("SubscribegetsetTab", "ReveiveType", "ID", 1, 1, 0, 1, "loginname='" + loginname + "'");
                    string ReveiveType = dtGetType.Rows[0]["ReveiveType"].ToString().Trim();
                    //�����ֻ����ʼ�
                    DataTable dtGetTool = obj.GetList("UserParametersTab", "NoticeEmail,NoticeMobile", "parID", 1, 1, 0, 1, "loginname='" + loginname + "'");
                    string email = dtGetTool.Rows[0]["NoticeEmail"].ToString().Trim();
                    string mobile = dtGetTool.Rows[0]["NoticeMobile"].ToString().Trim();
                    //��������
                    string fldName = "ID,InfoID,Title,HtmlFile,InfoTypeID,ReceiveLoginName,PublishT";
                    string strWhere = "ReceiveLoginName='" + loginname + "' and isSend<>1";
                    DataTable dt2 = obj.GetList("SubscribeRecViw", fldName, "InfoID", 2, 1, 0, 1, strWhere);
                    if (dt2.Rows.Count > 0)//��Ϣ�б�
                    {
                        #region �ֻ���վ�ڶ��� �ı��еı��� ֻȡ����
                        string strTitle = "";
                        if (dt2.Rows.Count>1)
                        {
                            for (int k = 0; k < dt2.Rows.Count; k++)
                            {
                                strTitle += "["+dt2.Rows[k]["Title"].ToString() + "],";
                                if (k == 1)
                                    break;
                            }
                        }
                        else
                        {
                            strTitle = "["+dt2.Rows[0]["Title"].ToString() + "],";
                        }
                        #endregion

                        #region ����վ�ڶ���
                        if (getType(ReveiveType, "1"))
                        {
                            string siteMsgStr = "�𾴵�" + GetNickName(dt2.Rows[0]["ReceiveLoginName"].ToString().Trim()) + "��"
                            + "��������" + dt2.Rows.Count.ToString() + "����Դ�Ƽ�������"
                            + strTitle
                            + "�����������뵽�ظ����ġ������ƹ㡱�����ġ�";
                            bool b = SendSiteMsg(loginname, "[����Ϣ]" + DateTime.Now.ToShortDateString() + "������Դ�Ƽ�", siteMsgStr);
                        }
                        #endregion

                        #region �����ֻ�����
                        if (getType(ReveiveType, "3"))
                        {
                            Tz888.BLL.SendNotice objSend = new SendNotice();
                            if (mobile != "")
                            {
                               bool ab = objSend.SendMobileMsg(mobile, "������Դ�Ƽ�," + strTitle + "������Դ���¼�ظ����Ĳ�ѯ(������Ϣ���)");
                            }
                        }

                        #endregion

                        #region �����ʼ�
                        if (getType(ReveiveType, "2"))
                        {
                            string url = System.Configuration.ConfigurationManager.AppSettings["EmailSubscribe"];
                            string TempStr = DownUrl(url, "GB2312");
                            string tempHtml = "";
                            for (int m = 0; m < dt2.Rows.Count; m++)
                            {
                                tempHtml += "<tr align='left'>"
                                          +"<td align='left' height='22px'>" + (m+1).ToString() + "��<span class='orange2'>" + dt2.Rows[m]["Title"].ToString() + "</span></td>"
                                          + "</tr>"
                                          +"<tr>"
                                          + "<td align='left' style='font-size:12px'>" + GetAbout(dt2.Rows[m]["InfoID"].ToString().Trim(), dt2.Rows[m]["InfoTypeID"].ToString().Trim()) + "</td>"
                                          + "</tr>"
                                          +"<tr>"
                                          + "<td align='left' height='22px'>��Դ����<a class='ablue01 f12' target='_blank' href='http://www.topfo.com/" + dt2.Rows[m]["HtmlFile"].ToString() + "'>http://www.topfo.com/" + dt2.Rows[m]["HtmlFile"].ToString() + "</a></td>"
                                          + "</tr>";

                            }
                            TempStr = TempStr.Replace("#InfoCount#", dt2.Rows.Count.ToString());
                            TempStr = TempStr.Replace("#SendHtml#", tempHtml);
                            TempStr = TempStr.Replace("#NickName#", GetNickName(dt2.Rows[0]["ReceiveLoginName"].ToString().Trim()));
                            SendEmail(email, "�й�����Ͷ����Ϊ���Ƽ�", TempStr);
                        }
                        #endregion

                        #region �޸ķ���״̬
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            bool issend = dalSend.isSend(loginname);
                        }
                        #endregion
                    }
                }
            }
        }
        #region

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
                catch (Exception ex)
                {

                }
            }
        }
        public string GetAbout(string InfoID, string TypeID)
        {
            DataTable dt = new DataTable();
            string strNull="&nbsp;&nbsp;&nbsp;&nbsp;��ϸ�������¼<a target='_blank' href='http://www.topfo.com'>http://www.topfo.com</a>�鿴";
            if (TypeID == "Capital")
            {
                dt = obj.GetList("CapitalInfoTab", "ComAbout", "Infoid", 1, 1, 0, 1, "InfoID=" + Convert.ToInt64(InfoID));
                if(dt.Rows.Count>0)
                    return "&nbsp;&nbsp;&nbsp;&nbsp;" + GetStr(dt.Rows[0]["ComAbout"].ToString());
                else 
                    return strNull;

            }
            if (TypeID == "Project")
            {
                dt = obj.GetList("ProjectInfoTab", "ComAbout", "Infoid", 1, 1, 0, 1, "InfoID=" + Convert.ToInt64(InfoID));
               if(dt.Rows.Count>0)
                    return "&nbsp;&nbsp;&nbsp;&nbsp;" + GetStr(dt.Rows[0]["ComAbout"].ToString());
                else 
                    return strNull;
            }
            if (TypeID == "Merchant")
            {
                dt = obj.GetList("MerchantInfoTab", "ZoneAbout", "Infoid", 1, 1, 0, 1, "InfoID=" + Convert.ToInt64(InfoID));
                if(dt.Rows.Count>0)
                     return "&nbsp;&nbsp;&nbsp;&nbsp;" + GetStr(dt.Rows[0]["ZoneAbout"].ToString());
                else 
                    return strNull;
            }
            else
            {
                return strNull;
            }
        }
        public string GetCustomType(object Vali)
        {
            if (Vali.ToString() == "0")
            {
                return "����";
            }
            else if (Vali.ToString() == "1")
            {
                return "Ͷ��";
            }
            else if (Vali.ToString() == "2")
            {
                return "����";
            }
            else if (Vali.ToString() == "3")
            {
                return "��ҵ";
            }
            else if (Vali.ToString() == "4")
            {
                return "�̻�";
            }
            else if (Vali.ToString() == "5")
            {
                return "��Ѷ";
            }
            else
            {
                return "";
            }
        }
        public string GetStr(string str)
        {
            if (str.Length > 200)
            {
                return str.Substring(0, 200).Trim();
            }
            else
            {
                return str.Trim();
            }
        }
        public string GetNickName(string loginname)
        {
            DataTable dt = obj.GetList("LoginInfoTab", "NickName", "LoginID", 1, 1, 0, 1, "LoginName='" + loginname + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["NickName"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// ʱ���
        /// </summary>
        /// <param name="adddate"></param>
        /// <returns></returns>
        public string GetDiff(string adddate)
        {
            DateTime date1 = new DateTime(Convert.ToDateTime(adddate).Year, Convert.ToDateTime(adddate).Month, Convert.ToDateTime(adddate).Day);
            DateTime date2 = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day);
            System.TimeSpan diff = date1 - date2;
            return diff.ToString();
        }
        public string GetInfoTypeName(string str)
        {
            if (str.ToString().Trim() == "Capital")
                return "Ͷ����Դ";
            if (str.ToString().Trim() == "Project")
                return "������Դ";
            if (str.ToString().Trim() == "Merchant")
                return "������Դ";
            else
                return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tool">���չ��� 1 �Ƿ�վ�ڶ��� 2 �Ƿ��ʼ� 3�Ƿ��ֻ� </param>
        /// <returns></returns>
        public bool getType(string type, string tool)
        {
            if (type != "")
            {
                bool b = type.Contains(tool);
                return b;
            }
            else
                return false;
        }
        #endregion
        #endregion

        #region ����վ�ڶ���
        /// <summary>
        /// ����վ�ڶ���
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="Title"></param>
        /// <param name="Body"></param>
        /// <returns></returns>
        public bool SendSiteMsg(string LoginName, string Title, string Body)
        {
            bool result;
            Tz888.Model.InnerInfo model = new Tz888.Model.InnerInfo();
            Tz888.BLL.InnerInfo infoBLL = new Tz888.BLL.InnerInfo();
            model.SendName = "tz888admin";
            model.Topic = Title;
            model.ReceiveName = LoginName;
            model.Context = Body;
            model.InfoTime = DateTime.Now;
            model.ChangeBy = "tz888admin";
            
            result = infoBLL.SendInfoBLL(model, false);
            return result;
        }
        #endregion

        #region  �����ʼ�
        //�෽�����Ƽ�ע���ʼ�
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendLoginName">������LoginName</param>
        /// <param name="sender">������email</param>
        /// <param name="emalList">�ռ����б��ԡ������Ÿ���</param>
        /// <param name="content"></param>
        public void SendMail2MenLst(string sendLoginName, string sender, string emalList, string content)
        {
            string smtpServer = System.Configuration.ConfigurationManager.AppSettings["SmtpServer2"];
            string senderName = System.Configuration.ConfigurationManager.AppSettings["SenderEmailName2"];
            string senderMail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail2"];
            string senderPWD = System.Configuration.ConfigurationManager.AppSettings["EmailPassword2"];
            string[] receiveLST = emalList.Split(',');
            ////////////////////////////////////////////////////////////////////////
            Tz888.BLL.Register.MemberInfoBLL memberBLL = new Tz888.BLL.Register.MemberInfoBLL();
            memberBLL.AddIntegral(sendLoginName, 100);
            MailMessage mailMSG = new MailMessage();
            mailMSG.From = new MailAddress(senderMail, senderName, System.Text.Encoding.Default);

            for (int i = 0; i < receiveLST.Length; i++)
            {
                mailMSG.To.Add(receiveLST[i].ToString());
            }

            mailMSG.SubjectEncoding = System.Text.Encoding.Default;
            mailMSG.Subject = "���ĺ���" + sender + "�����������ظ����ͥ";
            mailMSG.BodyEncoding = System.Text.Encoding.Default;
            mailMSG.Body = content;
            mailMSG.IsBodyHtml = false;
            mailMSG.Priority = MailPriority.High;

            SmtpClient smtp = new SmtpClient(smtpServer);
            smtp.Send(mailMSG);

        } 
        #endregion
        /// <summary>
        /// �෽�����ʼ��ķ���
        /// </summary>
        /// <param name="Email">�ռ����ʼ���ַ</param>
        /// <param name="Title">�ʼ�����</param>
        /// <param name="body">�ʼ�����</param>
        public void SendEmailAll(string Email, string Title, string body)
        {
           
            string smtpServer = System.Configuration.ConfigurationManager.AppSettings["SmtpServer2"];
            string senderName =System.Configuration.ConfigurationManager.AppSettings["SenderEmailName2"];
            string senderMail =System.Configuration.ConfigurationManager.AppSettings["SenderEmail2"];
            string senderPWD = System.Configuration.ConfigurationManager.AppSettings["EmailPassword2"];
            if (Email == "")
                return;
            ////////////////////////////////////////////////////////////////////////
            try
            {
                 string[] receiveLST = Email.Split(';');
                MailMessage mailMSG = new MailMessage();
                mailMSG.From = new MailAddress(senderMail, senderName, System.Text.Encoding.Default);
                for (int i = 0; i < receiveLST.Length; i++)
               {
                   mailMSG.To.Add(receiveLST[i].ToString());
                   mailMSG.SubjectEncoding = System.Text.Encoding.Default;
                   mailMSG.Subject = Title;
                   mailMSG.BodyEncoding = System.Text.Encoding.Default;
                   mailMSG.Body = body;
                   mailMSG.IsBodyHtml = true;
                   mailMSG.Priority = MailPriority.High;
                   mailMSG.Bcc.Add(receiveLST[i]);
                   SmtpClient smtp = new SmtpClient(smtpServer);
                   string mailname2 = senderMail;// senderMail.Substring(0, senderMail.IndexOf("@")).Trim();
                   smtp.UseDefaultCredentials = false;
                    
                   smtp.Credentials = new NetworkCredential(mailname2, senderPWD);
                   smtp.Port = 25;
                   
                   smtp.Send(mailMSG);
                   wt(Email + "�����ͳɹ�" + DateTime.Now.ToString());
                }
               

               
                
 
            }
            catch(Exception ex)
            {
                wt(Email + "������ʧ��.ԭ��" + ex.Message.ToString() + ","+DateTime.Now.ToString());
            }



        }
       
        /// <summary>
        /// �����ʼ��ķ���
        /// </summary>
        /// <param name="Email">�ռ����ʼ���ַ</param>
        /// <param name="Title">�ʼ�����</param>
        /// <param name="body">�ʼ�����</param>
        public void SendEmail(string Email, string Title, string body)
        {
            string smtpServer = System.Configuration.ConfigurationManager.AppSettings["SmtpServer2"];
            string senderName =System.Configuration.ConfigurationManager.AppSettings["SenderEmailName2"];
            string senderMail =System.Configuration.ConfigurationManager.AppSettings["SenderEmail2"];
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
                string mailname2 = senderMail;// senderMail.Substring(0, senderMail.IndexOf("@")).Trim();
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(mailname2, senderPWD);
                smtp.Port = 25;
                smtp.Send(mailMSG);

               
                
                wt(Email + "�����ͳɹ�"+DateTime.Now.ToString());
            }
            catch(Exception ex)
            {
                wt(Email + "������ʧ��.ԭ��" + ex.Message.ToString() + ","+DateTime.Now.ToString());
            }

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

    }
}
