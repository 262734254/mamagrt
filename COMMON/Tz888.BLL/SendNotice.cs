using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using Tz888.IDAL;
//using System.Runtime.InteropServices;

namespace Tz888.BLL
{
    public class SendNotice
    {
        private static string SmsUser = "topfo";
        private static string SmsPass = "123456";

        private static readonly ISendNotice dal = Tz888.DALFactory.DataAccess.CreateSendNotice();
        private static readonly Tz888.IDAL.Info.IMainInfo Member = Tz888.DALFactory.DataAccess.CreateInfo_MainInfo();
        Conn dalConn = new Conn();

        //[DllImport("EUCPComm.dll", EntryPoint = "SendSMS")]  //即时发送
        //public static extern int SendSMS(string sn, string mn, string ct, string msg);

        /// <summary>
        /// 购买成功通知
        /// <param name="LoginName">接收人</param>
        /// <param name="MobileContent">手机短信内容</param>
        /// <param name="Title">标题(站内短信和邮件公用)</param>
        /// <param name="SiteContent">站内短信文本内容)</param>
        /// <param name="EmailContent">邮件文本内容</param>
        public int PayNotice(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "PayNotice");//StrikeNotice
        }
        /// <summary>
        /// 充值成功通知
        /// <param name="LoginName">接收人</param>
        /// <param name="MobileContent">手机短信内容</param>
        /// <param name="Title">标题(站内短信和邮件需要)</param>
        /// <param name="SiteContent">站内短信文本内容)</param>
        /// <param name="EmailContent">邮件文本内容</param>
        public int StrikeSucess(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "StrikeNotice");//StrikeNotice
        }
        /// <summary>
        /// 资源审核通知
        /// <param name="LoginName">接收人</param>
        /// <param name="MobileContent">手机短信内容</param>
        /// <param name="Title">标题(站内短信和邮件需要)</param>
        /// <param name="SiteContent">站内短信文本内容)</param>
        /// <param name="EmailContent">邮件文本内容</param>
        public int InfoCheck(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            //InfoCheckNotice
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "InfoCheckNotice");
        }
        /// <summary>
        ///订阅资源新到通知
        /// <param name="LoginName">接收人</param>
        /// <param name="MobileContent">手机短信内容</param>
        /// <param name="Title">标题(站内短信和邮件需要)</param>
        /// <param name="SiteContent">站内短信文本内容)</param>
        /// <param name="EmailContent">邮件文本内容</param>
        public int Subscribe(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            //SubscribeNotice
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "SubscribeNotice");
        }
        /// <summary>
        /// 资源留言与评论通知
        /// </summary>
        /// <param name="LoginName">接收人</param>
        /// <param name="MobileContent">手机短信内容</param>
        ///<param name="Title">邮件或站内短信标题</param>
        /// <param name="SiteContent">站内短信文本内容)</param>
        /// <param name="EmailContent">邮件文本内容</param>
        public int InfoComment(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            //InfoCommentNotice
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "InfoCommentNotice");
        }
        /// <summary>
        /// 好友添加通知
        /// </summary>
        /// <param name="LoginName">通知对象</param>
        /// <param name="MobileContent">手机短信</param>
        /// <param name="Title">邮件或站内短信标题</param>
        /// <param name="SiteContent">站内短信文本内容)</param>
        /// <param name="EmailContent">邮件文本内容</param>
        public int FriendAdd(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "FriendAddNotice");
        }
        /// <summary>
        /// 资源即将过期通知
        /// <param name="LoginName">接收人</param>
        /// <param name="MobileContent">手机短信内容</param>
        /// <param name="Title">标题(站内短信和邮件需要)</param>
        /// <param name="SiteContent">站内短信文本内容)</param>
        /// <param name="EmailContent">邮件文本内容</param>
        public int InfoExpired(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            //InfoExpiredNotice
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "InfoExpiredNotice");
        }
        /// <summary>
        /// 资源匹配通知
        /// <param name="LoginName">接收人</param>
        /// <param name="MobileContent">手机短信内容</param>
        /// <param name="Title">标题(站内短信和邮件需要)</param>
        /// <param name="SiteContent">站内短信文本内容)</param>
        /// <param name="EmailContent">邮件文本内容</param>
        public int InfoMatching(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            //InfoMatchingNotice
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "InfoMatchingNotice");
        }
        /// <summary>
        /// 回复通知
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="MobileContent"></param>
        /// <param name="Title"></param>
        /// <param name="SiteContent"></param>
        /// <param name="EmailContent"></param>
        public int Reback(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "RebackNotice");
        }
        /// <summary>
        /// 会员即将过期通知
        /// <param name="LoginName">接收人</param>
        /// <param name="MobileContent">手机短信内容</param>
        /// <param name="Title">标题(站内短信和邮件需要)</param>
        /// <param name="SiteContent">站内短信文本内容)</param>
        /// <param name="EmailContent">邮件文本内容</param>
        public int VipExpired(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            //VipExpiredNotice
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "VipExpiredNotice");
        }
        /// <summary>
        /// 开始发送各种通知
        /// </summary>
        /// <param name="LoginName">接收人</param>
        /// <param name="MobileContent">手机短信内容</param>
        /// <param name="Title">标题(站内短信和邮件需要)</param>
        /// <param name="SiteContent">站内短信文本内容)</param>
        /// <param name="EmailContent">邮件文本内容</param>
        /// <param name="SetNotice">通知设置项</param>
        public void Send(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent, string SetNotice)
        {
            string mobile = IsMobile(LoginName, SetNotice);
            string emali = IsEmail(LoginName, SetNotice);
            string site = IsSite(LoginName, SetNotice);
            if (mobile != "")
            {
                bool b = SendMobileMsg(mobile, MobileContent);


                if (b)//发送手机短信
                {

                    bool b1 = UpdateMobileCount(LoginName);
                }
            }
            if (emali != "")//发送邮件
            {
                SendEmailMsg(emali, Title + "[中国招商投资网http://www.topfo.com]", EmailContent);
            }
            if (site != "")//发送站内短信
            {
                SendSiteMsg(LoginName, Title, SiteContent);
            }
        }
        //===============================================================================
        /// <summary>
        /// 向手机短信库写数据
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="Content">内容</param>
        /// <returns></returns>
        public bool SendMobileMsg(string mobile, string Content)
        {
            return dal.SendMobileMsg(mobile, Content);
        }

        #region  返回此条数据ID
        /// <summary>
        /// 开始发送各种通知
        /// </summary>
        /// <param name="LoginName">接收人</param>
        /// <param name="MobileContent">手机短信内容</param>
        /// <param name="Title">标题(站内短信和邮件需要)</param>
        /// <param name="SiteContent">站内短信文本内容)</param>
        /// <param name="EmailContent">邮件文本内容</param>
        /// <param name="SetNotice">通知设置项</param>
        public int SendSms(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent, string SetNotice)
        {
            string mobile = IsMobile(LoginName, SetNotice);
            string emali = IsEmail(LoginName, SetNotice);
            string site = IsSite(LoginName, SetNotice);
            int IntLog = 0;//0 未执行成功    

            if (mobile != "")
            {
                int b = SendMobileSms(mobile, MobileContent);
                IntLog = 1;//1数据录入数据库  

                if (b > 0)//发送手机短信
                {
                    int i = SendSms(mobile, MobileContent);//发送手机短信

                    if (i > 0)
                    {
                        IntLog = 2;//2数据录入数据库并发送短信成功
                        UPdateSms(b.ToString());//短信发送成功 更新短信状态
                        IntLog = 3;//3数据录入数据库并发送短信成功并更新已发送短信状态 
                    }
                    bool b1 = UpdateMobileCount(LoginName);
                }
            }
            if (emali != "")//发送邮件
            {
                SendEmailMsg(emali, Title + "[中国招商投资网http://www.topfo.com]", EmailContent);
            }
            if (site != "")//发送站内短信
            {
                SendSiteMsg(LoginName, Title, SiteContent);
            }

            return IntLog;
        }
        //===============================================================================
        /// <summary>
        /// 向手机短信库写数据
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="Content">内容</param>
        /// <returns></returns>
        public int SendMobileSms(string mobile, string Content)
        {
            return dal.SendMobileSms(mobile, Content);
        }
        #endregion

        /// <summary>
        /// 更新用户短信数量
        /// </summary>
        /// <param name="LoginName">用户名</param>
        /// <returns></returns>
        public bool UpdateMobileCount(string LoginName)
        {
            return dal.UpdateMobileCount(LoginName);
        }
        /// <summary>
        /// 发送站内短信
        /// </summary>
        /// <param name="LoginName">接送人</param>
        /// <param name="Title">标题</param>
        /// <param name="Content">内容</param>
        /// <returns></returns>
        public bool SendSiteMsg(string LoginName, string Title, string Content)
        {
            Tz888.BLL.AutoSendMsg send = new AutoSendMsg();
            bool b = send.SendSiteMsg(LoginName, Title, Content);
            return b;

        }
        /// <summary>
        /// 发送邮件通知
        /// </summary>
        /// <param name="LoginName">接收人</param>
        /// <param name="Title">标题</param>
        /// <param name="Content">内容</param>
        /// <returns></returns>
        public bool SendEmailMsg(string Email, string Title, string Content)
        {
            Tz888.BLL.AutoSendMsg send = new AutoSendMsg();
            send.SendEmail(Email, Title, Content);
            return true;
        }
        /// <summary>
        /// 多方发送邮件通知
        /// </summary>
        /// <param name="LoginName">接收人</param>
        /// <param name="Title">标题</param>
        /// <param name="Content">内容</param>
        /// <returns></returns>
        public bool SendEmailMsgAll(string Email, string Title, string Content)
        {
            Tz888.BLL.AutoSendMsg send = new AutoSendMsg();
            send.SendEmail(Email, Title, Content);
            return true;
        }
        /// <summary>
        /// 是否满足发送站内短信的条件
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="NoticeType">通知</param>
        /// <returns></returns>
        public string IsSite(string LoginName, string NoticeType)
        {
            DataTable dt = dalConn.GetList("UserParametersTab", NoticeType + ",MobileCount", "parID", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
            if (dt.Rows.Count > 0)
            {
                string notice = dt.Rows[0][NoticeType].ToString().Trim();

                if (notice != "")//有设置通知方式
                {
                    string[] s = notice.Split('|');
                    if (s[0].Trim() != "")//设置有站内短信方式
                    {
                        return "siteMsg";
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 是否满足发送邮件的条件
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="NoticeType"></param>
        /// <returns></returns>
        public string IsEmail(string LoginName, string NoticeType)
        {
            DataTable dt = dalConn.GetList("UserParametersTab", NoticeType + ",NoticeEmail", "parID", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
            if (dt.Rows.Count > 0)
            {
                string notice = dt.Rows[0][NoticeType].ToString().Trim();

                if (notice != "")//有设置通知方式
                {
                    string[] s = notice.Split('|');
                    if (s[1].Trim() != "")//设置有邮件方式
                    {
                        return dt.Rows[0]["NoticeEmail"].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }


            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 是否满足发送手机短信的条件
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="NoticeType"></param>
        /// <returns>通知的手机号</returns>
        public string IsMobile(string LoginName, string NoticeType)
        {
            DataTable dt = dalConn.GetList("UserParametersTab", NoticeType + ",MobileCount,PayNotice,NoticeEmail,NoticeMobile", "parID", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
            if (dt.Rows.Count > 0)
            {
                string notice = dt.Rows[0][NoticeType].ToString().Trim();
                string mobilecount = dt.Rows[0]["MobileCount"].ToString() == "" ? "0" : dt.Rows[0]["MobileCount"].ToString();
                if (Convert.ToInt32(mobilecount) > 0)//有足够的短信条数
                {
                    if (notice != "")//有设置通知方式
                    {
                        string[] s = notice.Split('|');
                        if (s[2].Trim() != "")//设置有手机短信方式
                        {
                            return dt.Rows[0]["NoticeMobile"].ToString();
                        }
                        else
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return "";
                    }

                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="Model">手机号</param>
        /// <param name="Contnts">短信内容</param>
        /// <returns></returns>
        public int SendSms(string Model, string Contnts)
        {
            
            SmsServer.BusinessServiceService bs = new Tz888.BLL.SmsServer.BusinessServiceService();
            bs.Url = "http://webservice.dodoca.com:8080/NOSmsPlatform/services/BusinessService";
            int i = bs.sendBatchMessage(SmsUser, SmsPass, Model, Contnts);
            return i;
        }

        //public int Sendmessage()
        //{
        //    int str = SendSMS("topfo", "123456", "15815504883", "中国招商投资网");
        //    return str;
        //}

        /// <summary>
        /// 更改已发送短信状态
        /// </summary>
        /// <param name="ID">短信ID</param>
        /// <returns></returns>
        public void UPdateSms(string id)
        {
            dal.UPdateSms(id);
        }

        /// <summary>
        /// 获取此条信息用户 然后发送通知
        /// </summary>
        /// <param name="infoid">该条资源ID</param>
        /// <param name="Contents">短信内容</param>
        /// <param name="Title">邮件标题</param>
        /// <returns></returns>
        public int GetMaininfo(string infoid, string Contents,string Title)
        {
            string loginname = Member.GetMaininfo(infoid);
            return InfoComment(loginname, Contents, Title, Contents, Contents);

        }


    }
}
