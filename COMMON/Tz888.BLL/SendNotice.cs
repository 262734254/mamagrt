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

        //[DllImport("EUCPComm.dll", EntryPoint = "SendSMS")]  //��ʱ����
        //public static extern int SendSMS(string sn, string mn, string ct, string msg);

        /// <summary>
        /// ����ɹ�֪ͨ
        /// <param name="LoginName">������</param>
        /// <param name="MobileContent">�ֻ���������</param>
        /// <param name="Title">����(վ�ڶ��ź��ʼ�����)</param>
        /// <param name="SiteContent">վ�ڶ����ı�����)</param>
        /// <param name="EmailContent">�ʼ��ı�����</param>
        public int PayNotice(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "PayNotice");//StrikeNotice
        }
        /// <summary>
        /// ��ֵ�ɹ�֪ͨ
        /// <param name="LoginName">������</param>
        /// <param name="MobileContent">�ֻ���������</param>
        /// <param name="Title">����(վ�ڶ��ź��ʼ���Ҫ)</param>
        /// <param name="SiteContent">վ�ڶ����ı�����)</param>
        /// <param name="EmailContent">�ʼ��ı�����</param>
        public int StrikeSucess(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "StrikeNotice");//StrikeNotice
        }
        /// <summary>
        /// ��Դ���֪ͨ
        /// <param name="LoginName">������</param>
        /// <param name="MobileContent">�ֻ���������</param>
        /// <param name="Title">����(վ�ڶ��ź��ʼ���Ҫ)</param>
        /// <param name="SiteContent">վ�ڶ����ı�����)</param>
        /// <param name="EmailContent">�ʼ��ı�����</param>
        public int InfoCheck(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            //InfoCheckNotice
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "InfoCheckNotice");
        }
        /// <summary>
        ///������Դ�µ�֪ͨ
        /// <param name="LoginName">������</param>
        /// <param name="MobileContent">�ֻ���������</param>
        /// <param name="Title">����(վ�ڶ��ź��ʼ���Ҫ)</param>
        /// <param name="SiteContent">վ�ڶ����ı�����)</param>
        /// <param name="EmailContent">�ʼ��ı�����</param>
        public int Subscribe(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            //SubscribeNotice
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "SubscribeNotice");
        }
        /// <summary>
        /// ��Դ����������֪ͨ
        /// </summary>
        /// <param name="LoginName">������</param>
        /// <param name="MobileContent">�ֻ���������</param>
        ///<param name="Title">�ʼ���վ�ڶ��ű���</param>
        /// <param name="SiteContent">վ�ڶ����ı�����)</param>
        /// <param name="EmailContent">�ʼ��ı�����</param>
        public int InfoComment(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            //InfoCommentNotice
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "InfoCommentNotice");
        }
        /// <summary>
        /// �������֪ͨ
        /// </summary>
        /// <param name="LoginName">֪ͨ����</param>
        /// <param name="MobileContent">�ֻ�����</param>
        /// <param name="Title">�ʼ���վ�ڶ��ű���</param>
        /// <param name="SiteContent">վ�ڶ����ı�����)</param>
        /// <param name="EmailContent">�ʼ��ı�����</param>
        public int FriendAdd(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "FriendAddNotice");
        }
        /// <summary>
        /// ��Դ��������֪ͨ
        /// <param name="LoginName">������</param>
        /// <param name="MobileContent">�ֻ���������</param>
        /// <param name="Title">����(վ�ڶ��ź��ʼ���Ҫ)</param>
        /// <param name="SiteContent">վ�ڶ����ı�����)</param>
        /// <param name="EmailContent">�ʼ��ı�����</param>
        public int InfoExpired(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            //InfoExpiredNotice
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "InfoExpiredNotice");
        }
        /// <summary>
        /// ��Դƥ��֪ͨ
        /// <param name="LoginName">������</param>
        /// <param name="MobileContent">�ֻ���������</param>
        /// <param name="Title">����(վ�ڶ��ź��ʼ���Ҫ)</param>
        /// <param name="SiteContent">վ�ڶ����ı�����)</param>
        /// <param name="EmailContent">�ʼ��ı�����</param>
        public int InfoMatching(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            //InfoMatchingNotice
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "InfoMatchingNotice");
        }
        /// <summary>
        /// �ظ�֪ͨ
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
        /// ��Ա��������֪ͨ
        /// <param name="LoginName">������</param>
        /// <param name="MobileContent">�ֻ���������</param>
        /// <param name="Title">����(վ�ڶ��ź��ʼ���Ҫ)</param>
        /// <param name="SiteContent">վ�ڶ����ı�����)</param>
        /// <param name="EmailContent">�ʼ��ı�����</param>
        public int VipExpired(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent)
        {
            //VipExpiredNotice
            return SendSms(LoginName, MobileContent, Title, SiteContent, EmailContent, "VipExpiredNotice");
        }
        /// <summary>
        /// ��ʼ���͸���֪ͨ
        /// </summary>
        /// <param name="LoginName">������</param>
        /// <param name="MobileContent">�ֻ���������</param>
        /// <param name="Title">����(վ�ڶ��ź��ʼ���Ҫ)</param>
        /// <param name="SiteContent">վ�ڶ����ı�����)</param>
        /// <param name="EmailContent">�ʼ��ı�����</param>
        /// <param name="SetNotice">֪ͨ������</param>
        public void Send(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent, string SetNotice)
        {
            string mobile = IsMobile(LoginName, SetNotice);
            string emali = IsEmail(LoginName, SetNotice);
            string site = IsSite(LoginName, SetNotice);
            if (mobile != "")
            {
                bool b = SendMobileMsg(mobile, MobileContent);


                if (b)//�����ֻ�����
                {

                    bool b1 = UpdateMobileCount(LoginName);
                }
            }
            if (emali != "")//�����ʼ�
            {
                SendEmailMsg(emali, Title + "[�й�����Ͷ����http://www.topfo.com]", EmailContent);
            }
            if (site != "")//����վ�ڶ���
            {
                SendSiteMsg(LoginName, Title, SiteContent);
            }
        }
        //===============================================================================
        /// <summary>
        /// ���ֻ����ſ�д����
        /// </summary>
        /// <param name="mobile">�ֻ���</param>
        /// <param name="Content">����</param>
        /// <returns></returns>
        public bool SendMobileMsg(string mobile, string Content)
        {
            return dal.SendMobileMsg(mobile, Content);
        }

        #region  ���ش�������ID
        /// <summary>
        /// ��ʼ���͸���֪ͨ
        /// </summary>
        /// <param name="LoginName">������</param>
        /// <param name="MobileContent">�ֻ���������</param>
        /// <param name="Title">����(վ�ڶ��ź��ʼ���Ҫ)</param>
        /// <param name="SiteContent">վ�ڶ����ı�����)</param>
        /// <param name="EmailContent">�ʼ��ı�����</param>
        /// <param name="SetNotice">֪ͨ������</param>
        public int SendSms(string LoginName, string MobileContent, string Title, string SiteContent, string EmailContent, string SetNotice)
        {
            string mobile = IsMobile(LoginName, SetNotice);
            string emali = IsEmail(LoginName, SetNotice);
            string site = IsSite(LoginName, SetNotice);
            int IntLog = 0;//0 δִ�гɹ�    

            if (mobile != "")
            {
                int b = SendMobileSms(mobile, MobileContent);
                IntLog = 1;//1����¼�����ݿ�  

                if (b > 0)//�����ֻ�����
                {
                    int i = SendSms(mobile, MobileContent);//�����ֻ�����

                    if (i > 0)
                    {
                        IntLog = 2;//2����¼�����ݿⲢ���Ͷ��ųɹ�
                        UPdateSms(b.ToString());//���ŷ��ͳɹ� ���¶���״̬
                        IntLog = 3;//3����¼�����ݿⲢ���Ͷ��ųɹ��������ѷ��Ͷ���״̬ 
                    }
                    bool b1 = UpdateMobileCount(LoginName);
                }
            }
            if (emali != "")//�����ʼ�
            {
                SendEmailMsg(emali, Title + "[�й�����Ͷ����http://www.topfo.com]", EmailContent);
            }
            if (site != "")//����վ�ڶ���
            {
                SendSiteMsg(LoginName, Title, SiteContent);
            }

            return IntLog;
        }
        //===============================================================================
        /// <summary>
        /// ���ֻ����ſ�д����
        /// </summary>
        /// <param name="mobile">�ֻ���</param>
        /// <param name="Content">����</param>
        /// <returns></returns>
        public int SendMobileSms(string mobile, string Content)
        {
            return dal.SendMobileSms(mobile, Content);
        }
        #endregion

        /// <summary>
        /// �����û���������
        /// </summary>
        /// <param name="LoginName">�û���</param>
        /// <returns></returns>
        public bool UpdateMobileCount(string LoginName)
        {
            return dal.UpdateMobileCount(LoginName);
        }
        /// <summary>
        /// ����վ�ڶ���
        /// </summary>
        /// <param name="LoginName">������</param>
        /// <param name="Title">����</param>
        /// <param name="Content">����</param>
        /// <returns></returns>
        public bool SendSiteMsg(string LoginName, string Title, string Content)
        {
            Tz888.BLL.AutoSendMsg send = new AutoSendMsg();
            bool b = send.SendSiteMsg(LoginName, Title, Content);
            return b;

        }
        /// <summary>
        /// �����ʼ�֪ͨ
        /// </summary>
        /// <param name="LoginName">������</param>
        /// <param name="Title">����</param>
        /// <param name="Content">����</param>
        /// <returns></returns>
        public bool SendEmailMsg(string Email, string Title, string Content)
        {
            Tz888.BLL.AutoSendMsg send = new AutoSendMsg();
            send.SendEmail(Email, Title, Content);
            return true;
        }
        /// <summary>
        /// �෽�����ʼ�֪ͨ
        /// </summary>
        /// <param name="LoginName">������</param>
        /// <param name="Title">����</param>
        /// <param name="Content">����</param>
        /// <returns></returns>
        public bool SendEmailMsgAll(string Email, string Title, string Content)
        {
            Tz888.BLL.AutoSendMsg send = new AutoSendMsg();
            send.SendEmail(Email, Title, Content);
            return true;
        }
        /// <summary>
        /// �Ƿ����㷢��վ�ڶ��ŵ�����
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="NoticeType">֪ͨ</param>
        /// <returns></returns>
        public string IsSite(string LoginName, string NoticeType)
        {
            DataTable dt = dalConn.GetList("UserParametersTab", NoticeType + ",MobileCount", "parID", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
            if (dt.Rows.Count > 0)
            {
                string notice = dt.Rows[0][NoticeType].ToString().Trim();

                if (notice != "")//������֪ͨ��ʽ
                {
                    string[] s = notice.Split('|');
                    if (s[0].Trim() != "")//������վ�ڶ��ŷ�ʽ
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
        /// �Ƿ����㷢���ʼ�������
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

                if (notice != "")//������֪ͨ��ʽ
                {
                    string[] s = notice.Split('|');
                    if (s[1].Trim() != "")//�������ʼ���ʽ
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
        /// �Ƿ����㷢���ֻ����ŵ�����
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="NoticeType"></param>
        /// <returns>֪ͨ���ֻ���</returns>
        public string IsMobile(string LoginName, string NoticeType)
        {
            DataTable dt = dalConn.GetList("UserParametersTab", NoticeType + ",MobileCount,PayNotice,NoticeEmail,NoticeMobile", "parID", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
            if (dt.Rows.Count > 0)
            {
                string notice = dt.Rows[0][NoticeType].ToString().Trim();
                string mobilecount = dt.Rows[0]["MobileCount"].ToString() == "" ? "0" : dt.Rows[0]["MobileCount"].ToString();
                if (Convert.ToInt32(mobilecount) > 0)//���㹻�Ķ�������
                {
                    if (notice != "")//������֪ͨ��ʽ
                    {
                        string[] s = notice.Split('|');
                        if (s[2].Trim() != "")//�������ֻ����ŷ�ʽ
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
        /// ���Ͷ���
        /// </summary>
        /// <param name="Model">�ֻ���</param>
        /// <param name="Contnts">��������</param>
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
        //    int str = SendSMS("topfo", "123456", "15815504883", "�й�����Ͷ����");
        //    return str;
        //}

        /// <summary>
        /// �����ѷ��Ͷ���״̬
        /// </summary>
        /// <param name="ID">����ID</param>
        /// <returns></returns>
        public void UPdateSms(string id)
        {
            dal.UPdateSms(id);
        }

        /// <summary>
        /// ��ȡ������Ϣ�û� Ȼ����֪ͨ
        /// </summary>
        /// <param name="infoid">������ԴID</param>
        /// <param name="Contents">��������</param>
        /// <param name="Title">�ʼ�����</param>
        /// <returns></returns>
        public int GetMaininfo(string infoid, string Contents,string Title)
        {
            string loginname = Member.GetMaininfo(infoid);
            return InfoComment(loginname, Contents, Title, Contents, Contents);

        }


    }
}
