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

        #region 资源定制通知---------------------------
        public void MacthingInfo()
        {
            Tz888.BLL.SendNotice notice = new SendNotice();
            DataTable dt1 = dalSend.GetMachInfoList("");//所有订阅人列表
            for(int i=0;i<dt1.Rows.Count;i++)
            {
                string loginname =dt1.Rows[i]["LoginName"].ToString().Trim();
                DataTable dtGetTool = obj.GetList("UserParametersTab", "NoticeEmail,NoticeMobile", "parID", 1, 1, 0, 1, "loginname='" + loginname + "'");
                string email = dtGetTool.Rows[0]["NoticeEmail"].ToString().Trim();
                string mobile = dtGetTool.Rows[0]["NoticeMobile"].ToString().Trim();
                DataTable dt2 = dalSend.GetMachInfoList(loginname);//订阅ID
                string TempStr = DownUrl("http://member.topfo.com/helper/sendMachinfo.aspx?ID=" + dt2.Rows[0]["ID"].ToString(), "GB2312");
                string title = GetCustomType("0");
                string siteContent = "您有新的订阅信息,请进“拓富助手-我的订阅”中查看!";
                notice.InfoMatching(loginname, siteContent, title + "信息订阅" + DateTime.Now.ToShortDateString(), siteContent, TempStr);
            }
 
        }
        #endregion

        #region 资源有效期即将到期通知---------------
        public void InfoVali()
        {

        }
        #endregion

        #region 拓富通会员即将到期通知---------------
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
                    string mobileContet = "您的拓富通会员资格即将在" + expireddate + "过期,为了保证您的特权,请及时续费!www.topfo.com[此条信息免费]";
                    objSend.Send(loginname, mobileContet,"您的拓富通即将到期",mobileContet,mobileContet,"VipExpiredNotice");
                }
            }
        }
        #endregion

        #region 推广发送---------------------
        public void SendSubscribe()
        {
            
            //推广接收人列表
            DataTable dt1 = dalSend.GetReceivedList("");
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string loginname = dt1.Rows[i]["ReceiveLoginName"].ToString().Trim();
                    //接收方式
                    DataTable dtGetType = obj.GetList("SubscribegetsetTab", "ReveiveType", "ID", 1, 1, 0, 1, "loginname='" + loginname + "'");
                    string ReveiveType = dtGetType.Rows[0]["ReveiveType"].ToString().Trim();
                    //接收手机和邮件
                    DataTable dtGetTool = obj.GetList("UserParametersTab", "NoticeEmail,NoticeMobile", "parID", 1, 1, 0, 1, "loginname='" + loginname + "'");
                    string email = dtGetTool.Rows[0]["NoticeEmail"].ToString().Trim();
                    string mobile = dtGetTool.Rows[0]["NoticeMobile"].ToString().Trim();
                    //接收内容
                    string fldName = "ID,InfoID,Title,HtmlFile,InfoTypeID,ReceiveLoginName,PublishT";
                    string strWhere = "ReceiveLoginName='" + loginname + "' and isSend<>1";
                    DataTable dt2 = obj.GetList("SubscribeRecViw", fldName, "InfoID", 2, 1, 0, 1, strWhere);
                    if (dt2.Rows.Count > 0)//信息列表
                    {
                        #region 手机和站内短信 文本中的标题 只取两条
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

                        #region 发送站内短信
                        if (getType(ReveiveType, "1"))
                        {
                            string siteMsgStr = "尊敬的" + GetNickName(dt2.Rows[0]["ReceiveLoginName"].ToString().Trim()) + "："
                            + "今天又有" + dt2.Rows.Count.ToString() + "条资源推荐给您："
                            + strTitle
                            + "…更多内容请到拓富中心“定向推广”处查阅。";
                            bool b = SendSiteMsg(loginname, "[好消息]" + DateTime.Now.ToShortDateString() + "优秀资源推荐", siteMsgStr);
                        }
                        #endregion

                        #region 发送手机短信
                        if (getType(ReveiveType, "3"))
                        {
                            Tz888.BLL.SendNotice objSend = new SendNotice();
                            if (mobile != "")
                            {
                               bool ab = objSend.SendMobileMsg(mobile, "优秀资源推荐," + strTitle + "更多资源请登录拓富中心查询(本条信息免费)");
                            }
                        }

                        #endregion

                        #region 发送邮件
                        if (getType(ReveiveType, "2"))
                        {
                            string url = System.Configuration.ConfigurationManager.AppSettings["EmailSubscribe"];
                            string TempStr = DownUrl(url, "GB2312");
                            string tempHtml = "";
                            for (int m = 0; m < dt2.Rows.Count; m++)
                            {
                                tempHtml += "<tr align='left'>"
                                          +"<td align='left' height='22px'>" + (m+1).ToString() + "、<span class='orange2'>" + dt2.Rows[m]["Title"].ToString() + "</span></td>"
                                          + "</tr>"
                                          +"<tr>"
                                          + "<td align='left' style='font-size:12px'>" + GetAbout(dt2.Rows[m]["InfoID"].ToString().Trim(), dt2.Rows[m]["InfoTypeID"].ToString().Trim()) + "</td>"
                                          + "</tr>"
                                          +"<tr>"
                                          + "<td align='left' height='22px'>资源链接<a class='ablue01 f12' target='_blank' href='http://www.topfo.com/" + dt2.Rows[m]["HtmlFile"].ToString() + "'>http://www.topfo.com/" + dt2.Rows[m]["HtmlFile"].ToString() + "</a></td>"
                                          + "</tr>";

                            }
                            TempStr = TempStr.Replace("#InfoCount#", dt2.Rows.Count.ToString());
                            TempStr = TempStr.Replace("#SendHtml#", tempHtml);
                            TempStr = TempStr.Replace("#NickName#", GetNickName(dt2.Rows[0]["ReceiveLoginName"].ToString().Trim()));
                            SendEmail(email, "中国招商投资网为您推荐", TempStr);
                        }
                        #endregion

                        #region 修改发送状态
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
            string strNull="&nbsp;&nbsp;&nbsp;&nbsp;详细介绍请登录<a target='_blank' href='http://www.topfo.com'>http://www.topfo.com</a>查看";
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
                return "招商";
            }
            else if (Vali.ToString() == "1")
            {
                return "投资";
            }
            else if (Vali.ToString() == "2")
            {
                return "融资";
            }
            else if (Vali.ToString() == "3")
            {
                return "创业";
            }
            else if (Vali.ToString() == "4")
            {
                return "商机";
            }
            else if (Vali.ToString() == "5")
            {
                return "资讯";
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
        /// 时间差
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
                return "投资资源";
            if (str.ToString().Trim() == "Project")
                return "融资资源";
            if (str.ToString().Trim() == "Merchant")
                return "招商资源";
            else
                return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tool">接收工具 1 是否站内短信 2 是否邮件 3是否手机 </param>
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

        #region 发送站内短信
        /// <summary>
        /// 发送站内短信
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

        #region  发送邮件
        //多方发送推荐注册邮件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendLoginName">发件人LoginName</param>
        /// <param name="sender">发送人email</param>
        /// <param name="emalList">收件人列表，以“，”号隔开</param>
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
            mailMSG.Subject = "您的好友" + sender + "邀请您加入拓富大家庭";
            mailMSG.BodyEncoding = System.Text.Encoding.Default;
            mailMSG.Body = content;
            mailMSG.IsBodyHtml = false;
            mailMSG.Priority = MailPriority.High;

            SmtpClient smtp = new SmtpClient(smtpServer);
            smtp.Send(mailMSG);

        } 
        #endregion
        /// <summary>
        /// 多方发送邮件的方法
        /// </summary>
        /// <param name="Email">收件人邮件地址</param>
        /// <param name="Title">邮件标题</param>
        /// <param name="body">邮件内容</param>
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
                   wt(Email + "：发送成功" + DateTime.Now.ToString());
                }
               

               
                
 
            }
            catch(Exception ex)
            {
                wt(Email + "：发送失败.原因：" + ex.Message.ToString() + ","+DateTime.Now.ToString());
            }



        }
       
        /// <summary>
        /// 发送邮件的方法
        /// </summary>
        /// <param name="Email">收件人邮件地址</param>
        /// <param name="Title">邮件标题</param>
        /// <param name="body">邮件内容</param>
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

               
                
                wt(Email + "：发送成功"+DateTime.Now.ToString());
            }
            catch(Exception ex)
            {
                wt(Email + "：发送失败.原因：" + ex.Message.ToString() + ","+DateTime.Now.ToString());
            }

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

    }
}
